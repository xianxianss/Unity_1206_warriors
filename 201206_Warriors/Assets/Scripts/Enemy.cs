﻿using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;
    [Header("攻擊範圍"), Range(0, 100)]
    public float rangeAtk = 10;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 10;
    [Header("血量"), Range(0, 5000)]
    public float hp = 2500;

    private Animator ani;
    private AudioSource aud;
    private Rigidbody2D rig;

    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
    }

    public void Damage(float damage)
    {
        hp -= damage;
        ani.SetTrigger("受傷觸發");
    }
}
