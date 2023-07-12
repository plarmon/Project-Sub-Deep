using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;



public class BrightnessControl : MonoBehaviour
{

    //volume profiles to be editted
    private VolumeProfile volumeProfile1;
    private VolumeProfile volumeProfile2;

    public GameObject volProfile1;
    public GameObject volProfile2;

    public static float brightBoi;

    void Start() {
        volumeProfile1 = volProfile1.GetComponent<UnityEngine.Rendering.Volume>()?.profile;
        volumeProfile2 = volProfile2.GetComponent<UnityEngine.Rendering.Volume>()?.profile;
    }

    public void SetBrightness(float brightness) {
        UnityEngine.Rendering.Universal.ColorAdjustments colorAdjust;
        //try-catch block just for stopping the error showing up in the console 
        //despite it working fine during runtime
        //also disabling this warning 
        #pragma warning disable 0168
        try {
            //change the color adjust of the 2 post-processing poops
            if (!volumeProfile1) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));
            if (!volumeProfile2) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));
            
            if (!volumeProfile1.TryGet(out colorAdjust)) throw new System.NullReferenceException(nameof(colorAdjust));
            if (!volumeProfile2.TryGet(out colorAdjust)) throw new System.NullReferenceException(nameof(colorAdjust));
            colorAdjust.postExposure.Override(brightness);
        }
        catch (Exception e) {
            //do nothing lol
        }

        //update the player preferences
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.Save();
    }
}
