using UnityEngine;

public class Coins : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip coin;

    void Awake()
    {
        GameObject sfxObject = GameObject.Find("SFX");
        
        if (sfxObject != null) {
            source = sfxObject.GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(coin);
            Destroy(gameObject);
        }
    }
}
