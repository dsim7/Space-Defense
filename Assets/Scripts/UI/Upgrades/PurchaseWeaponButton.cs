using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseWeaponButton : MonoBehaviour
{
    public WeaponTemplateVariable weapon;

    public PromptPanel prompt;

    public void PromptPurchase()
    {
        prompt.Prompt(() => weapon.Value.available.Value = true);
    }
}
