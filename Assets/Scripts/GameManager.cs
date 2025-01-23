using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool gameIsOver = false;

    public AnimationCurve timeFreezeCurve;
    public float timeFreezeDuration = 1f;

    public AnimationCurve audioVolumeCurve;
    public AudioSource audioSource;

    public GameObject normalUI;
    public GameObject gameOverUI;

    public Player player;

    private void Start()
    {
        Time.timeScale = 1f;
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            gameIsOver = true;
            player.Die();
            EndGame();
        }
    }

    private void EndGame()
    {
        StartCoroutine(FreezeTime());
        normalUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    IEnumerator FreezeTime()
    {
        float t = 1f;

        while (t > 0f)
        {
            Time.timeScale = timeFreezeCurve.Evaluate(t);
            audioSource.volume = audioVolumeCurve.Evaluate(t);
            t -= Time.unscaledDeltaTime / timeFreezeDuration;
            yield return 0;
        }
    }
}
