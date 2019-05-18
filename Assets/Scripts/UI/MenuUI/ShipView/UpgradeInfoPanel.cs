using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfoPanel : MonoBehaviour
{
    public UpgradeVariable inspectedUpgrade;
    public IntVariableSO credits;
    [Space]
    public Text description;
    public Text cost;
    public Button yesButton;
    [Space]
    public PlayerManager playerSave;

    void Start()
    {
        gameObject.SetActive(false);
        inspectedUpgrade.RegisterPostchangeEvent(UpdateInfo);
    }

    void UpdateInfo()
    {
        if (inspectedUpgrade.Value != null)
        {
            Upgrade upgrade = inspectedUpgrade.Value;
            int costAmount = upgrade.levelCosts[upgrade.level.Value];

            UpdateText(upgrade, costAmount);
            UpdateButton(costAmount);
        }
    }

    void UpdateText(Upgrade upgrade, int costAmount)
    {
        cost.text = GetCostString(costAmount);
        description.text = upgrade.levelDescriptions[upgrade.level.Value];
    }

    void UpdateButton(int costAmount)
    {
        if (credits.Value < costAmount)
        {
            yesButton.enabled = false;
            yesButton.GetComponent<Image>().color = yesButton.colors.disabledColor;
        }
        else
        {
            yesButton.enabled = true;
            yesButton.GetComponent<Image>().color = Color.white;
        }
    }

    string GetCostString(int costAmount)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Cost: ");
        if (credits.Value >= costAmount)
        {
            sb.Append(costAmount);
        }
        else
        {
            sb.Append("<color=#cc0000ff>").Append(costAmount).Append("</color>");
        }
        return sb.ToString();
    }

    public void DoUpgrade()
    {
        Upgrade upgrade = inspectedUpgrade.Value;
        if (upgrade != null)
        {
            credits.Value -= upgrade.levelCosts[upgrade.level.Value];
            upgrade.DoUpgrade();

            // Save
            playerSave.Save();
        }
    }
}
