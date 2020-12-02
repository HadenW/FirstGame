using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeUnit : MonoBehaviour
{
    [SerializeField]
    private AllySpawner allySpawner;

    private AllySpawner.Ally selectedAlly;
    private int allyIndex;

    //UI References
    [SerializeField]
    private TMP_Text unitName;

    [SerializeField]
    private TMP_Text health;

    [SerializeField]
    private TMP_Text damage;

    [SerializeField]
    private float healthMultiplier = 1.3f;

    [SerializeField]
    private float damageMultiplier = 1.3f;


    // Start is called before the first frame update
    void Start()
    {
        allyIndex = 0;
        selectedAlly = allySpawner.Allies[allyIndex];
        UpdateValues();
    }

    public void SelectNextUnit()
    {
        allyIndex++;
        if (allyIndex > allySpawner.Allies.Length - 1)
        {
            allyIndex = 0;
        }
        selectedAlly = allySpawner.Allies[allyIndex];
        UpdateValues();
    }
    public void SelectPreviousUnit()
    {
        allyIndex--;
        if (allyIndex < 0)
        {
            allyIndex = allySpawner.Allies.Length - 1;
        }
        selectedAlly = allySpawner.Allies[allyIndex];
        UpdateValues();
    }

    private void UpdateValues()
    {
        unitName.text = selectedAlly.name;
        health.text = selectedAlly.health.ToString();
        damage.text = selectedAlly.damage.ToString();
    }

    public void UpgradeHealth()
    {
        selectedAlly.health = Convert.ToInt32(selectedAlly.health * healthMultiplier);
        UpdateValues();
    }
    public void UpgradeDamage()
    {
        selectedAlly.damage = Convert.ToInt32(selectedAlly.damage * damageMultiplier);
        UpdateValues();
    }
}
