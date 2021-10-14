using System.Collections;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections.Generic;
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
    //Character children
    private GameObject Revolver;
    private GameObject Revolvers;
    //controller (animation) gun sprites
    private RuntimeAnimatorController revolverAnimatorController;
    private RuntimeAnimatorController revolversAnimatorController;
    //revolver config
    public float revolverShootDelay;
    //revolvers config
    public float revolversDelay;
    public float revolversAmmo;


    //Timers
    private float generalDelay = 0;
    private float generalAmmo = 0;
    void Start()
    {
        characterAnimator = gameObject.GetComponent<Animator>();

        //bullets
        revolverBullet = Resources.Load("Prefaps/Bullets/RevolverBullet") as GameObject;

        //gunsprites
        revolverAnimatorController = Resources.Load("Animations/Character/CharacterRevolver/CharacterRevolver") as RuntimeAnimatorController;
        revolversAnimatorController = Resources.Load("Animations/Character/CharacterRevolvers/CharacterRevolvers") as RuntimeAnimatorController;
        Debug.Log(revolverAnimatorController);
        //player children
        Revolver = GameObject.Find("Revolver");
        Revolvers = GameObject.Find("Revolvers");

        //settings revolver 
        gunType = 1;
        characterAnimator.runtimeAnimatorController = revolverAnimatorController;
        //setiings shotgun

    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        calculateTimers();
    }

    void shoot() {

        if (Input.GetKeyDown(KeyCode.Z) && gunType == 1 && generalDelay <= 0)
        {   //revolver
            Instantiate(revolverBullet, Revolver.transform.position, Quaternion.identity);
            generalDelay = revolverShootDelay;
        }if (Input.GetKey(KeyCode.Z) && gunType == 2 && generalDelay <=0) {
            //revolvers
            Instantiate(revolverBullet, Revolver.transform.position, Quaternion.identity);
            Instantiate(revolverBullet, Revolvers.transform.position, Quaternion.identity);
            generalDelay = revolversDelay;
            generalAmmo -= 1;
        }

        if (generalAmmo <= 0) {
            gunType = 1;
            characterAnimator.runtimeAnimatorController = revolverAnimatorController;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GunBox") {
            gunType = collision.gameObject.GetComponent<GunBox>().guntype;
            
            //revolvers
            if (gunType == 2)
            {
                characterAnimator.runtimeAnimatorController = revolversAnimatorController;
                generalAmmo = revolversAmmo;
            }
        }

    }

    void calculateTimers() {
        //general weapond delay to shoot
        if (generalDelay > 0)
        {
            generalDelay -= Time.deltaTime;
        }
      
    }


}
