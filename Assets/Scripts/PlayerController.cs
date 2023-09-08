//Jade Lee
//This code manages the player based on the user's control
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameOverScreen GameOverScreen;   //the GameOver screen
    public GameObject score;                //the users current score object 
    public GameObject highScore;            //the game's highscore object
    public float jumpForce;                 //the amount of upward force the player has when jumping (controls how high the player jumps)
    public Transform groundCheck;           //the grounds transform
    public float checkRadius;               //radius of the collider around the player to check if it is touching the ground or enemies
    public LayerMask whatIsGround;          //everything with this LayerMask will be treated as a ground
    public LayerMask enemyObject;           //all the objects with this Layer Mask will be treated as enemies

    private Rigidbody2D rb;                 //the rigidbody attached to the object (handles the physics of the object)
    private bool isGrounded;                //if the player is on the gorund or not 
    private int extraJumps;                 //how many more jumps the player has before he cant jump till he touches the ground again
    private const int EXTRA_JUMP_NUM = 1;   //how many jumps the user gets in between touching the ground (allows for double jumps... or even more)

    // Start is called before the first frame update
    void Start()
    {
        //intialize extraJumps
        extraJumps = EXTRA_JUMP_NUM;

        //set the rigidbody to the players rigidbody
        rb = GetComponent<Rigidbody2D>();
    }//Start 

    // Update is called once per frame
    void Update()
    {
        //if the player is touching the ground 
        if (isGrounded)
        {
            //reset the extraJumps
            extraJumps = EXTRA_JUMP_NUM;
        }//if

        //if they pressed the jump button and is grounded
        if ((Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded) || (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded))
        {
            //if the user is not ducking
            if (!Input.GetKey(KeyCode.DownArrow))
            {
                //make th eplayer object move upward(jump)
                rb.velocity = Vector2.up * jumpForce;
            }//if
        }//else if

        //if they pressed the jump button(space or up arrow) and they still have remaing jumps
        if ((Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) || (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0))
        {
            //if they are not ducking
            if(!Input.GetKey(KeyCode.DownArrow))
            {
                //make the game object move upwards(jump)
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }//if            
        }//if
    }//Update 

    //FixedUpdate - same as update ut for physics
    void FixedUpdate()
    {
        //check to see if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //if the player collided with an enemy
        if (Physics2D.OverlapCircle(this.gameObject.transform.position, checkRadius, enemyObject))
        {
            // //play the death side
            // AudioManager.playSound();

            //destroy the player
            Destroy(this.gameObject);             

            //pause the game
            Time.timeScale = 0f; 

            //show the gameover screen 
            GameOverScreen.Setup((int)Score.score);
        }//if
    }//FixedUpdate
}//PlayerController