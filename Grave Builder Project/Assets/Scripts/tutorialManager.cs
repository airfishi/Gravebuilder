using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{

    public GameObject first;
    GameObject newparent;

    void Start()
    {   
        newparent = gameObject.transform.Find("Canvas").transform.Find("GameScenes").gameObject; //set newparent to GameScenes
        StartCoroutine("firstPrompt");   
    }

    void Update(){
        firstPrompt();
    }

    IEnumerator firstPrompt()
    {
        Debug.Log("In firstprompt");
        Vector3 adjustment = new Vector3(-1600, 1200, 0);
        first = (GameObject)Instantiate(first, newparent.transform.position + adjustment, Quaternion.Euler(0,0,0), newparent.transform);
        while(!Input.anyKeyDown){
            yield return null;
        }
        Destroy(first);

    }

}
