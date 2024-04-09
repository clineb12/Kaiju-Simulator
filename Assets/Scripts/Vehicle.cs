using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private int health = 1;

    public Sprite Car;
    public Sprite DestroyedCar;

    public int damage = 5;
    [SerializeField] private BoxCollider2D boxColl;
    private Vector2 startPos;

    void Start() {
        startPos = transform.position;
    }


    void Update()
    {
        if (health == 1)
        {
            boxColl.enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Car;
        }
        else if (health == 0)
        {
            //Change appearance and remove collider
            
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DestroyedCar;
            boxColl.enabled = false;
            
        }
    }

    void LateUpdate() {
        // Keep vehicle position at constant y
        Vector2 playerPosition = transform.position;
        playerPosition.y = startPos.y;
        transform.position = playerPosition;
    }

    public int getHealth() {
        return health;
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player when colliding with the vehicle
            collision.gameObject.GetComponent<Player>().PlayerDamage(damage);
        }
    }

    public void takeDamage(int damage) {
        //If it would fall below zero, set to zero. Otherwise, do damage
        if (health - damage < 0) {
            health = 0;
            
        } else {
            health -= damage;
            ScoreManager.instance.addPoint(30000);
        }
        
    }
}
