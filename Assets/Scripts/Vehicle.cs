using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private int health = 1;

    public Sprite Car;
    public Sprite DestroyedCar;

    [SerializeField] private BoxCollider2D boxColl;

    void Update()
    {
        if (health == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Car;
        }
        else if (health == 0)
        {
            //Change appearance and remove collider
            
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DestroyedCar;
            boxColl.enabled = false;
            
        }
    }

    public int getHealth() {
        return health;
    }

    public void takeDamage(int damage) {
        //If it would fall below zero, set to zero. Otherwise, do damage
        if (health - damage < 0) {
            health = 0;
            
        } else {
            health -= damage;
        }
        ScoreManager.instance.addPoint(30000);
    }
}
