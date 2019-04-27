using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInspector : MonoBehaviour
{
    Image _image;
    Image image {  get { if (_image == null) _image = GetComponent<Image>(); return _image; } }

    [SerializeField]
    WeaponTemplate _weapon;
    public WeaponTemplate weapon { get { return _weapon; } set { _weapon = value; UpdateWeapon(); } }
    public WeaponTemplateVariable inspectedWeapon;
    public UpgradeVariable inspectedUpgrade;
    public Image icon;
    public GameObject purchaseIcon;
    [Space]
    public Color availableColor;
    public Color unavailableColor;

    void Start()
    {
        UpdateWeapon();
    }

    void UpdateWeapon()
    {
        if (weapon != null)
        {
            icon.sprite = weapon.icon;

            weapon.available.RegisterPostchangeEvent(UpdateColor);
        }
    }

    void UpdateColor()
    {
        if (!weapon.available.Value)
        {
            image.color = unavailableColor;
            purchaseIcon.SetActive(true);
        }
        else
        {
            image.color = availableColor;
            purchaseIcon.SetActive(false);
        }
    }

    public void InspectWeapon()
    {
        inspectedWeapon.Value = weapon;
        inspectedUpgrade.Value = weapon.upgrade;
    }
}
