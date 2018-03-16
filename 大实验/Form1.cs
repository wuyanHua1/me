using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 大实验
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int maxid;
        string connect_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\source\C#\大实验\大实验\Database1.mdf;Integrated Security=True";
        DataSet ds;
        SqlConnection sqlConnection;
        SqlDataAdapter sqlDataAdapter;
        private void Form1_Load(object sender, EventArgs e)
        {
            Add_TreeView();
        }
        public void Add_TreeView()
        {
            SqlConnection sqlConnection = new SqlConnection(connect_string);
            string sql = "select * from Orginfo";
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnection);
            ds.Clear();
            da.Fill(ds);

            maxid = ds.Tables[0].Rows.Count+1;

            for (int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                DataRow dataRow = ds.Tables[0].Rows[i];
                if(Convert.ToInt32(dataRow["supid"])==-1)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = dataRow["orgid"].ToString();
                    tn.Text = dataRow["orgname"].ToString();
                    Add_Child(tn);
                    treeView1.Nodes.Add(tn);
                }
            }
            treeView1.ExpandAll();
        }
        public void Add_Child(TreeNode parent)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dataRow = ds.Tables[0].Rows[i];
                if (Convert.ToInt32(dataRow["supid"]) == Convert.ToInt32(parent.Tag))
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = dataRow["orgid"].ToString();
                    tn.Text = dataRow["orgname"].ToString();
                    Add_Child(tn);
                    parent.Nodes.Add(tn);
                }
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(treeView1.SelectedNode!=null)
                {
                    Add add = new Add(treeView1.SelectedNode,maxid,connect_string);
                    add.ShowDialog();
                    treeView1.Nodes.Clear();
                    Add_TreeView();
                }
                else
                {
                    throw (new Exception("请选择添加对象"));
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            Add_TreeView();
        }
        int row_count;
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            string sql = string.Format("select * from Hr_person where orgid={0}",treeView1.SelectedNode.Tag);
            SqlConnection sqlConnection = new SqlConnection(connect_string);
            ds = new DataSet();
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(ds);
            row_count = ds.Tables[0].Rows.Count;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
            Tag = treeView1.SelectedNode.Tag.ToString();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            if (row_count < ds.Tables[0].Rows.Count)
            {
                string orgid = treeView1.SelectedNode.Tag.ToString();
                for(int i=row_count;i<ds.Tables[0].Rows.Count;i++)
                {
                    ds.Tables[0].Rows[i]["orgid"] = orgid;
                }
                row_count = ds.Tables[0].Rows.Count;
            }
            sqlDataAdapter.Update(ds);
            button_save.Enabled = false;
        }
        string Tag = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()!="")
            {
                string name = textBox1.Text;
                string sql = string.Format("select * from Hr_Person where orgid='{0}' and name like N'%{1}%'",Tag.Trim(),textBox1.Text.Trim());
                sqlConnection = new SqlConnection(connect_string);
                sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                ds = new DataSet();
                sqlDataAdapter.Fill(ds);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button_save.Enabled = true;
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
     
        }
    }
}
