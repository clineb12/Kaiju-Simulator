using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCamScroll : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.025f, 0, 0);
    }
}
