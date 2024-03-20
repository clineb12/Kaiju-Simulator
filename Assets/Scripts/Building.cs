using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private int health = 3;

    public Sprite FullHealthBuilding;
    public Sprite SlightDamage;
    public Sprite HalfDamage;
    public Sprite DestroyedBuilding;

    [SerializeField] private BoxCollider2D boxColl;

    void Update()
    {
        if (health == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = FullHealthBuilding;
        }
        else if (health == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = SlightDamage;
        }
       else if (health == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = HalfDamage;
        }
        else if (health == 0)
        {
            //Change appearance and remove collider
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DestroyedBuilding;
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
    }
}
