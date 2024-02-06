using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEater : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
    public KeyCode destroyKey = KeyCode.X; // Can change if nessisary
    private GameObject eatableItem; // Reference to the specific food item

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            // Set the current eatable item when the collision with "Food" occurs
            eatableItem = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == eatableItem)
        {
            // Resets the eatable item when the player is no longer in contact
            eatableItem = null;
            newSprite = null;
        }
    }



    private void Update()
    {
        if (eatableItem != null && newSprite != null && Input.GetKeyDown(destroyKey))
        {
            // Destroy the item
            // Destroy(eatableItem);
            ChangeSprite();
        }
    }
}
