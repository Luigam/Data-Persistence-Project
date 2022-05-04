using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public string username;
    public int newHighScorePoints;

    public string oldHighScoreUsername;
    public int oldHighScorePoints;

    public Text bestScoreText;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScoreNameAndPoints();
        //SaveHighScoreNameAndPoints();

        bestScoreText.text = $"Best Score : {oldHighScoreUsername}: {oldHighScorePoints}";
    }

    [System.Serializable]
    class SaveData
    {
        public string username;
        public int highScorePoints;
    }

    public void SaveHighScoreNameAndPoints()
    {
        SaveData data = new SaveData();
        //data.username = "Name";
        //data.highScorePoints = 0;
        data.username = username;
        data.highScorePoints = newHighScorePoints;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScoreNameAndPoints()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            oldHighScoreUsername = data.username;
            oldHighScorePoints = data.highScorePoints;
        }
    }
}
