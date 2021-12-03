using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTomahawk : MonoBehaviour
{
    //parabola 
    public float tomahawkImpulseX;
    public float tomahawkImpulseY;
    //Rotation
    public int rotationVelocity;
    //destroy on invisivle
    public bool destroyOnInvisible;
    //destroy timer
    public float destroyTimer;
    //Rotation direction 
    private bool rotation;
    //character script
    [HideInInspector]
    public GameObject parent;
    [HideInInspector]
    public float direction;
    [HideInInspector]
    public float distance;
    [HideInInspector]
    public float xVariation;

    private void Start()
    {
        rotationVelocity *= 100;

        //direction = enemyTomahawkScript.direction.x;
        //distance = enemyTomahawkScript.runtimeDistance;
        if (direction > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(distance + xVariation, tomahawkImpulseY) * gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Impulse);
            rotation = true;

        }
        if (direction < 0)
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-distance + xVariation, tomahawkImpulseY) * gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Impulse);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            rotation = false;
        }
    }
    void Update()
    {
        switch (rotation)
        {
            case true:
                gameObject.transform.eulerAngles -= new Vector3(0, 0, rotationVelocity * Time.deltaTime);
                break;
            case false:
                gameObject.transform.eulerAngles += new Vector3(0, 0, rotationVelocity * Time.deltaTime);
                break;
        }
        //destroy object 
        if (!destroyOnInvisible) 
        {

            if (destroyTimer <= 0)
            {

                Destroy(gameObject);
            }
            else
            {
                destroyTimer -= Time.deltaTime;
            }

        }

    }

    private void OnBecameInvisible()
    {
        if(destroyOnInvisible)Destroy(gameObject);
    }
}
