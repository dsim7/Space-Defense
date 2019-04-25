using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnHitEffector : ScriptableObject
{
    public abstract void OnHit(GameObject origin, GameObject target);
}
