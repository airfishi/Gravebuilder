using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onPlayerDeath : MonoBehaviour
{

    public GameObject endScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LargeSlime"))
        {
            Die();
        }
        if (other.gameObject.CompareTag("MediumSlime"))
        {
            Die();
        }
    }

    private void Die()
    {
        endScreen.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
