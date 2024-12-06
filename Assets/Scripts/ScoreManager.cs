using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } //one manager to be called from everything, makes things modular and easier
    public TextMeshProUGUI scoreText;
    private int score;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject); //make sure only one score manager exists
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void addScore(int points)
    {
        if (score + points < 0) //won't go into negative
            score = 0;
        else
            score += points;
        updateScoreText();
    }

    private void updateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
