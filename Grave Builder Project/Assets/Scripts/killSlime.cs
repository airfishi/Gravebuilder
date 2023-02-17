using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killSlime : MonoBehaviour
{
public GameObject block;
    
    private bool quitting = false;
    private Vector3 spawnloc = new Vector3(-5500,-1600,-2);

    void OnDestroy(){
        if(!quitting){
            int xpos = (int) transform.position.x;
            //spawnloc.x = -5500 + 360*(xpos - 5500 % 360); 
            //~33 blocks across, 360 width change
            //28 blocks high, 240 height change
            GameObject newEnemy = (GameObject)Instantiate(block,spawnloc,Quaternion.Euler(0,0,0), transform.parent.transform.parent.gameObject.transform);
        }
    }

    void OnApplicationQuit(){
        quitting = true;
    }
}
