using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health = 100;
    public GameObject healthBarPrefab; // Prefab of the health bar UI
    private EnemyHealthBar healthBar;

    void Start()
    {
        // Instantiate the health bar above the enemy
        GameObject healthBarGO = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
        healthBarGO.transform.SetParent(GameObject.Find("Canvas").transform, false); // Ensure it's part of the UI canvas
        healthBar = healthBarGO.GetComponent<EnemyHealthBar>();

        healthBar.SetMaxHealth(health);
    }
    
    public void TakeDamage(int damage)
    {
        health =- damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
