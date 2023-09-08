// Jade Lee
// Sep. 5. 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

//handles all the main menu buttons
public class MainMenu : MonoBehaviour
{

    //if the user presses the play button
    public void Play()
    {
        //load the game scene
        SceneManager.LoadScene("The Game");
    }//Play 

    //if the user wants to exit the game 
    public void Quit()
    {
        //end the application and close the window
/*        UnityEditor.EditorApplication.isPlaying = false;
*/        Application.Quit();
    }//Quit
}//MainMenu
