using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreScript : MonoBehaviour
{
    
    public TextMeshProUGUI text;
    private playerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.getScore().ToString();
    }
}
