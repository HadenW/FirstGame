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

    public static AllySpawner _instance;

    public static AllySpawner Instance()
    {
        return _instance;
    }


    [System.Serializable]
    public class Ally
    {
        public string name;
        public AllyType type;
        public GameObject prefab;
        public int spawnCost;
        public int health;
        public int damage;
    }

    [SerializeField]
    private Ally[] allies;
    public Ally[] Allies
    {
        get { return allies; }
    }

    [SerializeField]
    private Transform spawnPoint;

    public float updateRate = 2.0f;
    public int maxSpawnValue;

    [SerializeField]
    private int spawnValue;

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
    }
}
