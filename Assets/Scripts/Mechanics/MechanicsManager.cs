using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class MechanicsManager : MonoBehaviour
{
    // Serialized GameObjects
    [SerializeField] private GameObject blankScreenUI;
    [SerializeField] private GameObject flashScreenUI;
    [SerializeField] private GameObject blankScreenSonar;
    [SerializeField] private GameObject flashScreenSonar;
    [SerializeField] private GameObject blankBeamScreen;
    [SerializeField] private Material blankScreenLights;
    [SerializeField] private Material blankScreenLife;
    [SerializeField] private GameObject headlights;
    [SerializeField] private GameObject beamLight;
    [SerializeField] public GameObject BoidObject;

    // Serialized Camera Related Objects
    [SerializeField] private MinimapSnapshot snapCam;
    [SerializeField] private Camera minimapRender;
    [SerializeField] private Camera mainCamera;

    // Serialized Colors
    [SerializeField] private Color lightsOffFogColor;
    [SerializeField] private Color lightsOffCameraColor;
    [SerializeField] private Color lightsOnFogColor;
    [SerializeField] private Color lightsOnCameraColor;
    [SerializeField] private Color screenColor;

    // Serialized Sounds
    [SerializeField] private AudioClip sonarSound;
    [SerializeField] private AudioSource sonarSource; 

    // Serialized Floats
    [SerializeField] private float sonarInterval;   // 3.0f
    [SerializeField] private float flashInterval;   // 0.1f
    [SerializeField] private float sonarVolume;     // 1.0f
    [SerializeField] private float screenIntensity; // 0.5f

    [SerializeField] private GameObject tractorBeam;

    // Private Objects    
    //new energy system
    private EnergySystem_Redux energySystem;

    public GameManager gameManager;

    // Private Floats
    private float maxSonarInterval = 3.0f;
    private float maxFlashInterval = 0.1f;

    // Public Bools
    public bool sonarOn = false;
    public bool lightsOn = false;
    public bool lifeOn = false;
    public bool beamOn = false;
    private bool mechanicsOn = true;


    private void Start()
    {
        energySystem = GetComponent<EnergySystem_Redux>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Initializes variables if not defined
        if (blankScreenSonar == null)
            blankScreenSonar = new GameObject();
        if (flashScreenSonar == null)
            flashScreenSonar = new GameObject();
        if (flashScreenUI == null)
            flashScreenUI = new GameObject();
        if (blankScreenUI == null)
            blankScreenUI = new GameObject();

        blankScreenLife.EnableKeyword("_EMISSION");
        blankScreenLife.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        blankScreenLife.SetColor("_EmissionColor",Color.black * screenIntensity);

        blankScreenLights.EnableKeyword("_EMISSION");
        blankScreenLights.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        blankScreenLights.SetColor("_EmissionColor", Color.black * screenIntensity);

        
    }

    void Update()
    {
        // If there's electricity left check for keyboardinputs
        if (energySystem != null)
        {
            if (!energySystem.electricityAvailable)
            {
                if (sonarOn)
                {
                    SonarToggle();
                }
                if (lightsOn)
                {
                    LightsToggle();
                }
                if (lifeOn)
                {
                    LifeToggle();
                }
                if (beamOn)
                {
                    BeamToggle();
                }

                // Make the boid attracted to the sub
                if (BoidObject != null)
                {
                    BoidObject.GetComponent<BoidVectorController>().lightOn = true;
                }

                mechanicsOn = false;
            }
        }

        // If the sonar flash is happening
        if (flashScreenSonar.activeSelf)
        {
            // Turns the flash off if the flash interval is up
            if (flashInterval <= 0)
            {
                flashScreenSonar.SetActive(false);
                flashScreenUI.SetActive(false);
                flashInterval = maxFlashInterval;
            }
            else
            {
                flashInterval -= Time.deltaTime;
            }
        }

        // If the sonar is on then takes screenshots over an interval
        if (sonarOn)
        {
            if (sonarInterval <= 0)
            {
                SonarSnapshot();
            }
            sonarInterval -= Time.deltaTime;
        }

        //lifeOn is tied to the energy system's lifeSupportOn variable in order to account for the
        //life support being maxed
        //this block of code allows for the life support system to be automatically turned off
        //even if player input is not registered
        if (energySystem != null)
        {
            lifeOn = energySystem.lifeSupportOn;
        } else
        {
            lifeOn = false;
        }
    }

    //Updates the sonar
    private void SonarSnapshot()
    {
        // Takes a snapshot with the sonar camera
        snapCam.CallTakeSnapshot();
        // Flash on the sonar screens
        flashScreenSonar.SetActive(true);
        flashScreenUI.SetActive(true);
        sonarInterval = maxSonarInterval;
        // Play sonar sound
        BetterPlayClipAtPoint.PlayClipAtPoint(sonarSource, this.transform.position);
        // Pings the boid
        if (BoidObject != null)
        {
            BoidObject.GetComponent<BoidVectorController>().sonarWeight = (BoidObject.GetComponent<BoidVectorController>().sonarWeight + 0.1f) * 2.0f;
        }
    }

    //Turns on or off the sonar
    public void SonarToggle()
    {
        if (mechanicsOn && !gameManager.paused)
        {
            // Pings Energy System to update electricity because of sonar toggle 
            if (energySystem != null)
            {
                energySystem.sonarElectricityToggle();
            }

            // Toggles sonar
            sonarOn = !sonarOn;

            // Takes picture if it was off, gets rid of blank screen, and flashes
            if (!sonarOn)
            {
                sonarInterval = maxSonarInterval;
                blankScreenSonar.SetActive(true);
                blankScreenUI.SetActive(true);
            }
            // Turns the sonar off and turns the blank screen back on
            else
            {
                blankScreenSonar.SetActive(false);
                blankScreenUI.SetActive(false);
                SonarSnapshot();
            }
        }
    }

    //Turns on or off the lights
    public void LightsToggle()
    {
        if (mechanicsOn && !gameManager.paused)
        {
            // Pings Energy System to update electricity because of lights toggle
            if (energySystem != null)
            {
                energySystem.lightsElectricityToggle();
            }

            // Toggles headlights
            lightsOn = !lightsOn;
            headlights.SetActive(lightsOn);

            // Togles boid 
            if (BoidObject != null)
            {
                BoidObject.GetComponent<BoidVectorController>().lightOn = lightsOn;
            }

            // Set fog/background to correct color based on if the headlights are on or not
            if (lightsOn)
            {
                RenderSettings.fogColor = lightsOnFogColor;
                mainCamera.backgroundColor = lightsOnCameraColor;

                blankScreenLights.EnableKeyword("_EMISSION");
                blankScreenLights.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

                blankScreenLights.SetColor("_EmissionColor", screenColor * screenIntensity);
            }
            else
            {
                RenderSettings.fogColor = lightsOffFogColor;
                mainCamera.backgroundColor = lightsOffCameraColor;

                blankScreenLights.DisableKeyword("_EMISSION");
                blankScreenLights.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;

                blankScreenLights.SetColor("_EmissionColor", screenColor * screenIntensity);
            }
        }
    }

    //Turns on or off the life support
    public void LifeToggle()
    {
        if (mechanicsOn && !gameManager.paused)
        {
            // Pings Energy System to update electricity because of life support toggle
            energySystem.lifeElectricityToggle();
            lifeOn = energySystem.lifeSupportOn;
            if (lifeOn)
            {
                blankScreenLife.EnableKeyword("_EMISSION");
                blankScreenLife.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

                blankScreenLife.SetColor("_EmissionColor", screenColor * screenIntensity);
            }
            else
            {
                blankScreenLife.DisableKeyword("_EMISSION");
                blankScreenLife.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;

                blankScreenLife.SetColor("_EmissionColor", screenColor * screenIntensity);
            }
        }
    }

    public void BeamToggle()
    {
        if (mechanicsOn && !gameManager.paused)
        {
            beamOn = !beamOn;
            if (!beamOn)
            {
                tractorBeam.transform.localScale = tractorBeam.GetComponent<TractorBeamTrigger>().startingScale;
                tractorBeam.transform.position = tractorBeam.GetComponent<TractorBeamTrigger>().target.position;
                blankBeamScreen.SetActive(true);
                beamLight.SetActive(false);
            }
            else
            {
                tractorBeam.GetComponent<TractorBeamTrigger>().extending = true;
                blankBeamScreen.SetActive(false);
                beamLight.SetActive(true);
            }
            tractorBeam.SetActive(beamOn);
        }
    }
}
