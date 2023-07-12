using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    public DialogueTrigger cantWinMessage;

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the trigger zone, then transition to 'Win Screen'
        if (other.gameObject.CompareTag("Player"))
        {
            // Checks if the Player can win
            if (gm.canWin)
            {
                gm.SceneTransition("Win Screen");
            } else
            {
                cantWinMessage.TriggerDialogue();
            }
        }
    }
}
