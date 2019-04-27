using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InLevelTextDisplay : MonoBehaviour
{
    Text text;
    FadingDialog fader;

    public Text subtext;
    public LevelVariable currentLevel;

    void Start()
    {
        fader = GetComponent<FadingDialog>();
        text = GetComponent<Text>();
    }

    public void ShowFail()
    {
        text.text = "FAILED";
        text.color = Color.red;
        fader.fadeRate = 100;
        fader.Appear();
    }

    public void ShowSuccess()
    {
        text.text = "COMPLETE";
        text.color = Color.white;
        subtext.text = currentLevel.Value.rewardsDescription;
        fader.fadeRate = 100;
        fader.Appear();
    }

    public void ShowGetReady()
    {
        text.text = "GET READY";
        text.color = Color.white;
        fader.fadeRate = 0.4f;
        fader.Appear();
    }

    public void FadeOutSlowly()
    {
        fader.Disappear();
        fader.fadeRate = 0.4f;
    }
}
