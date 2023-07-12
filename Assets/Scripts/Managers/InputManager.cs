using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] MovementShipForce movement;
    [SerializeField] MechanicsManager mechanics;
    [SerializeField] Movement_Camera mainCam;
    [SerializeField] EnergySystem_Redux energySystem;
    [SerializeField] DialogueManager dialogue;
    [SerializeField] PauseMenu pause;
    [SerializeField] TimelineController timeline;

    private PlayerControls controls;
    private PlayerControls.MovementActions movementActions;
    private PlayerControls.MechanicsActions mechanicsActions;
    private PlayerControls.DialogueActions dialogueActions;
    private PlayerControls.PauseActions pauseActions;
    private PlayerControls.TimelineActions timelineActions;

    private float horizontalInput;
    private float verticalInput;

    private Vector2 mouseInput;

    private void Awake()
    {
        // Defining Input Actions
        controls = new PlayerControls();
        movementActions = controls.Movement;
        mechanicsActions = controls.Mechanics;
        dialogueActions = controls.Dialogue;
        pauseActions = controls.Pause;
        timelineActions = controls.Timeline;

        // Movement related Inputs
        movementActions.moveHorizInput.performed += ctx => horizontalInput = ctx.ReadValue<float>();
        movementActions.moveVertInput.performed += ctx => verticalInput = ctx.ReadValue<float>();

        // Mouse related Inputs
        movementActions.mouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        movementActions.mouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        // Mechanics related Inputs
        mechanicsActions.Beam.performed += _ => mechanics.BeamToggle();
        mechanicsActions.Lights.performed += _ => mechanics.LightsToggle();
        mechanicsActions.Sonar.performed += _ => mechanics.SonarToggle();
        mechanicsActions.Life.performed += _ => mechanics.LifeToggle();

        // Camera mechanics related Inputs
        mechanicsActions.View.performed += _ => mainCam.viewToggle();
        mechanicsActions.PushButton.performed += _ => mainCam.pushButton();

        // Dialogue related inputs
        dialogueActions.textContinue.performed += _ => dialogue.DisplayNextSentence();

        // Pause related Inputs
        if (pause != null)
        {
            pauseActions.pauseInput.performed += _ => pause.PauseToggle();
        }

        // Timeline related Inputs
        if (timeline != null)
        {
            timelineActions.PromptSkip.performed += _ => timeline.SkipPrompt();
            timelineActions.Skip.performed += _ => timeline.Skip();
        }
    }

    // Enable inputs
    private void OnEnable()
    {
        controls.Enable();
    }

    // Disable inputs
    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // If movement is available then send inputs
        if (movement != null)
        {
            movement.ReceiveInput(horizontalInput, verticalInput);
            movement.RecieveMouseInput(mouseInput);
        }
        if (mainCam != null)
        {
            mainCam.RecieveMouseInput(mouseInput);
        }
    }
}
