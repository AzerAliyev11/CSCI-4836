using UnityEngine;

public class PM02 : MonoBehaviour
{
    private Rigidbody rb;
    private float x_input;
    private float y_input;
    private float speed = 5f;

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
        rb.velocity = new Vector3(x_input, 0f, y_input) * speed;
    }
}
