using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedGreenLight : MonoBehaviour
{
    private bool canDetect;
    private bool canRotate = true;

    public Transform playerTransform;
    public GameObject player;
    public Camera playerCamera;

    private float distance;

    private float waitTime = 3f;

    void Start()
    {
        canDetect = false;
        distance = Vector3.Distance(transform.position, playerTransform.position);
    }

    void Update()
    {
        if(canRotate)
        {
            StartCoroutine(RotateDoll());
            canRotate = false;
        }
        if(canDetect)
        {
            Vector3 dir = (playerTransform.position - transform.position).normalized;
            Ray ray = new Ray(transform.position, dir);
            if(Physics.Raycast(ray, out RaycastHit hit)) {
                if(hit.transform.gameObject.CompareTag("Player"))
                {
                    playerCamera.transform.SetParent(transform);
                    Destroy(hit.transform.gameObject);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }

    private IEnumerator RotateDoll()
    {
        yield return new WaitForSeconds(waitTime);

        transform.Rotate(new Vector3(0, 180, 0));
        canDetect = !canDetect;
        canRotate = true;
        float newDistance = Vector3.Distance(transform.position, playerTransform.position);

        waitTime = 3f * (newDistance / distance);
        player.GetComponent<PlayerMovement>().speed = 10f * (distance / newDistance);
    }
}
