using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomahawk : MonoBehaviour
{
    //script de Tomahawk

    //parabola 
    public float tomahawkImpulseX;
    public float tomahawkImpulseY;
    //Rotation
    public int rotationVelocity;
    //Rotation direction 
    private bool rotation;
    //character script
    private CharacterController playerScript;
    //AstiMode
    private Gun gunscript;

    private void Start()
    {
        rotationVelocity *= 100;
        //is used to see the direction in witch the tomahawk shot be launched
        playerScript = GameObject.Find("Player").GetComponent<CharacterController>();
        ////it is used to see if the asti mode is active
        //gunscript = GameObject.Find("Player").GetComponent<Gun>();
        ////checks if asti mode is enabled
        //if (gunscript.astiMode)
        //{
        //    tomahawkImpulseX += tomahawkImpulseX * gunscript.astiModeMultiplayer;
        //    tomahawkImpulseY += tomahawkImpulseY * gunscript.astiModeMultiplayer;
        //}

        if (playerScript.playerDirection > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(tomahawkImpulseX, tomahawkImpulseY) * gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Impulse);
            rotation = true;
            
        }
        if (playerScript.playerDirection < 0) {

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-tomahawkImpulseX, tomahawkImpulseY) * gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Impulse);
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

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

