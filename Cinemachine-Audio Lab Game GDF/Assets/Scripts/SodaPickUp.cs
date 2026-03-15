using Unity.VisualScripting;
using UnityEngine;

public class SodaPickUp : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip sodaClip;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(sodaClip);
            Destroy(this.gameObject);
        }
    }
}
