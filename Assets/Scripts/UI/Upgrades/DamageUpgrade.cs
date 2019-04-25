using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DamageUpgrade : WeaponUpgrade<OnHitDamage>
{
    public int damageIncrease;

    protected override void UpgradeEffect()
    {
        upgradedThing.damageAmount += damageIncrease;
    }

    protected override void Reverse()
    {
        upgradedThing.damageAmount -= damageIncrease;
    }

}
