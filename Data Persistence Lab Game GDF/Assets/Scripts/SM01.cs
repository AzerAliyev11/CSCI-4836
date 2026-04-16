using System;
using System.IO;
using UnityEngine;

[System.Serializable]
public class P_Data
{
    public float x;
    public float y;
    public float z;
}

public class SM01 : MonoBehaviour
{
    private string saveFileLocation;
    public P_Data playerData = new P_Data();
    private Vector3 newPos = Vector3.zero;
    private float alpha = 0f;
    private bool loaded = false;

    void Start()
    {
        saveFileLocation = Path.Combine(Application.persistentDataPath, "player.json");
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
                transform.position = Vector3.Lerp(transform.position, newPos, alpha);
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
        alpha = 0;
        string data = File.ReadAllText(saveFileLocation);
        P_Data savedData = JsonUtility.FromJson<P_Data>(data);
        newPos = new Vector3(savedData.x, savedData.y, savedData.z);
    }
}
