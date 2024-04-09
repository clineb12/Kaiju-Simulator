using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runaway : MonoBehaviour
{
    public float speed = 1f;
    public Transform player;
    private Rigidbody2D rb;
    private bool isEaten = false; // Checks if the enemy is eaten
    public float detectionDistance = 10f; // Maximum distance to detect the player


    

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
            
            // else
            // {
            //     // If player is not within detection distance, stay idle
            //     rb.velocity = Vector2.zero;
            // }
        }
    }
        
       public void BeEaten()
       {
        isEaten = true;
        rb.velocity = Vector2.zero; // Stops the movement
       }     
       
}

