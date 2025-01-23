using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text scoreText;

    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        scoreText.text = "0";
        StartCoroutine(GetScore());

        if (PlayerStats.score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", PlayerStats.score);
        }
    }

    IEnumerator GetScore()
    {
        for (int i = 1; i <= PlayerStats.score; i++)
        {
            scoreText.text = i.ToString();
            yield return new WaitForSecondsRealtime(0.02f);
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(menuSceneName);
    }
}
