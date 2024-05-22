using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Vector3 offset; // Offset to position the health bar above the enemy

    public Enemy _enemy; // Reference to the enemy this health bar is tracking
    private Transform target;

    void Start()
    {
        if (_enemy != null)
        {
            target = _enemy.transform;
            healthSlider.maxValue = _enemy.health;
        }
        else
        {
            Debug.LogError("Enemy reference not set on EnemyHealthBar.");
        }
    }
    
    void Update()
    {
        if (_enemy != null)
        {
            // Position the health bar above the enemy
            transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
            SetHealth(_enemy.health);
        }
        else
        {
            healthSlider.gameObject.SetActive(false);
        }
    }

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}
