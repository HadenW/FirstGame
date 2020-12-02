using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveStarter : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Button waveStarter;

    private void OnTriggerEnter(Collider _collidedPlayer)
    {
        if (_collidedPlayer != null && gameManager.state == GameState.UPGRADING)
        {
            waveStarter.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider _collidedPlayer)
    {
        if (_collidedPlayer != null)
        {
            waveStarter.gameObject.SetActive(false);
        }
    }
}
