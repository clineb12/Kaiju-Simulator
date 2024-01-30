using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    int health = 1;

    public Sprite Car;
    public Sprite DestroyedCar;

    string[] vehicleState = {"Not", "Healthy"};

    void Update()
    {
        if (health == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Car;
        }
        else if (health == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DestroyedCar;
        }
    }
}
