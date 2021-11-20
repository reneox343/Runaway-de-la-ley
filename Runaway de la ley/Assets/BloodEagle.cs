using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEagle : MonoBehaviour
{
    public float speed;
    public float yAxisCrest;
    public float YAxisperiod;
    private float ypostion;
    // Update is called once per frame
    private void Start()
    {
        ypostion = 0;
    }
    void Update()
    {
        ypostion += Time.deltaTime;
        transform.position += new Vector3(-speed,Mathf.Sin(Mathf.PI*ypostion*YAxisperiod)*yAxisCrest, 0) * Time.deltaTime;
    }
}
