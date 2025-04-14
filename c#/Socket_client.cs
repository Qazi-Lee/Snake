using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Security.Principal;
using System.Diagnostics;


namespace Assets.c_
{
    internal class Socket_client
    {
        private string ip;
        private int port;
        IPEndPoint point;
        private Socket client;
        private bool isconnect;
        public bool account_test;
        public bool password_test;
        public bool account_insert;
        public bool password_insert;
        public bool sorce_test;
        public bool sorce_insert;
        public int sorce;
        public bool login;
        public bool register;
        Thread thread_receive;
        //public string nowmessage;
        public Socket_client(string ip,int port)
        {
            this.ip = ip;
            this.port = port;
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           point = new IPEndPoint(IPAddress.Parse(this.ip), this.port);
            account_test = false;
            password_test = false;
            login = false;
            register = false;
            account_insert = false;
            password_insert = false;
            sorce_test = false;
            sorce_insert = false;
            sorce = 0;
        }
        public  void Connect()
        {
            try {
                client.Connect(point);
                isconnect = true;
                //thread_receive = new Thread(Receive);
                //thread_receive.IsBackground = true;
                //thread_receive.Start();//连接成功就接收信息
                UnityEngine.Debug.Log("成功连接到服务器");
            
            }
            catch (Exception ex){
                UnityEngine.Debug.Log("连接失败"+ $"{ex.ToString()}");
            
            }

        }
        public void Receive()
        {
            Console.WriteLine("开始接收");
            try
            {
             
                    byte[] receive = new byte[1024];
                    int len = client.Receive(receive);
                    Console.WriteLine("接收成功");
                    string s = Encoding.UTF8.GetString(receive, 0, len);
                    string ss = s.Substring(1, s.Length - 1); //获得除操作码后的字符串
                    switch (s.First<char>())
                    {
                        case '1'://查找账号
                            if (ss == "找到账号")
                            {
                                account_test = true;

                            }
                            else
                            {
                                account_test = false;
                            }
                            Console.WriteLine(ss);
                            //nowmessage = ss;
                            //UnityEngine.Debug.Log(nowmessage);

                            break;
                        case '2'://密码
                            if (ss == "密码正确")
                            {
                                password_test = true;
                            }
                            else
                            {
                                password_test = false;
                            }
                            Console.WriteLine(ss);

                            break;
                        case '3'://返回比较信息
                        if (ss == "需要更新")
                        {
                            sorce_test = true;
                        }
                        else
                        {
                            sorce_test = false;
                        }
                        Console.WriteLine(ss);
                            break;
                        case '4':
                            if (ss == "成功插入账号")
                            {
                                account_insert = true;
                            }
                            else
                            {
                                account_insert = false;
                            }
                            Console.WriteLine(ss);
                            break;

                        case '5':
                            if (ss == "成功插入密码")
                            {
                                password_insert = true;
                            }
                            else
                            {
                                password_insert = false;
                            }
                            Console.WriteLine(ss);
                            break;
                        case '6':
                        if (ss == "更新分数成功")
                        {
                            sorce_insert = true;
                            
                        }
                        else
                        {
                            sorce_insert = false;
                        }
                            break;
                    case '7':
                        sorce = int.Parse(ss);
                        Console.WriteLine("已获得最高分数");
                        break;
                        default:
                            break;
                    }
                }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log("接收信息失败" + $"{ex.ToString()}");
            }
        
        }
        public void SendAccount_test(string account)//操作码为1
        {
            try
            {
                if (isconnect == true)
                {
                    //UnityEngine.Debug.Log("发送账号为：" + account);
                    byte[] send = new byte[1024];
                    string op = "1";
                    send = Encoding.UTF8.GetBytes(op+account);
                    client.Send(send);
           
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log("发送失败"+$"{ex.ToString()}");

            }
        }
        public void SendAccount_insert(string account) {
            try
            {
                if (isconnect == true)
                {
                    byte[] send = new byte[1024];
                    string op = "4";
                    send = Encoding.UTF8.GetBytes(op + account);
                    client.Send(send);

                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log("发送失败" + $"{ex.ToString()}");

            }


        }//操作码为4
        public void SendPassword_test(string password)//操作码为2
        {
            try
            {
                if (isconnect == true)
                {
                    byte[] send = new byte[1024];
                    string op = "2";
                    send = Encoding.UTF8.GetBytes(op+password);
                    client.Send(send);
     
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log("发送失败" + $"{ex.ToString()}");

            }

        }
        public void SendPassword_insert(string password) {
            try
            {
                if (isconnect == true)
                {
                    byte[] send = new byte[1024];
                    string op = "5";
                    send = Encoding.UTF8.GetBytes(op + password);
                    client.Send(send);
                 
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log("发送失败" + $"{ex.ToString()}");

            }
        }//操作码为5
        public void SendSorce_test(int sorce)//操作码为3,判断分数是否大于最高分
        {
            try
            {
                if (isconnect == true)
                {
                    byte[] send = new byte[1024];
                    string op = "3";
                    send = Encoding.UTF8.GetBytes(op+(sorce.ToString()));
                    client.Send(send);
                
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log("发送失败" + $"{ex.ToString()}");

            }

        }
        public void SendSorce_insert(int sorce) {
            try
            {
                if (isconnect == true)
                {
                    byte[] send = new byte[1024];
                    string op = "6";
                    send = Encoding.UTF8.GetBytes(op + (sorce.ToString()));
                    client.Send(send);
                 
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log("发送失败" + $"{ex.ToString()}");

            }
        }//操作码为6，将最高分更新
    public void Login(string account,string password) {
            //先判断账号是否存在
            SendAccount_test(account);
            Receive();
            if(account_test)//账号已存在
            {
                SendPassword_test(password);
                Receive();
                if (password_test)//密码正确
                {
                    UnityEngine.Debug.Log("密码正确，登录成功");
                    login = true;
                }
                else
                {
                    UnityEngine.Debug.Log("密码错误，登录失败");
                    login = false;
                }
            }
            else//账号不存在
            {
                UnityEngine.Debug.Log("账号不存在呢，请先注册");
                login = false;
            }
            if(login)
            {
                UnityEngine.Debug.Log("恭喜你，登录成功");
            }
            else
            {
                UnityEngine.Debug.Log("很遗憾，登录失败了");
            }
        
        }
     public void Register(string account,string password) {
            //先判断账号是否存在
            SendAccount_test(account);
            Receive();
            if(account_test)//存在账号
            {
                UnityEngine.Debug.Log("账号存在，注册失败");
                register = false;
            }
            else//不存在账号
            {
                SendAccount_insert(account);
                Receive();
                if (account_insert)//插入账号成功
                {
                    UnityEngine.Debug.Log("创建账号成功，请继续");
                    SendPassword_insert(password);
                    Receive();
                    if (password_insert)//插入密码成功
                    {
                        UnityEngine.Debug.Log("注册成功了");
                        register = true;
                    }
                    else
                    {
                        UnityEngine.Debug.Log("插入密码失败，注册失败");
                        register = false;
                    }
                }
                else
                {
                    UnityEngine.Debug.Log("创建账号失败，注册失败");
                    register = false;
                }
            }
            if(register)
            {
                UnityEngine.Debug.Log("恭喜你，已经注册成功了");
            }
            else
            {
                UnityEngine.Debug.Log("很遗憾，注册失败了");
            }
        }

    public void ClearControl()
        {
            account_test = false;
            password_test = false;
            login = false;
            register = false;
            account_insert = false;
            password_insert = false;
            sorce_test = false;
            sorce_insert = false;
        }

     public void Closeclient()
        {
            if(isconnect==true)
            {
                byte[] close = new byte[1024];
                close = Encoding.ASCII.GetBytes("*close*");
                client.Send(close);
                client.Close();
                isconnect = false;
            }

        }
    }
}
