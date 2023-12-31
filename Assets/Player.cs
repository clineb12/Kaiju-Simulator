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

    private BoxCollider2D coll; // 

    [SerializeField] private LayerMask jumpableGround; // so you can pass a layer into the field (IT SHOULD BE foreground)

    // I made this so its easier to call instead of typing GetComponent you know the drill aka storing a reference to a component.
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }
       
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


 
    private bool IsGrounded()
    {
        // this is the code that prevents infinite jumping
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); //  We create a box around our player the same shape as the box collider if that box overlapps with the boxcollider then it will prevent the infinite jumping 
    }

}