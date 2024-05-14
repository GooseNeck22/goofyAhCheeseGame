using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public TowerV2 tower; // Reference to the tower to upgrade

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(UpgradeTower);
    }

    void UpgradeTower()
    {
        tower.UpgradeTower();
        Debug.Log("upgraded");
    }
}
