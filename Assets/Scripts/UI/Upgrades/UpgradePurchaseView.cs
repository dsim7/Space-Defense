using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePurchaseView : MonoBehaviour
{
    public WeaponTemplateVariable inspectedWeapon;
    [Space]
    public UpgradeView upgradeView;
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
            UpdateInfo();
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
            if (inspectedWeapon.Value.available.Value)
            {
                upgradeView.gameObject.SetActive(true);
                purchaseView.SetActive(false);
            }
            else
            {
                upgradeView.gameObject.SetActive(false);
                purchaseView.SetActive(true);
            }
        }
    }
}
