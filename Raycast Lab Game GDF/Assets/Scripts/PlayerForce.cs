using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.AddForce(new Vector3(0, 0, speed));
    }
}
