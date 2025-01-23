using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int startScore = 0;
    public int startLives = 1;

    public static int score;
    public static int lives;

    private void Start()
    {
        score = startScore;
        lives = startLives;
    }
}
