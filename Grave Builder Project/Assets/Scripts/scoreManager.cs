using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;

    public int score, highScore;

    public TextMeshProUGUI scoreText, highScoreText, gameOverScore;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {
        score++;

        scoreText.text = score.ToString();
        gameOverScore.text = score.ToString();
        UpdateHighScore();
    }
    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
}
