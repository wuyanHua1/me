namespace 大实验
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_usernqme = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(64, 189);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(113, 12);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "没有账号？注册一个";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "密码";
            // 
            // label_usernqme
            // 
            this.label_usernqme.AutoSize = true;
            this.label_usernqme.Location = new System.Drawing.Point(52, 56);
            this.label_usernqme.Name = "label_usernqme";
            this.label_usernqme.Size = new System.Drawing.Size(41, 12);
            this.label_usernqme.TabIndex = 2;
            this.label_usernqme.Text = "用户名";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(106, 110);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(100, 21);
            this.textBox_password.TabIndex = 3;
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(106, 53);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(100, 21);
            this.textBox_username.TabIndex = 4;
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(80, 163);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(75, 23);
            this.button_Login.TabIndex = 5;
            this.button_Login.Text = "登录";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 256);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label_usernqme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_usernqme;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Button button_Login;
    }
}