using UnityEngine;

public class JarPickUp : MonoBehaviour
{
    public AudioSource source;
    public AudioClip jarSound;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(jarSound);
            other.gameObject.GetComponent<PlayerMovement>().jumpForce *= 5f;
            Destroy(this.gameObject);
        }
    }
}
