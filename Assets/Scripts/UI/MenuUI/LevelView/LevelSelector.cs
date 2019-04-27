using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    Camera _mainCamera;
    Camera mainCamera { get { if (_mainCamera == null) _mainCamera = Camera.main; return _mainCamera; } }

    public LevelVariable currentLevel;

    public void ClickOnPlanet()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            Planet levelSelector = hit.collider.GetComponent<Planet>();
            if (levelSelector != null)
            {
                if (levelSelector.level.available.Value)
                {
                    currentLevel.Value = levelSelector.level;
                }
            }
        }
    }   
}
