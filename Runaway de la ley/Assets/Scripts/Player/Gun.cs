using System.Collections;
using UnityEditor;
//using UnityEditor.Animations;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;


public class Gun : MonoBehaviour
{
    //character srpite renderer
    Animator characterAnimator;
    // Start is called before the first frame update
    [HideInInspector]
    public int gunType;

    //bullets
    private GameObject revolverBullet;
    private GameObject ShootgunBullet;

    //Character children
    private GameObject Revolver;
    private GameObject Revolvers;
    private GameObject shootGun;

    //controller (animation) gun sprites
    private RuntimeAnimatorController revolverAnimatorController;
    private RuntimeAnimatorController revolversAnimatorController;
    private RuntimeAnimatorController ShootgunAnimatorController;

    //revolver config
    [Header("Revolvers configuration")]
    public float revolverShootDelay;
    public float revolversDelay;
    public float revolversAmmo;

    //Shootgun config
    [Header("Shootgun configuration")]
    public float shootGunDelay;
    public float shootGunbullets;
    public float shootGunAmmo;

    //Timers
    private float generalDelay = 0;
    [HideInInspector]
    public float generalAmmo = 0;

    //AstiLicor 
    [HideInInspector]
    public bool astiMode;
    [HideInInspector]
    public float astiModeDuration;
    [HideInInspector]
    public float astiModeMultiplayer;

    private Light2D globalLight;


    void Start()
    {
        characterAnimator = gameObject.GetComponent<Animator>();

        //bullets
        revolverBullet = Resources.Load("Prefaps/Bullets/RevolverBullet") as GameObject;
        ShootgunBullet = Resources.Load("Prefaps/Bullets/ShootgunBullet") as GameObject;

        //runtimeAnimations
        revolverAnimatorController = Resources.Load("Animations/Character/CharacterRevolver/CharacterRevolver") as RuntimeAnimatorController;
        revolversAnimatorController = Resources.Load("Animations/Character/CharacterRevolvers/CharacterRevolvers") as RuntimeAnimatorController;
        ShootgunAnimatorController = Resources.Load("Animations/Character/CharacterShootgun/CharacterShootgun") as RuntimeAnimatorController;
        //player children
        Revolver = GameObject.Find("Revolver");
        Revolvers = GameObject.Find("Revolvers");

        //settings revolver 
        gunType = 1;
        characterAnimator.runtimeAnimatorController = revolverAnimatorController;
        //light
        globalLight = GameObject.Find("GlobalLight").GetComponent<Light2D>();
        //astimode 
        astiMode = false;
        astiModeDuration = 0;
        astiModeMultiplayer = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        calculateTimers();
    }

    void shoot() {

        if (Input.GetKeyDown(KeyCode.A) && gunType == 1 && generalDelay <= 0)
        {   //revolver
            Instantiate(revolverBullet, Revolver.transform.position, Quaternion.identity);
            generalDelay = revolverShootDelay;
        }if (Input.GetKey(KeyCode.A) && gunType == 2 && generalDelay <=0) {
            //revolvers
            Instantiate(revolverBullet, Revolver.transform.position, Quaternion.identity);
            Instantiate(revolverBullet, Revolvers.transform.position, Quaternion.identity);
            generalDelay = revolversDelay;
            generalAmmo -= 1;
        }
        if (Input.GetKey(KeyCode.A) && gunType == 3 && generalDelay <= 0)
        {
            //shootgun
            for (int i = 0; i < shootGunbullets; i++) {
                Instantiate(ShootgunBullet, Revolver.transform.position, Quaternion.identity);
            }
            
            generalDelay = shootGunDelay;
            generalAmmo -= 1;
        }

        if (generalAmmo <= 0) {
            gunType = 1;
            characterAnimator.runtimeAnimatorController = revolverAnimatorController;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Consumables" && collision.gameObject.GetComponent<GunBox>() != null) {
            gunType = collision.gameObject.GetComponent<GunBox>().guntype;
            
            //revolvers
            if (gunType == 2)
            {
                characterAnimator.runtimeAnimatorController = revolversAnimatorController;
                generalAmmo = revolversAmmo;
            }

            if (gunType == 3)
            {
                characterAnimator.runtimeAnimatorController = ShootgunAnimatorController;
                generalAmmo = shootGunAmmo;
            }
        }
        if (collision.gameObject.tag == "Consumables" && collision.gameObject.GetComponent<AstiLicor>() != null)
        {
            astiMode = true;
        }
    }

    void calculateTimers() {
        //general weapond delay to shoot
        if (generalDelay > 0)
        {
            generalDelay -= Time.deltaTime;
        }
        //astimode timers
        if (astiModeDuration > 0)
        {
            astiModeDuration -= Time.deltaTime;
        }
        else {
            astiMode = false;
        }
        //setting light color to red
        if (astiMode)
        {
            if (globalLight.color.g > 0.7f)
            {
                globalLight.color -= new Color(0, 0.3f, 0.3f) * Time.deltaTime;
            }
        }
        else {
            if (globalLight.color.g <= 1f)
            {
                globalLight.color += new Color(0, 0.3f, 0.3f) * Time.deltaTime;
            }
            else {
                globalLight.color = new Color(1f, 1f, 1f);
            }
        }

    }



}
