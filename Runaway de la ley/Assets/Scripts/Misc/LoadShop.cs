using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadShop : MonoBehaviour
{
    private PlayerHitbox playerHitbox;

    private void Start()
    {
        playerHitbox = GameObject.Find("Player").GetComponent<PlayerHitbox>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerData data = SaveSystemDataPlayer.loadPlayerData();
            SaveSystemDataPlayer.savePlayerData(data.level, playerHitbox.playerMoney, data.astiModeUpgrades, data.revolversUpgrades, data.shootgunUpgrades, data.trowablesUpgrades);
            if (data.level == 7)
            {
                SceneManager.LoadScene(0);
            }
            else {
                SceneManager.LoadScene(2);
            }
            
        }
    }
}
