using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeLandingAudio : MonoBehaviour
{

    public AudioClip land;
    public AudioClip walk;
    bool landedOnce = false;

    void Start(){
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = land;
    }

    void Update(){

    }


    //https://answers.unity.com/questions/1158528/wait-until-audio-is-finished-before-set-active-is.html
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!landedOnce)
        {
            landedOnce = true;
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().clip = walk;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
    }


}
