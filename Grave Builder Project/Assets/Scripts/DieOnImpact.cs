using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnImpact : MonoBehaviour
{
    private GameObject player;
    private GameObject gameScreen;
    // Start is called before the first frame update
    private void Start()
    {
        gameScreen = gameObject.transform.parent.gameObject;
        player = gameScreen.transform.Find("Player").gameObject;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<playerMovement>().beginInvulnerable();
            Destroy(transform.gameObject);
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }
}
