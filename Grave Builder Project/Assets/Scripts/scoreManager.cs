using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;

    public int score, highScore;

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
        UpdateHighScore();
    }
    public void UpdateHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
        }
    }
}
