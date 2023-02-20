using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class large_slime_spawning : MonoBehaviour
{
    // Start is called before the first frame update

    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;
    public GameObject slime_type;
    private GameObject gameScreen;

    private int xspawn;
    private int posneg;
    System.Random rand = new System.Random();

    void Start(){
        gameScreen = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > secondsBetweenSpawn){
            elapsedTime = 0;
            //randomly pick a place between -4200 and 2300 for slime to spawn
            //xspawn = rand.Next(5000);
            //posneg = rand.Next(2);
            //if(posneg == 1) xspawn = xspawn*-1;
            var lowerbound = -3200;
            var upperbound = 2600;
            var xspawn = rand.Next(lowerbound,upperbound);

            Vector3 spawnPosition = new Vector3(2600,2000,0);
            GameObject newEnemy = (GameObject)Instantiate(slime_type,spawnPosition,Quaternion.Euler(0,0,0), gameScreen.transform);
        }
    }
}
