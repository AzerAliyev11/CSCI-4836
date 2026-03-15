using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumpForce;
    public bool isGrounded;

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip jumpSFX;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, rb.velocity.z);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        if (source != null) {
            source.PlayOneShot(jumpSFX);
        }
    }
}
