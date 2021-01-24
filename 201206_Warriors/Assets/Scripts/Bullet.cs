﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子彈的攻擊力
    /// </summary>
    public float attack;

    /// <summary>
    /// 碰撞事件:兩個物件都沒有勾選is Trigger時使用
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果碰撞物件有Enemy腳本
        if (collision.gameObject.GetComponent<Enemy>())
        {
            //對 Enemy 呼叫 Damage(攻擊力) 
            collision.gameObject.GetComponent<Enemy>().Damage(attack);
        }
        Destroy(gameObject);  //刪除(此遊戲物件)
    }
}
