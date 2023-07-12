using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    //variable for the options menu gameobject
    public GameObject optionsMenu;
    //variable for the main menu ui gameobject
    public GameObject mainMenu;
    //variable for the exit confirmation
    public GameObject exitConfirmation; 

    //moves to the first level of the game
    public void StartGame() {
        //add some scene transition thingy here
        gm.SceneTransition("IntroCutscene");
    }

    //brings up the exit confirmation dialouge
    public void LoadExitConfirmation() {
        exitConfirmation.SetActive(true);
    }

    //gets rid of exit confirmation dialouge
    public void UnloadExitConfirmation() {
        exitConfirmation.SetActive(false);
    }

    //exits the application 
    public void QuitApplication() {
        Application.Quit();
    }

    //brings up the options menu 
    public void LoadOptions() {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    //loads the main menu from the options menu ui
    public void ToMainMenu() {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true); 
    }

    
}
