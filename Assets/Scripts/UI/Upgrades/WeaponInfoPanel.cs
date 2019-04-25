using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoPanel : MonoBehaviour
{
    public WeaponTemplateVariable inspectedWeapon;

    public Text weaponName, info;
    public Image icon;
    public UpgradeView upgradeView;

    void Start()
    {
        inspectedWeapon.RegisterPostchangeEvent(UpdateInfo);
        gameObject.SetActive(false);
    }

    void UpdateInfo()
    {
        gameObject.SetActive(true);
        if (inspectedWeapon.Value != null)
        {
            weaponName.text = GetBoldedWeaponName();
            info.text = inspectedWeapon.Value.description;
            icon.sprite = inspectedWeapon.Value.icon;
            upgradeView.upgradeSet = inspectedWeapon.Value.upgradeSet;
        }
    }

    string GetBoldedWeaponName()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<B>").Append(inspectedWeapon.Value.weaponName).Append("</B>");
        return sb.ToString();
    }

}
