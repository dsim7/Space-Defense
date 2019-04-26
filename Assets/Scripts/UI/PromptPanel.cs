using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PromptPanel : MonoBehaviour
{
    UnityEvent promptedAction = new UnityEvent();

    public void Prompt(UnityAction yesAction)
    {
        promptedAction.AddListener(yesAction);
        gameObject.SetActive(true);
    }
    
    public void Accept()
    {
        if (promptedAction != null)
        {
            promptedAction.Invoke();
        }
        promptedAction.RemoveAllListeners();
    }

    public void Decline()
    {
        promptedAction.RemoveAllListeners();
    }
}
