using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OnHitApplyStatus : OnHitEffector
{
    public StatusTemplate[] status;
    public Upgrade upgrade;

    public override void OnHit(GameObject origin, GameObject target)
    {
        StatusHandler enemyStatus = target.GetComponent<StatusHandler>();
        if (enemyStatus != null)
        {
            if (upgrade == null && status.Length > 0)
            {
                enemyStatus.AddStatus(status[0]);
            }
            else
            {
                int index = Mathf.Clamp(upgrade.level.Value, 0, status.Length);
                enemyStatus.AddStatus(status[index]);
            }
        }
    }
}
