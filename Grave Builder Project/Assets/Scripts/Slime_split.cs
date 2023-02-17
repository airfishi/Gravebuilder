using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_split : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject enemy;
    public GameObject babyEnemy;
    private bool quitting = false;
    public Transform gameScreen;
    
    void Start()
    {
     //   enemy = gameObject.transform.parent.gameObject;    
        quitting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag.Equals("Player"))
            Destroy(transform.parent.gameObject);
    }

    private void OnDestroy(){
        if(quitting == false){
            Vector3 right = new Vector3(1500, 0, 0);
            Vector3 up = new Vector3(0, -370, 0);
            //Vector3 up = Vector3.zero;
            Vector3 leftspawnloc = transform.position - right + up;
            Vector3 rightspawnloc = transform.position + right + up;
            
            GameObject leftEnemy;
            if(leftspawnloc.x > -5000)
                leftEnemy = (GameObject)Instantiate(babyEnemy,transform.position - right + up,Quaternion.Euler(0,0,0), transform.parent.transform.parent.gameObject.transform);  
            GameObject rightEnemy;
            if(rightspawnloc.x < 5000)
                rightEnemy = (GameObject)Instantiate(babyEnemy,transform.position + right + up,Quaternion.Euler(0,0,0), transform.parent.transform.parent.gameObject.transform);
        }
    }
    
    private void OnApplicationQuit(){
        quitting = true;
    }
}
