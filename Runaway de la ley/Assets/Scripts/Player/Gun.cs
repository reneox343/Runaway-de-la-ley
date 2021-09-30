using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    //character srpite renderer
    SpriteRenderer characerSprite;
    // Start is called before the first frame update
    [HideInInspector]
    public int gunType;
    //bullets
    private GameObject revolverBullet;
    //Character children
    private GameObject Revolver;
    private GameObject Revolvers;
    //character gun sprites
    private Sprite revolverSprite;
    private Sprite revolversSprite;
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
        characerSprite = gameObject.GetComponent<SpriteRenderer>();

        //bullets
        revolverBullet = (GameObject) Resources.Load("Prefaps/Bullets/RevolverBullet", typeof(GameObject));

        //gunsprites
        revolverSprite = (Sprite)Resources.Load("Sprites/Character/CharacterRevolver/CharacterRevolver", typeof(Sprite));
        revolversSprite = (Sprite)Resources.Load("Sprites/Character/CharacterRevolvers/CharacterRevolvers", typeof(Sprite));

        //player children
        Revolver = GameObject.Find("Revolver");
        Revolvers = GameObject.Find("Revolvers");

        //settings revolver 
        gunType = 1;
        characerSprite.sprite = revolverSprite;
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
            characerSprite.sprite = revolverSprite;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "GunBox") {
            gunType = collision.gameObject.GetComponent<GunBox>().guntype;
            
            //revolvers
            if (gunType == 2)
            {
                characerSprite.sprite = revolversSprite;
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
