using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSkinKnife : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 direction;
    private GameObject player;
    private Rigidbody2D rigidBody;
    private Animator redSkinKnifeAnimator;
    private BoxCollider2D knife;
    public float speed;
    public float jumpForce;
    public float distance;
    public bool followOnVisible;
    private bool visible;
    void Start()
    {
        visible = false;
        redSkinKnifeAnimator = gameObject.GetComponent<Animator>();
        knife = gameObject.GetComponentsInChildren<BoxCollider2D>()[1];
        knife.enabled = false;
        player = GameObject.Find("Player");
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!followOnVisible)followPlayer();
        if(followOnVisible && visible) followPlayer(); 
    }

    void followPlayer()
    {
        //finds the direction in with te arrow must be shoot to hit the player
        direction = player.transform.position - gameObject.transform.position;
        direction = new Vector3(direction.x, 0);
        direction = Vector3.Normalize(direction);
        if (Vector2.Distance(player.transform.position, gameObject.transform.position) > distance)
        {
            gameObject.transform.position += direction * speed * Time.deltaTime;
            redSkinKnifeAnimator.SetBool("Attack", false);
        }
        else {

            redSkinKnifeAnimator.SetBool("Attack", true);
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

    private void OnBecameVisible()
    {
        if(followOnVisible)visible = true;
    }

    private void attack() {

        knife.enabled = true;
    }    
    private void stopAttack() {

        knife.enabled = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

}
