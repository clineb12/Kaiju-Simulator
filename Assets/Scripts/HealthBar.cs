using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // stores the slider

public class HealthBar : MonoBehaviour
{
    public GameManagerScript gameManager;
    public Slider slider;

    private bool isDead;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
 public void SetHealth(int health)
 {
    slider.value = health;
    //check if health is zero or less
    if(health <= 0 && !isDead) // if health is zero and the player is dead display game over
    {
        isDead = true;
        gameObject.SetActive(false);
        gameManager.gameOver();
    }
 }
}
