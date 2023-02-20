using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEditor;
using System.Numerics;

public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    private GameObject pref;



    public string GameScreen;
    public string Player;

    void Start()
    {
        // Load target scene
        SceneManager.LoadScene(GameScreen, LoadSceneMode.Additive);

        // Load prefab from target scene
        pref = Resources.Load<GameObject>(Player);

        // Instantiate the prefab in current scene
        pref.GetComponent<playerMovement>().getScore();
        text.text = pref.ToString();
    }
    void Update()
    {

    }
}
