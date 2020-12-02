using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text moneyText;

    private void Start()
    {
        moneyText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        moneyText.text = "Gold: " + GameManager.Money;
    }
}
