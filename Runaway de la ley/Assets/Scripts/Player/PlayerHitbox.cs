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
    public int playerMoney;
    //invensivility
    public float invencibilityTimer;
    public float invincibilityEffectTimer;
    private float invencibilityGlobalTimer;
    //player sprite renderer
    private SpriteRenderer playerSpriteRenderer;
    //health bar
    private HealthBar healthBarScript;
    //audio
    private AudioSource playerAudioSource;
    //gun script
    private Gun gunScript;
    //current data
    private CurrentPlayerData currentData;
    //invensibility flag
    private bool invencibility;
    //astimode flag
    private bool astiModeUpgrade;
    //player curret data
    // Update is called once per frame
    private void Start()
    {
        

        astiModeUpgrade = false;
        invencibility = false;
        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        healthBarScript = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        gunScript = gameObject.GetComponent<Gun>();
        currentData =gameObject.GetComponent<CurrentPlayerData>();
        playerMoney = currentData.data.money;
        playerAudioSource = gameObject.GetComponent<AudioSource>();
    }   

    private void astiModeUpgradesPlayerHitbox()
    {
        if (currentData.data.astiModeUpgrades[3] && gunScript.astiMode && !astiModeUpgrade)
        {
            invencibilityGlobalTimer = currentData.astiModeInvencibilityUpgrade;
            InvokeRepeating("invincibilityEffectCaller", 0, invincibilityEffectTimer * 2);
            invencibility = true;
            astiModeUpgrade = true;
        }

        if (currentData.data.astiModeUpgrades[3] && !gunScript.astiMode && astiModeUpgrade)
        {
            astiModeUpgrade = false;
            invencibility = false;
        }
    }

    private void Update()
    {
        calculateTimers();

        astiModeUpgradesPlayerHitbox();

    }


    void calculateTimers()
    {

        if (invencibilityGlobalTimer > 0)
        {
            invencibilityGlobalTimer -= Time.deltaTime;
           
        }
        else
        {
            invencibility = false;
            CancelInvoke();
        }
    }

    void invincibilityEffectCaller() {
        StartCoroutine(invincibilityEffect());
    }
    IEnumerator invincibilityEffect()
    {

        playerSpriteRenderer.enabled = false;

        yield return new WaitForSeconds(invincibilityEffectTimer);


        playerSpriteRenderer.enabled = true;
    }    
    IEnumerator invincibilityEffectAstiModeUpgrade()
    {

        playerSpriteRenderer.enabled = false;

        yield return new WaitForSeconds(invincibilityEffectTimer);


        playerSpriteRenderer.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" && invencibilityGlobalTimer <= 0)
        {
            if (invencibility) return;
            playerHealth -= 1;
            healthBarScript.showDamage();
            if (playerHealth <= 0) Destroy(gameObject);
            InvokeRepeating("invincibilityEffectCaller", 0, invincibilityEffectTimer * 2);
            invencibility = true;
            invencibilityGlobalTimer = invencibilityTimer;
        }

        if (playerHealth <= 0) {

            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Money")
        {
            MoneyHitbox moneyHitboxScript = collision.gameObject.GetComponent<MoneyHitbox>();
            playerMoney += moneyHitboxScript.value;
            playerAudioSource.PlayOneShot(moneyHitboxScript.soundEfect);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EnemyBullet" && invencibilityGlobalTimer <= 0)
        {
            if (invencibility) return;
            playerHealth -= 1;
            healthBarScript.showDamage();
            if (playerHealth <= 0) Destroy(gameObject);
            InvokeRepeating("invincibilityEffectCaller", 0, invincibilityEffectTimer * 2);
            invencibility = true;
            invencibilityGlobalTimer = invencibilityTimer;
        }


        if (playerHealth <= 0)
        {

            SceneManager.LoadScene(0);
        }
    }

}
