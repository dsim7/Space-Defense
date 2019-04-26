using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public IntVariableSO lives;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collide");
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            lives.Value = lives.Value - 1;

            Destroy(other.gameObject);
        }
    }
}
