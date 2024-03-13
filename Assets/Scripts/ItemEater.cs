using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEater : MonoBehaviour
{
    private int health = 1;

    public Sprite Guy;
    public Sprite DeadGuy;

    [SerializeField] private BoxCollider2D boxColl;

    void Update()
    {
        if (health == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Guy;
        }
        else if (health == 0)
        {
            //Change appearance and remove collider
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DeadGuy;
            boxColl.enabled = false;

            // Call BeEaten from runaway.cs script
            runaway runawayComponent = GetComponent<runaway>();
            if (runawayComponent != null)
            {
                runawayComponent.BeEaten();
            }
            // Calling SetEaten from Shooting script
            Shooting shootingComponent = GetComponent<Shooting>();
            if(shootingComponent != null){
                shootingComponent.SetEaten(true);
            }
        }
    }

    public int getHealth()
    {
        return health;
    }

    public void takeDamage(int damage)
    {
        //If it would fall below zero, set to zero. Otherwise, do damage
        if (health - damage < 0)
        {
            health = 0;
        }
        else
        {
            health -= damage;
        }
    }
}
