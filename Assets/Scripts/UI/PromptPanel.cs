using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PromptPanel : MonoBehaviour
{
    UnityAction promptedAction;

    public void Prompt(UnityAction yesAction)
    {
        promptedAction = yesAction;
        gameObject.SetActive(true);
    }
    
    public void DoPromptedAction()
    {
        if (promptedAction != null)
        {
            promptedAction.Invoke();
        }
        promptedAction = null;
    }
}
