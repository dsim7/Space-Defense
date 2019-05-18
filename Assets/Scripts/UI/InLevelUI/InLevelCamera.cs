using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InLevelCamera : MonoBehaviour
{
    public BlackMask blackMask;
    public FadingDialog controls;
    public ShipShooter shipShooter;
    public InLevelTextDisplay infoText;
    [Space]
    public float delayUntilFadeText;
    public float delayUntilAllowControls;

    void Start()
    {
        blackMask.gameObject.SetActive(true);
        blackMask.FadeInstant(1f);
        blackMask.FadeIn();
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        infoText.ShowGetReady();
        yield return new WaitForSeconds(delayUntilFadeText);
        infoText.FadeOutSlowly();
        yield return new WaitForSeconds(delayUntilAllowControls);
        AllowControls();
    }

    void AllowControls()
    {
        controls.Appear();
        shipShooter.canShoot = true;
    }
}
