using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RetryGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
