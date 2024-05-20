using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Vector3 offset; // Offset to position the health bar above the enemy

    public Enemy _enemy;
    private Transform target;

    void Start()
    {
        //target = GetComponent<Enemy>().transform;
        //healthSlider.maxValue = _enemy.health;
        
    }
    
    void Update()
    {
        //target = GetComponent<Enemy>().transform;
        target = _enemy.transform;
        
        if (_enemy != null)
        {
            // Position the health bar above the enemy
            transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
        }
        else if(_enemy == null) 
        {
            healthSlider.gameObject.SetActive(false);
        }
        SetHealth(_enemy.health);

        
    }
        /*
    public int GetSliderValue() 
    {
        return healthSlider.value;
    }
    public void SetSliderValue(int val) 
    {
        healthSlider.value = val;
    }
        */
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
