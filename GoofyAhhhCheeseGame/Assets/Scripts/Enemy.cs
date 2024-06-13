using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] public int dmg = 5;
    private int mestohp;
    [SerializeField] private mesto mestoInstance; // Assign via Inspector

    public GameObject healthBarPrefab; // Prefab of the health bar UI
    private EnemyHealthBar healthBar;

    void Start()
    {
        if (mestoInstance != null)
        {
            mestohp = mestoInstance.GetBaseHp();
        }
        else
        {
            Debug.LogError("mesto instance not found! Please assign it in the Inspector.");
        }

        // Instantiate the health bar above the enemy
        GameObject healthBarGO = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
        healthBarGO.transform.SetParent(GameObject.Find("Canvas").transform, false); // Ensure it's part of the UI canvas
        healthBar = healthBarGO.GetComponent<EnemyHealthBar>();
        Debug.Log("healthbar funguje"); 

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(health);
            healthBar._enemy = this; // Assign the enemy reference to the health bar
        }
        else
        {
            Debug.LogError("Failed to get EnemyHealthBar component from healthBarGO.");
        }
        
    }

    void OnTriggerEnter2D(Collider2D BaseTrigger)
    {
        if (mestoInstance != null)
        {
            
            int newHp = mestohp - dmg;
            mestoInstance.SetBaseHp(newHp);
            Debug.Log(newHp);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}