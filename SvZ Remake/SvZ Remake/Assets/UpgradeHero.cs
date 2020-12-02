using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeHero : MonoBehaviour
{
    PlayerController playerRef;

    //UI References
    [SerializeField]
    private TMP_Text health;

    [SerializeField]
    private TMP_Text newHealth;
    private float newHealthValue;

    [SerializeField]
    private TMP_Text meleeDamage;    

    [SerializeField]
    private TMP_Text newMeleeDamage;
    private float newMeleeValue;

    [SerializeField]
    private TMP_Text rangedDamage;

    [SerializeField]
    private TMP_Text newRangedDamage;
    private float newRangedValue;

    [SerializeField]
    private float healthMultiplier = 1.3f;

    [SerializeField]
    private float damageMultiplier = 1.3f;

    [SerializeField]
    private int healthPrice;

    [SerializeField]
    private TMP_Text healthPriceText;

    [SerializeField]
    private int meleeDamagePrice;

    [SerializeField]
    private TMP_Text meleePriceText;

    [SerializeField]
    private int rangedDamagePrice;

    [SerializeField]
    private TMP_Text rangedPriceText;

    [SerializeField]
    private float priceMultiplier = 1.1f;

    private void Start()
    {
        playerRef = FindObjectOfType<PlayerController>();

        InitializeValues();
    }

    void InitializeValues()
    {
        newHealthValue = playerRef.stats.maxHealth;
        newMeleeValue  = playerRef.stats.meleeDamage;
        newRangedValue = playerRef.stats.rangedDamage;

        health.text       = newHealthValue.ToString();
        meleeDamage.text  = newMeleeValue. ToString();
        rangedDamage.text = newRangedValue.ToString();

        newHealthValue = Mathf.Round(newHealthValue * healthMultiplier);
        newMeleeValue  = Mathf.Round(newMeleeValue  * damageMultiplier);
        newRangedValue = Mathf.Round(newRangedValue * damageMultiplier);

        newHealth.text       = newHealthValue.ToString();
        newMeleeDamage.text  = newMeleeValue. ToString();
        newRangedDamage.text = newRangedValue.ToString();

        healthPriceText.text = healthPrice.      ToString();
        meleePriceText.text  = meleeDamagePrice. ToString();
        rangedPriceText.text = rangedDamagePrice.ToString();
    }

    public void UpgradeHealth()
    {
        if (GameManager.Money >= healthPrice)
        {
            GameManager.Money -= healthPrice;
            health.text        = newHealthValue.ToString();
            playerRef.stats.maxHealth    = Convert.ToInt32(newHealthValue);
            newHealthValue     = Mathf.Round(newHealthValue * healthMultiplier);
            newHealth.text     = newHealthValue.ToString();

            healthPrice = Convert.ToInt32(Mathf.Round(healthPrice * priceMultiplier));
            healthPriceText.text = healthPrice.ToString();
        }      
    }
    public void UpgradeMeleeDamage()
    {
        if (GameManager.Money >= meleeDamagePrice)
        {
            GameManager.Money -= meleeDamagePrice;
            meleeDamage.text = newMeleeValue.ToString();
            playerRef.stats.meleeDamage = Convert.ToInt32(newMeleeValue);
            newMeleeValue = Mathf.Round(newMeleeValue * damageMultiplier);
            newMeleeDamage.text = newMeleeValue.ToString();

            meleeDamagePrice = Convert.ToInt32(Mathf.Round(meleeDamagePrice * priceMultiplier));
            meleePriceText.text = meleeDamagePrice.ToString();
        }        
    }
    public void UpgradeRangedDamage()
    {
        if (GameManager.Money >= rangedDamagePrice)
        {
            GameManager.Money -= rangedDamagePrice;
            rangedDamage.text = newRangedValue.ToString();
            playerRef.stats.rangedDamage = Convert.ToInt32(newRangedValue);
            newRangedValue = Mathf.Round(newRangedValue * damageMultiplier);
            newRangedDamage.text = newRangedValue.ToString();

            rangedDamagePrice = Convert.ToInt32(Mathf.Round(rangedDamagePrice * priceMultiplier));
            rangedPriceText.text = rangedDamagePrice.ToString();
        }        
    }
}
