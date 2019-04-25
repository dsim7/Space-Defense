using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    public BoolVariable acquired;

    public void DoUpgrade()
    {
        acquired.Value = true;
        UpgradeEffect();
    }

    protected abstract void UpgradeEffect();

    protected abstract void Reverse();
} 

public abstract class WeaponUpgrade<T> : Upgrade
{
    public T upgradedThing;
}
