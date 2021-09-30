using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject throwable;
    private GameObject tomahawk;
    private int throwableType;

    void Start()
    {
        tomahawk = (GameObject)Resources.Load("Prefaps/Throwables/Tomahawk", typeof(GameObject));
        throwable = GameObject.Find("Throwables");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) {
            GameObject temporalTomahawk = Instantiate(tomahawk, throwable.transform.position,Quaternion.identity);
            
        }

    }

    
}