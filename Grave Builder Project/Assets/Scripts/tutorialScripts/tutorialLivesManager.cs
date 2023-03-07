using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialLivesManager : MonoBehaviour
{

    public GameObject dprompt;
    public int lives = 3;
    public TextMeshProUGUI liveCounter;
    public static tutorialLivesManager instance;
    public bool tutorial;
    private GameObject newparent;

    private void Awake(){
        instance = this;
    }

    void Start(){
        newparent = gameObject;

        while(!newparent.name.Equals("tutorialEverything"))
            newparent = newparent.transform.parent.gameObject;
        newparent = newparent.transform.Find("Canvas").transform.Find("GameScenes").gameObject;
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
        while(!Input.anyKeyDown){
            yield return null;
        }
        Time.timeScale = 1;
        Destroy(dprompt);
        SceneManager.LoadScene("TutorialScreen");
    }


    public int getLives(){
        return lives;
    }
}
