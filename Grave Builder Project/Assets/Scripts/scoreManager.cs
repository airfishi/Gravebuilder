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
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int addable)
    {
        score+=addable;
        scoreText.text = score.ToString();
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
            //highScoreText.text= highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
