using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 speed;
    private Vector3 jump;
    //private int jumpRemaining; //Jump Draft 1
    private bool jumping;
    private bool grounded;
    private bool movingRight;
    private bool movingLeft;
    void Start()
    {
        jump = new Vector3(0, 1,0); 
        speed = new Vector3(1, 0,0);
        //jumpRemaining= 0;
        //speedRemaining= 0;
        jumping = false;
        grounded = true;
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

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
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

       /* if (speedRemaining > 0)
        {
            
            if(Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.LeftArrow))
            {
                moving = 0;
            }
        }

        if (speedRemaining < 0)
        {
            
            if (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.RightArrow))
            {
                moving = 0;
            }
        }*/

        if (!jumping && grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping = true;
            }
        }
        else
        {
            if (jumping)
            {
                this.transform.localPosition += jump;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumping = false;
            }
        }
    }
}
