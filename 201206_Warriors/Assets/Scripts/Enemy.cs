using UnityEngine;
using UnityEngine.UI;

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
    [Header("血量文字")]
    public Text textHp;
    [Header("血量圖片")]
    public Image imgHp;

    private Animator ani;
    private AudioSource aud;
    private Rigidbody2D rig;
    private float hpMax;
    private Player player;

    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        hpMax = hp;

        player = FindObjectOfType<Player>(); //透過類行尋找物件<類型>() -不能是重複物件
    }

    private void Update()
    {
        Move();
    }

    public void Damage(float damage)
    {
        hp -= damage;
        ani.SetTrigger("受傷觸發");
        textHp.text = hp.ToString();
        imgHp.fillAmount = hp / hpMax;

        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        hp = 0;
        textHp.text = 0.ToString();
        ani.SetBool("死亡開關", true);
        //取得元件<膠囊碰撞>().啟動 = 關閉
        GetComponent<CapsuleCollider2D>().enabled = false;
        rig.Sleep(); //剛體.睡著()
        rig.constraints = RigidbodyConstraints2D.FreezeAll; //剛體.約束 = 約束.凍結全部
    }

    private void Move()
    {
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
    private void Attack()
    {
        rig.velocity = Vector3.zero;
        ani.SetTrigger("攻擊觸發");
    }
}
