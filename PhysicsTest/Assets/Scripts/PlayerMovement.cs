using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    private bool moveLeft = false;
    private bool moveRight = false;


    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
            moveRight = false;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            moveLeft = false;
            moveRight = true;
        }
        else
        {
            moveLeft = false;
            moveRight = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, 20f);

        if(moveLeft)
        {
            rb.velocity = new Vector3(-10f, 0, rb.velocity.z);
        }

        if(moveRight)
        {
            rb.velocity = new Vector3(10f, 0, rb.velocity.z);
        }
    }
}
