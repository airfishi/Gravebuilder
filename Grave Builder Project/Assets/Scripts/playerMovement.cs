using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
   //components
    public GameObject player;
    public Rigidbody2D playerBody;
    public AudioSource playerSound;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    //audio
    public AudioClip walking;
    public AudioClip jumpStart;
    public AudioClip kill;
    public AudioClip land;
    public AudioClip die;

    //factors
    private int speed;
    private Vector3 jump;
    private KeyCode jumpKey;
   
    //movement
    public bool jumping;
    public bool grounded;
    public bool movingRight;
    public bool movingLeft;
    private int jumpTime;
    private int maxJumpTime;

    //extras
    public int score;
    private bool dead;
    public int endScenes;
    private bool gameStart;

    public GameObject mainCanvas;
    public GameObject other;


    void Start()
    {
        jump = new Vector3(0, 1300, 0);
        speed = 1500;
        jumping = false;
        grounded = true;
        jumpTime = 0;
        maxJumpTime = 200;
        movingLeft = false;
        movingRight = false;
        score = 0;
        dead = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameStart = true;

    }

    public int getScore()
    {
        return score;
    }
    void OnCollisionEnter2D(Collision2D other)            //grounded is used in jumping, see bottom section of Update()
    {
        if (!dead)
        {
            if (other.gameObject.tag == "floor")
            {
                grounded = true;
                if (!gameStart)
                {
                    playerSound.Stop();
                    playerSound.loop = false;
                    playerSound.clip = land;
                    playerSound.Play();
                }
                else
                {
                    gameStart = false;
                }
            }

            if (other.gameObject.tag == "LargeSlime")
            {
                if (player.transform.position.y > other.gameObject.transform.position.y - 50)
                {
                    score++;
                    Destroy(other.transform.gameObject.transform.parent.gameObject);
                    playerSound.Stop();
                    playerSound.clip = kill;
                    playerSound.Play();
                }
                else
                {
                    playerSound.Stop();
                    playerSound.clip = die;
                    playerSound.loop = false;
                    playerSound.Play();
                    dead = true;
                }
            }

            if (other.gameObject.tag == "MediumSlime")
            {
                if (player.transform.position.y > other.gameObject.transform.position.y + 20)
                {
                    score++;
                    Destroy(other.transform.gameObject.transform.parent.gameObject);
                    playerSound.Stop();
                    playerSound.clip = kill;
                    playerSound.loop = false;
                    playerSound.Play();
                }
                else
                {
                    playerSound.Stop();
                    playerSound.clip = die;
                    playerSound.loop = false;
                    playerSound.Play();
                    dead = true;
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
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (!dead)
        {
            if (other.gameObject.tag == "floor")
            {
                grounded = false;

                playerSound.Stop();
                playerSound.clip = jumpStart;
                playerSound.loop = false;
                playerSound.Play();
                //Debug.Log("Left the Floor");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
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
                animator.SetBool("isRunning", true);
                spriteRenderer.flipX = true;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, player.GetComponent<Rigidbody2D>().velocity.y);
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    movingLeft = false;
                }
            }else if (movingRight)
            {
                animator.SetBool("isRunning", true);
                spriteRenderer.flipX = false;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, player.GetComponent<Rigidbody2D>().velocity.y);

                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    movingRight = false;
                }
            }else if (movingLeft && movingRight)
            {
                animator.SetBool("isRunning", false);
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (!movingLeft && !movingRight)
            {
                animator.SetBool("isRunning", false);
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.GetComponent<Rigidbody2D>().velocity.y);
            }

            //Walking Audio
            if ((movingLeft || movingRight) && grounded && playerSound.clip != walking)
            {
                playerSound.Stop();
                playerSound.clip = walking;
                playerSound.loop = true;
                playerSound.Play();
            }
            if (((!movingLeft && !movingRight) || !grounded) && playerSound.clip == walking)
            {
                playerSound.loop = false;
                if (!playerSound.isPlaying)
                    playerSound.clip = null;
            }

            if(!jumping && grounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumping = true;
                    jumpTime = 0;
                    playerBody.AddForce(jump*100, ForceMode2D.Force);
                    jumpKey = KeyCode.Space;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    jumping = true;
                    jumpTime = 0;
                    playerBody.AddForce(jump*100, ForceMode2D.Force);
                    jumpKey = KeyCode.UpArrow;
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    jumping = true;
                    jumpTime = 0;
                    playerBody.AddForce(jump*100, ForceMode2D.Force);
                    jumpKey = KeyCode.W;
                }
            }
            else
            {
                if (jumping)
                {
                    jumpTime++;
                    animator.SetBool("isJumping", true);
                }
                if (jumping && ((Input.GetKeyUp(KeyCode.Space) && jumpKey == KeyCode.Space) || (Input.GetKeyUp(KeyCode.UpArrow) && jumpKey == KeyCode.UpArrow) || (Input.GetKeyUp(KeyCode.W) && jumpKey == KeyCode.W) || jumpTime >= maxJumpTime))
                {
                    //playerBody.AddForce(jump * -1 * (int)(120 - (jumpTime / 2)), ForceMode2D.Force);
                    playerBody.AddForce(jump * -55, ForceMode2D.Force);
                    //Debug.Log(jumpKey + " " + Input.GetKeyUp(KeyCode.W)+ " " + jumpTime);
                    jumping = false;
                    animator.SetBool("isJumping", false);
                }
            }
        }
        
        else
        {
            animator.SetBool("isDying", true);
            if (!playerSound.isPlaying)
            {
                EndGame();
            }
        }    
    }

    private void EndGame()
    {
        SceneManager.LoadScene(endScenes);
    }
}

