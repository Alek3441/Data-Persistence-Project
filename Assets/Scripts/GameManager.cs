using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public string playerName { get; set; }
    public string scoreName { get; set; }
    public int score { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    class HighScore
    {
        public string Name;
        public int Score;
    }

    public void SaveScore(string name, int score)
    {
        HighScore hs = new HighScore()
        {
            Name = name,
            Score = score
        };

        string json = JsonUtility.ToJson(hs);
        File.WriteAllText(Application.persistentDataPath + "/score.json", json);
    }

    public void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/score.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/score.json");
            HighScore hs = JsonUtility.FromJson<HighScore>(json);

            scoreName = hs.Name;
            score = hs.Score;
        }
    }

    public string BestScore()
    {
        string name = string.IsNullOrEmpty(scoreName) ? "Name" : scoreName;
        return "Best Score : " + name + " : " + score;
    }
}
