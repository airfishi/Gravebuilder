using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    public TextMeshProUGUI text;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
           Destroy(transform.gameObject);
        }
    }

    public void setText(string newText)
    {
        text.text = newText;
    }
}
