using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health = 100;

    public void TakeDamage(int damage)
    {
        health =- damage;
    }
}
