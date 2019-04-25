using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour, IPointerDownHandler
{
    public ShipShooter shipShooter;

    public void OnPointerDown(PointerEventData eventData)
    {
        shipShooter.ShootAtMouse();
    }
}
