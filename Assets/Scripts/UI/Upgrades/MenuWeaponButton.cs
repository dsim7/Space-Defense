using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWeaponButton : MonoBehaviour
{
    [SerializeField]
    WeaponTemplate _weapon;
    public WeaponTemplate weapon { get { return _weapon; } set { _weapon = value; UpdateWeapon(); } }
    public WeaponTemplateVariable inspectedWeapon;
    public Image image;
    
    void Start()
    {
        UpdateWeapon();
    }

    void UpdateWeapon()
    {
        if (weapon != null)
        {
            image.sprite = weapon.icon;
        }
    }

    public void InspectWeapon()
    {
        inspectedWeapon.Value = weapon;
    }
}
