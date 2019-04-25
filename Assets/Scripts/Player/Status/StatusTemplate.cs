using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusTemplate : ScriptableObject
{
    public float duration;
    public GameObject sfxPrefab;

    public abstract void OnApply(MonoBehaviour target);

    public abstract void OnRemove(MonoBehaviour target);
}