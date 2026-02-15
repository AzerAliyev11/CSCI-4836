using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bullet;

    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        yRotation += Input.GetAxis("Mouse X");
        if(Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
            BulletMovement bm = b.GetComponent<BulletMovement>();
            bm.moveDir = transform.forward; 
        }
    }

    void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.Euler(0f, yRotation * 5f, 0f));
    }
}
