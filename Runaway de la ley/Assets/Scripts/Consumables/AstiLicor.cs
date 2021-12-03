using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstiLicor : MonoBehaviour
{
    // Start is called before the first frame update
    public float multiplayer;
    public float duration;
    private AudioSource playerAudioSource;
    private AudioClip drinking;
    private CurrentPlayerData currentData;

    private void Start()
    {
        
        playerAudioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        currentData = GameObject.Find("Player").GetComponent<CurrentPlayerData>();
        drinking = Resources.Load("Sounds/Consumables/Drinking") as AudioClip;
        astiModeUpgrades();
    }

    private void astiModeUpgrades() {

        if (currentData.data.astiModeUpgrades[1])
        {
            duration += currentData.astiModeDurationUpgrade;
        }
        if (currentData.data.astiModeUpgrades[2])
        {
            multiplayer += currentData.astiModeMultiplayerUpgrade;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Gun gunScript  = collision.gameObject.GetComponent<Gun>();
            gunScript.astiMode = true;
            gunScript.astiModeMultiplayer = multiplayer;
            gunScript.astiModeDuration = duration;
            playerAudioSource.PlayOneShot(drinking);
            Destroy(gameObject);
        }
    }
}
