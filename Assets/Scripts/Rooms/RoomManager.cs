using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<FlockUnit> roomFish;
    public RoomManager nextRoom;
    public RoomManager prevRoom;
    public Rooms room;

    public DialogueTrigger itemsRemaining;
    public DialogueTrigger roomClear;

    public int totalItems;

    public bool active;

    public enum Rooms {
        Room1,
        Room2,
        Room3
    }

    private void Update()
    {
        // If a room isn't active then despawn
        if (!active)
        {
            DeSpawn();
        }
    }

    //Spawns all of the necessary objects for a room
    public void Spawn()
    {
        // Spawn each object in fish array
        foreach (FlockUnit obj in roomFish)
        {
            obj.assignedFlock.active = true;
            obj.gameObject.SetActive(true);
        }
        active = true;
    }

    //Despawns all necessary objects for a room
    public void DeSpawn()
    {
        // Despawn each object in fish array
        foreach (FlockUnit obj in roomFish)
        {
            obj.assignedFlock.active = false;
            obj.gameObject.SetActive(false);
        }
        active = false;
    }

    /*
     * If the player exits then spawn the stuff for the next room,
     * also trigger dialogue if necessary
     */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (FlockUnit obj in roomFish)
            {
                if (!obj.assignedFlock.pathFlock)
                {
                    obj.assignedFlock.active = false;
                }
            }
            // Triggers Dialogue if objects are still in room
            if (totalItems > 0)
            {
                itemsRemaining.TriggerDialogue();
            } else
            {
                roomClear.TriggerDialogue();
            }
            // Sets players current room to null
            MovementShipForce player = other.gameObject.GetComponent<MovementShipForce>();
            player.currentRoom = null;
            // Spawns objects in next room
            if (nextRoom != null)
            {
                nextRoom.Spawn();
            }
        }
    }

    //If player enters then despawn stuff from previous room
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (FlockUnit obj in roomFish)
            {
                obj.assignedFlock.active = true;
            }
            // Sets the players current room to this room
            MovementShipForce player = other.gameObject.GetComponent<MovementShipForce>();
            player.currentRoom = this;
            // Despawns objects in previous room
            if(prevRoom != null)
            {
                prevRoom.DeSpawn();
            }
        }
    }
}
