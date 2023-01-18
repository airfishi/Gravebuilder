using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 speed;
    private Vector3 jump;
    private bool jumping;
    private bool grounded;
    private bool movingRight;
    private bool movingLeft;
    private int jumpTime;
    private int maxJumpTime;


    void Start()
    {
        jump = new Vector3(0, 1,0); 
        speed = new Vector3(1, 0,0);
        jumping = false;
        grounded = true;
        jumpTime = 0;
        maxJumpTime = 70;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))                     //Player Movement (left/right)
        {
            movingLeft= true;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            movingRight = true;
        }
        if (movingLeft)
        {
            player.transform.localPosition -= speed;
            if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                movingLeft = false;
            }
        }
        if (movingRight)
        {
            player.transform.localPosition += speed;
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                movingRight = false;
            }
        }



        if (!jumping && grounded)                                                               //Player Movement (Jumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping = true;
                jumpTime = 0;
            }
        }
        else
        {
            if (jumping)
            {
                this.transform.localPosition += jump;
                jumpTime++;
            }
            if (Input.GetKeyUp(KeyCode.Space) || jumpTime >= maxJumpTime)
            {
                jumping = false;
            }
        }
    }
}
