using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class MainMenuCamera : MonoBehaviour
{
    public BlackMask blackMask;
    [Space]
    public Transform cameraTarget;
    public Transform entryTarget;
    public Transform levelSelectTarget;

    void Start()
    {
        blackMask.gameObject.SetActive(true);
        blackMask.FadeIn();
    }

    public void GoToLevelSelect()
    {
        cameraTarget.position = levelSelectTarget.position;
    }
}
