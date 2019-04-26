using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public WeaponTemplateVariable weapon;
    public PromptPanel prompt;

    public void PromptUpgrade()
    {
        prompt.Prompt(DoUpgrade);
    }

    void DoUpgrade()
    {
        if (weapon.Value != null)
        {
            Upgrade upgrade = weapon.Value.upgradeSet;
            if (upgrade != null)
            {
                upgrade.DoUpgrade();
            }
        }
    }
}
