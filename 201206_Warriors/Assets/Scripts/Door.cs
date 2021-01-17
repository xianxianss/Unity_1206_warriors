
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("鑰匙")]
    public GameObject key;
    private Animator ani;
    private AudioSource aud;

    [Header("開門音效")]
    public AudioClip soundOpen;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "戰士" && key == null)
        {
            ani.SetTrigger("開門");
            aud.PlayOneShot(soundOpen, Random.Range(1.2f, 1.5f));
        }
    }
}
