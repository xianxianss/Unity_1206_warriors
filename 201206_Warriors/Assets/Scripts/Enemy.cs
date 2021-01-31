using UnityEngine;
using UnityEngine.UI;  //引用 介面 API
using UnityEngine.Events;  //引用 事件 API
using System.Collections;  //引用 系統.集合 API -協同程序需要

[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;
    [Header("攻擊範圍"), Range(0, 100)]
    public float rangeAtk = 10;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 10;
    [Header("攻擊冷卻"), Range(0, 10)]
    public float attackCD = 3.5f;
    [Header("血量"), Range(0, 5000)]
    public float hp = 2500;
    [Header("血量文字")]
    public Text textHp;
    [Header("血量圖片")]
    public Image imgHp;
    [Header("攻擊範圍位移")]
    public Vector3 offsetAttack;
    [Header("攻擊範圍大小")]
    public Vector3 sizeAttack;
    [Header("攻擊延遲傳送給玩家時間"), Range(0, 10)]
    public float attackDelay = 0.7f;
    [Header("死亡事件")]
    public UnityEvent onDead;

    private Animator ani;
    private AudioSource aud;
    private Rigidbody2D rig;
    private float hpMax;
    private Player player;
    private ControlCamera2D cam;
    private bool isSecond;
    private ParticleSystem psSecond;

    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;

    //僅在編輯器內顯示，發布後看不見
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position + transform.right * offsetAttack.x + transform.up * offsetAttack.y, sizeAttack);

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, rangeAtk);
    }

    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        hpMax = hp;

        player = FindObjectOfType<Player>(); //透過類型尋找物件<類型>() -不能是重複物件
        cam = FindObjectOfType<ControlCamera2D>();
        psSecond = GameObject.Find("骷髏二階段攻擊特效").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (ani.GetBool("死亡開關")) return; //如果 死亡開關 已勾選 就跳出
        Move();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(float damage)
    {
        hp -= damage;
        ani.SetTrigger("受傷觸發");
        textHp.text = hp.ToString();
        imgHp.fillAmount = hp / hpMax;

        if (hp <= hpMax * 0.8f)
        {
            isSecond = true;  //進入第二階段
            rangeAtk = 20;   //血量低於 八成 就進入 第二階段
        }

        if (hp <= 0) Dead();  //如果 血量 <=0 就死亡
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        onDead.Invoke();

        hp = 0;
        textHp.text = 0.ToString();
        ani.SetBool("死亡開關", true);
        //取得元件<膠囊碰撞>().啟動 = 關閉
        GetComponent<CapsuleCollider2D>().enabled = false;
        rig.Sleep(); //剛體.睡著()
        rig.constraints = RigidbodyConstraints2D.FreezeAll; //剛體.約束 = 約束.凍結全部
    }


    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //如果 動畫是 骷髏攻擊 或 骷髏受傷 就跳出
        AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("骷髏攻擊") || info.IsName("骷髏受傷")) return;

        /** 判斷式寫法
        if (transform.position.x > player.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        */

        //y  = x 是否大於玩家x ? 是y為180 : 否y為0
        float y = transform.position.x > player.transform.position.x ? 180 : 0;
        transform.eulerAngles = new Vector3(0, y, 0);

        
        float dis = Vector2.Distance(transform.position, player.transform.position);
        if (dis > rangeAtk)
        {
            //剛體.移動座標(座標 + 前方 * 一幀 * 移動速度) 
            rig.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
        else
        {
            Attack();
        }
    

        //動畫.設定布林值("走路開關",剛體.加速度.值 > 0)
        ani.SetBool("走路開關", rig.velocity.magnitude > 0);

    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        rig.velocity = Vector3.zero;
        if (timer < attackCD) //如果計時器<攻擊冷卻時間
        {
            timer += Time.deltaTime; //累加計時器
        }
        else  //否則 計時器 > = 攻擊冷卻
        {
            ani.SetTrigger("攻擊觸發"); //攻擊
            timer = 0; //計時器歸零
            StartCoroutine(DelaySendDamage());  //啟動協同程序(協成方法())
        }

        
    }

    //IEnumerator 允許傳回時間
    /// <summary>
    /// 延遲傳送傷害
    /// </summary>
    private IEnumerator DelaySendDamage()
    {
        //等待延遲時間
        yield return new WaitForSeconds(attackDelay);
        //碰撞物件 = 2D物理.盒型覆蓋區域(中心點,尺寸,角度,圖層)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * offsetAttack.x + transform.up * offsetAttack.y, sizeAttack, 0, 1 << 9);
        //如果 碰到物件 存在 玩家.受傷(攻擊力)
        if (hit) player.Damage(attack);
        //啟動(晃動攝影機效果())
        StartCoroutine(cam.ShakeCamera());

        //如果是第二階段 就播放特效
        if (isSecond) psSecond.Play();
    }
}
