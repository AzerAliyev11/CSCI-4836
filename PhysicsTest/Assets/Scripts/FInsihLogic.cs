using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInsihLogic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("We reached the finish line!");
        }
    }
}
