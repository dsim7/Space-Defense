using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FlippingUIPanel : MonoBehaviour
{
    Animator _anim;
    Animator anim { get { if (_anim == null) _anim = GetComponent<Animator>(); return _anim; } }
    
    public void Appear()
    {
        gameObject.SetActive(true);
        anim.SetTrigger("Appear");
    }

    public void Disappear()
    {
        anim.SetTrigger("Disappear");
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
