using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWeaponButton : MonoBehaviour
{
    Image _image;
    Image image {  get { if (_image == null) _image = GetComponent<Image>(); return _image; } }

    [SerializeField]
    WeaponTemplate _weapon;
    public WeaponTemplate weapon { get { return _weapon; } set { _weapon = value; UpdateWeapon(); } }
    public WeaponTemplateVariable inspectedWeapon;
    public Image icon;
    [Space]
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
            if (!weapon.available.Value)
            {
                image.color = unavailableColor;
            }
        }
    }

    public void InspectWeapon()
    {
        inspectedWeapon.Value = weapon;
    }
}
