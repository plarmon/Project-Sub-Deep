using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SkyboxManipulationTrigger : MonoBehaviour
{
    //volume profiles to be editted
    private VolumeProfile volumeProfile1;
    private VolumeProfile volumeProfile2;

    //game objects to extract volume profiles from 
    public GameObject volProfile1;
    public GameObject volProfile2;

    //brightness to be set
    public float skyboxBrightness;

    void Start() {
        volumeProfile1 = volProfile1.GetComponent<UnityEngine.Rendering.Volume>()?.profile;
        volumeProfile2 = volProfile2.GetComponent<UnityEngine.Rendering.Volume>()?.profile;
    }

    public void IncreaseBrightness(float brightness) {
        if (!volumeProfile1) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));
        if (!volumeProfile2) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));
        
        UnityEngine.Rendering.Universal.ColorAdjustments colorAdjust;

        if (!volumeProfile1.TryGet(out colorAdjust)) throw new System.NullReferenceException(nameof(colorAdjust));
        if (!volumeProfile2.TryGet(out colorAdjust)) throw new System.NullReferenceException(nameof(colorAdjust));

        //get current brightness amount
        float newBrightness = brightness + colorAdjust.postExposure.value; 
        colorAdjust.postExposure.Override(newBrightness);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            IncreaseBrightness(skyboxBrightness);            
        }
    }
}
