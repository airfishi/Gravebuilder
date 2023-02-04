using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeLandingAudio : MonoBehaviour
{

    public AudioClip saw;
    bool landedOnce = false;

    void Start(){
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = saw;
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(!landedOnce){
            landedOnce = true;
            GetComponent<AudioSource>().Play();
        }
    }


}
