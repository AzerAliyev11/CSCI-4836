using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody rb;
    private float speed = 5f;
    private Vector3 playerPos;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 dir = (playerPos - transform.position).normalized;
        rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.z * speed);
    }
}
