//Jade Lee
//This code controls the movement of the enemy in the sky (right to left)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyEnemController : MonoBehaviour
{
    public float speed = 10.0f;         //how fast the object will move
    private Rigidbody2D rb;             //the rigidbody attached to the object(handles the physics of the object 
    private Vector2 screenBounds;       //the bounds of the game screen 

    // Start is called before the first frame update
    void Start()
    {
        //assign the rigidbody to the gameobjects rigidbody
        rb = this.GetComponent<Rigidbody2D>();

        //set the velocity of the objects so it moves along the x axis only
        rb.velocity = new Vector2(-speed, 0);

        //set the screenBounds to the bounds of the game's screen
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }//sart

    // Update is called once per frame
    void Update()
    {
        //if the object is past the screen on the left we can delete it (we do this so it doesnt take up storage any more. Will stop crashes and make the game run smoother)
        //or if the game is over, destroy the game objects on the screen
        if (transform.position.x < -screenBounds.x * 2 || GameOverScreen.endOfGame())
        {
            //destory the game object
            Destroy(this.gameObject);
        }//if
    }//update
}//SkyEnemController
