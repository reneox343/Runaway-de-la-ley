using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class RedSkinBow : MonoBehaviour
{
    //bow 
    public GameObject bow;
    public GameObject bullet;
    public int delayToshoot;
    private int generalDelay;
    private bool visible = false;

    //get player
    GameObject player;
    //direction in witch the bullet will travel
    Vector3 direction;

    //shoot it is called by an animation event

    private void Start()
    {
        generalDelay = delayToshoot;
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        //finds the direction in with te arrow must be shoot to hit the player
        direction = player.transform.position - gameObject.transform.position;
        direction = new Vector3(direction.x, direction.y);
        direction = Vector3.Normalize(direction);

        if (direction.x <= 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void shoot() {

        if (!visible) return;
        if (generalDelay == delayToshoot )
        {
            Instantiate(bullet, bow.transform.position, Quaternion.identity);
            generalDelay = 0;
        }
        else {
            generalDelay++;
        }
        
    }

    private void OnBecameVisible()
    {
        visible = true;
    }
    private void OnBecameInvisible()
    {
        visible = false;
        generalDelay = 0;
    }
}
