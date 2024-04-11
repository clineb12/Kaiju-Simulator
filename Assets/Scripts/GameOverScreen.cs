using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    public void Setup()
    {
        // Check if ScoreManager instance is found
        if(scoreManager != null){
            // Set the points text to display the score
            pointsText.text = "Score: " + scoreManager.scoreText.ToString();
        }
        else
        {
            pointsText.text = "Score: N/A";
        }
        // Make sure the game over screen is active
        gameObject.SetActive(true);
    }
}
