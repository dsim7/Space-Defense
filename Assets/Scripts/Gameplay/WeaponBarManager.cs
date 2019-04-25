using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBarManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public List<Weapon> weapons = new List<Weapon>();
    public Transform hotBar;
    public GameObject weaponButtonPrefab;
    public Transform bulletsTransform;
    public WeaponVariable currentWeapon;

    void Start()
    {
        foreach (WeaponTemplate template in playerManager.weapons)
        {
            if (template.available.Value)
            {
                WeaponButton button = Instantiate(weaponButtonPrefab, hotBar).GetComponent<WeaponButton>();
                button.weapon = new Weapon(template, bulletsTransform);
                weapons.Add(button.weapon);
            }
        }
        currentWeapon.Value = weapons[weapons.Count - 1];
    }
}
