using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class initial_move_dir : MonoBehaviour
{
    public GameObject large_slime;
    //Vector2 speed = Vector2.zero;

    private Rigidbody2D slimeBody;

    private float dirX;
    private float magnitude = 500;
    System.Random rand = new System.Random();
    private float leftScreen = -4200;
    private float rightScreen = 2300;
    private Animator animator;

    void Start()
    {
        dirX = 0;
        animator = GetComponent<Animator>();
        slimeBody = large_slime.transform.GetChild(0).GetComponent<Rigidbody2D>();
    }
    
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.transform.position.y >= slimeBody.position.y)
        {
            if (dirX == 0)
            {
                if (animator)
                    animator.SetBool("isLanding", true);
                //randomly start the movement left or right when it lands
                int changeTo = rand.Next(2);
                if (changeTo == 1) dirX = -magnitude;
                else dirX = magnitude;
            }
            else if (GetComponent<Transform>().position.x > rightScreen) dirX = -magnitude;
            else if (GetComponent<Transform>().position.x < leftScreen) dirX = magnitude;
            else if (dirX == -magnitude) dirX = magnitude; //swap the direction when slime collides
            else dirX = -magnitude;
            slimeBody.position = new Vector2(slimeBody.position.x + dirX / 10, slimeBody.position.y);
        }
    }

    void Update(){
        slimeBody.velocity = new Vector2(dirX, slimeBody.velocity.y);
    }    
}
