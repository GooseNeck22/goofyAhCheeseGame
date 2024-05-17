using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGTower : MonoBehaviour
{
    public GameObject rpgProjectilePrefab; // The RPG projectile prefab
    public Transform firePoint; // The point from where the RPG is fired
    public float range = 10f; // Range of the tower
    public float fireRate = 1f; // Rate of fire (shots per second)

    private float fireCountdown = 0f;
    private Transform target;

    void Update()
    {
        // Find the nearest target
        UpdateTarget();

        if (target == null)
            return;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject rpgProjectileGO = Instantiate(rpgProjectilePrefab, firePoint.position, firePoint.rotation);
        RPGProjectile rpgProjectile = rpgProjectileGO.GetComponent<RPGProjectile>();

        if (rpgProjectile != null)
        {
            rpgProjectile.Seek(target);
        }
    }
}
