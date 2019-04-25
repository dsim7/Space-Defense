using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : MonoBehaviour
{
    Animator anim;

    float lifeTime = 0;
    
    [HideInInspector]
    public WeaponLance lanceWeapon;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > lanceWeapon.lifeTime)
        {
            anim.SetTrigger("Death");
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void DoLance()
    {
        Collider2D[] hits = new Collider2D[25];
        Physics2D.OverlapCollider(GetComponent<Collider2D>(), new ContactFilter2D(), hits);
        foreach (Collider2D hit in hits)
        {
            if (hit != null)
            {
                lanceWeapon.HitTarget(gameObject, hit.gameObject);
            }
        }
    }
}
