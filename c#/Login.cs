using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Net.Sockets;
using Assets.c_;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class Login : MonoBehaviour
{
    public Button button_login, button_register, button_exit;
    public InputField input_account, input_password;
    public TMP_Text tips;
    Socket_client client;
    // Start is called before the first frame update
    void Start()
    {
        //为案件添加监控器，一旦被点击则调用函数
        string ip=null;
        int port=0;
        ReadfromFile(ref ip, ref port);
        client = new Socket_client(ip, port);
        client.Connect();
        tips.gameObject.SetActive(false);
        button_login.onClick.AddListener(onbutton_login);
        button_register.onClick.AddListener(onbutton_register);
        button_exit.onClick.AddListener(onbutton_exit);//调用退出函数
     
    }
    public void ReadfromFile(ref string ip,ref int port)
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
    public void onbutton_login()
    {
        client.ClearControl();
       
        client.Login(input_account.text, input_password.text);
        if(client.login)
        {
            displaytips("登录成功");
            PlayerPrefs.SetString("account", input_account.text);
            SceneManager.LoadScene("game");
        }
        else
        {
            displaytips("登录失败");
        }

    }

    public void onbutton_register()
    {
        if (input_password.text.Length!=0&&input_account.text.Length!=0)
        {
            client.ClearControl();
            client.Register(input_account.text, input_password.text);
            if (client.register)
            {
                displaytips("注册成功");
            }
            else
            {
                displaytips("注册失败");
            }
        }
        else
        {
            displaytips("注册失败");
        }
       
    }
    public void onbutton_exit()
    {
        if (client != null)
        {
            client.Closeclient();
        }
        Application.Quit();
        UnityEngine.Debug.Log("退出游戏");

    }
    public void displaytips(string s)
    {
        tips.text = s;
        tips.gameObject.SetActive(true);
        Invoke("disapear",1.5f);
    }
    public void disapear()
    {
        tips.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
