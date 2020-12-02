using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [System.Serializable]
    public class Merchant
    {
        public GameObject merchant;
        public GameObject merchantPanel;
    }

    [SerializeField]
    private GameManager gameManager;

    // Value Returned To See Which Merchant Player Is At
    public MerchantType merchantType;

    // For Upgrading
    [SerializeField]
    private Button pressToShopButton;

    // For Disabling HUD
    [SerializeField]
    private GameObject HUDElements;

    // For UI Management
    private GameObject currentMenu;

    public Merchant[] Merchants;

    public static UIManager _instance;

    public static UIManager Instance()
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
        pressToShopButton.onClick.AddListener(TaskOnShopClick);

        // Set Default Value
        merchantType = MerchantType.NULL;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.State == GameState.UPGRADING)
        {
            HandleShopButton();
        }
    }

    void HandleShopButton()
    {
        if (merchantType != MerchantType.NULL && currentMenu == null)
        {
            pressToShopButton.gameObject.SetActive(true);
        }
        else if (merchantType == MerchantType.NULL || currentMenu != null)
        {
            pressToShopButton.gameObject.SetActive(false);
        }
        if (merchantType == MerchantType.NULL && currentMenu != null)
        {
            ExitCurrentUI();
        }
    }

    // Shows UI When Shop Button Is Clicked
    public void TaskOnShopClick()
    {
        ShowMerchantUI(merchantType);
    }

    // Shows UI Based on Merchant Type
    private void ShowMerchantUI(MerchantType type)
    {
        switch (type)
        {
            case MerchantType.HERO:
                {
                    Merchants[0].merchantPanel.SetActive(true);
                    currentMenu = Merchants[0].merchantPanel.gameObject;
                    ActivateHUD(false);
                }
                break;
            case MerchantType.UNIT:
                {
                    Merchants[1].merchantPanel.SetActive(true);
                    currentMenu = Merchants[1].merchantPanel.gameObject;
                    ActivateHUD(false);
                }
                break;
            case MerchantType.ITEM:
                {
                    Merchants[2].merchantPanel.SetActive(true);
                    currentMenu = Merchants[2].merchantPanel.gameObject;
                    ActivateHUD(false);
                }
                break;
            case MerchantType.NULL: // Should Never Be Passed As NULL
                break;
            default:
                break;
        }
    }

    public void ExitCurrentUI()
    {
        currentMenu.SetActive(false);
        ActivateHUD(true);
        currentMenu = null;
    }

    private void ActivateHUD(bool _bool)
    {
        HUDElements.SetActive(_bool);
    }
}
