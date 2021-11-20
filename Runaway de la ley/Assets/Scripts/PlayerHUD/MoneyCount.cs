using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCount : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerHitbox playerHitbox;
    public TMP_Text money;
    void Start()
    {
        playerHitbox = GameObject.Find("Player").GetComponent<PlayerHitbox>();
    }


    // Update is called once per frame
    void Update()
    {
        money.text = playerHitbox.playerMoney.ToString();

    }
}
