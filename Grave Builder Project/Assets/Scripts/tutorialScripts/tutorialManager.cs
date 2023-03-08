using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{

    public GameObject prompt1;
    public GameObject player;

    private GameObject newparent;
    

    void Awake()
    {   
        newparent = gameObject.transform.Find("Canvas").transform.Find("GameScenes").gameObject; //set newparent to GameScenes
        //Destroy(GameObject.FindGameObjectWithTag("Player"));
        Vector3 forward = new Vector3(0,0,-1);
        //GameObject gameScene = GameObject.FindGameObjectWithTag("GameScene");
        //GameObject newplayer = (GameObject)Instantiate(player, gameScene.transform.position + forward, Quaternion.Euler(0,0,0), gameScene.transform);
        StartCoroutine("firstPrompt");   
    }

    void Update(){

    }

    IEnumerator firstPrompt()
    {
        Vector3 adjustment = new Vector3(-1600, 1200, 0);
        prompt1 = (GameObject)Instantiate(prompt1, newparent.transform.position + adjustment, Quaternion.Euler(0,0,0), newparent.transform);
        Time.timeScale = 0;
        while(!Input.anyKeyDown){
            yield return null;
        }
        Time.timeScale = 1;
        Destroy(prompt1);

    }

}
