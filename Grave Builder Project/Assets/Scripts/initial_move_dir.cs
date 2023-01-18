using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class initial_move_dir : MonoBehaviour
{
    public GameObject large_slime;
    Vector3 speed = Vector3.zero;

    private bool movingright = false;
    private bool movingleft = false;
    private Vector3 left = new Vector3(-1,0,0);
    private Vector3 right = new Vector3(1,0,0);
    System.Random rand = new System.Random();

    void OnCollisionEnter2D(){
        if(movingleft == false && movingright == false){
            int changeTo = rand.Next(1);
            if(changeTo == 0){
                movingleft = true;
                movingright = false;
                speed = left;
                large_slime.transform.localPosition+=speed;
            }
            else{
                movingleft = false;
                movingright = true;
                speed = right;
                large_slime.transform.localPosition+=speed;
            }
        }
        else if(movingleft == true && movingleft == false){
            movingleft = false;
            movingright = true;
            speed = right;
        }
        else{
            movingleft = true;
            movingright = false;
            speed = left;
        }
    }

    void Update(){
        large_slime.transform.localPosition+=speed;
    }
}
