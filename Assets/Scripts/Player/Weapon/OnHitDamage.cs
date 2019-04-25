using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OnHitDamage : OnHitEffector
{
    public float damageAmount;

    public override void OnHit(GameObject origin, GameObject target)
    {
        EnemyLife enemyLife = target.GetComponent<EnemyLife>();
        if (enemyLife != null)
        {
            enemyLife.TakeDamage(damageAmount);
        }
    }
}