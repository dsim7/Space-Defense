using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    Camera mainCamera;

    public LevelVariable currentLevel;

    void Start()
    {
        mainCamera = Camera.main;
    }

    public void ClickOnPlanet()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            Planet levelSelector = hit.collider.GetComponent<Planet>();
            if (levelSelector != null)
            {
                currentLevel.Value = levelSelector.level;
            }
        }
    }   
}
