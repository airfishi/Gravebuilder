using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI text;
    GameObject cam;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level: " + cam.GetComponent<MoveCamera>().getLevel();
    }
}
