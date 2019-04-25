using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SlowStatus : StatusTemplate
{
    [Range(0,1)]
    public float slowAmount;

    public override void OnApply(MonoBehaviour target)
    {
        target.GetComponent<EnemyMover>().speedModCoef *= 1 - slowAmount;
    }

    public override void OnRemove(MonoBehaviour target)
    {
        target.GetComponent<EnemyMover>().speedModCoef /= 1 - slowAmount;
    }
}

