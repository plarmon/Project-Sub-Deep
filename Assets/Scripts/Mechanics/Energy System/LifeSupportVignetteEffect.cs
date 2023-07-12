using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;



public class LifeSupportVignetteEffect : MonoBehaviour {

    //volume profiles to be editted
    [SerializeField] private GameObject volumeProfile;
    private VolumeProfile volProfile;
    [SerializeField] private EnergySystem_Redux energySystem;

    //variables for the volume profile manipulation 
    private Vignette vignette;
    private ColorAdjustments colorAdjust;

    [Tooltip("This is the percentage of the life support energy at which the vignette effect begins. " +
        "Enter a value in the range [1,100].")]
    [SerializeField] private float startVignette;
    [Tooltip("This is the percentage of the life support energy at which the vignette effect ends. " +
        "Enter a value in the range [0,100].")]
    [SerializeField] private float endVignette; 

    void Start() {
        //getting the information needed for volume profile editing
        volProfile = volumeProfile.GetComponent<UnityEngine.Rendering.Volume>()?.profile;
        if (!volProfile) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));
        if (!volProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
        if (!volProfile.TryGet(out colorAdjust)) throw new System.NullReferenceException(nameof(colorAdjust));

        //ngl the code above is a bunch of jargon i found online
        //but it works lol
    }

    void Update() {
        //if energy system exists 
        if (energySystem != null) {

            //percentage of the life support energy available
            //should be in the range [0,1]
            float lifeSupportPercentage = energySystem.currentLifeSupportEnergy / energySystem.maxLifeSupportEnergy;

            //percentage of the vignette start/end 
            //should be in the range [0,1]
            float startVignettePercentage = (startVignette / 100);
            float endVignettePercentage = (endVignette / 100);

            //long winded way to say the value of the current life support at the percentage 
            //based from the start/end vignette percentage
            float lifeSupportVignetteStartPercentageValue = energySystem.maxLifeSupportEnergy * startVignettePercentage;
            float lifeSupportVignetteEndPercentageValue = energySystem.maxLifeSupportEnergy * endVignettePercentage;

            //if the current life support energy value is within the range of the start and end bar percentage
            if (lifeSupportPercentage >= endVignettePercentage && lifeSupportPercentage <= startVignettePercentage) {
                //execute mapping functions over the vignette and saturation effects
                vignette.intensity.Override(Map(energySystem.currentLifeSupportEnergy, lifeSupportVignetteEndPercentageValue, lifeSupportVignetteStartPercentageValue, 1f, 0f));
                colorAdjust.saturation.Override(Map(energySystem.currentLifeSupportEnergy, lifeSupportVignetteEndPercentageValue, lifeSupportVignetteStartPercentageValue, -100f, 0f));
            }
        }
    }

    //basic mapping function for a taking a value in the range [oldMin, oldMax] and putting it into [newMin, newMax]
    public float Map(float current, float oldMin, float oldMax, float newMin, float newMax) {
        return ((current - oldMin) / (oldMax - oldMin)) * (newMax - newMin) + newMin;
    }
}
