using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Upgrade
{
    HEALTH,
    R_DAMAGE,
    M_DAMAGE,
    DEFENSE
}

[System.Serializable]
public struct UpgradeButton
{
    public Sprite icon;
    public string name;
    public string currentValue;
    public string newValue;
    public string price;
    public Upgrade upgradeType;
}

[System.Serializable]
public struct BuyButton
{
    public Sprite icon;
    public string name;
    public string price;
}
