using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //reference to the audio mixer
    public AudioMixer masterMixer;

    //changes the SFX group volume
    public void setSFXLevel(float volume) {
        masterMixer.SetFloat("SFXVolume", -Map(volume,1f,0f,80,0));
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }
    
    //changes the Background group volume
    public void setBackgroundLevel(float volume) {
        masterMixer.SetFloat("BackgroundVolume", -Map(volume, 1f, 0f, 80, 0));
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
        PlayerPrefs.Save();
    }

    //mapping function for the mixer
    public float Map(float currentValue, float maxCurrentRange, float minCurrentRange, float maxNewRange, float minNewRange) {
        return ((currentValue - minCurrentRange) / (maxCurrentRange - minCurrentRange)) * (maxNewRange - minNewRange) + minNewRange;
    }
}
