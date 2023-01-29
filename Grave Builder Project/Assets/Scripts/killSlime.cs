using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killSlime : MonoBehaviour
{

    private void onTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals("Trap")){
            Destroy(collision.gameObject.transform.parent);
        }
    }
}
