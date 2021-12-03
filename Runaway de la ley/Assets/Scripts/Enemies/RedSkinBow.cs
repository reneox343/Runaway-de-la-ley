using UnityEngine;

public class RedSkinBow : MonoBehaviour
{
    //bow 
    public GameObject bow;
    public GameObject bullet;
    public float delayToshoot;
    public float jumpForce;
    public bool canJump;

    private float generalDelay;
    private bool visible = false;
    //animation
    Animator redSkinAnimator;
    
    //audio
    AudioSource redSkinAudioSource;
    AudioClip bowLoading;
    AudioClip bowShooting;
    //get player
    GameObject player;
    //direction in witch the bullet will travel
    Vector3 direction;
    //rigid body
    private Rigidbody2D rigidBody;


    //shoot it is called by an animation event

    private void Start()
    {
        //audio
        redSkinAudioSource = gameObject.GetComponent<AudioSource>();
        bowLoading = Resources.Load("Sounds/Enemies/RedSkin/BowLoading") as AudioClip;
        bowShooting = Resources.Load("Sounds/Enemies/RedSkin/BowShooting") as AudioClip;

        //animation
        redSkinAnimator = gameObject.GetComponent<Animator>();
        redSkinAnimator.enabled = false;
        //rigid body
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

        player = GameObject.Find("Player");
        generalDelay = delayToshoot;
    }

    private void Update()
    {
        generalDelay-=Time.deltaTime;

        if (visible) {
            faceThePlayer();
            if (generalDelay <= 0) {
                redSkinAnimator.enabled = true;
            
            }
        }

    }

    void shootBow()
    {
        Instantiate(bullet, bow.transform.position, Quaternion.identity);
        redSkinAudioSource.clip = bowShooting;
        redSkinAudioSource.Play();
        generalDelay = delayToshoot;
    }

    void reloadBow() {
        redSkinAudioSource.PlayOneShot(bowLoading);
    }

    void stopShootingAnimation() {
        redSkinAnimator.enabled = false;
    }

    void faceThePlayer() {
        //finds the direction in with te arrow must be shoot to hit the player
        direction = player.transform.position - gameObject.transform.position;
        direction = new Vector3(direction.x, direction.y);
        direction = Vector3.Normalize(direction);
        if (direction.x <= 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }


    private void OnBecameVisible()
    {
        visible = true;
    }
    private void OnBecameInvisible()
    {
        visible = false;
        generalDelay = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (Mathf.Abs(rigidBody.velocity.y) < 0.0001f && canJump)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }        
        if (Mathf.Abs(rigidBody.velocity.y) > 0.0001f && canJump)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    }
}
