using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mediumSlimeDeat : MonoBehaviour
{
    GameObject block;
    void OnDestroy(){
        block = (GameObject)Instantiate(block, transform.position, Quaternion.Euler(0,0,0));
    }

}
