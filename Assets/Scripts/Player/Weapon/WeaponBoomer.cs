using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponBoomer : WeaponTemplate
{
    public GameObject boomPrefab;
    [Space]
    public float radius;
    public LayerMask layer;
    public float lifeTime;

    public override void Fire(Transform origin, Vector2 destination, Transform bulletsTransform)
    {
        GameObject newBoom = Instantiate(boomPrefab, destination, Quaternion.identity, bulletsTransform);
        Boom boom = newBoom.GetComponent<Boom>();
        boom.boomWeapon = this;
        boom.DoBoom();
        Destroy(newBoom, lifeTime);
    }
}
