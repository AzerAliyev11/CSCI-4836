using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;

    public static ScoreManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        scoreText.text = $"Score: {score}";

        highScore = PlayerPrefs.GetInt("High Score", highScore);
        highScoreText.text = $"High Score: {highScore}";
    }

    public void AddScore(int scoreMultiplier)
    {
        score += scoreMultiplier;
        scoreText.text = $"Score: {score}";

        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);
            highScoreText.text = highScore.ToString();
        }
    }
}
