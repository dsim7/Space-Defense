using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Level : ScriptableObject
{
    public BoolVariable available;
    public string levelName;
    [TextArea]
    public string lore;
    public List<Wave> waves;
    public int lives;
    public int difficulty;
    [Header("Rewards")]
    public int creditsEarned;
    public List<Level> unlockedLevels;
    [TextArea]
    public string rewardsDescription;
    [Space]
    public IntVariableSO credits;

    public void Award()
    {
        credits.Value += creditsEarned;
        foreach (Level level in unlockedLevels)
        {
            level.available.Value = true;
        }
    }
}
