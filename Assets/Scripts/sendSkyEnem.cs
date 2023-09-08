// Jade Lee
// This code creates and spawns enemies in the sky accordingly

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendSkyEnem : MonoBehaviour
{
    public GameObject skyEnem;                          //the gameObject we are deploying

    private const int INCR_SCORE = 100;                 //every time the score increases by 100, the deploy rate increases
    private const int START_SCORE = 200;                //required score for the sky enemy to start deploying
    private const float DECR = 1.1f;                    //amount to decrement the spawn time by
    private const float MIN_Y = 0;                      //minimum location for the enemy on the y-axis
    private const float MAX_Y = 5f;                     //maximun location for the enemy on the x-axis
    private Vector2 screenBounds;                       //a vector3 representing the bounds of the game's screen
    private bool shouldDeploy;                          //whether we should deploy or not
    private bool startedDeploying = false;              //whether we started deploying or not
    private float minSpawnTime = 3;                     //the minimum time between spawning the Farrow objects
    private float maxSpawnTime = 5;                     //the maximum time between spawning the Farrow objects 
    private int incrRateScore = START_SCORE;            //score needed to increase the deploy rate of the enemy

    // Start is called before the first frame update
    void Start()
    {
        //set screen boundary for the enemy
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(Score.score >= START_SCORE && startedDeploying == false)
        {//start deploying once the score reaches 200
            StartCoroutine(deploySkyEnem());
            startedDeploying = true;
        }//if
        else if(startedDeploying && Score.score > incrRateScore)
        {//every time the score was increased by 100, increase the spawn rate by decreaseing the time interval between deployments
            incrRateScore += INCR_SCORE;

            minSpawnTime /= DECR;
            maxSpawnTime /= DECR;
        }//else if
    }

    IEnumerator deploySkyEnem()
    {
        //make it run as long as the game didn't end
        while (!GameOverScreen.endOfGame())
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            spawnSkyEnem();
        }//while
    }//deploySkyEnem

    //spawnSkyEnem - this code instantiates a new game object and spawns it on the gamne screen
    private void spawnSkyEnem()
    {
        GameObject skyEnemObj = Instantiate(skyEnem) as GameObject;
        skyEnemObj.transform.position = new Vector2(-screenBounds.x * -2, UnityEngine.Random.Range(MIN_Y, MAX_Y));
    }//spawnSkyEnem
}//sendSkyEnem
