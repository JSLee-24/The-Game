//Jade Lee
//This code manages the game over screen shown once the game ends
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    //public Text highScore;         //the games high score text (the text the user sees)
    public Text scoreTexts;         //the users score text (the text the user sees) 

    private static bool gameOver = false; 

    //set up the game over screen
    public void Setup(float score)
    {
        //game ended
        gameOver = true; 

        //set this gameobject to active so the user can see it
        gameObject.SetActive(true);                           
        
        //show there score 
        scoreTexts.text = "Your score was: " + score.ToString("0");
        
        //show the game's highscore
        //highScore.text = "High Score: " + PlayerPrefs.GetFloat("High Score", 0).ToString("0");
    }//Setup

    //if the user wants to restart the game they can click this button
    public void RestartButton()
    {
        //game restarts, no longer ended
        gameOver = false; 

        //reload the game scene
        SceneManager.LoadScene("The Game");

        //unpause the game
        Time.timeScale = 1f;
    }//RestartButton

    //if the user wnats to go back to the main menu they click this button
    public void MainMenuButton()
    {
        //load the main menu scene
        SceneManager.LoadScene("Menu");
    }//MainMenuButton

    //if the user wants to reset the games highscore they click this buttons
    public void RESETHighScore()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("High Score");
    }//RESETHighScore

    //returns whether the game ended or not
    public static bool endOfGame(){
        return gameOver; 
    }//endOfGame
}//GameOverScreen
