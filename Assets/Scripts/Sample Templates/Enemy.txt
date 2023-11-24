/*

this is our enemy script!
we might need to adjust this to not just kill our player, but rather
do damage to a set health.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 targetPosition; // set this inside inspector
    private Vector3 startPosition; // set this inside script

    public float moveSpeed;
    private bool movingToTargetPos;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; // current position
        movingToTargetPos = true; // start by moving to target position
    }

    // Update is called once per frame
    void Update()
    {
        if (movingToTargetPos == true)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                movingToTargetPos = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
               startPosition, moveSpeed * Time.deltaTime);
            if (transform.position == startPosition)
            {
                movingToTargetPos = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if bomb collides with Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // this calls the Player's GameOver() function from
            // outside the Player class.
            collision.gameObject.GetComponent<Player>().GameOver();
        }
    }
}
