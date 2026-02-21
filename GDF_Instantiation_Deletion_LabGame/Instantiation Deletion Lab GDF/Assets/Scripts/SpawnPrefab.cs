using TMPro;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere;
    public GameObject car;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            float pos = Random.Range(-5f, 5f);
            GameObject go = Instantiate(cube, new Vector3(pos, 10, pos), Quaternion.identity);
            go.transform.parent = gameObject.transform;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            float pos = Random.Range(-5f, 5f);
            GameObject go = Instantiate(sphere, new Vector3(pos, 10, pos), Quaternion.identity);
            go.transform.parent = gameObject.transform;
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach(Transform child in gameObject.transform)
            {
                Destroy(child.gameObject);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            float pos = Random.Range(-5f, 5f);
            GameObject go = Instantiate(car, new Vector3(pos, 10, pos), Quaternion.identity);
            go.transform.parent = gameObject.transform;
        }
    }
}
