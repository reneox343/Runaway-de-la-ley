using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class MoneyHitbox : MonoBehaviour
{
    public int value;
    public float despawnTimer;
    private float globalTimer;
    private float flashTimer;
    private SpriteRenderer spriteRenderer;
    private Light2D moneyLight;
    private void Start()
    {
        moneyLight = gameObject.GetComponentInChildren<Light2D>();

        //gets the sprite renderer from the money
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //set timers
        globalTimer = despawnTimer;
        //Makes the money shoot in random directions
        float ramdomDirectionX = Random.Range(-3f, 3f);
        float ramdomDirectionY = Random.Range(3f, 5f);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(ramdomDirectionX, ramdomDirectionY), ForceMode2D.Impulse);
    }

    private void Update()
    {
        globalTimer -= Time.deltaTime;
        flashTimer -= Time.deltaTime;

        if (globalTimer <= 0) Destroy(gameObject);
        if (flashTimer <= 0 && globalTimer <= 3)
        {
            switch (spriteRenderer.enabled)
            {
                case true:
                    spriteRenderer.enabled = false;
                    moneyLight.enabled = false;
                    break;
                case false:
                    spriteRenderer.enabled = true;
                    moneyLight.enabled = true;
                    break;

            }
            if (globalTimer >= 2) {
                flashTimer = 0.5f;
            }
            else if (globalTimer > 1 && globalTimer <2f)
            {
                flashTimer = 0.3f;
            }
            else if (globalTimer <= 1)
            {
                flashTimer = 0.075f;
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {

            Destroy(gameObject);

        }
    }
}
