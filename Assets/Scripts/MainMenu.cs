using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public string mainLevelSceneName = "MainLevel";

    public Text highscoreText;

    private void Start()
    {
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void Play()
    {
        sceneFader.FadeTo(mainLevelSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
}
