using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private DialogueTrigger optionsTrigger;

    public EndGame endGame;

    public bool sonarOn;
    public bool lightsOn;

    public Animator animator;

    private string levelToLoad;

    //controls whether cursor is locked
    public bool cursorLocked = true;

    //boolean for testing 
    //do not delete lol   
    public bool testing;

    public bool paused = false;

    public float maxHeight;

    // How many items the player has and if they can win or not
    public int itemCount = 0;
    public bool canWin = false;

    // Start is called before the first frame update
    void Start()
    {
        // Locks cursor in the middle of the screen while playing
        if (SceneManager.GetActiveScene().name.Equals("Start Screen"))
        {
            Debug.Log("StartScreenHit");
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if game is paused, then unlock the cursor
        if (PauseMenu.isPaused) {
            Cursor.lockState = CursorLockMode.None;
        }
        else if ((SceneManager.GetActiveScene().name.Equals("Code Testing"))) { 
             Cursor.lockState = CursorLockMode.None;
        }
        //lock the cursor to the middle of the screen
        else {
            if (!(SceneManager.GetActiveScene().name.Equals("Start Screen"))) {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        
        // If the player has collected this many items they can win
        if(itemCount >= 3)
        {
            canWin = true;
        }
    }

    public void SceneTransition(string sceneName)
    {
        animator.SetTrigger("FadeOut");
        Debug.Log("HitScene");
        if (GameObject.Find("Dialogue"))
        {
           GameObject.Find("Dialogue").SetActive(false);
        }
        levelToLoad = sceneName;
    }

    public void OnFadeComplete()
    {
        Debug.Log("Fade Complete");
        SceneManager.LoadScene(levelToLoad);
    }

    public void CheckOptions()
    {
        // Triggers options popup if the trigger exists in the scene
        if (GameObject.Find("OptionsTrigger"))
        {
            optionsTrigger = GameObject.Find("OptionsTrigger").GetComponent<DialogueTrigger>();
            optionsTrigger.TriggerDialogue();
        }
    }
}
