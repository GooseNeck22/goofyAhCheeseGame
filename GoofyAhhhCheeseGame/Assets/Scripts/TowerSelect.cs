using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerSelectionWindow; // Reference to the tower selection window GameObject
    public Text moneyText; // Reference to the Text component displaying money
    public int[] towerCosts; // Array holding the costs of each tower
    public GameObject[] towers; // Array holding references to each tower GameObject
    private int money; // Current money

    private void Start()
    {
        money = 100; // Starting amount of money (you can change this to whatever you want)
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = "Money: " + money.ToString();
    }

    private void OnMouseDown()
    {
        if (towerSelectionWindow != null)
        {
            towerSelectionWindow.SetActive(true); // Open tower selection window
        }
    }

    public void SelectTower(int towerIndex)
    {
        if (money >= towerCosts[towerIndex])
        {
            // Place the selected tower at the clicked position
            Instantiate(towers[towerIndex], transform.position, Quaternion.identity);

            // Deduct the cost of the tower from money
            money -= towerCosts[towerIndex];
            UpdateMoneyText();
        }
        else
        {
            Debug.Log("Not enough money to buy this tower!");
        }
    }
}