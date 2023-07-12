// GENERATED AUTOMATICALLY FROM 'Assets/Prefabs/Sub/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""12c17bbf-7129-4104-9a0e-032fb3cb82f1"",
            ""actions"": [
                {
                    ""name"": ""moveHorizInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8e8e2ba6-cff5-49db-956e-57583b84e2b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""moveVertInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a7cd0446-13ff-4d7b-83eb-40c33da90ba4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""mouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8e97aa54-b6d6-4183-b0f2-57c5d46374f2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""mouseY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""de347dab-1c78-43a9-b048-b75bfad1f08b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c2cff6b2-d919-48a6-b438-e86472b3dff9"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveHorizInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""forwardBackwards"",
                    ""id"": ""8e01a0a5-7076-4838-b804-6e7e63661f19"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveHorizInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""df55a80c-e27f-456a-9ef3-8b06a5682bc9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveHorizInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cd647a03-4e47-47cd-8930-2a5829535e4d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveHorizInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""90247707-9220-4ff1-88b5-2d57b2d682e7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveVertInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""upDown"",
                    ""id"": ""7ccf306d-e3ec-4315-8dd9-8ee8834de693"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveVertInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a88246f8-14a8-440c-b381-4556d62f9056"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveVertInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""405879f5-4793-4dbe-aa0b-b2af10face7f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveVertInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c40265d4-3392-43e4-9d62-55302103db7d"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""mouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""661eff1a-4565-4b66-862d-cc8276d0bb30"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""mouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mechanics"",
            ""id"": ""afb9a860-5364-411f-983c-49754e1814f3"",
            ""actions"": [
                {
                    ""name"": ""Lights"",
                    ""type"": ""Value"",
                    ""id"": ""b919d7c8-342a-4f59-9614-133605316a96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sonar"",
                    ""type"": ""Button"",
                    ""id"": ""b810ec43-9779-41a4-b0c4-673a0d5a271e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Life"",
                    ""type"": ""Button"",
                    ""id"": ""4470e8d6-4486-4502-a6c0-3780263e6351"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Beam"",
                    ""type"": ""Button"",
                    ""id"": ""0cd7820a-cbd4-4de7-81b2-7d82ebd47fa1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""View"",
                    ""type"": ""Button"",
                    ""id"": ""d3e02ac0-af6a-4868-b207-61efd5d2dc59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PushButton"",
                    ""type"": ""Button"",
                    ""id"": ""4b40115c-9fa5-40da-a50d-2c6474be2ee5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b9722ea-6c99-448e-8a38-6ebe082d6a72"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lights"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""645d4fc6-da4d-4aa1-bac0-c2e99a884119"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sonar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ca10d38-c09a-4804-9e92-d38b8f915f96"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Life"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35ef11fd-f20b-4a30-8002-0f5a71e94a6e"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Beam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0dbe24ab-ba37-42bf-ac28-ef7baf323ec7"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""958c66d5-59f2-487f-9f8d-3447cf3b9b66"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogue"",
            ""id"": ""55f9b900-41ad-45d6-919f-83209727b3d9"",
            ""actions"": [
                {
                    ""name"": ""textContinue"",
                    ""type"": ""Button"",
                    ""id"": ""60f61644-db8e-477d-9ef4-de21767486e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""620da76c-ae91-4f0e-84a0-e913e152b378"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""textContinue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause"",
            ""id"": ""43d4a9df-d0db-4a91-bb57-875ded010cec"",
            ""actions"": [
                {
                    ""name"": ""pauseInput"",
                    ""type"": ""Button"",
                    ""id"": ""e83505ac-c16f-4801-ad9d-48d37ed558ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ada80030-0974-45df-a9eb-624309e70a49"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pauseInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Timeline"",
            ""id"": ""d2ce92ed-f5e6-44a5-9ef9-908e88c98b2f"",
            ""actions"": [
                {
                    ""name"": ""PromptSkip"",
                    ""type"": ""Button"",
                    ""id"": ""aa1ba687-a9b6-4eb5-a52f-0403d0eaecea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skip"",
                    ""type"": ""Button"",
                    ""id"": ""b83c5838-8b5e-4ae3-b74e-3546df160a5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""118c9509-00e1-4891-8437-f8853a3a469c"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PromptSkip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c19af10-4e4d-4e81-a1b5-922a51ca5f09"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_moveHorizInput = m_Movement.FindAction("moveHorizInput", throwIfNotFound: true);
        m_Movement_moveVertInput = m_Movement.FindAction("moveVertInput", throwIfNotFound: true);
        m_Movement_mouseX = m_Movement.FindAction("mouseX", throwIfNotFound: true);
        m_Movement_mouseY = m_Movement.FindAction("mouseY", throwIfNotFound: true);
        // Mechanics
        m_Mechanics = asset.FindActionMap("Mechanics", throwIfNotFound: true);
        m_Mechanics_Lights = m_Mechanics.FindAction("Lights", throwIfNotFound: true);
        m_Mechanics_Sonar = m_Mechanics.FindAction("Sonar", throwIfNotFound: true);
        m_Mechanics_Life = m_Mechanics.FindAction("Life", throwIfNotFound: true);
        m_Mechanics_Beam = m_Mechanics.FindAction("Beam", throwIfNotFound: true);
        m_Mechanics_View = m_Mechanics.FindAction("View", throwIfNotFound: true);
        m_Mechanics_PushButton = m_Mechanics.FindAction("PushButton", throwIfNotFound: true);
        // Dialogue
        m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
        m_Dialogue_textContinue = m_Dialogue.FindAction("textContinue", throwIfNotFound: true);
        // Pause
        m_Pause = asset.FindActionMap("Pause", throwIfNotFound: true);
        m_Pause_pauseInput = m_Pause.FindAction("pauseInput", throwIfNotFound: true);
        // Timeline
        m_Timeline = asset.FindActionMap("Timeline", throwIfNotFound: true);
        m_Timeline_PromptSkip = m_Timeline.FindAction("PromptSkip", throwIfNotFound: true);
        m_Timeline_Skip = m_Timeline.FindAction("Skip", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_moveHorizInput;
    private readonly InputAction m_Movement_moveVertInput;
    private readonly InputAction m_Movement_mouseX;
    private readonly InputAction m_Movement_mouseY;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @moveHorizInput => m_Wrapper.m_Movement_moveHorizInput;
        public InputAction @moveVertInput => m_Wrapper.m_Movement_moveVertInput;
        public InputAction @mouseX => m_Wrapper.m_Movement_mouseX;
        public InputAction @mouseY => m_Wrapper.m_Movement_mouseY;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @moveHorizInput.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveHorizInput;
                @moveHorizInput.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveHorizInput;
                @moveHorizInput.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveHorizInput;
                @moveVertInput.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveVertInput;
                @moveVertInput.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveVertInput;
                @moveVertInput.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveVertInput;
                @mouseX.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseX;
                @mouseX.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseX;
                @mouseX.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseX;
                @mouseY.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseY;
                @mouseY.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseY;
                @mouseY.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMouseY;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @moveHorizInput.started += instance.OnMoveHorizInput;
                @moveHorizInput.performed += instance.OnMoveHorizInput;
                @moveHorizInput.canceled += instance.OnMoveHorizInput;
                @moveVertInput.started += instance.OnMoveVertInput;
                @moveVertInput.performed += instance.OnMoveVertInput;
                @moveVertInput.canceled += instance.OnMoveVertInput;
                @mouseX.started += instance.OnMouseX;
                @mouseX.performed += instance.OnMouseX;
                @mouseX.canceled += instance.OnMouseX;
                @mouseY.started += instance.OnMouseY;
                @mouseY.performed += instance.OnMouseY;
                @mouseY.canceled += instance.OnMouseY;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Mechanics
    private readonly InputActionMap m_Mechanics;
    private IMechanicsActions m_MechanicsActionsCallbackInterface;
    private readonly InputAction m_Mechanics_Lights;
    private readonly InputAction m_Mechanics_Sonar;
    private readonly InputAction m_Mechanics_Life;
    private readonly InputAction m_Mechanics_Beam;
    private readonly InputAction m_Mechanics_View;
    private readonly InputAction m_Mechanics_PushButton;
    public struct MechanicsActions
    {
        private @PlayerControls m_Wrapper;
        public MechanicsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Lights => m_Wrapper.m_Mechanics_Lights;
        public InputAction @Sonar => m_Wrapper.m_Mechanics_Sonar;
        public InputAction @Life => m_Wrapper.m_Mechanics_Life;
        public InputAction @Beam => m_Wrapper.m_Mechanics_Beam;
        public InputAction @View => m_Wrapper.m_Mechanics_View;
        public InputAction @PushButton => m_Wrapper.m_Mechanics_PushButton;
        public InputActionMap Get() { return m_Wrapper.m_Mechanics; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MechanicsActions set) { return set.Get(); }
        public void SetCallbacks(IMechanicsActions instance)
        {
            if (m_Wrapper.m_MechanicsActionsCallbackInterface != null)
            {
                @Lights.started -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnLights;
                @Lights.performed -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnLights;
                @Lights.canceled -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnLights;
                @Sonar.started -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnSonar;
                @Sonar.performed -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnSonar;
                @Sonar.canceled -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnSonar;
                @Life.started -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnLife;
                @Life.performed -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnLife;
                @Life.canceled -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnLife;
                @Beam.started -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnBeam;
                @Beam.performed -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnBeam;
                @Beam.canceled -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnBeam;
                @View.started -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnView;
                @PushButton.started -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnPushButton;
                @PushButton.performed -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnPushButton;
                @PushButton.canceled -= m_Wrapper.m_MechanicsActionsCallbackInterface.OnPushButton;
            }
            m_Wrapper.m_MechanicsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Lights.started += instance.OnLights;
                @Lights.performed += instance.OnLights;
                @Lights.canceled += instance.OnLights;
                @Sonar.started += instance.OnSonar;
                @Sonar.performed += instance.OnSonar;
                @Sonar.canceled += instance.OnSonar;
                @Life.started += instance.OnLife;
                @Life.performed += instance.OnLife;
                @Life.canceled += instance.OnLife;
                @Beam.started += instance.OnBeam;
                @Beam.performed += instance.OnBeam;
                @Beam.canceled += instance.OnBeam;
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
                @PushButton.started += instance.OnPushButton;
                @PushButton.performed += instance.OnPushButton;
                @PushButton.canceled += instance.OnPushButton;
            }
        }
    }
    public MechanicsActions @Mechanics => new MechanicsActions(this);

    // Dialogue
    private readonly InputActionMap m_Dialogue;
    private IDialogueActions m_DialogueActionsCallbackInterface;
    private readonly InputAction m_Dialogue_textContinue;
    public struct DialogueActions
    {
        private @PlayerControls m_Wrapper;
        public DialogueActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @textContinue => m_Wrapper.m_Dialogue_textContinue;
        public InputActionMap Get() { return m_Wrapper.m_Dialogue; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogueActions set) { return set.Get(); }
        public void SetCallbacks(IDialogueActions instance)
        {
            if (m_Wrapper.m_DialogueActionsCallbackInterface != null)
            {
                @textContinue.started -= m_Wrapper.m_DialogueActionsCallbackInterface.OnTextContinue;
                @textContinue.performed -= m_Wrapper.m_DialogueActionsCallbackInterface.OnTextContinue;
                @textContinue.canceled -= m_Wrapper.m_DialogueActionsCallbackInterface.OnTextContinue;
            }
            m_Wrapper.m_DialogueActionsCallbackInterface = instance;
            if (instance != null)
            {
                @textContinue.started += instance.OnTextContinue;
                @textContinue.performed += instance.OnTextContinue;
                @textContinue.canceled += instance.OnTextContinue;
            }
        }
    }
    public DialogueActions @Dialogue => new DialogueActions(this);

    // Pause
    private readonly InputActionMap m_Pause;
    private IPauseActions m_PauseActionsCallbackInterface;
    private readonly InputAction m_Pause_pauseInput;
    public struct PauseActions
    {
        private @PlayerControls m_Wrapper;
        public PauseActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @pauseInput => m_Wrapper.m_Pause_pauseInput;
        public InputActionMap Get() { return m_Wrapper.m_Pause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActions instance)
        {
            if (m_Wrapper.m_PauseActionsCallbackInterface != null)
            {
                @pauseInput.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnPauseInput;
                @pauseInput.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnPauseInput;
                @pauseInput.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnPauseInput;
            }
            m_Wrapper.m_PauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @pauseInput.started += instance.OnPauseInput;
                @pauseInput.performed += instance.OnPauseInput;
                @pauseInput.canceled += instance.OnPauseInput;
            }
        }
    }
    public PauseActions @Pause => new PauseActions(this);

    // Timeline
    private readonly InputActionMap m_Timeline;
    private ITimelineActions m_TimelineActionsCallbackInterface;
    private readonly InputAction m_Timeline_PromptSkip;
    private readonly InputAction m_Timeline_Skip;
    public struct TimelineActions
    {
        private @PlayerControls m_Wrapper;
        public TimelineActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PromptSkip => m_Wrapper.m_Timeline_PromptSkip;
        public InputAction @Skip => m_Wrapper.m_Timeline_Skip;
        public InputActionMap Get() { return m_Wrapper.m_Timeline; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TimelineActions set) { return set.Get(); }
        public void SetCallbacks(ITimelineActions instance)
        {
            if (m_Wrapper.m_TimelineActionsCallbackInterface != null)
            {
                @PromptSkip.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnPromptSkip;
                @PromptSkip.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnPromptSkip;
                @PromptSkip.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnPromptSkip;
                @Skip.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnSkip;
                @Skip.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnSkip;
                @Skip.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnSkip;
            }
            m_Wrapper.m_TimelineActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PromptSkip.started += instance.OnPromptSkip;
                @PromptSkip.performed += instance.OnPromptSkip;
                @PromptSkip.canceled += instance.OnPromptSkip;
                @Skip.started += instance.OnSkip;
                @Skip.performed += instance.OnSkip;
                @Skip.canceled += instance.OnSkip;
            }
        }
    }
    public TimelineActions @Timeline => new TimelineActions(this);
    public interface IMovementActions
    {
        void OnMoveHorizInput(InputAction.CallbackContext context);
        void OnMoveVertInput(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
    }
    public interface IMechanicsActions
    {
        void OnLights(InputAction.CallbackContext context);
        void OnSonar(InputAction.CallbackContext context);
        void OnLife(InputAction.CallbackContext context);
        void OnBeam(InputAction.CallbackContext context);
        void OnView(InputAction.CallbackContext context);
        void OnPushButton(InputAction.CallbackContext context);
    }
    public interface IDialogueActions
    {
        void OnTextContinue(InputAction.CallbackContext context);
    }
    public interface IPauseActions
    {
        void OnPauseInput(InputAction.CallbackContext context);
    }
    public interface ITimelineActions
    {
        void OnPromptSkip(InputAction.CallbackContext context);
        void OnSkip(InputAction.CallbackContext context);
    }
}
