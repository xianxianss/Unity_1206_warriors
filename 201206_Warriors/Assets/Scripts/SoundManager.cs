using UnityEngine;
using UnityEngine.Audio; //引用 音源 API

public class SoundManager : MonoBehaviour
{
    [Header("音源管理")]
    public AudioMixer mixer;

    public void VolumeBGM(float v)
    {
        mixer.SetFloat("VolumeBGM", v);
    }


    public void VolumeSFX(float v)
    {
        mixer.SetFloat("VolumeSFX", v);
    }
}
