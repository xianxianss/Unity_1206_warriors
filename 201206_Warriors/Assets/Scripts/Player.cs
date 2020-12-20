using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度") , Range(0,1000)]
    public float speed = 10.5f;

    [Header("跳躍高度"), Range(0, 3000)]
    public int height = 100;

    [Header("是否在地板上"), Tooltip("是否在地板上")]
    public bool onFloor = false;

    [Header("子彈"), Tooltip("選擇子彈圖片")]
    public Sprite bullet;

    [Header("子彈生成點"), Tooltip("選擇子彈生成位置")]
    public Transform bulletPosition;

    [Header("子彈速度"), Range(0,5000)]
    public int bulletSpeed = 800;

    [Header("開槍音效"), Tooltip("選擇開槍音效")]
    public AudioClip gunshotSound;

    [Header("血量"), Range(0, 200)]
    public int hp = 100;

 }
