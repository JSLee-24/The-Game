// Jade Lee
// This code keeps track of the current scores and the game's high score

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text scoreText;                          //the users current score text
    public Text highScore;                          //the game's highscore text
    public static float score;                      //the score as a float used thorughout the program
    private float pointIncreasePerSecond = 8f;      //how many points to increase by every second 

    // Start is called before the first frame update
    void Start() {

        //set the score to 0
        score = 0f;
        
        //set the highscore text
        highScore.text = "High Score: " + ((int)PlayerPrefs.GetFloat("High Score", 0)).ToString("0");
    }//Start

    // Update is called once per frame
    void Update() {

        //keep adding to the the score
        score += pointIncreasePerSecond * Time.deltaTime;
        
        //update the score text
        scoreText.text = "Score: " + (int)score;

        //if we have a new highscore
        if(score > (int)PlayerPrefs.GetFloat("High Score", 0)) {
            //update the new highscore
            PlayerPrefs.SetFloat("High Score", (int)score);
            //show the updated highscore
            highScore.text = "High Score: " + score.ToString("0");
        }//if
    }//Update
}//Score
