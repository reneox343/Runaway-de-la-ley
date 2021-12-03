using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    public GameObject parent;
    private AudioSource playerAudioSource;
    private AudioClip explotionAudioClip;
    private void Start()
    {
        playerAudioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        explotionAudioClip = Resources.Load("Sounds/Consumables/Explosion1") as AudioClip;
    }
    void explode() {
        playerAudioSource.PlayOneShot(explotionAudioClip);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }

    void destroyParent() {

        Destroy(parent);
    }
}
