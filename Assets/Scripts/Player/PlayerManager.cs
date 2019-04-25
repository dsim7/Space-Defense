using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerManager : ScriptableObject
{
    public int credits;
    public List<WeaponTemplate> weapons;
    public List<UpgradeSet> upgrades;
    
}
