﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
[RequireComponent(typeof(CanvasGroup))]
public class FadingDialog : MonoBehaviour, IDialog
{
    CanvasGroup _cg;
    CanvasGroup cg { get { if (_cg == null) { _cg = GetComponent<CanvasGroup>(); } return _cg; } set { _cg = value; } }

    [SerializeField]
    float targetAlpha = 1;

    UnityEvent thenEvent = new UnityEvent();
    
    public float fadeRate = 1;

    void Update()
    {
        if (cg.alpha == targetAlpha)
        {
            thenEvent.Invoke();
            thenEvent.RemoveAllListeners();
        }
        else
        {
            cg.alpha = Mathf.MoveTowards(cg.alpha, targetAlpha, fadeRate * Time.deltaTime);
        }
        
    }

    public void Disappear()
    {
        Disappear(null);
    }

    public void Appear()
    {
        Appear(null);
    }

    public void Disappear(UnityAction then)
    {
        Enable();
        targetAlpha = 0;
        cg.blocksRaycasts = false;
        cg.interactable = false;

        if (then != null)
        {
            thenEvent.AddListener(then);
        }
        thenEvent.AddListener(Disable);
    }

    public void Appear(UnityAction then)
    {
        Enable();
        targetAlpha = 1;
        cg.blocksRaycasts = true;
        cg.interactable = true;

        if (then != null)
        {
            thenEvent.AddListener(then);
        }
    }

    void Enable()
    {
        gameObject.SetActive(true);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
    
}
