using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public int playerHealth = 3;
    [HideInInspector]
    public int playerMoney =0;
    private HealthBar healthBarScript;


    // Update is called once per frame
    private void Start()
    {
        healthBarScript = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        //playerMoney = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "EnemyBullet")
        {
            playerHealth -= 1;
            healthBarScript.showDamage();
            if (playerHealth <= 0) Destroy(gameObject);
        }

        if (playerHealth <= 0) {

            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Money")
        {
            playerMoney += collision.gameObject.GetComponent<MoneyHitbox>().value;
            Destroy(collision.gameObject);
        }
    }

}
