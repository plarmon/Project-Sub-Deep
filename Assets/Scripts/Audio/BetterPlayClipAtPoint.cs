using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the entire purpose of this class is to extend the behavior on AudioSource.PlayClipAt
public class BetterPlayClipAtPoint : MonoBehaviour
{
    //returns a reference to the audio source so that it can at least be routed in audio mixer
    public static AudioSource PlayClipAtPoint(AudioSource audioSource, Vector3 pos) {
        GameObject tempGO = new GameObject("TempAudio"); // create the temp object
        tempGO.transform.position = pos; // set its position
        AudioSource tempASource = tempGO.AddComponent<AudioSource>(); // add an audio source

        //setting the properites
        tempASource.clip = audioSource.clip;
        tempASource.outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
        tempASource.mute = audioSource.mute;
        tempASource.bypassEffects = audioSource.bypassEffects;
        tempASource.bypassListenerEffects = audioSource.bypassListenerEffects;
        tempASource.bypassReverbZones = audioSource.bypassReverbZones;
        tempASource.playOnAwake = audioSource.playOnAwake;
        tempASource.loop = audioSource.loop;
        tempASource.priority = audioSource.priority;
        tempASource.volume = audioSource.volume;
        tempASource.pitch = audioSource.pitch;
        tempASource.panStereo = audioSource.panStereo;
        tempASource.spatialBlend = audioSource.spatialBlend;
        tempASource.reverbZoneMix = audioSource.reverbZoneMix;
        tempASource.dopplerLevel = audioSource.dopplerLevel;
        tempASource.rolloffMode = audioSource.rolloffMode;
        tempASource.minDistance = audioSource.minDistance;
        tempASource.spread = audioSource.spread;
        tempASource.maxDistance = audioSource.maxDistance;
        // set other aSource properties here, if desired
        
        // start the sound
        tempASource.Play(); 
        // destroy object after clip duration (this will not account for whether it is set to loop)
        MonoBehaviour.Destroy(tempGO, tempASource.clip.length);
        // return the AudioSource reference
        return tempASource; 
    }
    //credits to BowlerBitesLane on Unity Forums for this algorithm
}
