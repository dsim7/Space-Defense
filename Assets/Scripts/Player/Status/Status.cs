
using System;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    float applyTime, expireTime;
    GameObject sfx;

    public float durationPercentage { get { return (Time.time - applyTime) / (expireTime - applyTime); } }
    public bool completed { get { return durationPercentage > 1; } }

    public StatusTemplate template;
    
    public Status(StatusTemplate template)
    {
        this.template = template;
    }

    public void Apply(MonoBehaviour target)
    {
        template.OnApply(target);
        applyTime = Time.time;
        expireTime = Time.time + template.duration;
        sfx = UnityEngine.Object.Instantiate(template.sfxPrefab, target.transform.position, Quaternion.identity, target.transform);
    }

    public void End(MonoBehaviour target)
    {
        template.OnRemove(target);
        UnityEngine.Object.Destroy(sfx);
    }
}
