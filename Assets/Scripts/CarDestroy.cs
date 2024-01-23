using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroy : MonoBehaviour
{
    public Sprite Car;
    public KeyCode destroyKey = KeyCode.Z; //will change if necessary
    private GameObject destroyableItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            // Set the current destroyable item when collision occurs
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

    private void Update()
    {
        if (destroyableItem != null && Input.GetKeyDown(destroyKey))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Car;
        }
    }
}
