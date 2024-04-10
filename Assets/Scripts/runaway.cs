using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runaway : MonoBehaviour
{
    public float speed = 1f;
    public Transform player;
    private Rigidbody2D rb;
    private bool isEaten = false; // Checks if the enemy is eaten
    public float detectionDistance = 3f; // Maximum distance to detect the player
    private bool detectedPlayer = false; // Tracks if player is detected

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Start by moving to the left
        rb.velocity = Vector2.left * speed;
    }

    private void FixedUpdate()
    {
        if (!isEaten && !detectedPlayer) // if enemy is not eaten and player is not detected
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position); // calculates distance from the player

            if (distanceToPlayer < detectionDistance) // if player is within the detection distance
            {
                detectedPlayer = true;
                // Change direction to run to the right
                rb.velocity = Vector2.right * speed;
            }
        }
    }

    public void BeEaten()
    {
        isEaten = true;
        // rb.velocity = Vector2.zero; // Stops the movement
        rb.velocity = Vector2.left * speed;
    }
}