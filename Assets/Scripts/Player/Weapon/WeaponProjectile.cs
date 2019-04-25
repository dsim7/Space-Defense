using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponProjectile : WeaponTemplate
{
    public Projectile projectilePrefab;

    public float projLifetime;
    public float projSpeed;
    public bool destroyOnImpact;

    public override void Fire(Transform origin, Vector2 dest, Transform bulletsTransform)
    {
        Vector2 angle = new Vector2(dest.x - origin.position.x, dest.y - origin.position.y).normalized;

        Projectile projectile = Instantiate(projectilePrefab, origin.position, Quaternion.identity, bulletsTransform).GetComponent<Projectile>();
        projectile.direction = angle;
        projectile.origin = origin;
        projectile.weapon = this;
    }
}
