using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float moveLimit;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        moveLimit = startPos.x - 20f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < moveLimit)
        {
            transform.position = startPos;
        }
    }
}
