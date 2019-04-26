using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class MainMenuCamera : MonoBehaviour
{
    public BoolVariableSO seenIntro;
    public BlackMask blackMask;
    [Space]
    public Transform cameraTarget;
    public Transform entryTarget;
    public Transform levelSelectTarget;
    [Space]
    public FadeOutElement title;
    public Animator introShip;
    public FadeOutElement buttons;

    void Start()
    {
        Time.timeScale = 1;

        if (seenIntro.Value)
        {
            title.gameObject.SetActive(false);
            introShip.SetTrigger("Intro");
            buttons.FadeIn();
        }
        else
        {
            blackMask.FadeIn(() => { StartCoroutine(Intro()); });
        }
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(1f);
        title.FadeOut(() => { introShip.SetTrigger("Intro"); });
        yield return new WaitForSeconds(1.5f);
        buttons.FadeIn();
        seenIntro.Value = true;
    }

    public void GoToLevelSelect()
    {
        cameraTarget.position = levelSelectTarget.position;
    }

    public void GoToMenu()
    {
        cameraTarget.position = entryTarget.position;
    }
}
