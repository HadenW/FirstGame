using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;
    public GameState State
    {
        get { return state; }
        set { state = value; }
    }

    public static int Money = 0;

    public List<GameObject> activeEnemies = new List<GameObject>();
    public List<GameObject> ActiveEnemies
    {
        get { return activeEnemies; }
    }

    // How Often Searching For Alive Enemies
    private float searchCountdown = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static GameManager Instance()
    {
        return instance;
    }

    private void Start()
    {
        state = GameState.COUNTING;
    }

    private void Update()
    {
        switch (state)
        {
            case GameState.SPAWNING:
                break;
            case GameState.UPGRADING:
                break;
            case GameState.WAITING:
                {
                    // Check if enemies are alive
                    if (!EnemyIsAlive())
                    {
                        Debug.Log("Checking if alive");
                        // If No Enemies Finish Wave
                        StartUpgradeState();
                    }
                    else
                    {
                        return;
                    }
                }
                break;
            default:
                break;
        }
    }

    public void StartNextWave()
    {
        state = GameState.COUNTING;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        // Check for enemies
        if (searchCountdown <= 0.0f)
        {
            searchCountdown = 1.0f;
            if (activeEnemies.Count == 0)
            {
                return false;
            }
        }
        return true;
    }

    void StartUpgradeState()
    {
        Debug.Log("Now Upgrading");
        state = GameState.UPGRADING;
    }

    public static void DestroyPlayer(PlayerController _player)
    {
        Destroy(_player.gameObject);
    }

    public static void DestroyEnemy(Enemy _enemy)
    {
        instance.activeEnemies.Remove(_enemy.gameObject);

        Money += _enemy.MoneyAmount;

        Destroy(_enemy.gameObject);
    }
}
