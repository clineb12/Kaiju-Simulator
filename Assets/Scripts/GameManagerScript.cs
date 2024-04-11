using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static bool isGameOver; //accessable by other objects/scripts; used in those scripts to detect if game is paused
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // calls gameover UI
    public void gameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.Instance.StopMusic(); 
        isGameOver = true;
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        Time.timeScale = 1f; // make sure to set this to 1 otherwise if you try to start the game it will freeze
        SceneManager.LoadScene("Main Menu");
    }
    
}
