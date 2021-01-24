using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;

    [Header("跳躍高度"), Range(0, 3000)]
    public int jump = 500;

    [Header("是否在地板上"), Tooltip("是否在地板上")]
    public bool onFloor = false;

    [Header("子彈")]
    public GameObject bullet;

    [Header("子彈生成點")]
    public Transform bulletPosition;

    [Header("子彈速度"), Range(0, 5000)]
    public int bulletSpeed = 800;

    [Header("子彈傷害"), Range(0, 5000)]
    public float damageBullet = 50;

    [Header("開槍音效"), Tooltip("選擇開槍音效")]
    public AudioClip gunshotSound;

    [Header("血量"), Range(0, 200)]
    public float hp = 100;

    [Header("地面判定位移")]
    public Vector3 offset;

    [Header("地面判定半徑")]
    public float radius = 0.3f;

    [Header("鑰匙音效")]
    public AudioClip soundKey;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

    #endregion

    public float h;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }


    private void Update()
    {
        GetHorizontal();
        Move();
        Jump();
        Shot();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.35f);
        Gizmos.DrawSphere(transform.position + offset , radius);
    }





    #region 方法

    private void GetHorizontal()
    {
        h = Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// 觸發事件
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("key"))
        {
            Destroy(collision.gameObject);
            aud.PlayOneShot(soundKey, Random.Range(1.5f, 2.3f));
        }
    }


    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        rig.velocity = new Vector2(h * speed, rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localEulerAngles = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            transform.localEulerAngles = new Vector3(0,180,0);
        }

        ani.SetBool("跑步開關", h!= 0);
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if(onFloor && Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0, jump));
            ani.SetTrigger("跳躍觸發");
        }

        Collider2D hit = Physics2D.OverlapCircle(transform.position + offset, radius, 1 << 8);

        if(hit)
        {
            onFloor = true;
        }
        else
        {
            onFloor = false;
        }

        ani.SetFloat("跳躍", rig.velocity.y);
        ani.SetBool("是否在地面上", onFloor);
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            aud.PlayOneShot(gunshotSound, Random.Range(1.2f, 1.5f));
           GameObject temp = Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(bulletPosition.right * bulletSpeed + bulletPosition.up * 150);

            temp.AddComponent<Bullet>().attack = damageBullet;
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="getDamege">造成的傷害</param>
    private void Demage(float getDamege)
    {
      
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }

    #endregion

    #region 靜態屬性和方法

    //private void Start()
    //{
        //練習
        //print("所有攝影機的數量:" + Camera.allCamerasCount);


        //Physics2D.gravity = new Vector2(0, -20);
        //print("2D的重力大小:" + Physics2D.gravity);

        //Application.OpenURL("https://www.youtube.com/?gl=TW&hl=zh-TW");

        //print("9.999去小數點:" + Mathf.Floor(9.999f));

        //print("取得兩點的距離" + Vector3.Distance(new Vector3(1, 1, 1), new Vector3(22,22,22)));


       


        
   // }

    //private void Update()
   // {

     

        //print("是否輸入任意鍵" + Input.anyKeyDown);
        //print("遊戲經過時間" + Time.time);
        //print("是否按下空白鍵" + Input.GetKeyDown("space"));
   // }


    #endregion

}
