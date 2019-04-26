using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoPanel : MonoBehaviour
{
    public WeaponTemplateVariable inspectedWeapon;

    public Text weaponName, info, backButtonText;
    public Image icon, background;
    [Space]
    public Color availableBGColor;
    public Color availableTextColor, unavailableBGColor, unavailableTextColor;
    [Space]
    public BlackMask mask;
    public float fadeOutAmount;

    void Start()
    {
        inspectedWeapon.RegisterPostchangeEvent(UpdateInfo);
        inspectedWeapon.Value = null;

        inspectedWeapon.RegisterPostchangeEvent(UpdateColors);
        inspectedWeapon.RegisterPrechangeEvent(UnobserveWeaponAvailable);
        inspectedWeapon.RegisterPostchangeEvent(ObserveWeaponAvailable);

        gameObject.SetActive(false);
    }

    void ObserveWeaponAvailable()
    {
        if (inspectedWeapon.Value != null)
        {
            inspectedWeapon.Value.available.RegisterPostchangeEvent(UpdateColors);
            UpdateColors();
        }
    }

    void UnobserveWeaponAvailable()
    {
        if (inspectedWeapon.Value != null)
        {
            inspectedWeapon.Value.available.UnregisterPostchangeEvent(UpdateColors);
        }
    }

    void UpdateInfo()
    {
        if (inspectedWeapon.Value != null && !gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            mask.FadeOutPartial(fadeOutAmount);

            weaponName.text = GetBoldedWeaponName();
            info.text = inspectedWeapon.Value.description;
            icon.sprite = inspectedWeapon.Value.icon;
        }
    }

    void UpdateColors()
    {
        if (inspectedWeapon.Value.available.Value)
        {
            background.color = availableBGColor;
            weaponName.color = availableTextColor;
            info.color = availableTextColor;
            backButtonText.color = availableTextColor;
        }
        else
        {
            background.color = unavailableBGColor;
            weaponName.color = unavailableTextColor;
            info.color = unavailableTextColor;
            backButtonText.color = unavailableTextColor;
        }
    }

    string GetBoldedWeaponName()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<B>").Append(inspectedWeapon.Value.weaponName).Append("</B>");
        return sb.ToString();
    }

}
