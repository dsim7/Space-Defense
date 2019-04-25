using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class ShipMover : MonoBehaviour
{
    Rigidbody2D rb;
    bool facingRight = true;
    Vector3 localScale;

    [SerializeField]
    float thrust = 4f;
    [SerializeField]
    float dragScale = 0.98f;
    
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float xAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        float yAxis = CrossPlatformInputManager.GetAxis("Vertical");
        if (xAxis != 0 && yAxis != 0)
        {
            rb.AddForce(new Vector2(xAxis, yAxis) * thrust);
        }
        rb.velocity *= dragScale;
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (rb.velocity.x > 0)
        {
            facingRight = true;
        }
        else
        {
            if (rb.velocity.x < 0)
            {
                facingRight = false;
            }
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

}
