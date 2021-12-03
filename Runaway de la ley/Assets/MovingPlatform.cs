using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("X Axis Config")]
    public float speedX;
    public float rangeX;

    [Header("Y Axis Config")]
    public float speedY;
    public float rangeY;
    //private variables
    private bool directionX;
    private bool directionY;
    private float originalXPosition;
    private float originalYPosition;

    private void Start()
    {
        originalXPosition = gameObject.transform.position.x;
        originalYPosition = gameObject.transform.position.y;
        directionX = true;
        directionY = true;
    }

    // Update is called once per frame
    void Update()
    {
        checkPlatformDirection();
        movePlatform();
    }
    void checkPlatformDirection() 
    {
        if (gameObject.transform.position.x  >= originalXPosition + rangeX) 
        {
            directionX = false;
        }
        if (gameObject.transform.position.x <=  originalXPosition - rangeX)
        {
            directionX = true;
        }

        if (gameObject.transform.position.y >= originalYPosition + rangeY)
        {
            directionY = false;
        }
        if (gameObject.transform.position.y <= originalYPosition - rangeY)
        {
            directionY = true;
        }

    }

    void movePlatform() {
        //direction X
        if (directionX)
        {
            gameObject.transform.position += new Vector3(speedX, 0, 0) * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position -= new Vector3(speedX, 0, 0) * Time.deltaTime;
        }
        //direction Y
        if (directionY)
        {
            gameObject.transform.position += new Vector3(0, speedY, 0) * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position -= new Vector3(0, speedY, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //direction X
        if (directionX)
        {
            collision.gameObject.transform.position += new Vector3(speedX, 0, 0) * Time.deltaTime;
        }
        else
        {
            collision.gameObject.transform.position -= new Vector3(speedX, 0, 0) * Time.deltaTime;
        }
    }
}
