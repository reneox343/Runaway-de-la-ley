using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletDamage;
    public bool destroyOnImpact;
    public bool destroyOnInvisible;
    private Gun gunscript;

    private void Start()
    {
        gunscript = GameObject.Find("Player").GetComponent<Gun>();
        if (gunscript.astiMode) {

            BulletDamage += BulletDamage * gunscript.astiModeMultiplayer;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyOnImpact)
        {
            Destroy(gameObject);
        }
    }


    private void OnBecameInvisible()
    {
        if (destroyOnInvisible) 
        { 
            Destroy(gameObject);
        }
    }

}
