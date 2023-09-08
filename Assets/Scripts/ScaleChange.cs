//Jade Lee
//This code scales the size of the player based on input

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles the ducking of the player
public class ScaleChange : MonoBehaviour
{

    public CapsuleCollider2D playerCollider;           //the players collider
   
    //shrink
    private const float PLAYER_SHRINK = 20f;            //size of the player when shrunk
    private const float COLLIDER_SHRINK_X = 2.25f;      //x dimension of the collider when shrunk
    private const float COLLIDER_SHRINK_Y = 3.75f;      //y dimension of the collider when shrunk
    private const float COLLIDER_SHRINK_Z = 2.25f;      //z dimension of the collider when shrunk

    //normal
    private const float PLAYER = 30f;           //size of the player
    private const float COLLIDER_X = 4.5f;      //x dimension of the collider
    private const float COLLIDER_Y = 7.5f;      //y dimension of the collider
    private const float COLLIDER_Z = 4.5f;      //z dimension of the collider

    // Update is called once per frame
    void Update()
    {
        //if the player pressed the down arrow
        if(Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            //shrink the player and its collider
            transform.localScale = new Vector3(PLAYER_SHRINK, PLAYER_SHRINK, PLAYER_SHRINK);
            playerCollider.size = new Vector3(COLLIDER_SHRINK_X, COLLIDER_SHRINK_Y, COLLIDER_SHRINK_Z);
        }//if

        //if the player released the down arrow
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //grow the player and collider back to normal 
            transform.localScale = new Vector3(PLAYER, PLAYER, PLAYER);
            playerCollider.size = new Vector3(COLLIDER_X, COLLIDER_Y, COLLIDER_Z);
        }//if
    }//Update
}//ScaleChange
