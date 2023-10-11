using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination; // Set this in the Inspector by dragging the destination object

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
         if (Vector2.Distance(collision.transform.position, transform.position) > 0.3f) // Corrected 'Transform' to 'transform'
        {
            collision.transform.position = destination.position;
        }
    }
}
