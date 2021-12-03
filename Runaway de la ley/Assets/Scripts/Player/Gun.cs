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
    //cahracter audio source
    AudioSource characterAudioSource;

    // Start is called before the first frame update
    [HideInInspector]
    public int gunType;

    //bullets
    private GameObject revolverBullet;
    private GameObject ShootgunBullet;

    //Character children
    private GameObject revolver;
    private GameObject Revolvers;
    private GameObject shootGun;

    //controller (animation) gun sprites
    private RuntimeAnimatorController revolverAnimatorController;
    private RuntimeAnimatorController revolversAnimatorController;
    private RuntimeAnimatorController ShootgunAnimatorController;

    //sounds
    private AudioClip revolverAudioClip;
    private AudioClip revolverCockingAudioClip;
    private AudioClip ShootgunReloadAudioClip;
    private AudioClip ShootgunShootAudioClip;

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
    //lights
    private Light2D globalLight;
    //current player data
    private CurrentPlayerData currentData;
    private bool playRevolverCockedSound;

    void Start()
    {

        //get player components
        characterAnimator = gameObject.GetComponent<Animator>();
        characterAudioSource = gameObject.GetComponent<AudioSource>();

        //bullets
        revolverBullet = Resources.Load("Prefaps/Bullets/RevolverBullet") as GameObject;
        ShootgunBullet = Resources.Load("Prefaps/Bullets/ShootgunBullet") as GameObject;
        
        //runtimeAnimations
        revolverAnimatorController = Resources.Load("Animations/Character/CharacterRevolver/CharacterRevolver") as RuntimeAnimatorController;
        revolversAnimatorController = Resources.Load("Animations/Character/CharacterRevolvers/CharacterRevolvers") as RuntimeAnimatorController;
        ShootgunAnimatorController = Resources.Load("Animations/Character/CharacterShootgun/CharacterShootgun") as RuntimeAnimatorController;

        //Audioclips guns
        revolverAudioClip = Resources.Load("Sounds/Bullets/Revolver") as AudioClip;
        ShootgunReloadAudioClip = Resources.Load("Sounds/Bullets/shootgunReload") as AudioClip;
        ShootgunShootAudioClip = Resources.Load("Sounds/Bullets/shootgunShoot") as AudioClip;

        //Consumables
        revolverCockingAudioClip = Resources.Load("Sounds/Consumables/RevolverCocking") as AudioClip; ;

        //player children
        revolver = GameObject.Find("Revolver");
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
        //player current data
        currentData = gameObject.GetComponent<CurrentPlayerData>();
        //upgrades
        
        revolverUpgrades();

        shootgunUpgrades();
        //flags
        playRevolverCockedSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.pause) shoot();
        calculateTimers();

    }
    void revolverUpgrades() {

        if (currentData.data.revolversUpgrades[0]) 
        {
            revolversAmmo += currentData.ammoRevolversUpgrade;
        }        

        if (currentData.data.revolversUpgrades[2])
        {
            revolversDelay -= currentData.delayRevolversUpgrade;
        }        
        if (currentData.data.revolversUpgrades[3])
        {

            revolversAmmo += currentData.ammoRevolverUpgradeSpecial;
            revolversDelay = 0.1f;
        }

    }    
    void shootgunUpgrades() {

        if (currentData.data.shootgunUpgrades[0]) 
        {
            shootGunAmmo += currentData.ammoshootgunUpgrade;
        }        

        if (currentData.data.shootgunUpgrades[2])
        {
            shootGunDelay -= currentData.delayShootgunUpgrade;
        }        
        if (currentData.data.shootgunUpgrades[3])
        {
            shootGunAmmo += currentData.ammoshootgunUpgradeSpecial;

        }

    }



    void shoot() {

        //keyboard
        if (Input.GetKeyDown(KeyCode.A)&& gunType == 1 && generalDelay <= 0)
        {   //revolver
            shootRevolver();

        }if (Input.GetKey(KeyCode.A) && gunType == 2 && generalDelay <=0) {
            //revolvers
            shootRevolvers();
        }
        if (Input.GetKeyDown(KeyCode.A) && gunType == 3 && generalDelay <= 0)
        {
            //shootgun
            shootShootgun();
        }

        //controller
        if (Input.GetKeyDown("joystick button 2") && gunType == 1 && generalDelay <= 0)
        {   //revolver
            shootRevolver();

        }
        if (Input.GetKey("joystick button 2") && gunType == 2 && generalDelay <= 0)
        {
            //revolvers
            shootRevolvers();
        }
        if (Input.GetKeyDown("joystick button 2") && gunType == 3 && generalDelay <= 0)
        {
            //shootgun
            shootShootgun();
        }

        if (generalAmmo <= 0 && playRevolverCockedSound) {
            gunType = 1;
            characterAudioSource.PlayOneShot(revolverCockingAudioClip);
            playRevolverCockedSound = false;
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
                StartCoroutine(revolverCockingSoundEfect());
                characterAnimator.runtimeAnimatorController = revolversAnimatorController;
                generalAmmo = revolversAmmo;
            }

            if (gunType == 3)
            {
                characterAudioSource.PlayOneShot(ShootgunReloadAudioClip);
                characterAnimator.runtimeAnimatorController = ShootgunAnimatorController;
                generalAmmo = shootGunAmmo;
            }
            playRevolverCockedSound = true;
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

    private void shootRevolver() {
        Instantiate(revolverBullet, revolver.transform.position, Quaternion.identity);
        characterAudioSource.PlayOneShot(revolverAudioClip);
        generalDelay = revolverShootDelay;
    }
    private void shootRevolvers() {
        GameObject firstBullet =  Instantiate(revolverBullet, revolver.transform.position, Quaternion.identity);
        GameObject secondBullet = Instantiate(revolverBullet, Revolvers.transform.position, Quaternion.identity);

        if (currentData.data.revolversUpgrades[1])
        {
            firstBullet.GetComponent<Bullet>().rangeX += currentData.rangeRevolversUpgrade;
            secondBullet.GetComponent<Bullet>().rangeX += currentData.rangeRevolversUpgrade;
        }
        StartCoroutine(revolverSoundEfect());
        generalDelay = revolversDelay; ;
        generalAmmo -= 1;
    }
    private void shootShootgun() {
        for (int i = 0; i < shootGunbullets; i++)
        {
            GameObject shootgunBullet = Instantiate(ShootgunBullet, revolver.transform.position, Quaternion.identity);

            if (currentData.data.shootgunUpgrades[2])
            {
                shootgunBullet.GetComponent<Bullet>().ramdomDirectionVariation = currentData.spreadShootgunUpgrade;
            }

            if (currentData.data.shootgunUpgrades[1])
            {
                shootgunBullet.GetComponent<Bullet>().rangeX += currentData.rangeShootgunUpgrade; 
            }           

            if (currentData.data.shootgunUpgrades[3])
            {
                shootgunBullet.GetComponent<Bullet>().pelletsEnabled = true;
                
            }


        }
        StartCoroutine(ShootgunSoundEfect());
        generalDelay = shootGunDelay;
        generalAmmo -= 1;
    }

    IEnumerator revolverSoundEfect()
    {

        characterAudioSource.PlayOneShot(revolverAudioClip);

        yield return new WaitForSeconds(0.1f);


        characterAudioSource.PlayOneShot(revolverAudioClip);
    }        
    IEnumerator revolverCockingSoundEfect()
    {

        characterAudioSource.PlayOneShot(revolverCockingAudioClip);

        yield return new WaitForSeconds(0.3f);

        characterAudioSource.PlayOneShot(revolverCockingAudioClip);
    }    
    IEnumerator ShootgunSoundEfect()
    {

        characterAudioSource.PlayOneShot(ShootgunShootAudioClip);
        
        yield return new WaitForSeconds(0.1f);

        characterAudioSource.clip = ShootgunReloadAudioClip;
        characterAudioSource.Play();

    }
}
