using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsIndicator : MonoBehaviour
{
    public Text creditsText;
    public IntVariableSO credits;

    void Start()
    {
        credits.RegisterPostchangeEvent(UpdateInfo);
    }
    
    void UpdateInfo()
    {
        creditsText.text = credits.Value.ToString();
    }
}
