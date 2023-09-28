// Jade Lee
// Sep. 5. 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using System.Runtime.Serialization;
using System;

//handles all the main menu buttons
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;             // main menu page
    public GameObject rulesPage;            // rules page showing rules
    private bool mainMenuOn = true;         // whether the main menu screen is on or not

    // Update is called once per frame
    void Update()
    {
        //check if the user presses the keyboard to control the menu
        if(mainMenuOn)
        {// main menu controls
            if(Input.GetKey(KeyCode.P))
            {
                // P is pressed, play game
                Play(); 
            }//if
            else if(Input.GetKey(KeyCode.R))
            {
                // R is pressed, load Rules page
                Rules(); 
            }//else if
            else if(Input.GetKey(KeyCode.Q))
            {
                // Q is pressed, quit game
                Quit(); 
            }//else if
        }//if
        else
        {// rules page control
            if(Input.GetKey(KeyCode.B))
            {
                // B is pressed, go back to main menu
                Back(); 
            }//if
        }//else
    }//Update

    // if the user presses the play button
    public void Play()
    {
        //load the game scene
        SceneManager.LoadScene("The Game");
    }//Play 

    // switches to the rules page
    public void Rules()
    {
        //deactivate main menu screen and activate rules page
        mainMenu.SetActive(false);
        rulesPage.SetActive(true);  
        mainMenuOn = false; 
    }//Rules

    // switches back to the main menu page
    public void Back()
    {
        //deactivate main menu screen and activate rules page
        mainMenu.SetActive(true);
        rulesPage.SetActive(false);  
        mainMenuOn = true; 
    }//Back

    // if the user wants to exit the game 
    public void Quit()
    {
        //end the application and close the window
/*        UnityEditor.EditorApplication.isPlaying = false;
*/        Application.Quit();
    }//Quit
}//MainMenu
