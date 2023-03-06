using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialSlimeSplit : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject enemy;
    public GameObject babyEnemy;
    public Transform gameScreen;
    private bool quitting = false;
    private Animator animator;

    //tutorial stuff
    public GameObject prompt2;
    private GameObject newparent;
    private bool ready = false;

    void Start()
    {
     //   enemy = gameObject.transform.parent.gameObject;    
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag.Equals("Player")){
            Debug.Log("In collision");
            Time.timeScale = 0;
            StartCoroutine("secondPrompt");
        }
    }

    IEnumerable secondPrompt(){
        //Time.timeScale = 0;
        Debug.Log("Hit 1");
        newparent = gameObject;
        while(!newparent.name.Equals("tutorialEverything"))
            newparent = newparent.transform.parent.gameObject;
        Debug.Log(newparent.name + ": Hit 2");
        newparent = newparent.transform.Find("Canvas").transform.Find("GameScenes").gameObject;
        Debug.Log(newparent.name + "Should be GameScenes");
        Vector3 adjustment = new Vector3(-1600, 1200, 0);
        prompt2 = (GameObject)Instantiate(prompt2, newparent.transform.position + adjustment, Quaternion.Euler(0,0,0), newparent.transform);
        while(!Input.anyKeyDown)
            yield return null;
        yield return new WaitForSeconds(2);
        Time.timeScale = 1;
        ready = true;
    }

    private void Update(){
        if(ready){
            Destroy(gameObject);
        }
    }


    private void OnDestroy(){
        if(quitting == false){
            Vector3 right = new Vector3(1500, 0, 0);
            Vector3 up = new Vector3(0, -150, 0);
            //Vector3 up = Vector3.zero;
            Vector3 leftspawnloc = transform.position - right + up;
            Vector3 rightspawnloc = transform.position + right + up;
            
            GameObject leftEnemy;
            if(leftspawnloc.x > -3600)
                leftEnemy = (GameObject)Instantiate(babyEnemy,leftspawnloc,Quaternion.Euler(0,0,0), transform.parent.transform.parent.gameObject.transform);  
            GameObject rightEnemy;
            if(rightspawnloc.x < 2750)
                rightEnemy = (GameObject)Instantiate(babyEnemy,rightspawnloc,Quaternion.Euler(0,0,0), transform.parent.transform.parent.gameObject.transform);           
            
        }
    }

    private void OnApplicationQuit(){
        quitting = true;
    }
}
