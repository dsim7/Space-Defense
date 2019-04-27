using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePurchaseSwitch : MonoBehaviour
{
    public WeaponTemplateVariable inspectedWeapon;
    [Space]
    public GameObject upgradeView;
    public GameObject purchaseView;

    void Start()
    {
        inspectedWeapon.RegisterPostchangeEvent(UpdateInfo);
        inspectedWeapon.RegisterPrechangeEvent(UnobserveWeaponAvailable);
        inspectedWeapon.RegisterPostchangeEvent(ObserveWeaponAvailable);
    }

    void ObserveWeaponAvailable()
    {
        if (inspectedWeapon.Value != null)
        {
            inspectedWeapon.Value.available.RegisterPostchangeEvent(UpdateInfo);
        }
    }

    void UnobserveWeaponAvailable()
    {
        if (inspectedWeapon.Value != null)
        {
            inspectedWeapon.Value.available.UnregisterPostchangeEvent(UpdateInfo);
        }
    }

    void UpdateInfo()
    {
        if (inspectedWeapon.Value != null)
        {
            upgradeView.SetActive(inspectedWeapon.Value.upgrade != null && inspectedWeapon.Value.available.Value);
            purchaseView.SetActive(!inspectedWeapon.Value.available.Value);
        }
    }
}
