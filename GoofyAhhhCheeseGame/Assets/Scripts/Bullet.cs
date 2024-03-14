using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f; // Speed at which the bullet moves
    [SerializeField] Transform target; // Reference to the enemy target

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Destroy the bullet if target is null (e.g., enemy destroyed)
            return;
        }

        // Move bullet towards the target
        Vector2 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // If bullet has reached the target, damage the enemy and destroy the bullet
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // Deal damage to the enemy (you can customize this based on your game mechanics)
        Destroy(gameObject); // Destroy the bullet after hitting the target
    }
}
