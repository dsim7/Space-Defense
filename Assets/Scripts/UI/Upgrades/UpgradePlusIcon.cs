using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePlusIcon : MonoBehaviour
{
    Image image;

    [SerializeField]
    Upgrade _upgrade;
    public Upgrade upgrade
    {
        get { return _upgrade; }

        set
        {
            ObserveNewUpgrade(value);
        }
    }

    public Color acquiredColor, notAcquiredColor;

    void Awake()
    {
        image = GetComponent<Image>();
        ObserveNewUpgrade(upgrade);
    }

    void ObserveNewUpgrade(Upgrade value)
    {
        if (_upgrade != null)
        {
            _upgrade.acquired.UnregisterPostchangeEvent(SetFill);
        }
        _upgrade = value;
        if (_upgrade != null)
        {
            _upgrade.acquired.RegisterPostchangeEvent(SetFill);
        }
        SetFill();
    }

    void SetFill()
    {
        if (upgrade != null)
        {
            gameObject.SetActive(true);
            image.color = upgrade.acquired.Value ? acquiredColor : notAcquiredColor;
        }
    }
}
