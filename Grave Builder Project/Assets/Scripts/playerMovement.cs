using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject floor;
    public AnimationClip animationID;

    private Vector3 speed;
    private Vector3 jump;
    private KeyCode jumpKey;

    public bool jumping;
    public bool grounded;
    public bool movingRight;
    public bool movingLeft;
    public int jumpTime;
    public int maxJumpTime;
    public int onWall;
    

    void Start()
    {
        jump = new Vector3(0, 1000, 0);
        speed = new Vector3(1500, 0, 0);
        jumping = false;
        grounded = true;
        jumpTime = 0;
        maxJumpTime = 210;
        movingLeft = false;
        movingRight = false;
        floor.tag = "floor";
    }

    void OnCollisionEnter2D(Collision2D other)            //gounded is uesed in jumping, see bottom section of Update()
    {
        if (other.gameObject.tag == "floor")
        {
            grounded = true;
        }

        if (other.gameObject.tag == "LargeSlime")
        {
            if(player.transform.position.y > other.gameObject.transform.position.y + 260)
            {
                Destroy(other.transform.gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(player);
            }
        }

        if (other.gameObject.tag == "MediumSlime")
        {
            if(player.transform.position.y > other.gameObject.transform.position.y + 100)
            {
                Destroy(other.transform.gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(player);
            }
        }

        /*if (other.gameObject.tag == "SmallSlime")
        {
            if(player.transform.position.y < other.gameObject.transform.position.y - 20000)
            {
                Destroy(other.transform.gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(player);
            }
        }*/
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "floor")
        {
            grounded = false;
            //Debug.Log("Left the Floor");
        }
        else
        {
            //Debug.Log("Left something else");

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement (left/right)
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))  //GetKeyDown only returns true on initial press.  Boolean allows continuous movement until GetKeyUp returns true.
        {
            movingLeft = true;

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            movingRight = true;
        }
        if (movingLeft)
        {
            player.transform.localPosition -= speed * Time.deltaTime;                               //adjusts player's position in game--does not check for collisions. Collision check might be needed in later development to smooth gameplay.
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                movingLeft = false;
            }
        }
        if (movingRight)
        {
            player.transform.localPosition += speed * Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                movingRight = false;
            }
        }



        if (!jumping && grounded)                                                  //Player Movement (Jumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping = true;
                jumpTime = 0;
                jumpKey = KeyCode.Space;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumping = true;
                jumpTime = 0;
                jumpKey = KeyCode.UpArrow;
            }
        }
        else
        {
            if (jumping)
            {
                player.transform.localPosition += jump * Time.deltaTime;
                jumpTime++;
            }
            if ((Input.GetKeyUp(KeyCode.Space) && jumpKey == KeyCode.Space) || (Input.GetKeyUp(KeyCode.UpArrow) && jumpKey == KeyCode.UpArrow) || jumpTime >= maxJumpTime)
            {
                jumping = false;
            }
        }
    }
}
