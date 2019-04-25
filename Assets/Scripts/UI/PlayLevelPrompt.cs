using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevelPrompt : MonoBehaviour
{
    FadeOutElement fader;

    public BlackMask mask;
    
    void Awake()
    {
        fader = GetComponent<FadeOutElement>();
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
    }
}
