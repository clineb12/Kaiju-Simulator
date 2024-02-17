using UnityEngine;

public class runaway : MonoBehaviour
{
    public float speed = -5f;
    public Transform player;
    private Rigidbody2D rb;
    private bool isEaten = false; // Checks if the enemy is eaten
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isEaten){
            // Calculate the direction from the object to the player
            Vector2 direction = new Vector2(-1,0);
            direction.Normalize();

            // Move the object away from the player
            rb.velocity = direction * speed;
        }
    }
        
       public void BeEaten()
       {
        isEaten = true;
        rb.velocity = Vector2.zero; // Stops the movement
       }     
}

