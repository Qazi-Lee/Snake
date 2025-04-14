using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

//同步
namespace snake服务器
{
    internal class Socket_server
    {//设置ip和端口
        private string ip;
        private int port;
        private Socket listener;
        private Socket socket;
        private Socket connect;
        private bool isconnect;
        private bool isclientclose;
        private bool isinit;
        public bool connectex;
        Thread thread_listen;
        Thread thread_connect;
        //private List<string> account;
        private string nowaccount;
        //Dictionary<string, string> atop;//由账号查找密码
        //Dictionary<string, int> atos;//由账号查找分数
        public MySQL mysql;


        public Socket_server(string ip, int port,string server,string sqlport,string user,string database,string password,string charset)
        {
            this.ip = ip;
            this.port = port;
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //account = new List<string>();
            //atop = new Dictionary<string, string>();
            //atos = new Dictionary<string, int>();
            mysql = new MySQL(server,sqlport,user,database,password,charset);
            Control.CheckForIllegalCrossThreadCalls = false;
            isinit = true;
            connectex = false;
        }
        public void Start()
        {
            Console.WriteLine("服务器正在启动");
            Console.WriteLine($"端口ip信息：{ip}" + $"端口编号： {port}");
            //设置监听器端口   
            IPEndPoint point = new IPEndPoint(IPAddress.Parse(ip), port);       
            //绑定端口
            try
            {
                listener.Bind(point);
                //创建监听队列并指定容量
                listener.Listen(100);
                thread_listen = new Thread(OnAccept);//监听线程
                thread_listen.IsBackground = true;
                thread_listen.Start(listener);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                connectex = true;

            }

        }
        public void OnAccept(object o)
        {
            connect = o as Socket;//对应listener
            try
            {
                while (true)
                {
                    Console.WriteLine("正在等待客户端接入");
                    socket = connect.Accept();
                    isconnect = true;
                    isclientclose = false;
                    //如果连接成功
                    Console.WriteLine("连接客户端成功");
                    Console.WriteLine($"{socket.RemoteEndPoint.ToString()}");
                    //创建新的线程来接受客户端信息
                    thread_connect = new Thread(Receive);
                    thread_connect.IsBackground = true;
                    thread_connect.Start(socket);
                  
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                isconnect = false;
            }

        }
        public void Receive(object o)
        {
            socket = o as Socket;
            while (true)//不断接收来自客户端的信息
            {
                try
                {
                    if (isconnect == true && isclientclose == false)
                    {
                        byte[] receive = new byte[1024];
                        int len = socket.Receive(receive);//获得字长
                        string s = Encoding.UTF8.GetString(receive, 0, len);
                        if (s == "*close*")
                        {
                            isclientclose = true;
                            break;
                        }//关闭信息则关闭
                        else//操作信息
                        {
                            string ss = s.Substring(1, s.Length - 1); //获得除操作码后的字符串
                            Console.WriteLine(ss);
                            switch (s.First<char>())
                            {
                                case '1'://验证账号
                                    if(mysql.FindAccount(ss))//如果数据库中有账号
                                    {
                                        SendAccount_test("找到账号");
                                        nowaccount = ss;
                                        Console.WriteLine("找到账号s");
                                    }
                                    else//数据库中没有账号
                                    {
                                        SendAccount_test("找不到账号");
                                        Console.WriteLine("找不到账号s");
                                    }                                   
                                    break;
                                case '2'://验证密码
                                    //Console.WriteLine(mysql.FindPassword(nowaccount));
                                     if(ss==mysql.FindPassword(nowaccount))
                                    {
                                        SendPassword_test("密码正确");
                                        Console.WriteLine("密码正确s");
                                    }
                                    else
                                    {
                                        SendPassword_test("密码错误");
                                        Console.WriteLine("密码错误s");
                                    }

                                    break;
                                case '3'://分数,和最高分数比较
                                    int sorce = int.Parse(ss);
                                    if(sorce<=mysql.FindSorce(nowaccount))//不大于历史最高分,返回最高分
                                    {
                                        SendSorce(mysql.FindSorce(nowaccount));//发送当前账号对应的最高分
                                        Console.WriteLine("不大于最高分");
                                    }
                                    else//大于最高分，返回控制信号
                                    {
                                        SendSorce_test("需要更新");
                                        Console.WriteLine("需要更新");
                                    }
                                    break;
                                case '4'://插入账号
                                    if (ss != null)
                                    {
                                        mysql.InsertAccount(ss);
                                        nowaccount = ss;
                                        Console.WriteLine(ss);
                                        SendAccount_insert("成功插入账号");
                                        Console.WriteLine("成功插入账号s");
                                    }
                                    else
                                    {
                                        SendAccount_insert("插入账号失败");
                                        Console.WriteLine("插入账号失败");
                                    }
                                    break;
                                case '5'://插入密码
                                    if (ss != null)
                                    {
                                        mysql.InsertPassword(nowaccount, ss);
                                        SendPassword_insert("成功插入密码");
                                        Console.WriteLine("成功插入密码s");
                                    }
                                    else
                                    {
                                        SendPassword_insert("插入密码失败");
                                        Console.WriteLine("插入密码失败");
                                    }
                                    break;
                                case '6'://插入分数
                                    mysql.UpdateSorce(nowaccount, int.Parse(ss));
                                    SendSorec_insert("更新分数成功");
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    break;
                }
            }
        }
        public void SendAccount_test(string message)
        {
            byte[] send = new byte[1024];
            string op = "1";
            send = Encoding.UTF8.GetBytes(op+message);
            socket.Send(send);
        }
        public void SendPassword_test(string message)
        {
            byte[] send = new byte[1024];
            string op = "2";
            send = Encoding.UTF8.GetBytes(op + message);
            socket.Send(send);
        }
        public void SendSorce_test(string message)//操作码为3,返回比较信息
        {
            byte[] send = new byte[1024];
            string op = "3";
            send = Encoding.UTF8.GetBytes(op + message);
            socket.Send(send);
        }
        public void SendAccount_insert(string message)
        {
            byte[] send = new byte[1024];
            string op = "4";
            send = Encoding.UTF8.GetBytes(op + message);
            socket.Send(send);
        }//操作码为4
        public void SendPassword_insert(string message)
        {
            byte[] send = new byte[1024];
            string op = "5";
            send = Encoding.UTF8.GetBytes(op + message);
            socket.Send(send);
        }//操作码为5
        public void SendSorec_insert(string message)
        {
            byte[] send = new byte[1024];
            string op = "6";
            send = Encoding.UTF8.GetBytes(op + message);
            socket.Send(send);
        }
        public void SendSorce(int sorce)//操作码为7，返回最高分
        {
            byte[] send = new byte[1024];
            string op = "7";
            send = Encoding.UTF8.GetBytes(op + sorce.ToString());
            socket.Send(send);
        }
        public void Close()
        {
            if (isinit == true)
            {
                Console.WriteLine("调用关闭函数");
                if (isconnect == true)
                {
                    Console.WriteLine("连接线程关闭");
                    thread_connect.Interrupt();
                    socket.Close();
                }
           
                if (thread_listen != null)
                {
                    Console.WriteLine("监听线程关闭");
                    thread_listen.Interrupt();
                }
                connect.Close();
                listener.Close();
                Console.WriteLine("服务器关闭");
                isclientclose = true;
                isconnect = false;
                connectex = false;
            }

        }

    }

}

