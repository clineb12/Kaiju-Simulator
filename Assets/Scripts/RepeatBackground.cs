using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float moveLimit;
    [SerializeField] private float resetPointOffset;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < startPos.x - resetPointOffset)
        {
            transform.position = startPos;
        }
    }
}
