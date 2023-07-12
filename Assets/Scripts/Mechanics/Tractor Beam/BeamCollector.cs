using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamCollector : MonoBehaviour
{
    public GameManager gm;
    public MovementShipForce player;

    private void Start()
    {
        // Initializes Game Manager if it's not already
        if(gm == null)
        {
            gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Collects item
        if (other.gameObject.CompareTag("Item"))
        {
            // Trigger Dialogue
            other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(other.gameObject);
            // Increases item count
            gm.itemCount += 1;
            player.currentRoom.totalItems -= 1;
        }
    }
}
