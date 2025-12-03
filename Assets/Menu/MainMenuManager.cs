using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private Button playButton;
    private Button helpButton;
    private Button exitButton;

    void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Help()
    {
        Debug.Log("Help Pushed");
    }

    void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    void Start()
    {
        playButton = GameObject.Find("Play").GetComponent<Button>();
        playButton.onClick.AddListener(Play);
        helpButton = GameObject.Find("How To Play").GetComponent<Button>();
        helpButton.onClick.AddListener(Help);
        exitButton = GameObject.Find("Exit Button").GetComponent<Button>();
        exitButton.onClick.AddListener(ExitApplication);
    }
}
