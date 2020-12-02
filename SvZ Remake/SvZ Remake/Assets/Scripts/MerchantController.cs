using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantController : MonoBehaviour
{
    public MerchantType merchantType;

    public List<UpgradeButton> upgradeButtons = new List<UpgradeButton>();
    public List<BuyButton> buyButtons = new List<BuyButton>();

    public Transform shopPanelTransform;

    public GameObject buttonTemplate;

    // Start is called before the first frame update
    void Start()
    {
       //InstantiateButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
    
    private void OnTriggerEnter(Collider _collidedPlayer)
    {
        if (_collidedPlayer != null)
        {
            UIManager.Instance().merchantType = merchantType;
        }
    }
    private void OnTriggerExit(Collider _collidedPlayer)
    {
        if (_collidedPlayer != null)
        {
            UIManager.Instance().merchantType = MerchantType.NULL;
        }
    }

    private void InstantiateButtons()
    {
        if (upgradeButtons.Count > 0)
        {
            for (int i = 0; i < upgradeButtons.Count; i++)
            {
                GameObject buttonObj = Instantiate(buttonTemplate, shopPanelTransform);
                ButtonTemplate test = buttonObj.GetComponent<ButtonTemplate>();
                test.setUpgradeValues(upgradeButtons[i]);
            }
        }
        else if (buyButtons.Count > 0)
        {
            for (int i = 0; i < buyButtons.Count; i++)
            {
                GameObject buttonObj = Instantiate(buttonTemplate, shopPanelTransform);
                ButtonTemplate test = buttonObj.GetComponent<ButtonTemplate>();
                test.setBuyValues(buyButtons[i]);
            }
        }
        
    }
}
