using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianBoss : MonoBehaviour
{
    //Boss components
    Rigidbody2D rigidBody;
    [Header("Timers")]
    public float attackTimer;
    private float globalAttackTimer;
    [Header("Tomahawk")]
    public GameObject thrower;
    public GameObject enemyTomahawk;
    private Vector3 direction;
    private float runtimeDistance;
    private GameObject player;
    private int attack;
    [Header("Spikes")]
    public GameObject Spikes;
    public float jumpForce;
    public float waitToDecend;
    public float speedToAcend;
    private int colisionCounter;
    private bool keepJumping;
    private bool elevate;
    [Header("Destroy")]
    public GameObject walls;
    public GameObject spawners;

    // Start is called before the first frame update
    void Start()
    {
        keepJumping = true;
        elevate = false;
        colisionCounter = 0;
        player = GameObject.Find("Player");
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        globalAttackTimer = attackTimer;
        attack = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {

        lookAtPlayer();
        calculateTimers();
        //spikes
        if (elevate)
        {
            elevateSpikes();
        }
        else 
        {
            decendSpikes();
        }
    }

    private void jump() 
    {
        if (Mathf.Abs(rigidBody.velocity.y) < 0.001f && keepJumping)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            keepJumping = false;
        }
        
    }
    private void elevateSpikes() 
    {
        if (Spikes.transform.position.y < -0.324f) {
            Spikes.transform.position += new Vector3(0, speedToAcend * Time.deltaTime, 0);
        }

    }    
    private void decendSpikes() 
    {

        if (Spikes.transform.position.y > -0.874f)
        {
            Spikes.transform.position -= new Vector3(0, speedToAcend * Time.deltaTime, 0);
        }

    }
    IEnumerator spikesController()
    {

        elevate = true;
        yield return new WaitForSeconds(waitToDecend);
        elevate = false;
        attack = Random.Range(0, 2);
        keepJumping = true;
    }
    private void calculateTimers()
    {

        if (globalAttackTimer <= 0)
        {
            //change attacks
            switch (attack)
            {
                case 0:
                    spawnTomahawks();
                    break;
                case 1:
                    jump();
                    break;
            }
            globalAttackTimer = attackTimer;
            
        }
        else
        {
            globalAttackTimer -= Time.deltaTime;
        }

    }
    void spawnTomahawks() 
    {
        launchTomahawk(1f);
        launchTomahawk(2f);
        launchTomahawk(-0.5f);
        attack = Random.Range(0, 2);
    }
    void lookAtPlayer()
    {
        //finds the direction in with te arrow must be shoot to hit the player
        direction = player.transform.position - gameObject.transform.position;
        direction = new Vector3(direction.x, 0);
        direction = Vector3.Normalize(direction);
        runtimeDistance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (direction.x <= 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    void launchTomahawk(float xVariaton)
    {
        GameObject temporalTomahawk = Instantiate(enemyTomahawk, thrower.transform.position, Quaternion.identity);
        EnemyTomahawk temporalTomahawkScript = temporalTomahawk.GetComponent<EnemyTomahawk>();
        temporalTomahawkScript.direction = direction.x;
        temporalTomahawkScript.distance = runtimeDistance;
        temporalTomahawkScript.xVariation = xVariaton;
        temporalTomahawkScript.tomahawkImpulseY += 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        colisionCounter++;
        if (colisionCounter != 1) 
        {
            StartCoroutine(spikesController());
        }
    }

    private void OnDestroy()    
    {
        Destroy(spawners);
        Destroy(walls);
        Destroy(Spikes);
    }
}
