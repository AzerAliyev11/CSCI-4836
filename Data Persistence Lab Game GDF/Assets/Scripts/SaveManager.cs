using System.IO;
using UnityEngine;
using UnityEngine.PlayerLoop;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int gold;
    public float posX;
    public float posY;
    public float posZ;
}

public class SaveManager : MonoBehaviour
{
    public PlayerData data = new PlayerData();
    private string saveFilePath;
    private bool loaded = false;
    private Vector3 newPos;
    private float fraction = 0f;

    void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "player_save.json");
        Debug.Log("Save file location: " + saveFilePath);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) { data.gold += 100; Debug.Log("Gold added! Current Gold: " + data.gold); }
        if (Input.GetKeyDown(KeyCode.S)) { SaveGame(); }
        if (Input.GetKeyDown(KeyCode.L)) { LoadGame(); }

        if(loaded) 
        {
            if(fraction < 1)
            {
                fraction += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, newPos, fraction); 
            }
            else
            {
                loaded = false;
                fraction = 0;
                
            }
        }
    }

    public void SaveGame()
    {
        data.posX = transform.position.x;
        data.posY = transform.position.y;
        data.posZ = transform.position.z;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(saveFilePath, json);

        Debug.Log("<color=green>Game Saved!</color> Content: " + json);
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);

            data = JsonUtility.FromJson<PlayerData>(json);

            newPos = new Vector3(data.posX, data.posY, data.posZ);
            //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);
            loaded = true;
            Debug.Log("<color=cyan>Game Loaded!</color> Player: " + data.playerName + " | Gold: " + data.gold);
        }
        else
        {
            Debug.LogWarning("No save file found at: " + saveFilePath);
        }
    }
}