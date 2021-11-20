using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletDamage;
    public bool destroyOnImpact;
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
}
