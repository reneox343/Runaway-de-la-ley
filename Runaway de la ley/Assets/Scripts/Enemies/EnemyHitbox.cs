using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Enemy configuration")]
    public float enemyHealth;
    [Header("Coins drop")]
    [Range(0, 700)]
    public int minDrop;
    [Range(0, 700)]
    public int maxDrop;
    private GameObject[] moneyGameobjects = new GameObject[4];
    private int[] coins = { 50, 25, 10, 1 };
    private int[] coinsQuantity = { 0, 0, 0, 0 };
    private bool moneySpawned;


    private void Awake()
    {
        int money = Random.Range(minDrop, maxDrop);
        for (int i = 0; i < 4; i++)
        {

            coinsQuantity[i] = money / coins[i];
            money -= coins[i] * (money / coins[i]);

        }
    }

    private void Start()
    {
        moneyGameobjects[0] = Resources.Load("Prefaps/Money/Diamond") as GameObject;
        moneyGameobjects[1] = Resources.Load("Prefaps/Money/BloodCoin") as GameObject;
        moneyGameobjects[2] = Resources.Load("Prefaps/Money/GoldCoin") as GameObject;
        moneyGameobjects[3] = Resources.Load("Prefaps/Money/SilverCoin") as GameObject;
        moneySpawned = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            
            enemyHealth -= collision.gameObject.GetComponent<BulletHitbox>().BulletDamage;
            Debug.Log(enemyHealth);
            if (enemyHealth <= 0) {

                if (!moneySpawned)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < coinsQuantity[i]; j++)
                        {
                            Instantiate(moneyGameobjects[i], gameObject.transform.position, Quaternion.identity);
                        }
                    }
                    moneySpawned = true;
                }
                Destroy(gameObject);
            } 
        }
    }
}
