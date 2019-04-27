using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    Camera cam;

    public WeaponVariable currentWeapon;
    public Transform bulletsTransform;
    [Space]
    public bool canShoot;

    void Start()
    {
        cam = Camera.main;
    }

    public void ShootAtMouse()
    {
        if (canShoot)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 dest = cam.ScreenToWorldPoint(touch.position);
                    currentWeapon.Value.Use(transform, dest);
                }
            }

            //Vector2 dest = cam.ScreenToWorldPoint(Input.mousePosition);

            //currentWeapon.Value.Use(transform, dest);
        }
    }
}
