using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class blockSquashSlime : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MediumSlime"))
        {

            if (collision.transform.position.y+200 < GetComponent<Transform>().position.y)
            {
                Debug.Log("Destroyed!");
                Destroy(collision.gameObject);
            }
            else
            {

            }
        }
        else if (collision.gameObject.tag.Equals("LargeSlime"))
        {

            if (collision.transform.position.y -100 < GetComponent<Transform>().position.y)
            {
                Debug.Log("Destroyed!");
                Destroy(collision.gameObject);
            }
            else
            {

            }
        }
    }
}
