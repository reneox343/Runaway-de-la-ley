using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject throwable;
    private GameObject tomahawk;
    private int throwableType;
    [HideInInspector]
    public int generalAmmo;
    //tomahawk configuration
    public int tomahawkAmmo;


    void Start()
    {
        tomahawk = (GameObject)Resources.Load("Prefaps/Throwables/Tomahawk", typeof(GameObject));
        throwable = GameObject.Find("Throwables");
        throwableType = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && throwableType == 1 && generalAmmo>0) {
            GameObject temporalTomahawk = Instantiate(tomahawk, throwable.transform.position,Quaternion.identity);
            generalAmmo--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Consumables" && collision.gameObject.GetComponent<ThrowablesBox>() != null) {
            throwableType = collision.gameObject.GetComponent<ThrowablesBox>().throwabletype;
            generalAmmo = tomahawkAmmo;
        }
    }

}