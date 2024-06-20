using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int startingCurrency = 1000;
    private int currentCurrency;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            Debug.Log("boom");
        }
        
        Debug.Log(instance);
        
        // Initialize current currency
        currentCurrency = startingCurrency;
    }

    public bool CanAfford(int amount)
    {
        return currentCurrency >= amount;
    }

    public void AddCurrency(int amount)
    {
        currentCurrency += amount;
    }

    public int GetCurrency()
    {
        return currentCurrency;
    }

    public void SpendCurrency(int amount)
    {
        if (CanAfford(amount))
        {
            currentCurrency -= amount;
        }
        else
        {
            Debug.Log("Not enough currency to spend");
        }
    }
}
