using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetSpawnButtonValues : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text costText;

    private string pawnName;

    // DONT KNOW WHY 
    // 'PREFAB' VARIABLE MUST BE PUBLIC OR IT ALWAYS RUNS AS 0
    [SerializeField]
    private int cost;

    // DONT KNOW WHY 
    // 'PREFAB' VARIABLE MUST BE PUBLIC OR IT ALWAYS RUNS AS NULL
    [SerializeField]
    private GameObject prefab;

    public void SetValues(string _name, int _cost, GameObject _prefab)
    {
        pawnName = _name;
        cost = _cost;
        prefab = _prefab;

        nameText.text = pawnName;
        costText.text = cost.ToString();
    }

    public void OnButtonPress()
    {
        AllySpawner script = GameObject.FindGameObjectWithTag("GameController").GetComponent<AllySpawner>();
        script.SpawnAlly(prefab, cost);

    }
}
