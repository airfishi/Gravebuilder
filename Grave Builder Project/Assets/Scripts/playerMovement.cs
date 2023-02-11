using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Rigidbody2D playerBody;
    public AudioSource playerSound;

    public AudioClip walking;
    public AudioClip jumpStart;
    public AudioClip kill;
    public AudioClip land;
    public AudioClip die;

    private Vector3 speed;
    private Vector3 jump;
    private KeyCode jumpKey;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public bool jumping;
    public bool grounded;
    public bool movingRight;
    public bool movingLeft;

    public bool idle;

    private int jumpTime;
    private int maxJumpTime;
    private int score;
    private bool dead;



    void Start()
    {
        jump = new Vector3(0, 3000, 0);
        speed = new Vector3(1500, 0, 0);
        jumping = false;
        grounded = true;
        jumpTime = 0;
        maxJumpTime = 1000;
        movingLeft = false;
        movingRight = false;
        score = 0;
        dead = false;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public int getScore()
    {
        return score;
    }
    void OnCollisionEnter2D(Collision2D other)            //gounded is uesed in jumping, see bottom section of Update()
    {
        if (!dead)
        {
            if (other.gameObject.tag == "floor")
            {
                grounded = true;

                playerSound.Stop();
                playerSound.loop = false;
                playerSound.clip = land;
                playerSound.Play();
            }

            if (other.gameObject.tag == "LargeSlime")
            {
                if (player.transform.position.y > other.gameObject.transform.position.y - 30)
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
                if (player.transform.position.y > other.gameObject.transform.position.y + 55)
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
                animator.SetBool("isRunning", true);
                spriteRenderer.flipX = true;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                movingRight = true;
                animator.SetBool("isRunning", true);
                spriteRenderer.flipX = false;
            }
            if (movingLeft)
            {
                player.transform.localPosition -= speed * Time.deltaTime;                               //adjusts player's position in game--does not check for collisions. Collision check might be needed in later development to smooth gameplay.
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    movingLeft = false;
                    animator.SetBool("isRunning", false);
                }
            }
            if (movingRight)
            {
                player.transform.localPosition += speed * Time.deltaTime;
                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    movingRight = false;
                    animator.SetBool("isRunning", false);
                }
            }
            if (!movingLeft && !movingRight)
            {
                animator.SetBool("isRunning", false);
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



            if (!jumping && grounded)                                                  //Player Movement (Jumping)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumping = true;
                    jumpTime = 10;
                    jumpKey = KeyCode.Space;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    jumping = true;
                    jumpTime = 10;
                    jumpKey = KeyCode.UpArrow;
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    jumping = true;
                    jumpTime = 10;
                    jumpKey = KeyCode.W;
                }
            }
            else
            {
                if (jumping)
                {
                    playerBody.AddForce(jump/(jumpTime/10), ForceMode2D.Force);
                    jumpTime++;
                }
                if ((Input.GetKeyUp(KeyCode.Space) && jumpKey == KeyCode.Space) || (Input.GetKeyUp(KeyCode.UpArrow) && jumpKey == KeyCode.UpArrow) || (Input.GetKeyUp(KeyCode.W) && jumpKey == KeyCode.W) || jumpTime >= maxJumpTime)
                {
                    jumping = false;
                }
            }

            idle = (grounded && !movingLeft && !movingRight);
        }
        else
        {
            if (!playerSound.isPlaying)
            {
                Destroy(player);
            }
        }
    }
}
