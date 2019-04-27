using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OnHitFireWeapon : OnHitEffector
{
    public WeaponTemplate[] weaponEffect;
    public Upgrade upgrade;

    public override void OnHit(GameObject origin, GameObject target)
    {
        if (upgrade == null)
        {
            weaponEffect[0].Fire(target.transform, target.transform.position, origin.transform.parent);
        }
        else
        {
            int index = Mathf.Clamp(upgrade.level.Value, 0, weaponEffect.Length);
            weaponEffect[index].Fire(target.transform, target.transform.position, origin.transform.parent);
        }
    }
}
