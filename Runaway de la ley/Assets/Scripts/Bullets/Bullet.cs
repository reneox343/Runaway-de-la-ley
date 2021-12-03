using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Defines the range of the bullet
    [SerializeField]
    public float rangeX;
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
    //ramdom direction
    private float randomDirection;
    //ramdom direction variation
    public float ramdomDirectionVariation;
    //AstiMode
    private Gun gunscript;
    [Header("Pellets")]
    //pellets
    public bool isPellet;
    public bool pelletsEnabled;
    public int amountOfPellets;
    public GameObject pellets;
    [SerializeField]
    public int direction;
    void Start()
    {
        //give the bullet a random direction 
        randomDirection =  Random.Range(-ramdomDirectionVariation, ramdomDirectionVariation);
        //find the original X axis position in wich the bullet was fired
        OriginalX = gameObject.transform.position.x;
        OriginalY = gameObject.transform.position.y;
        //Destroy(gameObject,bulletTimer);
        
        playerScript = GameObject.Find("Player").GetComponent<CharacterController>();

        if(!isPellet) direction = playerScript.playerDirection;

        //finds the direction the character is looking to fire the bullet
        switch (direction)
        {
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
            case 3:
                bulletDirection = 3;
                gameObject.transform.eulerAngles = new Vector3(0, 0, -40);
                break;
            case -3:
                bulletDirection = -3;
                gameObject.transform.eulerAngles = new Vector3(0, 0, -120);
                break;

        }
        //get players gunscript
        gunscript = GameObject.Find("Player").GetComponent<Gun>();
        //checks if asti mode is enabled
        if (gunscript.astiMode)
        {
            bulletSpeed += bulletSpeed * gunscript.astiModeMultiplayer;
            rangeX += rangeX * gunscript.astiModeMultiplayer;
        }


    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();
    }
    void moveBullet()
    {

        switch (bulletDirection)
        {
            case 1:
                gameObject.transform.position += new Vector3(bulletSpeed, randomDirection, 0) * Time.deltaTime;
                if (gameObject.transform.position.x >= OriginalX + rangeX)
                {
                    createPellet();
                    Destroy(gameObject);
                }
                    
                break;
            case -1:
                gameObject.transform.position -= new Vector3(bulletSpeed, randomDirection, 0) * Time.deltaTime;
                if (gameObject.transform.position.x <= OriginalX - rangeX) 
                {
                    createPellet();
                    Destroy(gameObject);
                } 
                break;
            case 2:
                gameObject.transform.position += new Vector3(bulletSpeed, bulletSpeed +randomDirection, 0) * (0.5f) * Time.deltaTime;
                if ((gameObject.transform.position.x >= OriginalX + (rangeX * 0.5)) && (gameObject.transform.position.y >= OriginalY + (rangeX * 0.5))) 
                {
                    createPellet();
                    Destroy(gameObject);
                } 
                break;
            case -2:
                gameObject.transform.position += new Vector3(-bulletSpeed, bulletSpeed +randomDirection, 0) * (0.5f) * Time.deltaTime;
                if ((gameObject.transform.position.x <= OriginalX - (rangeX * 0.5)) && (gameObject.transform.position.y >= OriginalY + (rangeX * 0.5))) 
                {
                    createPellet();
                    Destroy(gameObject);
                } 
                break;            
            case 3:
                gameObject.transform.position += new Vector3(bulletSpeed, -bulletSpeed + randomDirection, 0) * (0.5f) * Time.deltaTime;
                if ((gameObject.transform.position.x >= OriginalX + (rangeX * 0.5)) && (gameObject.transform.position.y >= OriginalY + (rangeX * 0.5))) 
                {
                    createPellet();
                    Destroy(gameObject);
                } 
                break;
            case -3:
                gameObject.transform.position += new Vector3(-bulletSpeed, -bulletSpeed +randomDirection, 0) * (0.5f) * Time.deltaTime;
                if ((gameObject.transform.position.x <= OriginalX - (rangeX * 0.5)) && (gameObject.transform.position.y >= OriginalY + (rangeX * 0.5))) 
                {
                    createPellet();
                    Destroy(gameObject);
                } 
                break;
        }
    }
    void createPellet() {
        for (int i = 0; i < amountOfPellets && pelletsEnabled; i++)
        {
            GameObject pellet = Instantiate(pellets, gameObject.transform.position, Quaternion.identity);
            pellet.GetComponent<Bullet>().isPellet = true;
            pellet.GetComponent<Bullet>().direction = bulletDirection;
        }

    }

}

