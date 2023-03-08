using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject endScene;
    public AudioClip gameAudio;
    public AudioClip endAudio;

    private bool game;

    private void Start()
    {
        //endScene = GameObject.FindGameObjectWithTag("EndScenes");
        game = true;
        GetComponent<AudioSource>().clip = gameAudio;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        //if(endScene == null)
        //endScene = GameObject.FindGameObjectWithTag("EndScenes");
        //Debug.Log(GetComponent<AudioSource>().clip + " " + GetComponent<AudioSource>().isPlaying);
        if (!game && !endScene.activeSelf)
        {
            GetComponent<AudioSource>().Stop();
            game = true;
            GetComponent<AudioSource>().clip = gameAudio;
            GetComponent<AudioSource>().Play();

        }
        else if(game && endScene.activeSelf)
        {
            GetComponent<AudioSource>().Stop();
            game = false;
            GetComponent<AudioSource>().clip = endAudio;
            GetComponent<AudioSource>().Play();
        }
    }
}
