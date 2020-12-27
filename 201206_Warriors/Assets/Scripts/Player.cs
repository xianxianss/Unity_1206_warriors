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

    private void Move()
    {
        print("移動");
    }

    private void Jump()
    {
        print("跳躍");
    }

    private void Shot()
    {
        print("開槍");
    }

    private void Hurtanddie(int Hurt, string Die)
    {
        print("受傷:"+ Hurt);
        print("死亡:"+ Die);
    }

    

    private void Start()
    {
        Move();
        Jump();
        Shot();
        Hurtanddie(120,"被石頭");       
    }
}
