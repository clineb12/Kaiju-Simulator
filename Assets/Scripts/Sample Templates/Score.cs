/*

this is our Score script! I'll add details below

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class /* insert name of score here */ : MonoBehaviour
{
    public int value = /* insert value of score here */;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().AddScore(value);
            Destroy(gameObject);
        }
    }

}

/*

We might want to have multiple of these scripts under different names.
Here is an example of how this might look for a building score!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int value = 10,000;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().AddScore(value);
            Destroy(gameObject);
        }
    }

}

*/
