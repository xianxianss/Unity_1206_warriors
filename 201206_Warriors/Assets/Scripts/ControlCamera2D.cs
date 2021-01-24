
using UnityEngine;
using System.Collections;

public class ControlCamera2D : MonoBehaviour
{
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 3.5f;
    [Header("晃動間隔"), Range(0, 1)]
    public float shakeInterval = 0.05f;
    [Header("晃動值"), Range(0, 5)]
    public float shakeValue = 0.5f;


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

    //延遲更新 : 在Update執行後才執行，追蹤
    private void LateUpdate()
    {
        Track();
    }

    /// <summary>
    /// 晃動效果
    /// </summary>
    /// <returns></returns>
    public IEnumerator ShakeCamera()
    {
        transform.position += Vector3.up * shakeInterval;
        yield return new WaitForSeconds(shakeInterval);
        transform.position -= Vector3.up * shakeInterval;
        yield return new WaitForSeconds(shakeInterval);
        transform.position += Vector3.up * shakeInterval;
        yield return new WaitForSeconds(shakeInterval);
        transform.position -= Vector3.up * shakeInterval;
        yield return new WaitForSeconds(shakeInterval);
        transform.position += Vector3.up * shakeInterval;
        yield return new WaitForSeconds(shakeInterval);
        transform.position -= Vector3.up * shakeInterval;
        yield return new WaitForSeconds(shakeInterval);
    }
}
