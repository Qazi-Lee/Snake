using System.Collections.Generic;
using UnityEngine;
using Assets.c_;


public class Snake : MonoBehaviour
{
    public Food food;
    public UI gameui;
    Vector3 dircetion;
    public float speed = 0.1f;
    public Transform body;
    public Transform tial;
    public List<Transform> bodies = new List<Transform>();
    public Collider2D area;
    public bool start = false;
    public bool eat = false;
    public void init()
    {
        //设置速度
        speed = 0.1f;
        //清空object
        for (int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }
        transform.position = new Vector3(0, 0, 0);
        dircetion = Vector3.zero;
        bodies.Clear();
        bodies.Add(transform);
        bodies.Add(Instantiate(tial, new Vector3(
            transform.position.x,
            transform.position.y - 1.0f,
            transform.position.z), Quaternion.identity));
        gameui.bindaccount();
        gameui.Updatesorce();
        gameui.resetnum();
        start = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = speed;
        //Instantiate(tial, new Vector3(
        //    transform.position.x - 1.5f,
        //    transform.position.y,
        //    transform.position.z), Quaternion.Euler(0f, 0f, 90f));
        init();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 position = bodies[0].position - bodies[1].position;
        Vector2 up, down, left, right;
        up = new Vector2(0.00f, -1.00f);
        down = new Vector2(0.00f, 1.00f);
        left = new Vector2(1.00f, 0.00f);
        right = new Vector2(-1.00f, 0.00f);
        //UnityEngine.Debug.Log(position);
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (position != up)
            {
                start = true;
                //transform.Translate(Vector3.up);
                dircetion = Vector3.up;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (position != down)
            {
                start = true;
                //transform.Translate(Vector3.down);
                dircetion = Vector3.down;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (position != left)
            {
                start = true;
                //transform.Translate(Vector3.left);
                dircetion = Vector3.left;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (position != right)
            {
                start = true;
                //transform.Translate(Vector3.right);
                dircetion = Vector3.right;
            }
        }
    }
    private void FixedUpdate()
    {
        //设置速度
        Time.timeScale = speed;
        thru();
        snakemove();
    }
    //碰撞回调函数
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {//插入
            food.resetfood();
            bodies.Insert(bodies.Count - 1, Instantiate(body, bodies[bodies.Count - 2].position, Quaternion.identity));
            //snakemove();
            //每次吃增长速度增加
            speed += 0.005f;
            eat = true;
            gameui.numadd();
        }
        if (collision.CompareTag("Wall"))
        {
            UnityEngine.Debug.Log(collision);
            init();
        }
        if (collision.CompareTag("Tial"))
        {
            UnityEngine.Debug.Log("Tial");
            if (bodies.Count > 2)
            {
                init();
            }

        }
    }
    void snakemove()
    {
        for (int i = bodies.Count - 1; i > 0; i--)
        {//蛇尾
            if (i == bodies.Count - 1)
            {
                if (start)
                {
                    if (eat)
                    {
                        bodies[i].position = bodies[i].position;
                        eat = false;

                    }
                    else
                    {
                        float angle;
                        if (bodies[i].position.x == bodies[i - 1].position.x)
                        {
                            //UnityEngine.Debug.Log("坐标变换");

                            if (bodies[i - 1].position.y > bodies[i].position.y)
                            {
                                angle = 0;
                                bodies[i].transform.rotation = Quaternion.Euler(0, 0, angle);


                            }
                            else
                            {
                                angle = 180;
                                bodies[i].transform.rotation = Quaternion.Euler(0, 0, angle);
                            }
                        }
                        else
                        {
                            //UnityEngine.Debug.Log("坐标变换");
                            if (bodies[i - 1].position.x > bodies[i].position.x)
                            {
                                angle = -90;
                                bodies[i].transform.rotation = Quaternion.Euler(0, 0, angle);
                            }
                            else
                            {
                                angle = 90;
                                bodies[i].transform.rotation = Quaternion.Euler(0, 0, angle);
                            }

                        }
                        bodies[i].position = bodies[i - 1].position;
                    }
                }
                else
                {
                    UnityEngine.Debug.Log("暂未开始");
                }
            }
            //蛇身体
            else
            {
                bodies[i].position = bodies[i - 1].position;
            }

        }
        transform.Translate(dircetion);

    }
    //穿越边界
    void thru()
    {
        Vector3 leftposition = new Vector3(-transform.position.x - 1, transform.position.y, transform.position.z);
        Vector3 upposition = new Vector3(transform.position.x, -transform.position.y+1, transform.position.z);
        Vector3 downposition = new Vector3(transform.position.x, -transform.position.y-1, transform.position.z);
        Vector3 rightposition = new Vector3(-transform.position.x + 1, transform.position.y, transform.position.z);
        switch (transform.position.x)
        {
            case 11:
                transform.position = rightposition;
                break;
            case -11:
                transform.position = leftposition;
                break;
        }
        switch (transform.position.y)
        {
            case 11:
                transform.position = upposition;
                break;
            case -11:
                transform.position = downposition;
                break;
        }

    }
}
