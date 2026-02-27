using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingAI : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;

    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            TurnAround();  
        }
    }

    void TurnAround()
    {
        transform.Rotate(0f, 180f, 0f);
        speed = -speed;
    }
}
