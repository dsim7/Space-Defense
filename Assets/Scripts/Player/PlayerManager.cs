using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerManager : ScriptableObject
{
    public IntVariableSO credits;
    public List<WeaponTemplate> weapons;
    public List<Upgrade> upgrades;
    public List<Level> levels;
    
    // FOR RESETTING SAVE IN UNITY EDITOR
    //void OnEnable()
    //{
    //    Debug.Log("RESETTING SAVES");
    //    PlayerPrefs.DeleteAll();
    //}

    public void Save()
    {
        Debug.Log("SAVING");

        // Credits
        int creditsSave = credits.Value;
        PlayerPrefs.SetInt("credits", creditsSave);

        // Weapons
        foreach (WeaponTemplate weapon in weapons)
        {
            PlayerPrefs.SetInt(weapon.name, weapon.available.Value ? 1 : 0);
        }
        
        // Upgrades
        foreach (Upgrade upgrade in upgrades)
        {
            PlayerPrefs.SetInt(upgrade.name, upgrade.level.Value);
        }

        // Levels
        foreach (Level level in levels)
        {
            PlayerPrefs.SetInt(level.name, level.available.Value ? 1 : 0);
        }
    }

    public void Load()
    {
        // Credits
        int creditsLoad = PlayerPrefs.GetInt("credits");
        credits.Value = creditsLoad;

        // Weapons
        foreach (WeaponTemplate weapon in weapons)
        {
            weapon.available.Value = PlayerPrefs.GetInt(weapon.name) != 0;
        }
        weapons[0].available.Value = true;

        // Upgrades
        foreach (Upgrade upgrade in upgrades)
        {
            upgrade.level.Value = PlayerPrefs.GetInt(upgrade.name);
        }

        // Levels
        foreach (Level level in levels)
        {
            level.available.Value = PlayerPrefs.GetInt(level.name) != 0;
        }
        levels[0].available.Value = true;
    }
}
