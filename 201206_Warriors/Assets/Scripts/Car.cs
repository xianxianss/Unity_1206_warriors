
using UnityEngine;

public class Car : MonoBehaviour
{
    #region 練習欄位
    [Header("這是汽車的高度")]
    public int height = 3;
    [Tooltip("這是汽車的重量，單位是噸") , Range(1.5f,10)]
    public float weight = 6.5f;
    public string brand = "BMW";
    public bool hasWindows = true;
    [Header("顏色選擇")]
    public Color color1 = new Color(0.1f, 5, 4.2f);
    public Color color2 = Color.yellow;
    public Color color3;

    [Header("座標")]
    public Vector2 v2no1 = Vector2.zero;
    public Vector2 v2no2 = Vector2.one;
    public Vector2 v2no3 = new Vector2(12, 7);
    public Vector3 v3no1 = new Vector3(89, 12, 7);
    public Vector4 v4no1 = new Vector4(19, 89, 12, 7);

    [Header("圖片與音效")]
    public Sprite picture1;
    public AudioClip sound1;

    [Header("遊戲物件與元件")]
    public GameObject objt1;
    public GameObject objt2;

    public Transform tras1;
    public Camera cam1;
    #endregion

    #region 練習方法
    private void Test()
    {
        print("哈囉");
    }

    private void Start()
    {
        Test();

        print("品牌:" + brand);
        print("高度:" + height);
        print("顏色:" + color1);

        hasWindows = false;
        weight = 8.6f;

        print("傳回的數字:"+five());
        print("傳回的數字:" +sixsix());

        string myName = Name();
        print(myName);

        Drive("後面","轟轟轟",200);
        Drive("前面","轟轟轟",120);
        Drive("左邊","轟轟轟",150);

        OpenBrush("刷刷",speed:500);

    }

    private int five()
    {
        return 5;
    }

    private float sixsix()
    {
        return 6.6f;
    }

    private string Name()
    {
        return "xianxian";
    }

    /// <summary>
    /// 開車方法
    /// </summary>
    /// <param name="direction">方向</param>
    /// <param name="sound">音效</param>
    /// <param name="speed">速度</param>
    private void Drive (string direction,string sound,int speed)
    {
        print("開車方向:" + direction);
        print("開車音效:"+ sound);
        print("開車速度:" + speed);
    }

    /// <summary>
    /// 開啟雨刷
    /// </summary>
    /// <param name="speed">雨刷速度</param>
    private void OpenBrush(string sound,int count=20, int speed = 148)
    {
        print("開雨刷");
        print("雨刷音效:" + sound);
        print("雨刷速度:"+speed);
        print("雨刷數量:"+count);
    }


    #endregion 
}
