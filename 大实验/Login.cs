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
    public partial class Login : Form
    {
        public bool close;
        public Login()
        {
            InitializeComponent();
        }
        string connect_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\source\C#\大实验\大实验\Database1.mdf;Integrated Security=True";

        private void Login_Load(object sender, EventArgs e)
        {
            close = false;
            textBox_password.PasswordChar = '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            if(textBox_username.Text.Trim()=="")
            {
                MessageBox.Show("请输入账号!");
            }
            else if(textBox_password.Text.Trim()=="")
            {
                MessageBox.Show("请输入密码！");
            }
            else
            {
                string username = textBox_username.Text.Trim();
                string password = textBox_password.Text.Trim();
                SqlConnection sqlConnection = new SqlConnection(connect_string);
                string sql =string.Format( "select * from Login where usname = '{0}'",username);
                SqlCommand sqlCommand = new SqlCommand(sql,sqlConnection);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader dataReader=sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader != null)
                        {
                            if (dataReader[2].ToString().Trim().Equals(password))
                            {
                                this.Close();
                                close = true;
                            }
                            else
                            {
                                MessageBox.Show("密码错误");
                            }
                        }
                        else
                        {
                            MessageBox.Show("用户名错误");
                        }
                    }
                }
                catch (Exception ex)
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
