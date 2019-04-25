using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    Camera mainCamera;

    public LevelVariable currentLevel;
    public GameObject playLevelPrompt;

    void Start()
    {
        Time.timeScale = 1;
        mainCamera = Camera.main;
    }

    public void ClickOnPlanet()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            LevelSelector level = hit.transform.GetComponent<LevelSelector>();
            if (level != null)
            {
                currentLevel.Value = level.levelToSelect;
                playLevelPrompt.GetComponent<FadeOutElement>().FadeIn();
            }
        }
    }   
}
