using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveGame : MonoBehaviour
{
    public PlayerManager playerManager;

    void Awake()
    {
        // Ensure that we only ever load once: when the app starts
        DontDestroyOnLoad(gameObject);
        playerManager.Load();
    }
}