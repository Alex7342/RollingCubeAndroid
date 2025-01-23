using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        scoreText.text = "0";
    }

    public void Update()
    {
        scoreText.text = PlayerStats.score.ToString();
    }
}