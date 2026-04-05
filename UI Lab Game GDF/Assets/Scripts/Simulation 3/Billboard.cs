using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform cam;


    //Using LateUpdate instead of Update function so the changes happen without visible jitters
    void LateUpdate()
    {
        // Rotate the object to face the same direction as the camera (billboard effect)
        transform.LookAt(transform.position + cam.forward);
    }
}
