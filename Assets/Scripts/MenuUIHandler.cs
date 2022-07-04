using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Highscore - " + SessionData.Instance.playerName + " : " + SessionData.Instance.hiScore;
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        SessionData.Instance.currentPlayerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
