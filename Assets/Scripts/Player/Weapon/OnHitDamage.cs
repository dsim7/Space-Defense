using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OnHitDamage : OnHitEffector
{
    public float[] damageAmount;
    public Upgrade upgrade;

    public override void OnHit(GameObject origin, GameObject target)
    {
        EnemyLife enemyLife = target.GetComponent<EnemyLife>();
        if (enemyLife != null)
        {
            if (upgrade == null && damageAmount.Length > 0)
            {
                enemyLife.TakeDamage(damageAmount[0]);
            }
            else
            {
                int index = Mathf.Clamp(upgrade.level.Value, 0, damageAmount.Length);
                enemyLife.TakeDamage(damageAmount[index]);
            }
        }
    }
}