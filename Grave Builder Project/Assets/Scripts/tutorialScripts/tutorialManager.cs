using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{

    public GameObject prompt1;

    private GameObject newparent;

    void Start()
    {   
        newparent = gameObject.transform.Find("Canvas").transform.Find("GameScenes").gameObject; //set newparent to GameScenes
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
