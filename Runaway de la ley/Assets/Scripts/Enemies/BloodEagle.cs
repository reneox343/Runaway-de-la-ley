using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEagle : MonoBehaviour
{
    public float speed;
    public float yAxisCrest;
    public float YAxisperiod;
    private float ypostion;
    private Vector3 direction;

    // Update is called once per frame
    private void Start()
    {
        direction = GameObject.Find("Player").transform.position - gameObject.transform.position;
        if (direction.x >= 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }

        ypostion = 0;
    }
    void Update()
    {
        ypostion += Time.deltaTime;
        if (direction.x >= 0)
        {
            transform.position += new Vector3(speed, Mathf.Sin(Mathf.PI * ypostion * YAxisperiod) * yAxisCrest, 0) * Time.deltaTime;
            
        }
        else 
        {

            transform.position += new Vector3(-speed, Mathf.Sin(Mathf.PI * ypostion * YAxisperiod) * yAxisCrest, 0) * Time.deltaTime;

        }
        
    }
}
