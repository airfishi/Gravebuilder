using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{

    private GameObject health;
    private Canvas temp;

    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D collision){
        health = gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<GameObject>();
        Debug.Log(health.name);
    }
}
