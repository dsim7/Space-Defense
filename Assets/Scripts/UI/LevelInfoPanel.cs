using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelInfoPanel : MonoBehaviour
{
    FadeOutElement fader;

    public LevelVariable inspectedLevel;
    public BlackMask mask;
    public BlackMask inspectingMask;
    [Space]
    public Text levelName;
    public Text desc, difficulty;

    void Awake()
    {
        fader = GetComponent<FadeOutElement>();
        inspectedLevel.RegisterPostchangeEvent(UpdateInfo);
        inspectedLevel.Value = null;

        gameObject.SetActive(false);
    }

    void UpdateInfo()
    {
        if (inspectedLevel.Value != null)
        {
            fader.FadeIn();
            inspectingMask.FadeOutPartial(0.6f);

            levelName.text = inspectedLevel.Value.levelName;
            desc.text = inspectedLevel.Value.lore;
            difficulty.text = inspectedLevel.Value.difficulty.ToString();
        }
    }

    public void YesPlayLevel()
    {
        fader.FadeOut();
        mask.FadeOut(GoToLevel);
    }

    void GoToLevel()
    {
        SceneManager.LoadScene("InLevel");
    }

    public void NoPlayLevel()
    {
        fader.FadeOut();
        inspectingMask.FadeIn();
    }
}
