using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AllyType
{
    NORMAL,
    TANK,
    RANGED
}

public class AllySpawner : MonoBehaviour
{

    [SerializeField]
    private SpawnBar spawnBar;

    private GameManager gameManager;


    [System.Serializable]
    public class Ally
    {
        public string pawnName;
        public AllyType type;
        public GameObject prefab;
        public int spawnCost;
        //public int health;
        //public int damage;
    }

    [SerializeField]
    private Ally[] allies;
    public Ally[] Allies
    {
        get { return allies; }
    }

    [SerializeField]
    private GameObject buttonParentUI;
    [SerializeField]
    private GameObject allyButtonPrefab;

    [SerializeField]
    private List<GameObject> allyUIButtons = new List<GameObject>();

    [SerializeField]
    private Transform spawnPoint;

    public float updateRate = 2.0f;
    public int maxSpawnValue;

    [SerializeField]
    private int spawnValue;                 // The Current Value Of The Spawning Value

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();

        spawnBar.SetMaxValue(maxSpawnValue);
        InvokeRepeating("UpdateSpawnBar", 1.0f / updateRate, 1.0f / updateRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateSpawnBar()
    {        
        if (spawnBar.slider.value >= spawnBar.slider.maxValue)
        {
            // Do Nothing
        }
        else
        {
            spawnValue++;
            spawnBar.SetCurrentValue(spawnValue);
        }        
    }

    public void SpawnTank()
    {
        AllyType type;

        type = allies[0].type;

        if (gameManager.state == GameState.UPGRADING)
        {

        }
        else if (gameManager.state != GameState.UPGRADING)
        {
            if (type == AllyType.TANK)
            {
                if (spawnValue >= allies[0].spawnCost)
                {
                    GameObject obj = Instantiate(allies[0].prefab, spawnPoint.position, Quaternion.identity);

                    spawnValue -= allies[0].spawnCost;
                    spawnBar.SetCurrentValue(spawnValue);
                }
                else
                {
                    Debug.Log("Not Enough Spawning Points");
                }
            }
        }              

        // ----- Not Needed Proper Function Above -----

        /*
        for (int i = 0; i < allies.Length; i++)
        {
            if (gameManager.state == GameState.UPGRADING)
            {
                break;
            }

            type = allies[i].type;

            if (type == AllyType.TANK)
            {
                if (spawnValue >= allies[i].spawnCost)
                {
                    GameObject obj = Instantiate(allies[i].prefab, spawnPoint.position, Quaternion.identity);
                    //obj.GetComponent<TankAlly>().SetStats(allies[i]);

                    spawnValue -= allies[i].spawnCost;
                    spawnBar.SetCurrentValue(spawnValue);
                }
                else
                {
                    Debug.Log("Not Enough Spawning Points");
                }
            }
        }
        */
    }

    public void UpdateButtons()
    {
        for (int i = 0; i < allyUIButtons.Count; i++)
        {
            DestroyImmediate(allyUIButtons[i]);
        }

        allyUIButtons.Clear();

        // For Setting Up The UI For The Spawning Buttons With The Proper Information For Each Ally
        for (int i = 0; i < allies.Length; i++)
        {
            GameObject lButton = Instantiate(allyButtonPrefab, buttonParentUI.transform);
            lButton.transform.SetParent(buttonParentUI.transform, false);
            lButton.GetComponent<SetSpawnButtonValues>().SetValues(allies[i].pawnName, allies[i].spawnCost);
            allyUIButtons.Add(lButton);
        }
    }
}
