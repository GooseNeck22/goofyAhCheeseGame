using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TowerV2 : MonoBehaviour
{
    public enum TowerTargetPriority
    {
        First,
        Close,
        Strong
    }
    
    public int level = 1;
    public int maxLevel = 3;
    public int[] upgradeCosts; // Array to hold upgrade costs for each level
    
    public GameObject towerSelectionWindow; // Reference to the tower selection window GameObject
    
    [Header("Info")]
    public float range;
    //[SerializeField] private List<Enemy> curEnemiesInRange = new List<Enemy>();
    [SerializeField]private Collider2D[] enemy;
    [SerializeField] private LayerMask enemyMask;
    private Enemy curEnemy;
    public TowerTargetPriority targetPriority;
    public bool rotateTowardsTarget;
    [Header("Attacking")]
    public float attackRate;
    private float lastAttackTime;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPos;
    public int projectileDamage;
    public float projectileSpeed;
    
    
    
    void Start()
    {
        // Initialize upgrade costs if not already set
        if (upgradeCosts.Length == 0)
        {
            upgradeCosts = new int[maxLevel];
            // Initialize upgrade costs here, for example:
            upgradeCosts[0] = 50;
            upgradeCosts[1] = 100;
        }
    }
    
    
    private void OnMouseDown()
    {
        if (towerSelectionWindow != null)
        {
            towerSelectionWindow.SetActive(true); // Open tower selection window
        }
    }
    
    public void UpgradeTower()
    {
        if (level < maxLevel)
        {
            // Check if player has enough currency to upgrade
            int upgradeCost = upgradeCosts[level - 1]; // Cost for the next level
            if (GameManager.instance.CanAfford(upgradeCost))
            {
                // Deduct cost from player's currency
                GameManager.instance.SpendCurrency(upgradeCost);

                // Upgrade the tower
                level++;

                // TODO: Implement tower upgrade visuals or functionality here

                Debug.Log("Tower upgraded to level " + level);
            }
            else
            {
                Debug.Log("Not enough currency to upgrade tower");
            }
        }
        else
        {
            Debug.Log("Tower is already at max level");
        }
    }

    
    
    void Update ()
    {

        enemy = Physics2D.OverlapCircleAll(transform.position, range, enemyMask);
        
        
        // attack every "attackRate" seconds
        if(Time.time - lastAttackTime > attackRate)
        {
            lastAttackTime = Time.time;
            
            curEnemy = GetEnemy();
            if (curEnemy != null)
            {
                Attack();
            }
        }
    }
    // returns the current enemy for the tower to attack
    Enemy GetEnemy ()
    {
        //.RemoveAll(x => x == null);
        if (enemy.Length == 0)
        {
            return null;
        }
        if (enemy.Length == 1)
        {
            Debug.Log("working in GetEnemy");
            return enemy[0].gameObject.GetComponent<Enemy>();
        }
        switch(targetPriority)
        {
            case TowerTargetPriority.First:
            {
                return enemy[0].gameObject.GetComponent<Enemy>();
            }
            case TowerTargetPriority.Close:
            {
                Enemy closest = null;
                float dist = 99;
                for(int x = 0; x < enemy.Length; x++)
                {
                    float d = (transform.position - enemy[x].transform.position).sqrMagnitude;
                    if(d < dist)
                    {
                        closest = enemy[x].gameObject.GetComponent<Enemy>();
                        dist = d;
                    }
                }
                return closest;
            }
            case TowerTargetPriority.Strong:
            {
                Enemy strongest = null;
                int strongestHealth = 0;
                //enemy[0].gameObject
                foreach(Collider2D enemy in enemy)
                {
                    if(enemy.gameObject.GetComponent<Enemy>().health > strongestHealth)
                    {
                        strongest = enemy.gameObject.GetComponent<Enemy>();
                        strongestHealth = enemy.gameObject.GetComponent<Enemy>().health;
                    }
                }
                return strongest;
            }
        }
        return null;
    }
    // attacks the curEnemy
    void Attack ()
    {
        
        GameObject proj = Instantiate(projectilePrefab, projectileSpawnPos.position, Quaternion.identity);
        proj.GetComponent<Projectile>().Initialize(curEnemy, projectileDamage, projectileSpeed);
    }
    
    /*
    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            curEnemiesInRange.Add(collision.gameObject.GetComponent<Enemy>());
        }
    } 
    private void OnTriggerExit (Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            curEnemiesInRange.Remove(other.GetComponent<Enemy>());
        }
    } */

    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        try
        {
            Handles.color = Color.green;
            Handles.DrawWireDisc(transform.position, Vector3.forward, range);
        }
        catch
        {
        }
    }
#endif
}