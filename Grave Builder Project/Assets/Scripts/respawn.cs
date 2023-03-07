using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class respawn : MonoBehaviour
{

    public GameObject player;

    private GameObject gameScreen;
    private GameObject endScreen;

    private bool quitting = false;

    private int xspawn = 0;
    private int yspawn = 0;

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
            if(livesManager.instance.getLives() <= 0){
                Debug.Log("end game was hit");
                EndGame();
            }
            else{
                Debug.Log("newplayer was hit");
                GameObject newPlayer = (GameObject)Instantiate(player, new Vector3(xspawn,yspawn,0), Quaternion.Euler(0,0,0), gameScreen.transform);
                newPlayer.SetActive(true);
                //Destroy(gameObject);
            }
        }
    }

    public void setSpawn(int x, int y)
    {
        xspawn = x;
        yspawn = y;
    }

    public int getYSpawn()
    {
        return yspawn;
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
