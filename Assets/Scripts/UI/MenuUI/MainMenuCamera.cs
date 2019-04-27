using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class MainMenuCamera : MonoBehaviour
{
    public static bool introSeen = false;

    public BlackMask blackMask;
    [Space]
    public Transform cameraTarget;
    public Transform entryTarget;
    public Transform levelSelectTarget;
    [Space]
    public FadingDialog title;
    public Animator introShip;
    public FadingDialog buttons;

    void Start()
    {
        Debug.Log("Intro");
        Time.timeScale = 1;

        if (introSeen)
        {
            blackMask.FadeIn();
            title.gameObject.SetActive(false);
            introShip.SetTrigger("Intro");
            buttons.Appear();
        }
        else
        {
            introSeen = true;
            blackMask.FadeIn(() => { StartCoroutine(Intro()); });
        }
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(1f);
        title.Disappear(() => { introShip.SetTrigger("Intro"); });
        yield return new WaitForSeconds(1.5f);
        buttons.Appear();
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
