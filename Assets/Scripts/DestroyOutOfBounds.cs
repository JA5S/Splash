using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//destroy out of bounds object
public class DestroyOutOfBounds : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        DestroyAtScreenBottom();
    }

    //destroy object at bottom of screen
    void DestroyAtScreenBottom()
    {
        if (transform.position.y <= -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
