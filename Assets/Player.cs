using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;  // public so the inspector can access it
    public Rigidbody2D rig;
    public float jumpForce;  // public so inspector can access it
    public SpriteRenderer sr;
    

    void FixedUpdate() // called 50x/sec, best for physics
    {
        // get x-axis input for horiz axis -1 to 1
        float xInput = Input.GetAxis("Horizontal");

        // set the x-axis speed and direction
        rig.velocity = new Vector2(xInput * moveSpeed, rig.velocity.y);

    }

    void Update() // called every frame
    {
        // detect when we jump
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            && IsGrounded())
        {
            // force builds speed, impulse makes speed instantenous
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (rig.velocity.x > 0.01f) // player is moving right
        {
            sr.flipX = false;
        }
       
    }

    bool IsGrounded()
    {
        // Raycast will act as radar below player, can detect if in air or on ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.1f, 0),
            Vector2.down, 0.2f);
        return hit.collider != null;
    }

}