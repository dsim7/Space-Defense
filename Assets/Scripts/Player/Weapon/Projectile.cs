using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    bool dead = false;
    float lifeTime;

    [HideInInspector]
    public WeaponProjectile weapon;
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public Transform origin;

    public virtual void Start() { }

    public virtual void Update()
    {
        if (!dead)
        {
            lifeTime += Time.deltaTime;
            if (lifeTime > weapon.projLifetime && !dead)
            {
                StartDeath();
            }
            transform.Translate(direction * weapon.projSpeed * Time.deltaTime);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D hit)
    {
        if (!dead)
        {
            weapon.HitTarget(gameObject, hit.gameObject);
            if (weapon.destroyOnImpact)
            {
                StartDeath();
            }
        }
    }

    public void StartDeath()
    {
        dead = true;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
        GetComponent<Animator>().SetTrigger("Death");
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
