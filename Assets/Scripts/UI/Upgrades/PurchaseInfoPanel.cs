using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseInfoPanel : MonoBehaviour
{
    public WeaponTemplateVariable inspectedWeapon;
    public IntVariableSO credits;
    [Space]
    public Text cost;
    public Button yesButton;

    void Start()
    {
        inspectedWeapon.RegisterPostchangeEvent(UpdateInfo);
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        if (inspectedWeapon.Value != null && inspectedWeapon.Value.upgradeSet != null)
        {
            int costAmount = inspectedWeapon.Value.cost;

            UpdateText(costAmount);
            UpdateButton(costAmount);
        }
    }

    void UpdateText(int costAmount)
    {
        cost.text = GetCostString(costAmount);
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
}
