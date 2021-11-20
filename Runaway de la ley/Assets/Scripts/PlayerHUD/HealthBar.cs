using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite emptyHeart;
    SpriteRenderer heart1;
    SpriteRenderer heart2;
    SpriteRenderer heart3;
    PlayerHitbox playerHitboxScript;
    void Start()
    {
        heart1 = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        heart2 = gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        heart3 = gameObject.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();
        playerHitboxScript = GameObject.Find("Player").GetComponent<PlayerHitbox>();
    }

    public void showDamage() {
        
        switch (playerHitboxScript.playerHealth) {
        
            case 2:
                heart1.sprite = emptyHeart;
                break;
            case 1:
                heart2.sprite = emptyHeart;
                break;
            case 0:
                heart3.sprite = emptyHeart;
                break;

        }
    
    }
}
