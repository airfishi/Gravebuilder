using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killSlime : MonoBehaviour
{

    public GameObject block;
    private GameObject cameraObject;

    private bool quitting = false;
    private Vector3 spawnloc;
    private GameObject gameScreen;
    
    void Start()
    {
        //removed gameScreen object from being assigned in inspector
        gameScreen = gameObject;
        while(!gameScreen.name.Equals("GameScenes")){
            gameScreen = gameScreen.transform.parent.gameObject;
        }
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
    }


    void OnDestroy(){
        //Debug.Log(gameScreen); //should be gameScreen, but cannot directly reference
        if(!gameScreen.activeInHierarchy) quitting = true;
        if(!quitting){
            //x, 250 between each block, first location is -4200, last is 2300

            int xpos = Mathf.RoundToInt(transform.position.x / 500) * 500;
            int ypos = Mathf.RoundToInt(transform.position.y / 500) * 500;
            
            spawnloc = new Vector3(xpos,ypos-180, transform.position.z);

            GameObject newEnemy = (GameObject)Instantiate(block,spawnloc,Quaternion.Euler(0,0,0), gameScreen.transform);
            
            cameraObject.GetComponent<MoveCamera>().addBlock(ypos, xpos);

        }
    }

    void OnApplicationQuit(){
        quitting = true;
    }
}
