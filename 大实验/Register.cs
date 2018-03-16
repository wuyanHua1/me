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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        int id;
        string connect_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\source\C#\大实验\大实验\Database1.mdf;Integrated Security=True";
        SqlConnection sqlConnection;
        private void Register_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connect_string);
            DataSet dataSet = new DataSet();
            string sql = "select * from Login";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(dataSet);
            id = dataSet.Tables[0].Rows.Count;
            textBox_password.PasswordChar = '*';
            textBox_re_password.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_username.Text.Trim()=="")
            {
                MessageBox.Show("输入用户名!");
            }
            else if (textBox_password.Text.Trim() == "")
            {
                MessageBox.Show("输入密码!");
            }
            else if (textBox_re_password.Text.Trim() == "")
            {
                MessageBox.Show("确认密码!");
            }
            else if(textBox_password.Text.Trim()!= textBox_re_password.Text.Trim())
            {
                MessageBox.Show("确认两次输入密码是否一致!");
            }
            else
            {
                string sql = string.Format("insert into Login(id,usname,password) values({0},'{1}','{2}')",id,textBox_username.Text.Trim(),textBox_password.Text.Trim());
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("注册成功！");
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
