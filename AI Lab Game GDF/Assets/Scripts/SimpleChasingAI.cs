using UnityEngine;

public class SimpleChasingAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;  

    void Update()
    {
        // Get the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized; 
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Rotate the AI to face the player
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);

        // Move the AI towards the player
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
