using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangetoEnd : MonoBehaviour
{
    public GameObject ends;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("EndScreen", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
