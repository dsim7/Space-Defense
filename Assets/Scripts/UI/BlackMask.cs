using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class BlackMask : MonoBehaviour
{
    CanvasGroup cg;

    float alphaTarget = 0;
    UnityEvent thenEvent = new UnityEvent();

    public float fadeRate = 0.5f;

    void Awake()
    {
        cg = GetComponent<CanvasGroup>();
        cg.blocksRaycasts = true;
    }

    void Update()
    {
        if (cg.alpha == alphaTarget)
        {
            thenEvent.Invoke();
            thenEvent.RemoveAllListeners();
        }
        else
        {
            cg.alpha = Mathf.MoveTowards(cg.alpha, alphaTarget, fadeRate * Time.deltaTime);
        }
    }

    public void FadeOut(UnityAction then = null)
    {
        alphaTarget = 1;
        cg.blocksRaycasts = true;

        if (then != null)
        {
            thenEvent.AddListener(then);
        }
    }

    public void FadeIn(UnityAction then = null)
    {
        alphaTarget = 0;
        cg.blocksRaycasts = false;

        if (then != null)
        {
            thenEvent.AddListener(then);
        }
    }

}
