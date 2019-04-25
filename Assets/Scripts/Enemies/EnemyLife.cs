using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{     
    public float maxHealth;
    public float health;
    [Space]
    public SpawnZone spawner;
    public float damageTakenCoef = 1;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        float realAmount = amount * Mathf.Max(damageTakenCoef, 0);
        health -= realAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (spawner != null)
        {
            spawner.CheckGameOverOrComplete();
        }
        Destroy(gameObject);
    }
}
