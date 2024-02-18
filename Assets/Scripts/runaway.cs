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
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            Debug.Log("Distance to player: " + distanceToPlayer); // shows on the bottom on unity how far the distance is from the player to the object

            if (distanceToPlayer <= detectionDistance)
            {
                // Calculate the direction from the object to the player
                Vector2 direction = (transform.position - player.position).normalized;
                // Move the object away from the player
                rb.velocity = direction * speed;
            }
            else
            {
                // If player is not within detection distance, stay idle
                rb.velocity = Vector2.zero;
            }
        }
    }
        
       public void BeEaten()
       {
        isEaten = true;
        rb.velocity = Vector2.zero; // Stops the movement
       }     
       
}

