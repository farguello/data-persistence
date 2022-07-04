using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionData : MonoBehaviour
{
    public static SessionData Instance;

    public string playerName;
    public int hiScore;
    public string currentPlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        LoadPlayerData();
        DontDestroyOnLoad(gameObject);
    }

    public void SavePlayerData() {
        SaveData saveData = new SaveData();

        saveData.playerName = currentPlayerName;
        saveData.hiScore = hiScore;

        string path =  Application.persistentDataPath + "/savefile.json";
        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(path, json);
    }

    public void LoadPlayerData() {
        string path =  Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            playerName = saveData.playerName;
            hiScore = saveData.hiScore;
        }

    }
}


[System.Serializable]
class SaveData
{
    public string playerName;
    public int hiScore;
}
