using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class blockSquashSlime : MonoBehaviour
{
    Transform block;

    private void Start()
    {
        block = GetComponent<Transform>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MediumSlime"))
        {

            if (collision.transform.position.y+200 < block.position.y && (collision.transform.position.x < block.position.x + 300 && collision.transform.position.x > block.position.x - 300))
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

            if (collision.transform.position.y -100 < block.position.y && (collision.transform.position.x < block.position.x+300 && collision.transform.position.x > block.position.x-300))
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
