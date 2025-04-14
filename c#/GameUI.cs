using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.c_;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class UI : MonoBehaviour
{
    public TMP_Text sorce;
    public TMP_Text bestsorce;
    public Button pasue, restart, mainmenu;
    public Snake snake;
    private string account;
    private Socket_client client;
    int num;
    //绑定账号，用来上传所得分数
    public void bindaccount()
    {
        account = PlayerPrefs.GetString("account");
    }
    //分数重置
   public void resetnum()
    {
        num = 0;
        sorce.text = num.ToString();
    }
    //分数变化
   public void numadd()
    {
        num++;
        sorce.text = num.ToString();

    }
    public void Updatesorce()
    {
        if (account != null)
        {
            //client = new Socket_client("127.0.0.1", 1234);
            string ip = null;
            int port = 0;
            ReadfromFile(ref ip, ref port);
            client = new Socket_client(ip, port);
            client.Connect();
            client.ClearControl();
            client.SendAccount_test(account);//绑定账号
            client.Receive();
            if(client.account_test)//账号存在，进行下一步
            {
                client.SendSorce_test(int.Parse(sorce.text));
                client.Receive();//判断是否要更新
                if(client.sorce_test)//需要更新
                {
                    client.SendSorce_insert(int.Parse(sorce.text));
                    client.Receive();
                    if (client.sorce_insert)//更新成功
                    {
                        bestsorce.text = sorce.text;
                    }
                    else
                    {
                        Console.WriteLine("更新分数失败");
                    }

                }
                else//不需要更新，则拿到历史最高分
                {
                    bestsorce.text = client.sorce.ToString();
                }
            }
            else
            {
                Console.WriteLine("无法找到账号！");
            }
        }
        else
        {
            Console.WriteLine("请先登录账号");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        pasue.onClick.AddListener(onbutton_pasue);
        restart.onClick.AddListener(onbutton_restart);
        mainmenu.onClick.AddListener(onbutton_mainmenu);
    }
    public void ReadfromFile(ref string ip, ref int port)
    {
        FileStream fs = new FileStream("server.txt", FileMode.Open);
        Console.WriteLine("成功打开文件");
        StreamReader sr = new StreamReader(fs);
        ip = sr.ReadLine();
        port = int.Parse(sr.ReadLine());
        Console.WriteLine($"文件读取成功,ip={ip}port={port}");
        sr.Close();
        fs.Close();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //暂停对应函数
    public void onbutton_pasue()
    {       
        if(pasue.GetComponentInChildren<TMP_Text>().text=="暂停")
        {
            Time.timeScale = 0;
            pasue.GetComponentInChildren<TMP_Text>().text = "继续";
        }
        else
        {
            Time.timeScale = snake.speed;
            pasue.GetComponentInChildren<TMP_Text>().text = "暂停";
        }
    }
    //重启对应函数
    public void onbutton_restart()
    {
        snake.init();
    }
    //主菜单对应函数
    public void onbutton_mainmenu()
    {
        snake.init();
        SceneManager.LoadScene("登录界面");
    }
}
