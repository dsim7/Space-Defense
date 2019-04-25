using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OnHitApplyStatus : OnHitEffector
{
    public StatusTemplate status;

    public override void OnHit(GameObject origin, GameObject target)
    {
        StatusHandler enemyStatus = target.GetComponent<StatusHandler>();
        if (enemyStatus != null)
        {
            enemyStatus.AddStatus(status);
        }
    }
}
