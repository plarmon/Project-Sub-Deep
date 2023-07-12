using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    //flag for game paused
    public static bool isPaused = false;
    //game object variable for pause and options menu
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    

    //game object variable for the confirmation dialog prompt
    public GameObject confirmationPrompt;

    //called at start of game
    private void Start() {
        //need this for the game manager? 
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();  
    }

    public void PauseToggle() {
        if (!isPaused) { 
            //pause the game silly
            Pause();
        }
        else {
            //resume the game silly
            Resume();
        }
    }

    //resume function
    public void Resume() {
        //closes out the menu uis
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        

        //setting game to move at normal rate
        Time.timeScale = 1f;
        gm.paused = false;
        isPaused = false;
    }

    //pause function
    public void Pause() {
        //closes exit confirmation if needed
        confirmationPrompt.SetActive(false);
        //brings up the pause menu ui
        pauseMenuUI.SetActive(true);
        
        //freezes the game
        Time.timeScale = 0f;
        gm.paused = true;
        isPaused = true;       
    }

    //function handling the options menu ui stuffs
    public void LoadOptions() {
        //closes the pause menu
        pauseMenuUI.SetActive(false);
        //brings up the options menu
        optionsMenuUI.SetActive(true);
        //freezes the game
        Time.timeScale = 0f;
        gm.paused = true;
        isPaused = true;
    }

    //returns to the pause menu
    public void GoBackPauseMenu() {
        //closes the options menu
        optionsMenuUI.SetActive(false);
        //opens the pause menu
        pauseMenuUI.SetActive(true);
        
        //freezes the game
        Time.timeScale = 0f;
        gm.paused = true;
        isPaused = true;
    }

    //changes the scene to the main menu one
    public void MainMenuConfirmation() {        
        //clear the screen of all other prompts        
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);

        //bring up confirmation prompt
        confirmationPrompt.SetActive(true);
    }

    //after confirmation, changes the scene to main menu 
    public void ToMainMenu() {
        Resume();
        gm.SceneTransition("Start Screen");
    }  
}
