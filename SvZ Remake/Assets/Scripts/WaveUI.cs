using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveUI : MonoBehaviour
{
    [SerializeField]
    WaveSpawner spawner;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    private TMP_Text waveNumber;

    //[SerializeField]
    //Button startWaveButton;

    private GameState previousState;

    // Start is called before the first frame update
    void Start()
    {
        if (spawner == null)
        {
            Debug.LogError("No Spawner Referenced");
            this.enabled = false;
        }
        if (gameManager == null)
        {
            Debug.LogError("No gameManager Referenced");
            this.enabled = false;
        }
        if (waveNumber == null)
        {
            Debug.LogError("No waveNumber Referenced");
            this.enabled = false;
        }
        /*
        if (startWaveButton == null)
        {
            Debug.LogError("No startWaveButton Referenced");
            this.enabled = false;
        }
        */
    }

    void Update()
    {
        switch (gameManager.State)
        {
            case GameState.UPGRADING:
                {
                    SetWaveNumber();
                }
                break;
            case GameState.WAITING:
                {

                }
                break;
            default:
                break;
        }
        previousState = gameManager.State;
    }
    /*
    private void OnTriggerEnter(Collider _collidedPlayer)
    {
        if (_collidedPlayer != null && gameManager.State == GameState.UPGRADING)
        {
            // Show UI To Start Next Wave
            startWaveButton.gameObject.SetActive(true);
        }
    }
    */
    /*
    private void OnTriggerExit(Collider _collidedPlayer)
    {
        if (_collidedPlayer != null && gameManager.State == GameState.UPGRADING)
        {
            // Show UI To Start Next Wave
            startWaveButton.gameObject.SetActive(false);
        }
    }
    */

    void SetWaveNumber()
    {
        if (previousState != GameState.UPGRADING)
        {
            waveNumber.text = "Wave " + spawner.WaveIndex.ToString();
        }
        
    }
}
