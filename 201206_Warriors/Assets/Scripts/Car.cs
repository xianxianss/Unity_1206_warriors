
using UnityEngine;

public class Car : MonoBehaviour
{
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

}
