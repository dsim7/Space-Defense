using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class Upgrade : ScriptableObject
{
    public IntVariable level;
    public int maxLevel = 3;
    public int[] levelCosts;
    public string[] levelDescriptions;

    public void DoUpgrade()
    {
        if (CanUpgrade())
        {
            level.Value++;
        }
    }

    public bool CanUpgrade()
    {
        return level.Value < maxLevel;
    }
}
