using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeLandingAudio : MonoBehaviour
{

    public AudioClip land;
    public AudioClip walk;
    private bool landedOnce = false;

    void Start(){
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().loop = true;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!landedOnce){
            landedOnce = true;
            if(transform.gameObject.tag == "LargeSlime")
                StartCoroutine(playSlimeSound());
            else{
                GetComponent<AudioSource>().clip = walk;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    IEnumerator playSlimeSound(){
        GetComponent<AudioSource>().clip = land;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        GetComponent<AudioSource>().clip = walk;
        GetComponent<AudioSource>().Play();
    }

}
/*
//https://answers.unity.com/questions/904981/how-to-play-an-audio-file-after-another-finishes.html
         public AudioClip engineStartClip;
         public AudioClip engineLoopClip;
         void Start()
         {
             GetComponent<AudioSource> ().loop = true;
             StartCoroutine(playEngineSound());
         }
 
         IEnumerator playEngineSound()
         {
             audio.clip = engineStartClip;
             audio.Play();
             yield return new WaitForSeconds(audio.clip.length);
             audio.clip = engineLoopClip;
             audio.Play();
         }
*/
