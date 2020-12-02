using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatTracker : MonoBehaviour
{
    // Get Reference To Access Player Stats
    private PlayerController playerRef;

    public TMP_Text health;
    public TMP_Text meleeDamage;
    public TMP_Text rangedDamage;

    private void Start()
    {
        playerRef = FindObjectOfType<PlayerController>();
    }

    public void SetStatTracker()
    {
        health.text = playerRef.stats.maxHealth.ToString();
        meleeDamage.text = playerRef.stats.meleeDamage.ToString();
        rangedDamage.text = playerRef.stats.rangedDamage.ToString();
    }

    private void FixedUpdate()
    {
        SetStatTracker();
    }
}
