using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject throwable;
    private GameObject tomahawk;
    private GameObject granade;
    private int throwableType;
    [HideInInspector]
    public int generalAmmo;
    //tomahawk configuration
    public int throwablesAmmo;
    //data
    CurrentPlayerData currentData;
    //Player audio source
    AudioSource playerAudioSource;
    //Audio clips
    AudioClip throwAudioClip;
    AudioClip granadeAudioClip;
    AudioClip tomahackAudioClip;

    void Start()
    {
        //player components
        playerAudioSource = gameObject.GetComponent<AudioSource>(); 
        currentData = GameObject.Find("Player").GetComponent<CurrentPlayerData>();
        //audio clips
        throwAudioClip = Resources.Load("Sounds/Consumables/Throw") as AudioClip;
        granadeAudioClip = Resources.Load("Sounds/Consumables/Explosion1") as AudioClip;
        tomahackAudioClip = Resources.Load("Sounds/Consumables/Tomahack") as AudioClip;
        //throwables
        tomahawk = (GameObject)Resources.Load("Prefaps/Throwables/Tomahawk", typeof(GameObject));
        granade = (GameObject)Resources.Load("Prefaps/Throwables/Granade", typeof(GameObject));
        throwable = GameObject.Find("Throwables");
        //setting up config
        throwableType = 0;
        throwablesUpgrades();
    }

    void throwablesUpgrades() {

        if (currentData.data.trowablesUpgrades[0])
        {
            throwablesAmmo += currentData.ammoThrowablesUpgrade1;
        }        
        if (currentData.data.trowablesUpgrades[1])
        {
            throwablesAmmo += currentData.ammoThrowablesUpgrade2;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        //keyboard
        if (Input.GetKeyDown(KeyCode.S) && throwableType == 1 && generalAmmo>0) {
            throwGameObject(tomahawk);
        }       
        //controller
        if (Input.GetKeyDown("joystick button 3") && throwableType == 1 && generalAmmo>0) {
            throwGameObject(tomahawk);
        }       
        //keyboard
        if (Input.GetKeyDown(KeyCode.S) && throwableType == 2 && generalAmmo>0) {
            throwGameObject(granade);
        }       
        //controller
        if (Input.GetKeyDown("joystick button 3") && throwableType == 2 && generalAmmo>0) {
            throwGameObject(granade);
        }
        //sound effect
        if (Input.GetKeyDown(KeyCode.S) && generalAmmo > 0) 
        {
            playerAudioSource.PlayOneShot(throwAudioClip);
        }

    }

    void throwGameObject(GameObject throwItem) {

        Instantiate(throwItem, throwable.transform.position, Quaternion.identity);
        if (currentData.data.trowablesUpgrades[2]) 
        { 
            GameObject temporalThrowable = Instantiate(throwItem, throwable.transform.position, Quaternion.identity);

            if (temporalThrowable.GetComponent<Tomahawk>())
            {
                temporalThrowable.GetComponent<Tomahawk>().tomahawkImpulseX++;
            }
            if (temporalThrowable.GetComponent<Granade>())
            {
                temporalThrowable.GetComponent<Granade>().tomahawkImpulseX++;
            }
        }
        if (currentData.data.trowablesUpgrades[3])
        {

            GameObject temporalThrowable = Instantiate(throwItem, throwable.transform.position, Quaternion.identity);

            if (temporalThrowable.GetComponent<Tomahawk>())
            {
                temporalThrowable.GetComponent<Tomahawk>().tomahawkImpulseX --;
            }
            if (temporalThrowable.GetComponent<Granade>())
            {
                temporalThrowable.GetComponent<Granade>().tomahawkImpulseX--;
            }
        }
        generalAmmo--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Consumables" && collision.gameObject.GetComponent<ThrowablesBox>() != null) {
            throwableType = collision.gameObject.GetComponent<ThrowablesBox>().throwabletype;
            generalAmmo = throwablesAmmo;
            if (throwableType == 1)
            {
                playerAudioSource.PlayOneShot(tomahackAudioClip);
            }
            else if (throwableType == 2) 
            {
                playerAudioSource.PlayOneShot(granadeAudioClip);
            }

        }
    }

}