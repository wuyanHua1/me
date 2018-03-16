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
    public partial class Add : Form
    {
        string supid;
        int id;
        string name;
        string type;
        string connect_str;
        public Add(TreeNode parent,int id,string connect_str)
        {
            this.id = id;
            this.supid = parent.Tag.ToString();
            this.connect_str = connect_str;
            InitializeComponent();
        }
        private void Add_Load(object sender, EventArgs e)
        {
            if(Convert.ToInt32(supid)!=-1)
            {
                type = "班组";
            }
            else
            {
                type = "部门";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            if (name != "")
            {
                string sql = string.Format("insert into Orginfo(orgid,orgname,type,supid) values({0},N'{1}',N'{2}','{3}')", id, name, type, supid);
                SqlConnection sqlConnection = new SqlConnection(connect_str);
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入需要添加的名字");
            }
        }
    }
}
