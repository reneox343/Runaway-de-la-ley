using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    //sets the spped of the bullet
    public float speed;
    //sets the ditastance that it will separete from the player
    public float distanceFromPlayerX;

    private float distanceX;

    //get player
    GameObject player;
    //direction in witch the bullet will travel
    Vector3 direction;



    void Start()
    {
        player = GameObject.Find("Player");
        //finds the direction in with te arrow must be shoot to hit the player


    }

    // Update is called once per frame
    void Update()
    {
        //makes the eagle follow the players direction
        direction = player.transform.position - gameObject.transform.position;
        distanceX = Mathf.Abs(direction.x);
        direction = Vector3.Normalize(direction);
        //corrects the axis in witch the eagle will fly to the player
        // usar mas al rato Vector3.Distance(transform.position, target.position) > 1f
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > distanceX)
        {
            gameObject.transform.position += direction * speed * Time.deltaTime;
        }


        //makes the eagle face the players direction
        if (direction.x <= 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }


    }



}
