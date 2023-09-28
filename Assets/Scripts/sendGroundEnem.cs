// Jade Lee
// This code creates and spawns enemies on the ground accordingly

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class sendGroundEnem : MonoBehaviour
{
    public GameObject groundEnem;           //the gameObject we are deploying

    private const float MIN_Y = -4.5f;      //minimum location for the enemy on the y-axis
    private const float MAX_Y = -1f;        //maximun location for the enemy on the x-axis
    private Vector3 screenBounds;           //a vector3 representing the bounds of the game's screen
    private int difficultyCounter = 100;    //this will be used to determine when to increase the difficulty (every 100 points the difficulty will be increased)
    private float minSpawnTime = 2;         //the minimum time between spawning the Farrow objects
    private float maxSpawnTime = 5;         //the maximum time between spawning the Farrow objects 

    // Start is called before the first frame update
    void Start()
    {
        //set hte screen bounds to bounds of the game's screen 
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

       //start deploying the enemies (will be constantly running) the code inside the
        StartCoroutine(deployGroundEnem());
    }//start


    //puts a new ground enemy game object into the game
    private void spawnGroundEnem()
    {
        //make a new object and make it a new ground enemy game object
        GameObject groundEnemObj = Instantiate(groundEnem) as GameObject;
  
        //set its position to appear on the ground and at the right of the screen
        groundEnemObj.transform.position = new Vector2(-screenBounds.x * -2, UnityEngine.Random.Range(MIN_Y, MAX_Y));
    }//spawngroundEnem

    //deploys the groundEnem enemy game objects after. it pauses for a random time between min and max spawn times before it deploys another one
    IEnumerator deployGroundEnem()
    {
        //make it run as long as the game didn't end
        while (!GameOverScreen.endOfGame())
        {
            //wait for a random amount of seconds between the max and min spawn times 
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnTime, maxSpawnTime));
            //then spawn a groundEnem enemy game object
            spawnGroundEnem();
        }//while
    }//deploygroundEnem

    // Update is called once per frame
    void Update()
    {
        //if another 100 points have passes
        if(difficultyCounter < Score.score)
        { 
            //add to the dificulty counter for the next level
            difficultyCounter += 100;

            //shorten the max and min spawn times
            minSpawnTime /= 1.1f;
            maxSpawnTime /= 1.1f;
        }//if
    }//update
}//sendgroundEnem