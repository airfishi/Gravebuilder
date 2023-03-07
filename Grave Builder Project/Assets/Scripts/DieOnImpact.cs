// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DieOnImpact : MonoBehaviour
// {
//     private GameObject player;
//     private GameObject gameScreen;
//     // Start is called before the first frame update
//     private void Start()
//     {
//         gameScreen = gameObject.transform.parent.gameObject;
//         player = gameScreen.transform.Find("Player1").gameObject;
//     }
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         Debug.Log(collision.gameObject.tag);
//         if(collision.gameObject.tag == "Player")
//         {
//             GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<playerMovement>().beginInvulnerable();
//             Destroy(transform.gameObject);
//         }
//         else
//         {
//             Destroy(transform.gameObject);
//         }
//     }
// }
