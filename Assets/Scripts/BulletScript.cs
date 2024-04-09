using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public int damage = 5; // sets damage of bullet

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // deletes the bullet after x amount of seconds
        if(timer > 2)
        {
            Destroy(gameObject);
        }
    }

    // if the bullet collides with the player it destroys the object
     void OnTriggerEnter2D(Collider2D other)
     {
        if(other.gameObject.CompareTag("Player"))
        {
           other.gameObject.GetComponent<Player>().PlayerDamage(damage); // hurts the player
           Destroy(gameObject);
        }
     }
}
