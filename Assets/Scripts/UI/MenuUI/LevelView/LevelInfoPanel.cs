using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelInfoPanel : MonoBehaviour
{
    IDialog dialog;

    public LevelVariable inspectedLevel;
    [Space]
    public Text levelName;
    public Text desc, difficulty;
    [Space]
    public BlackMask inspectingMask;
    public float fadeOutAmount;
    public BlackMask mask;

    void Awake()
    {
        dialog = GetComponent<IDialog>();
        inspectedLevel.RegisterPostchangeEvent(UpdateInfo);

        gameObject.SetActive(false);
    }

    void UpdateInfo()
    {
        if (inspectedLevel.Value != null && !gameObject.activeSelf)
        {
            Show();

            levelName.text = inspectedLevel.Value.levelName;
            desc.text = inspectedLevel.Value.lore;
            difficulty.text = inspectedLevel.Value.difficulty.ToString();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        inspectingMask.FadeOutPartial(fadeOutAmount);
        dialog.Appear();
    }

    public void Hide()
    {
        inspectingMask.FadeIn();
        dialog.Disappear();
    }

    public void YesPlayLevel()
    {
        Hide();
        mask.FadeOut(GoToLevel);
    }
    
    public void NoPlayLevel()
    {
        Hide();
    }

    void GoToLevel()
    {
        SceneManager.LoadScene("InLevel");
    }
}
