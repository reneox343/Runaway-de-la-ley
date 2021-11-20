using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    public float jumpForce;
    private Rigidbody2D rigidBody;

    //jump smoke
    [SerializeField]
    private GameObject smokeEmitter;
    [SerializeField]
    private GameObject smoke;

    [HideInInspector]
    public int playerDirection;

    [HideInInspector]
    public bool isPlayerJumping;

    private Animator playerAnimator;


    void Start()
    {
        playerDirection = 1;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        jump();

        movement();

        setPlayerDirection();
    }
    
    void jump() {

        if (Input.GetAxisRaw("Jump") == 1 && Mathf.Abs(rigidBody.velocity.y) < 0.001f)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            Destroy(Instantiate(smoke, smokeEmitter.transform.position, Quaternion.identity), 1);

        }
        if (Mathf.Abs(rigidBody.velocity.y) > 0.001f) isPlayerJumping = true;
        else isPlayerJumping = false;
        

    }

    void movement() {


        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            playerAnimator.SetFloat("moving", 0);

        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            playerAnimator.SetFloat("moving", 0);
            return;
        }

        //moves the player to the correc position and rotate the character
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed, 0, 0);
        playerAnimator.SetFloat("moving", Mathf.Abs( Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed));


    }

    void setPlayerDirection() {
        //setting players direction by movement
        //horizontal
        if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 0)
        {
            playerDirection = 1;
        }
        if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 0)
        {
            playerDirection = -1;
        }
        //up diagonals
        if ((Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 1))
        {
            playerDirection = 2;
        }
        if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 1) {
            playerDirection = -2;
        }        
        //down diagonals
        if ((Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == -1))
        {
            playerDirection = 3;
        }
        if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == -1) {
            playerDirection = -3;
        }
        //correcting players direction
        if (playerDirection == 2 && Input.GetAxisRaw("Vertical") == 0)
        {
            playerDirection = 1;
        }

        if (playerDirection == -2 && Input.GetAxisRaw("Vertical") == 0)
        {
            playerDirection = -1;
        }        
        
        if (playerDirection == 3 && Input.GetAxisRaw("Vertical") == 0)
        {
            playerDirection = 1;
        }

        if (playerDirection == -3 && Input.GetAxisRaw("Vertical") == 0)
        {
            playerDirection = -1;
        }

    }


}
