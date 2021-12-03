using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSkinTomahawk : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject thrower;
    public float attackTimer;
    public float speed;
    public float jumpForce;
    public float distance;
    public bool canJump;
    public bool canFollowPlayer;
    public bool followOnVisible;
    private float globalAttackTimer;
    private GameObject player;
    private Rigidbody2D rigidBody;
    private GameObject enemyTomahawk;
    private bool visibleFollow;
    private bool visible;
    [HideInInspector]
    public float runtimeDistance;
    [HideInInspector]
    public Vector3 direction;
    void Start()
    {
        visibleFollow = false;
        visible = false;
        player = GameObject.Find("Player");
        enemyTomahawk = Resources.Load("Prefaps/EnemyBullets/RedSkinTomahawkTrowable") as GameObject;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        globalAttackTimer = attackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //this is used to follow the player
        if (visibleFollow && followOnVisible) {
            followPlayer();
        }
        if (!followOnVisible) {
            followPlayer();   
        }
        //this is used to attack the player only when he is visible
        if (visible) {
            calculateTimers();
        }
    }

    void launchTomahawk() {
        GameObject temporalTomahawk = Instantiate(enemyTomahawk,thrower.transform.position,Quaternion.identity);
        temporalTomahawk.GetComponent<EnemyTomahawk>().direction = direction.x;
        temporalTomahawk.GetComponent<EnemyTomahawk>().distance = runtimeDistance;
    }

    void followPlayer()
    {
        //finds the direction in with te arrow must be shoot to hit the player
        direction = player.transform.position - gameObject.transform.position;
        direction = new Vector3(direction.x, 0);
        direction = Vector3.Normalize(direction);
        runtimeDistance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (runtimeDistance > distance && canFollowPlayer)
        {
            gameObject.transform.position += direction * speed * Time.deltaTime;
        }
        if (direction.x <= 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }

    private void calculateTimers() {

        if (globalAttackTimer <= 0)
        {
            launchTomahawk();
            globalAttackTimer = attackTimer;
        }
        else {
            globalAttackTimer -= Time.deltaTime;
        }
    
    }

    private void OnBecameVisible()
    {
        launchTomahawk();
        visibleFollow = true;
        visible = true;
    }
    private void OnBecameInvisible()
    {
        visible = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(rigidBody.velocity.y) < 0.001f && canJump)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    }

}
