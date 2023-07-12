using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar_Redux : MonoBehaviour
{
    //gague slider
    private Image energyImage;
    private Energy energy; 

     private float maxAmount = 100f;
     private float currentAmount;    


    private void Awake() {
        //finding the image gameobject 
        energyImage = transform.Find("Fill").GetComponent<Image>();

        energy = new Energy(maxAmount, maxAmount, 0.1f);
    }

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {   
        //calls the Update function in energy to start the draining effect
        energy.Update();
        //changes the image to correspond to the change
        energyImage.fillAmount = energy.Map(energy.currentEnergy,energy.ENERGY_MAX,0,1,0);
    }

    //sets max energy
    public void SetMaxEnergy(float amount) {
        energy.ENERGY_MAX = amount;
    }

    //set amount of energy to be added
    public void setEnergyChange(float amount) {
        energy.deltaEnergy = amount;
    }

    public float getDeltaEnergy() {
        return energy.deltaEnergy;
    }

    public float getCurrentEnergy() {
        return energy.currentEnergy;
    }
 }

public class Energy {    
    //max amount of energy
    public float ENERGY_MAX;

    //amount of energy
    public float currentEnergy;
    //amount of energy that changes
    public float deltaEnergy;
    //controls how fast energy changes
    public float fillSpeed;

    //constructors
    public Energy(float maxEnergy, float deltaEnergy, float fillSpeed) {
        this.ENERGY_MAX = maxEnergy;
        currentEnergy = ENERGY_MAX;
        this.deltaEnergy = deltaEnergy;
        this.fillSpeed = fillSpeed;
    }

    //default constructor
    public Energy() {
        Energy constructor = new Energy(100f, 5.0f,0.1f);
        this.deltaEnergy = constructor.deltaEnergy;
        this.ENERGY_MAX = constructor.ENERGY_MAX;
        this.fillSpeed = constructor.fillSpeed;
    }

    //runs every frame
    public void Update() {
        //change current energy at the speed determined by Time.deltaTime * xf
        currentEnergy += deltaEnergy * (Time.deltaTime * fillSpeed);
        //clamp between 0 and ENERGY_MAX
        currentEnergy = Mathf.Clamp(currentEnergy, 0f, ENERGY_MAX);
    }    

    //mapping function 
    public float Map(float currEnergy, float maxEnergy, float minEnergy, float maxNewRange, float minNewRange) {
        return ((currEnergy - minEnergy) / (maxEnergy - minEnergy)) * (maxNewRange - minNewRange) + minNewRange;        
    }

   
}