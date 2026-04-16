using System.IO;
using UnityEngine;

[System.Serializable]
public class Pl_Data
{
    public float x;
    public float y;
    public float z;
}

public class SM02 : MonoBehaviour
{
    private string saveFileLocation;
    Pl_Data playerData = new Pl_Data();
    private Vector3 oldPos = Vector3.zero;
    private float alpha = 0f;
    private bool loaded = false;

    void Start()
    {
        saveFileLocation = Path.Combine(Application.persistentDataPath, "player_new.json");
        Debug.Log(saveFileLocation);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveFile();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadFile();
        }

        if(loaded)
        {
            if(alpha < 1)
            {
                alpha += Time.deltaTime * 2f;
                transform.position = Vector3.Lerp(transform.position, oldPos, alpha);
            }
            else
            {
                loaded = false;
            }
        }
    }

    private void SaveFile()
    {
        playerData.x = transform.position.x;
        playerData.y = transform.position.y;
        playerData.z = transform.position.z;

        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(saveFileLocation, json);
    }

    private void LoadFile()
    {
        loaded = true;
        alpha = 0f;
        string readFile = File.ReadAllText(saveFileLocation);
        Pl_Data savedData = JsonUtility.FromJson<Pl_Data>(readFile);
        oldPos = new Vector3(savedData.x, savedData.y, savedData.z);
    }
}
