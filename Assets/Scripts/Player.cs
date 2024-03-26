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
    private float normalSpeed;
    private float speedDiff;
    public KeyCode destroyButton = KeyCode.Z; // will change if necessary
    [SerializeField] private GameObject destroyableItem; // for destroyables
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround; // so you can pass a layer into the field (IT SHOULD BE foreground)
    [SerializeField] private MoveLeft moveLeft; // for controlling scroll speed

    // I made this so its easier to call instead of typing GetComponent you know the drill aka storing a reference to a component.
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        PauseMenu.isPaused = false;
        normalSpeed = moveLeft.speed;
        speedDiff = 3f;
    }

    void FixedUpdate() // called 50x/sec, best for physics
    {
        // get x-axis input for horiz axis -1 to 1
        float xInput = Input.GetAxis("Horizontal");

        // set the x-axis speed and direction
        rig.velocity = new Vector2(xInput * moveSpeed, rig.velocity.y);

        // change scroll speed depending on movement
        if (xInput < 0) {
            moveLeft.speed = normalSpeed - speedDiff;
        } else if (xInput > 0) {
            moveLeft.speed = normalSpeed + speedDiff;
        } else {
            moveLeft.speed = normalSpeed;
        }

    }

    void Update() // called every frame
    {
        if (!PauseMenu.isPaused) //checks if game is paused (via PauseMenu script)
        {
            // detect when we jump
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
                && IsGrounded())
            {
                // force builds speed, impulse makes speed instantenous
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                AudioManager.Instance.PlaySFX("Jump");
            }

            if (rig.velocity.x > 0.01f) // player is moving right
            {
                sr.flipX = false;
            }
            if (destroyableItem != null && Input.GetKeyDown(destroyButton))
            {
                // Destroy(destroyableItem);
                Damage(destroyableItem, 1); //This does a bite, the player is against the object
            }

        }
    }

    private void Damage(GameObject destroyableItem, int damage)
    {
        //Get script associated with health of vehicle
        //(consider making it a global script that's ONLY responsible for health)
        if (destroyableItem.CompareTag("Vehicle"))
        {
            Vehicle objScript = destroyableItem.GetComponent<Vehicle>();
            objScript.takeDamage(damage);
            AudioManager.Instance.PlaySFX("Destroy");
        }
        else if (destroyableItem.CompareTag("Food"))
        { // for eatable script
            AudioManager.Instance.PlaySFX("Eat");
            ItemEater objScript = destroyableItem.GetComponent<ItemEater>();
            objScript.takeDamage(damage);
        }
         else if (destroyableItem.CompareTag("Building")){
            Building objScript =  destroyableItem.GetComponent<Building>();
            objScript.takeDamage(damage);
            AudioManager.Instance.PlaySFX("Destroy");
         // for building script
         }

        //Call the objects takeDamage function (Modify this for objects to take later)
        // objScript.takeDamage(damage);
    }

    private bool IsGrounded()
    {
        // this is the code that prevents infinite jumping
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround); // We create a box around our player the same shape as the BoxCollider
                                                                                                                // if that box overlaps with the Boxcollider then it will prevent the infinite jumping 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            // Set the current destroyable item when collision occurs
            destroyableItem = collision.gameObject;
        }
         if (collision.gameObject.CompareTag("Building"))
        {
            // Set the current destroyable item when collision occurs
            destroyableItem = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("Food"))
        {
            destroyableItem = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == destroyableItem)
        {
            //resets the item when the car isn't destroyable
            destroyableItem = null;
        }
    }

}
