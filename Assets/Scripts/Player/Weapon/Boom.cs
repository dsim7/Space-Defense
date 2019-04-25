using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [HideInInspector]
    public WeaponBoomer boomWeapon;

    public void DoBoom()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, boomWeapon.radius, boomWeapon.layer);
        foreach (Collider2D hit in hits)
        {
            if (hit != null)
            {
                boomWeapon.HitTarget(gameObject, hit.gameObject);
            }
        }
    }
}
