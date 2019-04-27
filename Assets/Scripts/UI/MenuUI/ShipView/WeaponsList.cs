using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsList : MonoBehaviour
{
    public PlayerManager playerManager;
    public WeaponInspector weaponButtonPrefab;
    public Transform weaponsGrid;

    void Start()
    {
        AddWeaponButtons();
    }

    public void AddWeaponButtons()
    {
        foreach (WeaponTemplate weapon in playerManager.weapons)
        {
            WeaponInspector newButton = Instantiate(weaponButtonPrefab, weaponsGrid);
            newButton.weapon = weapon;
        }
    }
}
