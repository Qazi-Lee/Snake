using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace snake服务器
{
    internal class MySQL
    {
        private string connectstr;
        private MySqlConnection msc;
        private MySqlCommand command;
        private string comtext;
        private string server, port, user, database, password, charset;
        public bool isconnect;
        public MySQL(string s,string por,string u,string data,string pass,string ch)
        {
            try
            {
                server = s; port = por; user = u; database = data; password = pass; charset = ch;
                CreatDB(server, user, password, database);
                //connectstr = $"server = 127.0.0.1;port = 3306;user= root;database = snake;password = 040216;charset=utf8";
                connectstr = $"server ={server};port = {port};user= {user};database = {database};password = {password};charset={charset}";
                msc = new MySqlConnection(connectstr);
                isconnect = true;
                msc.Open();
                comtext = " CREATE TABLE IF NOT EXISTS snake (account varchar(255),password varchar(255),sorce int)";
                command = msc.CreateCommand();
                command = new MySqlCommand(comtext, msc);
                command.ExecuteNonQuery();
                msc.Close();
                Console.WriteLine("创建表成功");
            }
            catch(Exception ex)
            {
                Console.WriteLine("连接数据库失败"+ex.ToString());
                isconnect = false;
            }
        }
        public void CreatDB(string ip,string user,string password,string database)
        {
            MySqlConnection conn = new MySqlConnection($"Data Source={ip};Persist Security Info=yes;UserId={user}; PWD={password};");
            MySqlCommand cmd = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS {database};", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void InsertAccount(string account)
        {
            try {
             
                    msc.Open();
                    comtext = $"INSERT INTO snake (account) VALUES('{account}')";
                    command = new MySqlCommand(comtext, msc);
                    command.ExecuteNonQuery();
                    Console.WriteLine("创建账号成功sql");
                          
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString()+"创建账号失败sql");
            }
            finally {
                command.Dispose();
                msc.Close();
            }
        }
        public void InsertPassword(string account, string password)//密码为空则插入
        {
            try
            {                                                              
                     msc.Open();
                     comtext = $"UPDATE snake SET password = '{password}' WHERE account ='{account}'";
                     command = new MySqlCommand(comtext, msc);
                     command.ExecuteNonQuery();
                     Console.WriteLine("写入密码成功sql");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString() + "添加密码失败sql");

            }
            finally
            {
                   command.Dispose();
                    msc.Close();               

            }


        }
        public void UpdateSorce(string account, int sorce)
        {
            try
            {
                if (FindAccount(account) == true)
                {
                    int a = FindSorce(account);
                    Console.WriteLine(a);
                    if (a>=sorce)//历史最高分大于当前得分
                    {
                        Console.WriteLine("未达最高分");

                    }
                    else//更新最高分
                    {
                        msc.Open();
                        comtext = $"UPDATE snake SET sorce = {sorce} WHERE account ='{account}'";
                        command = new MySqlCommand(comtext, msc);
                        command.ExecuteNonQuery();
                        Console.WriteLine("更新得分成功");
                    }
                }
                else
                {
                    Console.WriteLine("暂无账号，无法添加得分");

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + "更新得分失败失败");

            }
            finally
            {
                if (msc != null)
                {
                    command.Dispose();
                    msc.Close();
                }

            }

        }
        public bool FindAccount(string account)
        {
            try
            {
                msc.Open();
                //Console.WriteLine("连接数据库成功");
                //comtext = $"SELECT * FROM snake WHERE account LIKE {account}";
                comtext = $"SELECT account FROM snake where account='{account}'";
                command = new MySqlCommand(comtext, msc);
                MySqlDataReader dr = command.ExecuteReader();
                if (dr.Read() == false)
                {
                    Console.WriteLine("账号不存在(创建账号)sql");
                    return false;
                }
                else
                {
                    Console.WriteLine("账号存在sql");
                    return true;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString()+"sql");
                return false;
            }
            finally
            {
                command.Dispose();
                msc.Close();
            }
            }       
        public string FindPassword(string account)
        {
            try
            {
                if(FindAccount(account)==true)
                {
                    msc.Open();
                    //comtext= $"SELECT * FROM `snake`.`snake` WHERE `account` LIKE {account} LIMIT 0,1000";
                    //comtext = $"SELECT * FROM `snake` WHERE `account` LIKE {account}";
                    comtext = $"SELECT password FROM snake where account='{account}'";
                    command = new MySqlCommand(comtext, msc);
                    MySqlDataReader dr = command.ExecuteReader();
                    dr.Read();
                    return dr.GetString(0);
                    //return dr[1].ToString();
                }
                else
                {
                    Console.WriteLine("账号不存在(查询密码）sql");
                    return null;
                }



            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                command.Dispose();
                msc.Close();
            }

        }
        public int FindSorce(string account)
        {
            try
            {
                if (FindAccount(account) == true)
                {
                    msc.Open();
                    //comtext = $"SELECT * FROM `snake`.`snake` WHERE `account` LIKE {account} LIMIT 0,1000";
                    //comtext = $"SELECT * FROM `snake` WHERE `account` LIKE {account} ";
                    comtext = $"SELECT sorce FROM snake where account='{account}'";
                    command = new MySqlCommand(comtext, msc);
                    MySqlDataReader dr = command.ExecuteReader();
                    //return int.Parse(dr[2].ToString());
                    dr.Read();
                    return dr.GetInt32(0);
                }
                else
                {
                    Console.WriteLine("账号不存在");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                command.Dispose();
                msc.Close();
            }
        }

    }
}
