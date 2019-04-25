using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    float CDStarted;
    float CDFinish;

    public WeaponTemplate weaponTemplate;
    public float CurrentCD { get { return CDFinish - Time.time; } }
    public float CurrentCDPercent { get { return (Time.time - CDStarted) / (CDFinish - CDStarted); } }
    public bool IsOffCD { get { return Time.time > CDFinish; } }
    public Transform bulletsTransform;

    public Weapon(WeaponTemplate weaponTemplate, Transform bulletsTransform)
    {
        CDStarted = 0;
        CDFinish = 0;

        this.weaponTemplate = weaponTemplate;
        this.bulletsTransform = bulletsTransform;
    }

    public void StartCD()
    {
        CDStarted = Time.time;
        CDFinish = Time.time + weaponTemplate.cooldown;
    }
    
    public bool Use(Transform origin, Vector2 target)
    {
        if (IsOffCD)
        {
            weaponTemplate.Fire(origin, target, bulletsTransform);
            StartCD();
            return true;
        }
        return false;
    }
}
