using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("buttons")]
    public Button[] upgrades = new Button[4];
    public int[] prices = new int[4];
    [HideInInspector]
    public bool[] bought = new bool[4];
    private ShopManager shopManager;
    void Start()
    {
        shopManager = GameObject.Find("ShopCanvas").GetComponent<ShopManager>();

        

        upgrades[0].onClick.AddListener(() => buy(prices[0], 0));
        upgrades[1].onClick.AddListener(() => buy(prices[1], 1));
        upgrades[2].onClick.AddListener(() => buy(prices[2], 2));
        upgrades[3].onClick.AddListener(() => buy(prices[3], 3));

        upgrades[0].GetComponent<ShowPrice>().price = prices[0];
        upgrades[1].GetComponent<ShowPrice>().price = prices[1];
        upgrades[2].GetComponent<ShowPrice>().price = prices[2];
        upgrades[3].GetComponent<ShowPrice>().price = prices[3];
 
    }

    private void Update()
    {
        checkIfBought();
    }
    void buy(int price,int index) {
        if (shopManager.data.money < price) return;
        bought[index] = true;
        upgrades[index].interactable = false;
        shopManager.refreshMoney(price);
        if (bought[0] && bought[1] && bought[2])
        {
            upgrades[3].interactable = true;
        }
    }

    void checkIfBought() {
        upgrades[3].interactable = false;
        if (bought[0])
        {
            upgrades[0].interactable = false;
        }        
        if (bought[1])
        {
            upgrades[1].interactable = false;
        }        
        if (bought[2])
        {
            upgrades[2].interactable = false;
        }

        if (bought[0] && bought[1] && bought[2] && !bought[3])
        {
            upgrades[3].interactable = true;
        }
        else if (bought[0] && bought[1] && bought[2] && bought[3]) 
        {
            upgrades[3].interactable = false;
        }


    }
    
}
