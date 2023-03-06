using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorialLivesManager : MonoBehaviour
{

    public GameObject dprompt;
    public int lives = 3;
    public TextMeshProUGUI liveCounter;
    public static tutorialLivesManager instance;

    private GameObject newparent;

    private void Awake(){
        instance = this;
    }

    void Start(){
        newparent = gameObject;
        /*
        while(!newparent.name.Equals("tutorialEverything") || !newparent.name.Equals("Everything"))
            Debug.Log(newparent.name);
            newparent = newparent.transform.parent.gameObject;
        newparent = newparent.transform.Find("Canvas").transform.Find("GameScenes").gameObject;
        */
        liveCounter.text = $"Lives: {lives}";
    }

    void Update(){
        
    }

    public void loseLife(){
        StartCoroutine("deathPrompt");
    }

    IEnumerator deathPrompt(){
        Time.timeScale = 0;
        Vector3 adjustment = new Vector3(-1600, 1200, 0);
        dprompt = (GameObject)Instantiate(dprompt, newparent.transform.position + adjustment, Quaternion.Euler(0,0,0), newparent.transform);
        Time.timeScale = 0;
        while(!Input.anyKeyDown){
            yield return null;
        }
        Time.timeScale = 1;
    }


    public int getLives(){
        return lives;
    }
}
