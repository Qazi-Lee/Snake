using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;



namespace snake服务器
{
    public partial class 服务器 : Form
    {
        Socket_server server;
    
        public 服务器()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {

            string ip = textBox_address.Text;
            string port_s = textBox_port.Text;
            string mysqlserver = textBox_mysql_server.Text;
            string mysqlport = textBox_mysql_port.Text;
            string mysqluser = textBox_mysql_user.Text;
            string mysqlpassword = textBox_mysql_password.Text;
            string mysqldatabase = textBox_mysql_database.Text;
            string mysqlcharset = textBox_mysql_charset.Text;
            System.DateTime datetime = new System.DateTime();
            datetime = System.DateTime.Now;
            if (textBox_address.TextLength!=0&& textBox_port.TextLength!=0&& textBox_mysql_server.TextLength!=0&& textBox_mysql_port.TextLength!=0&& textBox_mysql_user.TextLength!=0 && textBox_mysql_password.TextLength!=0
                && textBox_mysql_database.TextLength!=0&& textBox_mysql_charset.TextLength!=0) {
                int port = int.Parse(port_s);
                server = new Socket_server(ip, port, mysqlserver, mysqlport, mysqluser, mysqldatabase, mysqlpassword, mysqlcharset);
                if (server.mysql.isconnect)
                {
                    richTextBox_message.Text+= datetime+"  连接数据库成功  "+'\n';
                }
                else
                {
                    richTextBox_message.Text += datetime + "  连接数据库失败  " + '\n';
                }              
                WritetoFile(ip, port);
                server.Start();
                if (server.connectex)
                {
                    richTextBox_message.Text += datetime + "  服务器连接失败  " + '\n';
                }
                else
                {
                    richTextBox_message.Text += datetime + "  服务器连接成功  " + '\n';
                }
                button_start.Enabled = false; }
        }
        private void WritetoFile(string ip,int port)
        {
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
            string path = di.Parent.Parent.Parent.FullName;
            Console.WriteLine(path);
            FileStream fs = new FileStream(path+@"\客户端\server.txt", FileMode.Create, FileAccess.Write);
            Console.WriteLine("创建文件成功");
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(ip);
            sw.WriteLine(port);
            Console.WriteLine("写入文件成功");
            sw.Close();
            fs.Close();

        }

        private void button_close_Click(object sender, EventArgs e)
        {
            server.Close();
            button_start.Enabled = true;
        }

        private void textBox_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_address_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_receive_Click(object sender, EventArgs e)
        {
            //mysql.InsertAccount("123");
            //mysql.UpdateSorce("123",5);
            //mysql.UpdateSorce("123", 3);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox_port_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
