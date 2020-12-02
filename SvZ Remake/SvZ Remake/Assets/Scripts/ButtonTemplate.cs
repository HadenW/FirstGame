using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonTemplate : MonoBehaviour
{
    public Button button;

    public Image icon;
    public TMP_Text tittle;
    public TMP_Text currentValue;
    public TMP_Text newValue;
    public TMP_Text price;
    public Upgrade upgradeType;

    public void setUpgradeValues(UpgradeButton _upgradeButton)
    {
        icon.sprite = _upgradeButton.icon;
        tittle.text = _upgradeButton.name;
        currentValue.text = _upgradeButton.currentValue;
        newValue.text = _upgradeButton.newValue;
        price.text = _upgradeButton.price;
        upgradeType = _upgradeButton.upgradeType;
    }

    public void setBuyValues(BuyButton _buyButton)
    {
        icon.sprite = _buyButton.icon;
        tittle.text = _buyButton.name;
        price.text = _buyButton.price;
    }
}
