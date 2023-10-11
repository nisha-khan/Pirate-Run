using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 1.5f;
    float startingX;
    int direction = 1;
    bool hasChangedDirection = false;

    void Start()
    {
        startingX = transform.position.x;
    }

    void Update()
    {
        // Move the enemy.
        transform.Translate(Vector2.left * speed * Time.deltaTime * direction);

        // Check if the enemy has reached its range and change direction.
        if (!hasChangedDirection && (transform.position.x < startingX || transform.position.x > startingX + range))
        {
            direction *= -1;
            Flip();
            hasChangedDirection = true;
        }
        else if (hasChangedDirection && transform.position.x > startingX - 0.1f && transform.position.x < startingX + 0.1f)
        {
            // Reset the hasChangedDirection flag when the enemy returns to its starting position.
            hasChangedDirection = false;
        }
    }

    void Flip()
    {
        // Flip the entire enemy GameObject.
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
