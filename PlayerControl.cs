using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    //Attributes to the player
    public float moveSpeed;
    public float speedMultiplier;
    public float speedIncreaseIntervalPoint;
    private float speedIncreaseCount;

    private float moveSpeedHold;
    private float speedIncreaseCountHold;
    private float speedInvervalHold;

    public float jumpForce;

    //Check if touching the ground to be able to jump
    //Logic behind ground
    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float radiusGroundCheck;

    //Private functionality of character, the body and the collider
    private Rigidbody2D myRigidBodyCharacter;
   
    //not being used currently
    //private Collider2D myCollider;

    //Animation for player
    private Animator myAnimator;

    //GameManager for restarting a lost game
    public GameManager gm;

    //Additional jumping
    private bool stoppedJumping;
    private bool canDoubleJump;
    private float jumpTimeCounter;
    public float jumpTime;

    // Use this for initialization-Only happens at once in the start of the game
    void Start () {
        //set the component of the character rigidbody/collider/animator
        myRigidBodyCharacter = GetComponent<Rigidbody2D>();

        //myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
        speedIncreaseCount = speedIncreaseIntervalPoint;
        moveSpeedHold = moveSpeed;
        speedIncreaseCountHold = speedIncreaseCount;
        speedInvervalHold = speedIncreaseIntervalPoint;
    }

    // Update is called once per frame
    void Update() {

        //check if the player is colliding with a layer known as ground with a bool value
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, radiusGroundCheck, whatIsGround);



        if (transform.position.x > speedIncreaseCount)
        {
            speedIncreaseCount += speedIncreaseIntervalPoint;
            speedIncreaseCount = speedIncreaseCount * speedMultiplier;
            moveSpeed *= speedMultiplier;
        }



            //set the velocity of the rigidbody
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
                myRigidBodyCharacter.velocity = new Vector2(moveSpeed, myRigidBodyCharacter.velocity.y);
           
        } else
        {
            myRigidBodyCharacter.velocity = new Vector2(0, myRigidBodyCharacter.velocity.y);
        }



        //if space or mouse button pressed for jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //check if grounded otherwise jump wont register
            if (grounded)
            {
                //give a vertical speed for jumpforce
                myRigidBodyCharacter.velocity = new Vector2(myRigidBodyCharacter.velocity.x, jumpForce);
                stoppedJumping = false;

            }
            if(!grounded && canDoubleJump)
            {
                myRigidBodyCharacter.velocity = new Vector2(myRigidBodyCharacter.velocity.x, jumpForce*2/3);
                jumpTimeCounter = jumpTime;
                stoppedJumping = false;
                canDoubleJump = false;
            }
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))&& !stoppedJumping)
        {
            //check if grounded otherwise jump wont register
            if (jumpTimeCounter>0)
            {
                //give a vertical speed for jumpforce
                myRigidBodyCharacter.velocity = new Vector2(myRigidBodyCharacter.velocity.x, jumpForce);
                jumpTime -= Time.deltaTime;

            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            jumpTime = 0;
        }
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }



        //If speed is greater than 0.1 then the motion is running
        //If grounded is false then running is true else character is in the sky
        myAnimator.SetFloat("Speed", myRigidBodyCharacter.velocity.x);
        myAnimator.SetBool("Grounded", grounded);




    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "killingFloor")
        {
            gm.Restart();
            moveSpeed = moveSpeedHold;
            speedIncreaseCount = speedIncreaseCountHold;
            speedIncreaseIntervalPoint = speedInvervalHold;
        }
    }
}
