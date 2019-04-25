using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponLance : WeaponTemplate
{
    public GameObject lancePrefab;
    [Space]
    public float lifeTime;

    public override void Fire(Transform origin, Vector2 destination, Transform bulletsTransform)
    {
        Vector2 spawnPoint = Vector2.MoveTowards(origin.position, destination, 1f);

        Vector2 direction = (Vector2) origin.position - destination;
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 180;
        Quaternion spawnAngle = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject newLance = Instantiate(lancePrefab, spawnPoint, spawnAngle, bulletsTransform);
        Lance lance = newLance.GetComponent<Lance>();
        lance.lanceWeapon = this;
    }
}
