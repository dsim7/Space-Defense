using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    float speed;

    public float minSpeed, maxSpeed, defaultSpeed, speedModCoef = 1, speedModConst = 0;

    void Start()
    {
        defaultSpeed = Random.Range(minSpeed, maxSpeed);
        speed = defaultSpeed;
    }

    void Update()
    {
        float realSpeed = speed * speedModCoef + speedModConst;
        transform.Translate(Vector2.left * realSpeed * Time.deltaTime);
    }
}
