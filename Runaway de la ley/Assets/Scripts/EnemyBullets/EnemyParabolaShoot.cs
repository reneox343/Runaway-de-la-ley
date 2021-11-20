using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParabolaShoot : MonoBehaviour
{
    public float speed = 10f;
    //public GameObject particleOnCol;

    //public Vector3 testVector;

    private Transform target;
    public Vector3 landingPos;
    private float landingPosX;
    private float landingPosZ;
    private float startingPosY;
    bool isInFirstStage = true;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        landingPos = target.transform.position;
        landingPosX = target.transform.position.x;
        landingPosZ = target.transform.position.z;
        startingPosY = transform.position.y;
        Invoke("ChangeStage", 0.5f); //end of first half of parabola.

    }

    void Update()
    {
        if (isInFirstStage == true)
        {
            GetPosStart();
        }
        else
        {
            MoveToTarget();
        }
    }

    void MoveToTarget() //falling part of the ball
    {
        transform.position = Vector3.MoveTowards(transform.position, landingPos, speed * Time.deltaTime);
    }

    void GetPosStart() //ball is going up.
    {
        Vector3 GetHere = new Vector3(landingPosX, startingPosY + 10f, landingPosZ);
        transform.position = Vector3.MoveTowards(transform.position, GetHere, Time.deltaTime * speed);
    }

    void ChangeStage()
    {
        isInFirstStage = false;
    }
}
