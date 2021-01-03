using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;

    [Header("跳躍高度"), Range(0, 3000)]
    public int height = 100;

    [Header("是否在地板上"), Tooltip("是否在地板上")]
    public bool onFloor = false;

    [Header("子彈")]
    public GameObject bullet;

    [Header("子彈生成點")]
    public Transform bulletPosition;

    [Header("子彈速度"), Range(0, 5000)]
    public int bulletSpeed = 800;

    [Header("開槍音效"), Tooltip("選擇開槍音效")]
    public AudioClip gunshotSound;

    [Header("血量"), Range(0, 200)]
    public float hp = 100;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

    #endregion

    public float h;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        GetHorizontal();
        Move();
    }






    #region 方法

    private void GetHorizontal()
    {
        h = Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        rig.velocity = new Vector2(h * speed, rig.velocity.y);
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Shot()
    {
      
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
