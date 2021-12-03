using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    //script de Tomahawk

    //parabola 
    public float tomahawkImpulseX;
    public float tomahawkImpulseY;
    //Rotation
    public int rotationVelocity;
    //Rotation direction 
    private bool rotation;
    private bool keeprotating;
    //character script
    private CharacterController playerScript;
    //childern
    public GameObject explosion;


    private void Start()
    {
        keeprotating = true;
        explosion.GetComponent<Animator>().enabled = false;
        explosion.GetComponent<SpriteRenderer>().enabled = false;
        explosion.GetComponent<BoxCollider2D>().enabled = false;
        rotationVelocity *= 100;
        playerScript = GameObject.Find("Player").GetComponent<CharacterController>();

        if (playerScript.playerDirection > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(tomahawkImpulseX, tomahawkImpulseY) * gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Impulse);
            rotation = true;

        }
        if (playerScript.playerDirection < 0)
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-tomahawkImpulseX, tomahawkImpulseY) * gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Impulse);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            rotation = false;
        }
    }
    void Update()
    {
        if (keeprotating) rotate();


    }

    void rotate() {
        switch (rotation)
        {
            case true:
                gameObject.transform.eulerAngles -= new Vector3(0, 0, rotationVelocity * Time.deltaTime);
                break;
            case false:
                gameObject.transform.eulerAngles += new Vector3(0, 0, rotationVelocity * Time.deltaTime);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        keeprotating = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //enable explotion
        explosion.transform.rotation = Quaternion.identity;
        explosion.GetComponent<SpriteRenderer>().enabled = true;
        explosion.GetComponent<Animator>().enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        keeprotating = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //enable explotion
        explosion.transform.rotation = Quaternion.identity;
        explosion.GetComponent<SpriteRenderer>().enabled = true;
        explosion.GetComponent<Animator>().enabled = true;
    }
}
