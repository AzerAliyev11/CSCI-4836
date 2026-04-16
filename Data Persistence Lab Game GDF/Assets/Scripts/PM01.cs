using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM01 : MonoBehaviour
{
    private Rigidbody rb;
    float x_input = 0f, y_input = 0f;
    private float speed = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x_input = Input.GetAxis("Horizontal");
        y_input = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(x_input, 0, y_input) * speed;
    }
}
