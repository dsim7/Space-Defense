using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponTemplate : ScriptableObject
{
    public BoolVariable available;
    public string weaponName;
    [TextArea]
    public string description;
    public Sprite icon;
    public float cooldown;
    [SerializeField]
    List<OnHitEffector> hitEffects;

    [Space]
    public UpgradeSet upgradeSet;

    public abstract void Fire(Transform origin, Vector2 destination, Transform bulletsTransform);
    
    public void HitTarget(GameObject origin, GameObject target)
    {
        foreach (OnHitEffector effect in hitEffects)
        {
            if (effect != null)
            {
                effect.OnHit(origin, target);
            }
            else
            {
                Debug.LogWarning("Missing Effect");
            }
        }
    }
}
