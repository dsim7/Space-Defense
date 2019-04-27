using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    public UpgradeVariable inspectedUpgrade;
    [Space]
    public List<Image> pluses;
    public Button upgradeButton;
    [Space]
    public Color upgradedColor;
    public Color unupgradedColor;

    void Start()
    {
        inspectedUpgrade.RegisterPrechangeEvent(UnobserveUpgradeLevel);
        inspectedUpgrade.RegisterPostchangeEvent(ObserveUpgradeLevel);
    }

    void ObserveUpgradeLevel()
    {
        if (inspectedUpgrade.Value != null)
        {
            inspectedUpgrade.Value.level.RegisterPostchangeEvent(UpdateInfo);
        }
    }

    void UnobserveUpgradeLevel()
    {
        if (inspectedUpgrade.Value != null)
        {
            inspectedUpgrade.Value.level.UnregisterPostchangeEvent(UpdateInfo);
        }
    }

    void UpdateInfo()
    {
        if (inspectedUpgrade.Value != null) 
        {
            Upgrade upgrade = inspectedUpgrade.Value;
            UpdatePluses(upgrade);
            UpdateButton(upgrade);
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
}
