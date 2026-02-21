using Unity.VisualScripting;
using UnityEngine;

public class ObjectSoawner : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            float pos = Random.Range(-5.0f, 5.0f);
            GameObject go = Instantiate(cube, new Vector3(pos, 10, pos), Quaternion.identity);
            go.transform.parent = gameObject.transform;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            float pos = Random.Range(-5.0f, 5.0f);
            GameObject go = Instantiate(sphere, new Vector3(pos, 10, pos), Quaternion.identity);
            go.transform.parent = gameObject.transform;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
