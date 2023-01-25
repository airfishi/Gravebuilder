using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small_Slime_Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
        Destroy(transform.parent.transform.parent.gameObject);
    }
}
