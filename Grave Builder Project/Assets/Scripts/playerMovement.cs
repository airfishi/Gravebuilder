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
    public bool slamming;
    private bool jumpFall;
    private float jumpTime;
    private float maxJumpTime;

    //extras
    public bool dead;
    private bool gameStart;
    private bool invulnerable;
    private float invulnerableTime;
    public bool isTutorial;

    private static bool isFirst = true;

    public GameObject mainCanvas;
    public GameObject other;


    void Start()
    {
        GetComponent<SpriteRenderer>().color = new UnityEngine.Color(255, 255, 255, 1);
        jump = new Vector3(0, 3600, 0);
        speed = 1900;
        jumping = false;
        grounded = true;
        jumpTime = 0;
        maxJumpTime = 0.45f;
        movingLeft = false;
        movingRight = false;
        dead = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameStart = true;
        invulnerableTime = 0;
        invulnerable = false;
        if (!isFirst)
        {
            beginInvulnerable();
        }

    }

    void OnCollisionEnter2D(Collision2D other)            //grounded is used in jumping, see bottom section of Update()
    {
        if (!dead)
        {
            if (other.gameObject.tag == "floor")
            {
                grounded = true;
                jumpFall = false;
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
                if ((player.transform.position.y > other.gameObject.transform.position.y - 70) || invulnerable)
                {
                    //Destroy(other.transform.gameObject.transform.parent.gameObject);
                    playerSound.Stop();
                    playerSound.clip = kill;
                    playerSound.Play();
                    if (jumpFall)
                        Jump(95, 3 * maxJumpTime / 4);
                    else
                    {
                        Jump(45, 3 * maxJumpTime / 4);
                    }
                    scoreManager.instance.AddScore();
                }
                else //part where the player dies
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
                if ((player.transform.position.y > other.gameObject.transform.position.y + 100) || invulnerable)
                {
                    //Destroy(other.transform.gameObject.transform.parent.gameObject);
                    playerSound.Stop();
                    playerSound.clip = kill;
                    playerSound.loop = false;
                    playerSound.Play();
                    player.transform.position += new Vector3(0, 200, 0);
                    if (jumpFall)
                        Jump(75, 3 * maxJumpTime / 4);
                    else
                    {
                        Jump(35, 3 * maxJumpTime / 4);
                    }
                    scoreManager.instance.AddScore();
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
        Debug.Log(GetComponent<SpriteRenderer>().color);
        if (invulnerable)
        {
            invulnerableTime+= Time.deltaTime;
            if (invulnerableTime > 8)
            {
                GetComponent<SpriteRenderer>().color = new UnityEngine.Color(255, 255, 255, 1);
                invulnerable = false;
                invulnerableTime = 0;
            }
            else if (invulnerableTime > 6)
            {
                GetComponent<SpriteRenderer>().color = new UnityEngine.Color(0, 150, 255, (0.25f + 0.75f * (1 / (8 - invulnerableTime))));
            }
            else if (invulnerableTime > 4)
            {
                GetComponent<SpriteRenderer>().color = new UnityEngine.Color(0, 0, 255, (0.25f + 0.75f * (1 / (8 - invulnerableTime))));
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new UnityEngine.Color(0, 0, 0, (0.25f + 0.75f * (1 / (8 - invulnerableTime))));
            }
        }
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
            }
            if (movingRight)
            {
                animator.SetBool("isRunning", true);
                spriteRenderer.flipX = false;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, player.GetComponent<Rigidbody2D>().velocity.y);

                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    movingRight = false;
                }
            }
            if (movingLeft && movingRight)
            {
                animator.SetBool("isRunning", false);
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.GetComponent<Rigidbody2D>().velocity.y);
            }
            if (!movingLeft && !movingRight)
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



            //Jumping
            if(!jumping && grounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                    jumpKey = KeyCode.Space;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Jump();
                    jumpKey = KeyCode.UpArrow;
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    Jump();
                    jumpKey = KeyCode.W;
                }
            }
            else
            {
                if (jumping)
                {
                    jumpTime+=Time.deltaTime;
                    animator.SetBool("isJumping", true);
                }
                if (jumping && ((Input.GetKeyUp(KeyCode.Space) && jumpKey == KeyCode.Space) || (Input.GetKeyUp(KeyCode.UpArrow) && jumpKey == KeyCode.UpArrow) || (Input.GetKeyUp(KeyCode.W) && jumpKey == KeyCode.W) || jumpTime >= maxJumpTime))
                {
                    //playerBody.AddForce(jump * -1 * (int)(120 - (jumpTime / 2)), ForceMode2D.Force);
                    playerBody.AddForce(jump * -35, ForceMode2D.Force);
                    //Debug.Log(jumpKey + " " + Input.GetKeyUp(KeyCode.W)+ " " + jumpTime);
                    jumping = false;
                    jumpFall = true;
                    animator.SetBool("isJumping", false);
                    //Debug.Log("");
                }
            }


            //Slam Down
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                slamming = true;
            }
            if (slamming && (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)))
            {
                slamming = false;
            }
            if (slamming)
            {
                playerBody.AddForce(-3 * jump,ForceMode2D.Force);
            }
        }
        
        //End of Game

        else
        {
            animator.SetBool("isDying", true);
            if (!playerSound.isPlaying)
            {
                isFirst = false;
                if (isTutorial)
                {
                    tutorialLivesManager.instance.loseLife();
                }
                else
                {
                    livesManager.instance.loseLife();
                }
                Destroy(gameObject);
            }
        }    
    }

    private void Jump()
    {
        jumping = true;
        jumpTime = 0;
        playerBody.AddForce(jump * 100, ForceMode2D.Force);
        //Debug.Log("JUMPING!!!");
    }

    private void Jump(int strength, float durationPenalty)
    {
        jumping = true;
        jumpTime = durationPenalty;
        playerBody.AddForce(jump * strength, ForceMode2D.Force);
    }

    private void EndGame()
    {
        mainCanvas.gameObject.SetActive(false);

        other.gameObject.SetActive(true);
    }

    public void beginInvulnerable()
    {
        invulnerableTime = 0;
        invulnerable = true;
        GetComponent<SpriteRenderer>().color = new UnityEngine.Color(0,0,0, 0.5f);
    }

}

