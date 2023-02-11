using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class initial_move_dir : MonoBehaviour
{
    public GameObject large_slime;
    Vector3 speed = Vector3.zero;

    private float dirX;
    System.Random rand = new System.Random();

    void OnCollisionEnter2D(){
        
        if(dirX==0){
            //randomly start the movement left or right when it lands
            int changeTo = rand.Next(2);
            if(changeTo == 1) dirX = -1;
            else dirX = 1; 
        }
        else if(dirX == -1) dirX = 1; //swap the direction when slime collides
        else dirX = -1;
        speed = new Vector3(dirX*Time.deltaTime*Screen.width/100,0,0);
    }

    /*
    void OnCollisionExit2D(){
        large_slime.transform.localPosition+=speed;
    }
    */

    void Update(){
        large_slime.transform.localPosition+=speed;
    }
}
