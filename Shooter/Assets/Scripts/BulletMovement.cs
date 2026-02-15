using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector3 moveDir = Vector3.forward;
    public Rigidbody rb;
    private float speed = 20f;
    private float bulletLife = 3f;

    void Update()
    {
        bulletLife -= Time.deltaTime;

        if(bulletLife <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveDir * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
