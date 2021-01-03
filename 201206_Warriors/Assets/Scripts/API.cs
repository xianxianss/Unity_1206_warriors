using UnityEngine;

public class API : MonoBehaviour
{
    public Transform traA;
    public Transform tester;
    public Camera cam;
    public SpriteRenderer spt;
    public GameObject objt;
    private void Start()
    {
        print("座標:" + traA.position);

        tester.position = new Vector3(2, 0, 0);

        tester.Rotate(0, 0, 30);

        print("攝影機數量:" + Camera.allCamerasCount);
        cam.backgroundColor = new Color(0.3f, 6.6f, 8.1f);

        print("圖片的顏色:" + spt.color);
        print("物件的圖層:" + objt.layer);

        spt.flipX = true;
        objt.layer = 5;

    }

    private void Update()
    {
        tester.Rotate(0,0,30);
        tester.Translate(0.5f, 0, 0,Space.World);
    }
}
