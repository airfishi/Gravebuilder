using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 speed;
    private Vector3 jump;
    private int jumpRemaining;
    private int speedRemaining;
    void Start()
    {
        jump = new Vector3(0, 1, 0); 
        speed = new Vector3(1, 0, 0);
        jumpRemaining= 0;
        speedRemaining= 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpRemaining == 0)                                                 //Jumps by 1 10 times over 10 frames.
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpRemaining = 10;
            }
        }
        else
        {
            player.transform.localPosition += jump;
            jumpRemaining--;
        }



        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.DownArrow))    //Begins moving player left or right by 1 10 times over 10 frames.
        {
            speedRemaining = 10;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            speedRemaining = -10;
        }

        if(speedRemaining > 0)
        {
            player.transform.localPosition -= speed;
            speedRemaining--;
        }

        if(speedRemaining < 0)
        {
            player.transform.localPosition += speed;
            speedRemaining++;
        }
    }
}
