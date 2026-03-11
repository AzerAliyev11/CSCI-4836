using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIVision : MonoBehaviour
{
    private bool canDetect;

    public Transform playerTransform;
    private bool canRotate = true;

    void Start()
    {
        canDetect = false;
    }

    void Update()
    {
        if (canRotate) {
            canRotate = false;
            StartCoroutine(TimerCountdown());
        }
        if(canDetect)
        {
            Vector3 dir = (playerTransform.position - transform.position).normalized;
            Ray ray = new Ray(transform.position, dir);

            if(Physics.Raycast(ray, out RaycastHit hit)) {
                if(hit.transform.gameObject.CompareTag("Player"))
                {
                    Destroy(hit.transform.gameObject);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }

    private IEnumerator TimerCountdown()
    {
        yield return new WaitForSeconds(3f);
        
        canDetect = !canDetect;
        transform.Rotate(new Vector3(0, 180, 0));

        canRotate = true;
    }
}
