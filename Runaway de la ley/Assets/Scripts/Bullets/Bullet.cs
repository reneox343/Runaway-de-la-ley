using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Defines the range of the bullet
    [SerializeField]
    private float rangeX;
    //Defines how fast the bullet will travel
    [SerializeField]
    private float bulletSpeed;
    //character controller scritp
    private CharacterController playerScript;
    //direction in witch the bullet will travel on the X axis
    private int bulletDirection;
    //find the original X axis position
    private float OriginalX;    
    //find the original X axis position
    private float OriginalY;
    void Start()
    {
        //find the original X axis position in wich the bullet was fired
        OriginalX = gameObject.transform.position.x;
        OriginalY = gameObject.transform.position.y;
        //Destroy(gameObject,bulletTimer);
        playerScript = GameObject.Find("Player").GetComponent<CharacterController>();
        //finds the direction the character is looking to fire the bullet
        switch (playerScript.playerDirection) {
            case 1:
                bulletDirection = 1;
                break;
            case -1:
                bulletDirection = -1;
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                break;
            case 2:
                bulletDirection = 2;
                gameObject.transform.eulerAngles = new Vector3(0, 0, 40);
                break;
            case -2:
                bulletDirection = -2;
                gameObject.transform.eulerAngles = new Vector3(0, 0, 120);
                break;
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();


    }
    void moveBullet() {
        switch (bulletDirection)
        {
            case 1:
                gameObject.transform.position += new Vector3(bulletSpeed, 0, 0) * Time.deltaTime;
                if (gameObject.transform.position.x >= OriginalX + rangeX) Destroy(gameObject);
                break;
            case -1:
                gameObject.transform.position -= new Vector3(bulletSpeed, 0, 0) * Time.deltaTime;
                if (gameObject.transform.position.x <= OriginalX - rangeX) Destroy(gameObject);
                break;
            case 2:
                gameObject.transform.position += new Vector3(bulletSpeed, bulletSpeed, 0) * (0.5f) * Time.deltaTime;
                if ((gameObject.transform.position.x >= OriginalX + (rangeX*0.5)) && (gameObject.transform.position.y >= OriginalY + (rangeX * 0.5))) Destroy(gameObject);
                break;
            case -2:
                gameObject.transform.position += new Vector3(-bulletSpeed, bulletSpeed, 0) * (0.5f) * Time.deltaTime;
                if ((gameObject.transform.position.x <= OriginalX - (rangeX * 0.5)) && (gameObject.transform.position.y >= OriginalY + (rangeX * 0.5))) Destroy(gameObject);
                break;
        }
    }

}

    