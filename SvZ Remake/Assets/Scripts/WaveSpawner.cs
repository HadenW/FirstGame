using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject unit;
        public int amount;
        public float rate;
    }

    public Transform spawnPoint;

    public Wave[] waves;
    private int waveIndex = 0;
    public int WaveIndex
    {
        get { return waveIndex + 1; }
    }

    public int unitIndex = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public static WaveSpawner _instance;

    public static WaveSpawner Instance()
    {
        return _instance;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            Debug.LogError("No gameManager Referenced");
            this.enabled = false;
        }

        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveCountdown <= 0)
        {
            if (gameManager.State != GameState.SPAWNING)
            {
                // Start Spawning Current Wave
                StartCoroutine(SpawnWave(waves[waveIndex]));
            }
        }
        else if (gameManager.state == GameState.COUNTING)
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        gameManager.State = GameState.SPAWNING;

        // Spawn
        for (int i = 0; i < _wave.amount; i++)
        {
            SpawnUnit(_wave.unit);

            yield return new WaitForSeconds(1.0f / _wave.rate);
        }

        Debug.Log("Finished Spawning");
        gameManager.State = GameState.WAITING;
        // Set Values For Next Wave
        waveIndex++;
        waveCountdown = timeBetweenWaves;       

        yield break;
    }

    void SpawnUnit (GameObject _unit)
    {
        // Spawn Enemy
        GameObject spawnedUnit = Instantiate(_unit, spawnPoint.position, spawnPoint.rotation);
        // Add Enemy To List
        gameManager.ActiveEnemies.Add(spawnedUnit);       
    }
}
