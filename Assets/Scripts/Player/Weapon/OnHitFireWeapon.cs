using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OnHitFireWeapon : OnHitEffector
{
    public WeaponTemplate weaponEffect;

    public override void OnHit(GameObject origin, GameObject target)
    {
        weaponEffect.Fire(target.transform, target.transform.position, origin.transform.parent);
    }
}
