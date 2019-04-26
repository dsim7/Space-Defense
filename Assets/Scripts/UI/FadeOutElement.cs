using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class FadeOutElement : MonoBehaviour
{
    CanvasGroup _cg;
    CanvasGroup cg { get { if (_cg == null) { _cg = GetComponent<CanvasGroup>(); } return _cg; } set { _cg = value; } }

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

    public void FadeOut()
    {
        FadeOut(null);
    }

    public void FadeIn()
    {
        FadeIn(null);
    }

    public void FadeOut(UnityAction then)
    {
        Enable();
        targetAlpha = 0;
        cg.interactable = false;

        if (then != null)
        {
            thenEvent.AddListener(then);
        }
        thenEvent.AddListener(Disable);
    }

    public void FadeIn(UnityAction then)
    {
        Enable();
        targetAlpha = 1;
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
