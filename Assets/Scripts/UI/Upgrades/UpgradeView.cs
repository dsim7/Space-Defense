using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    public WeaponTemplateVariable inspectedWeapon;
    [Space]
    public List<Image> pluses;
    public Button upgradeButton;
    [Space]
    public Color upgradedColor;
    public Color unupgradedColor;

    void Start()
    {
        inspectedWeapon.RegisterPostchangeEvent(UpdateInfo);
        inspectedWeapon.RegisterPrechangeEvent(UnobserveWeaponUpgradeLevel);
        inspectedWeapon.RegisterPostchangeEvent(ObserveWeaponUpgradeLevel);
    }

    void ObserveWeaponUpgradeLevel()
    {
        if (inspectedWeapon.Value != null && inspectedWeapon.Value.upgradeSet != null)
        {
            inspectedWeapon.Value.upgradeSet.level.RegisterPostchangeEvent(UpdateInfo);
            UpdateInfo();
        }
    }

    void UnobserveWeaponUpgradeLevel()
    {
        if (inspectedWeapon.Value != null && inspectedWeapon.Value.upgradeSet != null)
        {
            inspectedWeapon.Value.upgradeSet.level.UnregisterPostchangeEvent(UpdateInfo);
        }
    }

    void UpdateInfo()
    {
        if (inspectedWeapon.Value != null && inspectedWeapon.Value.upgradeSet != null) 
        {
            gameObject.SetActive(true);
            Upgrade upgrade = inspectedWeapon.Value.upgradeSet;
            UpdatePluses(upgrade);
            UpdateButton(upgrade);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void UpdatePluses(Upgrade upgrade)
    {
        int upgradeLevel = upgrade.level.Value;

        for (int i = 0; i < pluses.Count; i++)
        {
            bool shouldFill = i + 1 <= upgradeLevel;
            pluses[i].color = shouldFill ? upgradedColor : unupgradedColor;
        }
    }

    void UpdateButton(Upgrade upgrade)
    {
        upgradeButton.gameObject.SetActive(upgrade != null && upgrade.CanUpgrade());
    }

    //[SerializeField]
    //Upgrade _upgrade;
    //public Upgrade upgradeSet
    //{
    //    get { return _upgrade; }

    //    set
    //    {
    //        _upgrade = value;
    //        ToggleButton();
    //        SetUpPluses();
    //    }
    //}

    //[Space]
    //[SerializeField]
    //Image[] pluses;
    //public Button upgradeButton;
    //public Transform plusesPanel;
    //public PromptPanel prompt;

    ////void Start()
    ////{
    ////    ToggleButton();
    ////}

    //public void PromptUpgrade()
    //{
    //    prompt.Prompt(DoUpgrade);
    //}

    //void DoUpgrade()
    //{
    //    if (_upgrade != null)
    //    {
    //        _upgrade.DoUpgrade();
    //        ToggleButton();
    //    }
    //}

    //void ToggleButton()
    //{
    //    if (_upgrade == null || !_upgrade.HasMoreUpgrades())
    //    {
    //        upgradeButton.gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        upgradeButton.gameObject.SetActive(true);
    //    }
    //}
}
