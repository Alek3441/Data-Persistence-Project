using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public InputField input;
    public Text highScore;

    private void Start()
    {
        string name = string.IsNullOrEmpty(GameManager.Instance.scoreName) ? "Name" : GameManager.Instance.scoreName;
        highScore.text = "Best Score: " + name + " : " + GameManager.Instance.score;
    }

    public void StartGame()
    {
        if (!string.IsNullOrEmpty(input.text))
        {
            GameManager.Instance.playerName = input.text;
            SceneManager.LoadScene("main");
        }
        else
        {
            //TODO: Add error text for not entering name
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
