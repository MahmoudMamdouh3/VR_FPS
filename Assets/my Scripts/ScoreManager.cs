using UnityEngine;
using TMPro; // This line tells Unity we are using TextMeshPro!

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    public TextMeshProUGUI scoreText; // Now it will accept your TMP object

    public void AddScore(int amount)
    {
        currentScore += amount;
        scoreText.text = "SCORE: " + currentScore;
    }
}