using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runawayCar : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    private bool isEaten = false; // Checks if the enemy is eaten
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isEaten)
        {
            // Move the enemy constantly left
            rb.velocity = Vector2.left * speed;
        }
        else
        {
            // Stop the enemy if it's eaten
            rb.velocity = Vector2.zero;
        }
    }
        
    public void BeEaten()
    {
        isEaten = true;
        rb.velocity = Vector2.zero; // Stops the movement
    }     
       
}