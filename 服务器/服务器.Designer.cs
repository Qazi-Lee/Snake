namespace snake服务器
{
    partial class 服务器
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_start = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label_address = new System.Windows.Forms.Label();
            this.label_port = new System.Windows.Forms.Label();
            this.label0 = new System.Windows.Forms.Label();
            this.textBox_mysql_server = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_mysql_port = new System.Windows.Forms.TextBox();
            this.textBox_mysql_user = new System.Windows.Forms.TextBox();
            this.textBox_mysql_database = new System.Windows.Forms.TextBox();
            this.textBox_mysql_password = new System.Windows.Forms.TextBox();
            this.textBox_mysql_charset = new System.Windows.Forms.TextBox();
            this.richTextBox_message = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(28, 353);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(154, 58);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "启动";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(228, 353);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(154, 58);
            this.button_close.TabIndex = 1;
            this.button_close.Text = "关闭";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // textBox_address
            // 
            this.textBox_address.Location = new System.Drawing.Point(107, 57);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(228, 25);
            this.textBox_address.TabIndex = 2;
            this.textBox_address.TextChanged += new System.EventHandler(this.textBox_address_TextChanged);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(107, 144);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(228, 25);
            this.textBox_port.TabIndex = 3;
            this.textBox_port.TextChanged += new System.EventHandler(this.textBox_port_TextChanged);
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(39, 60);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(53, 15);
            this.label_address.TabIndex = 4;
            this.label_address.Text = "ip地址";
            this.label_address.Click += new System.EventHandler(this.label_address_Click);
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(39, 147);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(37, 15);
            this.label_port.TabIndex = 5;
            this.label_port.Text = "端口";
            // 
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.Location = new System.Drawing.Point(33, 226);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(68, 15);
            this.label0.TabIndex = 6;
            this.label0.Text = "数据库ip";
            // 
            // textBox_mysql_server
            // 
            this.textBox_mysql_server.Location = new System.Drawing.Point(107, 226);
            this.textBox_mysql_server.Name = "textBox_mysql_server";
            this.textBox_mysql_server.Size = new System.Drawing.Size(228, 25);
            this.textBox_mysql_server.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "数据库端口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "用户";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "库名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(453, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "charset";
            // 
            // textBox_mysql_port
            // 
            this.textBox_mysql_port.Location = new System.Drawing.Point(560, 57);
            this.textBox_mysql_port.Name = "textBox_mysql_port";
            this.textBox_mysql_port.Size = new System.Drawing.Size(228, 25);
            this.textBox_mysql_port.TabIndex = 13;
            // 
            // textBox_mysql_user
            // 
            this.textBox_mysql_user.Location = new System.Drawing.Point(560, 144);
            this.textBox_mysql_user.Name = "textBox_mysql_user";
            this.textBox_mysql_user.Size = new System.Drawing.Size(228, 25);
            this.textBox_mysql_user.TabIndex = 14;
            // 
            // textBox_mysql_database
            // 
            this.textBox_mysql_database.Location = new System.Drawing.Point(560, 223);
            this.textBox_mysql_database.Name = "textBox_mysql_database";
            this.textBox_mysql_database.Size = new System.Drawing.Size(228, 25);
            this.textBox_mysql_database.TabIndex = 15;
            // 
            // textBox_mysql_password
            // 
            this.textBox_mysql_password.Location = new System.Drawing.Point(560, 296);
            this.textBox_mysql_password.Name = "textBox_mysql_password";
            this.textBox_mysql_password.Size = new System.Drawing.Size(228, 25);
            this.textBox_mysql_password.TabIndex = 16;
            // 
            // textBox_mysql_charset
            // 
            this.textBox_mysql_charset.Location = new System.Drawing.Point(560, 372);
            this.textBox_mysql_charset.Name = "textBox_mysql_charset";
            this.textBox_mysql_charset.Size = new System.Drawing.Size(228, 25);
            this.textBox_mysql_charset.TabIndex = 17;
            // 
            // richTextBox_message
            // 
            this.richTextBox_message.Location = new System.Drawing.Point(28, 272);
            this.richTextBox_message.Name = "richTextBox_message";
            this.richTextBox_message.Size = new System.Drawing.Size(354, 64);
            this.richTextBox_message.TabIndex = 18;
            this.richTextBox_message.Text = "";
            this.richTextBox_message.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // 服务器
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox_message);
            this.Controls.Add(this.textBox_mysql_charset);
            this.Controls.Add(this.textBox_mysql_password);
            this.Controls.Add(this.textBox_mysql_database);
            this.Controls.Add(this.textBox_mysql_user);
            this.Controls.Add(this.textBox_mysql_port);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_mysql_server);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_start);
            this.Name = "服务器";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.TextBox textBox_mysql_server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_mysql_port;
        private System.Windows.Forms.TextBox textBox_mysql_user;
        private System.Windows.Forms.TextBox textBox_mysql_database;
        private System.Windows.Forms.TextBox textBox_mysql_password;
        private System.Windows.Forms.TextBox textBox_mysql_charset;
        private System.Windows.Forms.RichTextBox richTextBox_message;
    }
}

