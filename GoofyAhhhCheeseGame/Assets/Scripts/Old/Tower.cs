using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] float attackRange = 5f; // Range within which the tower can attack enemies
    [SerializeField] float attackRate = 1f; // Rate of attack in seconds
    [SerializeField] public GameObject bulletPrefab; // Prefab of the bullet to be instantiated
    [SerializeField] Transform firePoint; // Point from where the bullet will be spawned

    [SerializeField] float nextAttackTime = 0f; // Time when the tower can perform the next attack

    //public GameObject xBullet;
    private Bullet zBullet;

    private float bulletSpeed;

    private void Start()
    {
        //zBullet = xBullet.GetComponent<Bullet>();
        //zBullet = zBullet.GetComponent<Bullet>();
        bulletSpeed = zBullet.speed;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate; // Update the next attack time
        }
    }

    void Attack()
    {
        // Find all enemies within attack range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
    
        // Loop through all colliders found
        foreach (Collider2D col in hitColliders)
        {
            // Check if the collider belongs to an enemy
            if (col.CompareTag("Enemy"))
            {
                
                // Calculate direction towards the enemy
                Vector2 direction = col.transform.position - firePoint.position;
            
                // Instantiate bullet at fire point and make it face the enemy
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed; // Set bullet velocity
                break; // Stop attacking after the first enemy found within range
            }
        }
    }


    // Visualize attack range in the Unity Editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
