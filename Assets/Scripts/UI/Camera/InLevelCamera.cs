using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLevelCamera : MonoBehaviour
{
    public BlackMask blackMask;

    void Start()
    {
        blackMask.gameObject.SetActive(true);
        blackMask.FadeIn();
    }
}
