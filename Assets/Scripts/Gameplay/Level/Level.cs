using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Level : ScriptableObject
{
    public string levelName;
    [TextArea]
    public string lore;
    public List<Wave> waves;
    public int lives;
    public int credits;
}
