using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIndicator : MonoBehaviour
{
    public Level level;
    public GameObject indication;

    void Start()
    {
        indication.SetActive(level.available.Value);
    }
    
}
