using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreBonus : MonoBehaviour
{
    private GameObject player;
    private GameObject gameScreen;
    // Start is called before the first frame update
    private void Start()
    {
        gameScreen = gameObject.transform.parent.gameObject;
        if(gameScreen.transform.Find("Player1"))
            player = gameScreen.transform.Find("Player1").gameObject;
        if(gameScreen.transform.Find("Player"))
            player = gameScreen.transform.Find("Player").gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            scoreManager.instance.AddScore(20);
        }
        Destroy(transform.gameObject);
    }
}
