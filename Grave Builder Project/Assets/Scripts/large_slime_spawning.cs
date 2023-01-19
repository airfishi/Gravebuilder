using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class large_slime_spawning : MonoBehaviour
{
    // Start is called before the first frame update

    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;
    public GameObject large_slime;
    private int xspawn;
    private int posneg;
    System.Random rand = new System.Random();

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > secondsBetweenSpawn){
            elapsedTime = 0;
            //randomly pick a place between -6 and 6 for slime to spawn
            xspawn = rand.Next(3000);
            posneg = rand.Next(2);
            if(posneg == 1) xspawn = xspawn*-1;
            Vector3 spawnPosition = new Vector3(xspawn,1500,0);
            GameObject newEnemy = (GameObject)Instantiate(large_slime,spawnPosition,Quaternion.Euler(0,0,0));
        }
    }
}
