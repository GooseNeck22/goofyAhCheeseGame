using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]public Transform[] movePoints; // Array to store movement points
    public float moveSpeed = 5f; // Speed of movement
    private int currentPointIndex = 0; // Index of the current movement point

    void Update()
    {
        // Check if there are movement points
        if (movePoints.Length > 0)
        {
            // Move towards the current movement point
            transform.position = Vector2.MoveTowards(transform.position, movePoints[currentPointIndex].position, moveSpeed * Time.deltaTime);

            // Check if the enemy has reached the current movement point
            if (Vector2.Distance(transform.position, movePoints[currentPointIndex].position) < 0.1f)
            {
                // Move to the next movement point
                currentPointIndex++;

                // Check if the enemy has reached the last movement point
                if (currentPointIndex >= movePoints.Length)
                {
                    // Stop moving
                    enabled = false;
                }
            }
        }
    }
}
