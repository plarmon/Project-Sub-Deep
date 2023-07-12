using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem_Redux : MonoBehaviour {

    //values for electricity and life support amounts
    public float maxElectricityEnergy;
    public float currentElectricityEnergy;   
    public float maxLifeSupportEnergy;
    public float currentLifeSupportEnergy;

    //values for tracking whether life support/electricity functions are operational
    public bool lifeSupportOn = false;
    public bool lightsOn = false;
    public bool sonarOn = false;

    //link to life support audio
    //public GameObject lifeSupportAudioObject;

    //energy bar variables
    public EnergyBar_Redux lifeSupportBar; 
    public EnergyBar_Redux electricityBar;

    //tracks whether or not there is electricity or life support energy to use
    public bool lifeSupportAvailable = false;
    public bool electricityAvailable = false;    
 
    //drain speeds for the systems
    [Tooltip("Controls how fast energy from the life support goes down")]
    public float lifeSupportDrainSpeed;
    [Tooltip("Controls how fast energy from the life support goes up")]
    public float lifeSupportIncreaseSpeed;
    [Tooltip("Controls how fast energy from the electricity goes down")]
    public float lifeSupportElectricityDrainSpeed;
    private float totalLifeSupportGaugeSpeed = 0f;
    public float lightsDrainSpeed;
    public float sonarDrainSpeed;
    //handles the accumulated drain speed
    private float totalElectricityDrainSpeed = 0f;

    //variables for the dimming lights stuff
    [SerializeField] private Light dimLights;
    [SerializeField] private Light dimLightsFlicker;
    [SerializeField] private Color outOfEnergyColor;
    [SerializeField] private float lightsOutIntensity;

    //link to Life Support effects
    [SerializeField] private GameObject lifeSupportObject;
    private Animator lifeSupportAnimator;
    public DialogueTrigger suffocate;
    private bool suffocatePlayed = false;

    public AudioSource alarmSound;

    // Start is called before the first frame update
    void Start()
    {
        //initalizing the starting amounts for the gauges
        currentElectricityEnergy = maxElectricityEnergy;
        currentLifeSupportEnergy = maxLifeSupportEnergy;
        lifeSupportAnimator = lifeSupportObject.GetComponent<Animator>();

        //setting the initial gauge drain rates
        if (lifeSupportBar != null)
        {            
            //default rate of change for the bars
            totalLifeSupportGaugeSpeed = -lifeSupportDrainSpeed;
            lifeSupportBar.setEnergyChange(totalLifeSupportGaugeSpeed);
        }
        if (electricityBar != null)
        {
            //making to where it doesn't drain yuh
            electricityBar.setEnergyChange(0.0f);
        }

        //if there is positive non-zero energy set this variable to be true
        if (currentElectricityEnergy > 0) {
            electricityAvailable = true;
        }        

        //if there is positive non-zero energy set this variable to be true
        if (currentLifeSupportEnergy > 0) {
            lifeSupportAvailable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for changing the max amount of energy in both gauges
        if (lifeSupportBar != null) {
            lifeSupportBar.SetMaxEnergy(maxLifeSupportEnergy);
            currentLifeSupportEnergy = lifeSupportBar.getCurrentEnergy();
        }
        if (electricityBar != null) {
            electricityBar.SetMaxEnergy(maxElectricityEnergy);
            currentElectricityEnergy = electricityBar.getCurrentEnergy();
        }

        // if there's no energy, sets electricityAvailable to false
        if (currentElectricityEnergy <= 0) {
            if (electricityAvailable == true)
            {
                electricityAvailable = false;
                alarmSound.Play();
            }
            dimLights.color = outOfEnergyColor;
            dimLights.intensity = lightsOutIntensity;
            dimLightsFlicker.color = outOfEnergyColor;
            dimLightsFlicker.intensity = lightsOutIntensity;
        }

        //if there is positive non-zero energy set these variable to be true
        if (currentLifeSupportEnergy > 0) {
            lifeSupportAvailable = true;
            if (suffocatePlayed) suffocatePlayed = false;
        }
        else {
            lifeSupportAvailable = false;
            if (!suffocatePlayed) suffocate.TriggerDialogue();
        }

        //if there is no life support energy available, set it to zero
        if (!lifeSupportAvailable) {
            if (!suffocatePlayed) suffocatePlayed = true;
            currentLifeSupportEnergy = 0;
        }

        // Toggle Life Support Effects
        lifeSupportAnimator.SetBool("lifeSupportToggle", lifeSupportOn);     
        
    }

    //handles the state configuration of the life support bar
    public void lifeElectricityToggle() {
        if (currentLifeSupportEnergy >= 0 && lifeSupportOn == false) {
            //zero out the draining           
            lifeSupportBar.setEnergyChange(0f);
            //change the drain speed now
            totalLifeSupportGaugeSpeed = lifeSupportIncreaseSpeed;
            lifeSupportBar.setEnergyChange(lifeSupportIncreaseSpeed);

            totalElectricityDrainSpeed -= lifeSupportElectricityDrainSpeed;
            electricityBar.setEnergyChange(totalElectricityDrainSpeed);

            lifeSupportOn = true;
        }
        //essentially reversing the effects caused by turning the system on
        else if (currentLifeSupportEnergy >= 0 && lifeSupportOn == true) {
            //zero out the draining
            totalLifeSupportGaugeSpeed = 0f;
            lifeSupportBar.setEnergyChange(totalLifeSupportGaugeSpeed);
            //change the drain speed now
            totalLifeSupportGaugeSpeed = -lifeSupportDrainSpeed;
            lifeSupportBar.setEnergyChange(totalLifeSupportGaugeSpeed);

            totalElectricityDrainSpeed += lifeSupportElectricityDrainSpeed;
            electricityBar.setEnergyChange(totalElectricityDrainSpeed);

            lifeSupportOn = false;
        }        
    }

    //sonar make electricity bar go brrr like sonaarrrrrrrr brrr
    public void sonarElectricityToggle() {
        if (currentElectricityEnergy > 0 && sonarOn == false) {
            totalElectricityDrainSpeed -= sonarDrainSpeed;
            electricityBar.setEnergyChange(totalElectricityDrainSpeed);
            sonarOn = true;
        }
        else if (currentElectricityEnergy > 0 && sonarOn == true) {
            totalElectricityDrainSpeed += sonarDrainSpeed;
            electricityBar.setEnergyChange(totalElectricityDrainSpeed);
            sonarOn = false; 
        }
    }

    //lights make electricity bar go whooooosh and ahhhhh like whooooshhhahhhhhbrrrrrrrrrrr
    public void lightsElectricityToggle() {
        if (currentElectricityEnergy > 0 && lightsOn == false) {
            totalElectricityDrainSpeed -= lightsDrainSpeed;
            electricityBar.setEnergyChange(totalElectricityDrainSpeed);
            lightsOn = true;
        }
        else if (currentElectricityEnergy > 0 && lightsOn == true) {
            totalElectricityDrainSpeed += lightsDrainSpeed;
            electricityBar.setEnergyChange(totalElectricityDrainSpeed);
            lightsOn = false;
        }    
    }
}
