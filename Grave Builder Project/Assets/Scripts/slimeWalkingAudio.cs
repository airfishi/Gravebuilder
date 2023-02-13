using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeWalkingAudio : MonoBehaviour
{

    public AudioClip walk;
    private bool landedOnce = false;

    void Start(){
        GetComponent<AudioSource>().playOnAwake = false;
    }

    void Update(){
        if(landedOnce)
            GetComponent<AudioSource>().Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!landedOnce)
        {
            landedOnce = true;
            GetComponent<AudioSource>().clip = walk;
            GetComponent<AudioSource>().loop = true;
        }
    }


}
