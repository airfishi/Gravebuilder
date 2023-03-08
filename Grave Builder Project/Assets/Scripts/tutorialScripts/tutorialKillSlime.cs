using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialKillSlime : MonoBehaviour
{

    public GameObject block;
    private GameObject cameraObject;

    private bool quitting = false;
    private Vector3 spawnloc;
    private GameObject gameScreen;
    
    //tutorial stuff
    public GameObject prompt3;
    public GameObject dprompt;
    private GameObject newparent;
    private bool destroySlime;


    void Awake()
    {
        //removed gameScreen object from being assigned in inspector
        gameScreen = gameObject;
        while(!gameScreen.name.Equals("GameScenes")){
            gameScreen = gameScreen.transform.parent.gameObject;
        }
        newparent = gameScreen;
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            //Debug.Log(collision.gameObject.transform.position.y - gameObject.transform.parent.transform.position.y);
            if(collision.gameObject.transform.position.y - gameObject.transform.parent.transform.position.y > 0){
                quitting = true;
                //tutorialRespawn.instance.setQuitting(true);
                StartCoroutine("thirdPrompt");
            }
            else{
                //StartCoroutine("deathPrompt");
                quitting = true;
                tutorialLivesManager.instance.loseLife();
            }

        }
    }

    IEnumerator thirdPrompt(){
        Time.timeScale = 0;
        Vector3 adjustment = new Vector3(-1600, 1500, -1);
        prompt3 = (GameObject)Instantiate(prompt3, newparent.transform.position + adjustment, Quaternion.Euler(0,0,0), newparent.transform);
        while(!Input.anyKeyDown)
            yield return null;

        Time.timeScale = 1;
        Destroy(prompt3);
        SceneManager.LoadScene("TitleScreen");

    }

    IEnumerator deathPrompt() {
        Time.timeScale = 0;
        Vector3 adjustment = new Vector3(-1600, 1200, 0);
        dprompt = (GameObject)Instantiate(dprompt, newparent.transform.position + adjustment, Quaternion.Euler(0,0,0), newparent.transform);
        while(!Input.anyKeyDown)
            yield return null;

        Time.timeScale = 1;
        Destroy(dprompt);
    }


    void OnDestroy(){
        //Debug.Log(gameScreen); //should be gameScreen, but cannot directly reference
        if(!gameScreen.activeInHierarchy) quitting = true;
        if(!quitting){
            //x, 250 between each block, first location is -4200, last is 2300

            int xpos = Mathf.RoundToInt(transform.position.x / 500) * 500;
            int ypos = Mathf.RoundToInt(transform.position.y / 250) * 250;
            
            spawnloc = new Vector3(xpos,ypos+100, transform.position.z);

            GameObject newEnemy = (GameObject)Instantiate(block,spawnloc,Quaternion.Euler(0,0,0), gameScreen.transform);
            
            cameraObject.GetComponent<MoveCamera>().addBlock(ypos, xpos);

        }
    }

    void OnApplicationQuit(){
        quitting = true;
    }
}
