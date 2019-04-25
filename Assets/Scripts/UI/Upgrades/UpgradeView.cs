using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField]
    UpgradePlusIcon[] pluses;

    [SerializeField]
    UpgradeSet _upgradeSet;
    public UpgradeSet upgradeSet
    {
        get { return _upgradeSet; }

        set
        {
            _upgradeSet = value;
            ToggleButton();
            SetUpPluses();
        }
    }

    public Button upgradeButton;
    public Transform plusesPanel;
    public PromptPanel prompt;

    void Start()
    {
        ToggleButton();
    }

    public void PromptUpgrade()
    {
        prompt.Prompt(DoUpgrade);
    }

    void DoUpgrade()
    {
        if (_upgradeSet != null)
        {
            _upgradeSet.Upgrade(1);
            ToggleButton();
        }
    }

    void SetUpPluses()
    {
        if (upgradeSet == null)
        {
            foreach (UpgradePlusIcon plus in pluses)
            {
                plus.gameObject.SetActive(false);
            }
            return;
        }

        for (int i = 0; i < pluses.Length; i++)
        {
            if (i < upgradeSet.upgrades.Count)
            {
                pluses[i].gameObject.SetActive(true);
                pluses[i].upgrade = upgradeSet.upgrades[i];
            }
            else
            {
                pluses[i].gameObject.SetActive(false);
            }
        }
    }

    void ToggleButton()
    {
        if (_upgradeSet == null || !_upgradeSet.HasMoreUpgrades())
        {
            upgradeButton.gameObject.SetActive(false);
        }
        else
        {
            upgradeButton.gameObject.SetActive(true);
        }
    }
}
