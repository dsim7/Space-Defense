using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VulnerableStatus : StatusTemplate
{
    public float vulModifier;

    public override void OnApply(MonoBehaviour target)
    {
        EnemyLife life = target.GetComponent<EnemyLife>();
        if (life != null)
        {
            life.damageTakenCoef += vulModifier;
        }
    }

    public override void OnRemove(MonoBehaviour target)
    {
        EnemyLife life = target.GetComponent<EnemyLife>();
        if (life != null)
        {
            life.damageTakenCoef -= vulModifier;
        }
    }
}
