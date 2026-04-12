using UnityEngine;
using UnityEngine.UI; // Required for dealing with UI text

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    public Text scoreText; // The visual text on your screen

    public void AddScore(int amount)
    {
        currentScore += amount;
        scoreText.text = "SCORE: " + currentScore;
    }
}