using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class livesManager : MonoBehaviour
{

    public int lives = 3;
    public TextMeshProUGUI liveCounter;
    public static livesManager instance;

    private void Awake(){
        instance = this;
    }

    void Start(){
        liveCounter.text = $"Lives: {lives}";
    }

    void Update(){
        
    }

    public void loseLife(){
        lives = --lives;
        if(lives <= 0){
            liveCounter.text = "Lives: DEAD";
        }
        liveCounter.text = $"Lives: {lives}";
        if(gameObject.transform.parent.Find("Player1"))
            Destroy(gameObject.transform.parent.Find("Player1").gameObject);
        if(gameObject.transform.parent.Find("Player"))
            Destroy(gameObject.transform.parent.Find("Player").gameObject);
    }

    public int getLives(){
        return lives;
    }
}
