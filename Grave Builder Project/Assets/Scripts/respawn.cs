using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{

    public GameObject player;

    private GameObject gameScreen;
    private GameObject endScreen;

    private bool quitting = false;

    void Start(){
        gameScreen = gameObject;
        while(!gameScreen.name.Equals("GameScenes")){
            gameScreen = gameScreen.transform.parent.gameObject;
        }

        endScreen = gameObject;
        while(!endScreen.name.Equals("Canvas")){
            endScreen = endScreen.transform.parent.gameObject;
        }
        endScreen = endScreen.transform.Find("End Scenes").gameObject;
 }

    //what to do when the player dies each time
    void OnDestroy(){
        if(!quitting){
            if(livesManager.instance.getLives() == 0){
                Debug.Log("end game was hit");
                EndGame();
            }
            else{
                Debug.Log("newplayer was hit");
                GameObject newPlayer = (GameObject)Instantiate(player, Vector3.zero, Quaternion.Euler(0,0,0), gameScreen.transform);
                newPlayer.SetActive(true);

                //tried this but doesn't work, also tried using Behaviours and MonoBehaviours
                /*
                Component[] components = newPlayer.GetComponents(typeof(Component));
                for(Component component in components){
                    component.enabled = true;
                }
                */
            }
        }
    }

    //activate the end game screen and disable the game screen
    private void EndGame()
    {
        gameScreen.gameObject.SetActive(false);

        endScreen.gameObject.SetActive(true);
    }

    void OnApplicationQuit(){
        quitting = true;
    }
}
