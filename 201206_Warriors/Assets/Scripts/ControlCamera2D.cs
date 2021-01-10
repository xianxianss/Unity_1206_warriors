
using UnityEngine;

public class ControlCamera2D : MonoBehaviour
{
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 3.5f;


    /// <summary>
    /// 追蹤目標物件
    /// </summary>
    private void Track()
    {
        Vector3 posA = target.position;
        Vector3 posB = transform.position;
        posA.z = -10;
        posB = Vector3.Lerp(posB, posA, 0.5F * speed * Time.deltaTime);
        transform.position = posB;
    }

    private void LateUpdate()
    {
        Track();
    }
}
