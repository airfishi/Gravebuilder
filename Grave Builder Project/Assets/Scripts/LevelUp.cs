using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelUp : MonoBehaviour
{
    // Start is called before the first frame update
    private int time;
    private GameObject well;
    void Start()
    {
        well = transform.parent.transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).gameObject;
        System.Random rnd = new System.Random();
        int num = rnd.Next(0,3);
        switch(num){
            case 0:         //Accelerate Slime Spawning
                well.GetComponent<large_slime_spawning>().secondsBetweenSpawn *= 2;
                well.GetComponent<large_slime_spawning>().secondsBetweenSpawn /= 3;
                Debug.Log(":EVEL UP: Slimes Spawn  Faster!");
                break;
            case 1:         //Spawn another slime, but spawn less frequently.
                well.GetComponent<large_slime_spawning>().clumpNumber++;
                Debug.Log("LEVEL UP: Slime Clumping Increased");
                break;
            case 2:         //Increase the block height required to level up
                GetComponent<MoveCamera>().incBlockInLevel();
                Debug.Log("LEVEL UP: Level Height Increased");
                break;
            case 3:         //No Effect(Yay)
                Debug.Log("LEVEL UP!!!!");
                break;

        }
    }
    private void Update()
    {
        time++;
        if(time > 1000)
        {
            Destroy(this);
        }
    }
}
