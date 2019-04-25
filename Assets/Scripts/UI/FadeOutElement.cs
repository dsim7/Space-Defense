using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class FadeOutElement : MonoBehaviour
{
    CanvasGroup cg;

    float targetAlpha = 1;
    UnityEvent thenEvent = new UnityEvent();
    
    public float fadeRate = 1;

    void Awake()
    {
        cg = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (cg.alpha == targetAlpha)
        {
            thenEvent.Invoke();
            thenEvent.RemoveAllListeners();
            if (cg.alpha == 0)
            {
                gameObject.SetActive(false);
            }
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
        targetAlpha = 0;
        cg.interactable = false;

        if (then != null)
        {
            thenEvent.AddListener(then);
        }
    }

    public void FadeIn(UnityAction then)
    {
        targetAlpha = 1;
        gameObject.SetActive(true);
        cg.interactable = true;

        if (then != null)
        {
            thenEvent.AddListener(then);
        }
    }
    
}
