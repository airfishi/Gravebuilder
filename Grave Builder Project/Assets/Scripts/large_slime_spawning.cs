using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class large_slime_spawning : MonoBehaviour
{
    // Start is called before the first frame update

    public float secondsBetweenSpawn;
    public float clumpNumber = 1;
    public float elapsedTime = 0.0f;
    public GameObject slime_type;
    public GameObject invulnerability_upgrade;
    public GameObject block;
    public GameObject scoreBonus;
    private GameObject gameScreen;
    
    private int xspawn;
    private int yspawn = 2000;
    private int posneg;
    System.Random rand = new System.Random();

    void Start(){
        gameScreen = gameObject.transform.parent.gameObject;
    }
    public void increaseYSpawn()
    {
        yspawn += 250;
    }
    // Update is called once per frame
    void Update()
    {
        
        elapsedTime += Time.deltaTime;
        if (elapsedTime/clumpNumber > secondsBetweenSpawn){
            elapsedTime = 0;
            for (int i = 0; i < clumpNumber; i++)
            {
                //randomly pick a place between -4200 and 2300 for slime to spawn
                //xspawn = rand.Next(5000);
                //posneg = rand.Next(2);
                //if(posneg == 1) xspawn = xspawn*-1;
                var lowerbound = -3200;
                var upperbound = 2600;
                var xspawn = rand.Next(lowerbound, upperbound);
                var type = rand.Next(0, 20);

                Vector3 spawnPosition = new Vector3(xspawn, yspawn, 0);
                GameObject newObject;
                if (type >= 7)
                {
                    newObject = (GameObject)Instantiate(slime_type, spawnPosition, Quaternion.Euler(0, 0, 0), gameScreen.transform);
                }else if (type == 6)
                {
                    newObject = (GameObject)Instantiate(slime_type, spawnPosition, Quaternion.Euler(0, 0, 0), gameScreen.transform);
                }
                else if (type == 4 || type == 3)
                {
                    newObject = (GameObject)Instantiate(scoreBonus, spawnPosition, Quaternion.Euler(0, 0, 0), gameScreen.transform);
                }
                else if (type == 1 || type == 2)
                {
                    newObject = (GameObject)Instantiate(invulnerability_upgrade, spawnPosition, Quaternion.Euler(0, 0, 0), gameScreen.transform);
                }
                else if (type == 0 || type == 5)
                {
                    int xpos = Mathf.RoundToInt(spawnPosition.x / 500) * 500;
                    int ypos = Mathf.RoundToInt(spawnPosition.y / 250) * 250;

                    spawnPosition = new Vector3(xpos, ypos + 100, transform.position.z);
                    newObject = (GameObject)Instantiate(block, spawnPosition, Quaternion.Euler(0, 0, 0), gameScreen.transform);

                    Transform everything = gameScreen.transform.parent.transform.parent;
                    everything.Find("Main Camera").GetComponent<MoveCamera>().addBlock(ypos, xpos);
                }
            }
        }
    }
}
