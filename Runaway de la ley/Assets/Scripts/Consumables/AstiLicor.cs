using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class AstiLicor : MonoBehaviour
{
    // Start is called before the first frame update
    public float multiplayer;
    public float duration;
    private void Start()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Gun gunScript  = collision.gameObject.GetComponent<Gun>();
            gunScript.astiMode = true;
            gunScript.astiModeMultiplayer = multiplayer;
            gunScript.astiModeDuration = duration;
            Destroy(gameObject);
        }
    }
}
