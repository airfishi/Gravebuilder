using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onPlayerDeath : MonoBehaviour
{

    public GameObject endScreen;

    private void OnTriggerEnter2D(Collider2D other)
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
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
