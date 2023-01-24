using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject babyEnemy;
    private bool quitting = false;
    
    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;    
        quitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
        Destroy(transform.parent.transform.parent.gameObject);
    }

    private void OnDestroy(){
        if(quitting == false){
            Vector3 right = new Vector3(250, 0, 0);
            GameObject leftEnemy = (GameObject)Instantiate(babyEnemy,transform.parent.position - right,Quaternion.Euler(0,0,0));   
            GameObject rightEnemy = (GameObject)Instantiate(babyEnemy,transform.parent.position + right,Quaternion.Euler(0,0,0));
        }
    }
    
    private void OnApplicationQuit(){
        quitting = true;
    }
}
