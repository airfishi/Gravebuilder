using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killSlime : MonoBehaviour
{

public GameObject block;

    private bool quitting = false;
    private Vector3 spawnloc;
    private GameObject gameScreen;
    public GameObject camera;
    
    void Start()
    {
        gameScreen = transform.parent.transform.parent.transform.parent.gameObject;
    }


    void OnDestroy(){
        //Debug.Log(gameScreen); //should be gameScreen, but cannot directly reference
        if(!gameScreen.activeInHierarchy) quitting = true;
        if(!quitting){
            //x, 250 between each block, first location is -4200, last is 2300

            int xpos = Mathf.RoundToInt(transform.position.x / 250) * 250;
            int ypos = Mathf.RoundToInt(transform.position.y /250) * 250;
            
            spawnloc = new Vector3(xpos,ypos - 250, transform.position.z);

            camera.GetComponent<MoveCamera>().addBlock(ypos, xpos);

            GameObject newEnemy = (GameObject)Instantiate(block,spawnloc,Quaternion.Euler(0,0,0), transform.parent.transform.parent.gameObject.transform);

        }
    }

    void OnApplicationQuit(){
        quitting = true;
    }
}
