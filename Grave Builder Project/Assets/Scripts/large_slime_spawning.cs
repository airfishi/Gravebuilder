using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class large_slime_spawning : MonoBehaviour
{
    // Start is called before the first frame update

    public float secondsBetweenSpawn = 20000;
    public float elapsedTime = 0.0f;
    public GameObject large_slime;
    System.Random rand = new System.Random();

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        //int posneg = rand.Next(1);
        if(elapsedTime > secondsBetweenSpawn){
            elapsedTime = 0;
            Vector3 spawnPosition = new Vector3(rand.Next(100,200),8,0);
            GameObject newEnemy = (GameObject)Instantiate(large_slime,spawnPosition,Quaternion.Euler(0,0,0));
        }
    }
}
