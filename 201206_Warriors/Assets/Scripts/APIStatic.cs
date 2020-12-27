using UnityEngine;

/// <summary>
/// 認識API 靜態 Static
/// </summary>
public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        #region 靜態屬性
        print("隨機值:" + Random.value);
        print("拍:" + Mathf.PI);

        Cursor.visible = false;

        Time.timeScale = 2;

        #endregion

        #region 靜態方法

        print("隨機值介於100-500:" + Random.Range(100, 500));

        print("隨機值介於100-500:" + Random.Range(100f, 500f));

        int number = Mathf.Abs(-99);
        print("取完絕對值的整數:" + number);

        float number2 = Mathf.Abs(-85.65175f);
        print("取完絕對值的浮點數:" + number2);

        #endregion
    }
}
