using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoPanel : MonoBehaviour
{
    IDialog dialog;

    public WeaponTemplateVariable inspectedWeapon;
    [Space]
    public Text weaponName, info;
    public Image icon, background;
    [Space]
    public Color availableBGColor;
    public Color availableTextColor, unavailableBGColor, unavailableTextColor;
    [Space]
    public BlackMask mask;
    public float fadeOutAmount;

    void Start()
    {
        dialog = GetComponent<IDialog>();

        inspectedWeapon.RegisterPostchangeEvent(UpdateInfo);

        inspectedWeapon.RegisterPrechangeEvent(UnobserveWeaponAvailable);
        inspectedWeapon.RegisterPostchangeEvent(ObserveWeaponAvailable);

        gameObject.SetActive(false);
    }

    void ObserveWeaponAvailable()
    {
        if (inspectedWeapon.Value != null)
        {
            inspectedWeapon.Value.available.RegisterPostchangeEvent(UpdateColors);
        }
    }

    void UnobserveWeaponAvailable()
    {
        if (inspectedWeapon.Value != null)
        {
            inspectedWeapon.Value.available.UnregisterPostchangeEvent(UpdateColors);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        mask.FadeOutPartial(fadeOutAmount);
        dialog.Appear();
    }

    public void Hide()
    {
        mask.FadeIn();
        dialog.Disappear();
    }
    
    void UpdateInfo()
    {
        if (inspectedWeapon.Value != null && !gameObject.activeSelf)
        {
            Show();

            weaponName.text = GetBoldedWeaponName();
            info.text = inspectedWeapon.Value.description;
            icon.sprite = inspectedWeapon.Value.icon;
        }
    }

    void UpdateColors()
    {
        if (inspectedWeapon.Value != null && inspectedWeapon.Value.available.Value)
        {
            background.color = availableBGColor;
            weaponName.color = availableTextColor;
            info.color = availableTextColor;
        }
        else
        {
            background.color = unavailableBGColor;
            weaponName.color = unavailableTextColor;
            info.color = unavailableTextColor;
        }
    }

    string GetBoldedWeaponName()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<B>").Append(inspectedWeapon.Value.weaponName).Append("</B>");
        return sb.ToString();
    }

}
