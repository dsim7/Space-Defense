using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBeam : Projectile
{
    LineRenderer lr;
    
    public override void Start()
    {
        base.Start();
        lr = GetComponent<LineRenderer>();
    }
    
    public override void Update()
    {
        base.Update();
        lr.SetPosition(0, origin.position);
        lr.SetPosition(lr.positionCount - 1, transform.position);
    }
    
}
