using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    Image _image;
    Weapon _weapon;

    public Weapon weapon
    {
        get { return _weapon; }

        set
        {
            _weapon = value;
            if (_weapon != null && _weapon.weaponTemplate != null)
            {
                iconImage.sprite = _weapon.weaponTemplate.icon;
            }
        }
    }
    
    public Image iconImage;
    public Image CDImage;
    public WeaponVariable currentWeapon;
    public Color selectedColor;

    void Awake()
    {
        _image = GetComponent<Image>();
        currentWeapon.RegisterPostchangeEvent(SetColor);
    }

    void Update()
    {
        CDImage.fillAmount = 1 - weapon.CurrentCDPercent;
    }

    public void OnPressed()
    {
        currentWeapon.Value = weapon;
    }

    void SetColor()
    {
       _image.color = currentWeapon.Value == weapon ? selectedColor : Color.white;
    }
}
