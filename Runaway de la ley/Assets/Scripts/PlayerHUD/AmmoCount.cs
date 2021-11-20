using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCount : MonoBehaviour
{
    // Start is called before the first frame update
    private Gun gunscript;
    public TMP_Text ammo; 
    void Start()
    {
        gunscript = GameObject.Find("Player").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gunscript.generalAmmo) {

            case 0:
                ammo.text = "INF";
                break;
            default:
                ammo.text = gunscript.generalAmmo.ToString();
                break;
        }

        
    }
}
