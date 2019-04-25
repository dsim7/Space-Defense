using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class UpgradeSet : ScriptableObject
{
    [SerializeField]
    List<Upgrade> _upgrades;
    public List<Upgrade> upgrades { get { return _upgrades; } }

    int _level = -1;
    public int level
    {
        get
        {
            if (_level == -1)
            {
                int result = 0;
                _upgrades.ForEach(upg => { if (upg.acquired.Value) result++; });
                _level = result;
                return result;
            }
            else
            {
                return _level;
            }
        }
    }

    public void Upgrade(int levels)
    {
        for (int i = 0; i < levels; i++)
        {
            Upgrade toUpgrade = FindNextUpgrade();
            if (toUpgrade != null)
            {
                toUpgrade.DoUpgrade();
            }
        }
    }

    public Upgrade FindNextUpgrade()
    {
        return _upgrades.Find(upg => !upg.acquired.Value);
    }

    public bool HasMoreUpgrades()
    {
        return _upgrades.Any(upg => !upg.acquired.Value);
    }
}
