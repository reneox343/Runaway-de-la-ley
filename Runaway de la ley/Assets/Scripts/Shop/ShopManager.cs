using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public PlayerData data;
    public GameObject[] upgradeManagers = new GameObject[4];
    public Button continueButton;
    private Upgrades[] upgradesScripts = new Upgrades[4];
    public TMP_Text moneyText;
    public bool returnTomenu;
    
    

    private void Start()
    {
        continueButton.onClick.AddListener(continueButtonListener);
        for (int i = 0; i < 4; i++) 
        {
            upgradesScripts[i] = upgradeManagers[i].GetComponent<Upgrades>();
        }
        upgradesScripts[0].bought = data.astiModeUpgrades;
        upgradesScripts[1].bought = data.revolversUpgrades;
        upgradesScripts[2].bought = data.shootgunUpgrades;
        upgradesScripts[3].bought = data.trowablesUpgrades;
        moneyText.text = data.money.ToString();
    }

    public void refreshMoney(int price)
    {
        data.money -= price;
        moneyText.text = data.money.ToString();
    }

    private void Awake()
    {
        data = SaveSystemDataPlayer.loadPlayerData();
    }

    private void continueButtonListener() {
        if (returnTomenu)
        {
            SaveSystemDataPlayer.savePlayerData(data.level, data.money, upgradesScripts[0].bought, upgradesScripts[1].bought, upgradesScripts[2].bought, upgradesScripts[3].bought);
            SceneManager.LoadScene(0);

        }
        else 
        { 
            SaveSystemDataPlayer.savePlayerData(data.level+1, data.money, upgradesScripts[0].bought, upgradesScripts[1].bought, upgradesScripts[2].bought, upgradesScripts[3].bought);
            SceneManager.LoadScene(data.level + 1);
        }
    }

}
