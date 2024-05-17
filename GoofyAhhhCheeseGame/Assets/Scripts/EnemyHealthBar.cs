using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Vector3 offset; // Offset to position the health bar above the enemy

    private Transform target;

    void Start()
    {
        //target = GetComponentInParent<Enemy>().transform;
    }

    void Update()
    {
        target = GetComponentInParent<Enemy>().transform;
        if (target != null)
        {
            // Position the health bar above the enemy
            transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
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
