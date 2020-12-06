using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetSpawnButtonValues : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text costText;


    private string pawnName;
    private int cost;
    public void SetValues(string _name, int _cost)
    {
        pawnName = _name;
        cost = _cost;

        nameText.text = pawnName;
        costText.text = cost.ToString();
    }
}
