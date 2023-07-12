using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkyboxSkyGradientManipulation : MonoBehaviour
{
    //material variable for the skybox
    private Material skybox;
    
    public List<GradientSet> skyGradientColors; 
    //tracks the current position in the list 
    private int listPosition;

    //a boolean for testing purposes
    [Tooltip("Controls whether you can change the skybox colors at will.\n" +
        "If enabled, Press K to go backwards 1 skybox color " +
        "and Press L to go forwards 1 skybox color.")]
    public bool gradientControl = true; 

    void Start() {
        //always starting the counter at 0
        listPosition = 0;
        //changes the skybox to first gradient set defined        
        setCurrentGradient(RenderSettings.skybox);
    }

    void Update() {
        //for debugging lol
        // Commenting out this part to implement new input system
        //if (gradientControl) { 
        //    if (Input.GetKeyDown(KeyCode.L)) {
        //        moveForwardsSkyGradient(RenderSettings.skybox);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.K)){
        //        moveBackwardsGradient(RenderSettings.skybox);
        //    }            
        //}

        //makes sure that it cant attempt to set the skybox to
        //an index that is out of bounds of the list lol
        if (listPosition > -1 && listPosition < skyGradientColors.Count) { 
            setCurrentGradient(RenderSettings.skybox);
        }        
    }

    //whenever executed, it changes the skybox's sky gradient
    //to the next item within the list
    public void moveForwardsSkyGradient(Material skybox) {
        //check to see if the list position is less than the total
        //size of skyGradientColors
        if (listPosition+1 > -1 && listPosition+1 < skyGradientColors.Count) {
            listPosition++;
            //getting the colors
            Color skyGradTop = skyGradientColors[listPosition].gradientTop;
            Color skyGradBottom = skyGradientColors[listPosition].gradientBottom;

            skybox.SetColor("_SkyGradientTop", new Color(skyGradTop.r, skyGradTop.g, skyGradTop.b));
            skybox.SetColor("_SkyGradientBottom", new Color(skyGradBottom.r, skyGradBottom.g, skyGradBottom.b));
        }                
    }
    
    //whenever executed, it changes the skybox's sky gradient
    //to the last item within the list
    public void moveBackwardsGradient(Material skybox) {
        //check to see if the list position is less than the total
        //size of skyGradientColors
        if (listPosition-1 > -1 && listPosition-1 < skyGradientColors.Count) {
            listPosition--;

            //getting the colors
            Color skyGradTop = skyGradientColors[listPosition].gradientTop;
            Color skyGradBottom = skyGradientColors[listPosition].gradientBottom;

            skybox.SetColor("_SkyGradientTop", new Color(skyGradTop.r, skyGradTop.g, skyGradTop.b));
            skybox.SetColor("_SkyGradientBottom", new Color(skyGradBottom.r, skyGradBottom.g, skyGradBottom.b)); 
        }               
    }

    //sets the skybox's sky gradient to the values 
    //at skyGradientColors[listPosition]
    public void setCurrentGradient(Material skybox) {
        if (listPosition > - 1  && listPosition < skyGradientColors.Count) {
            //getting the colors
            Color skyGradTop = skyGradientColors[listPosition].gradientTop;
            Color skyGradBottom = skyGradientColors[listPosition].gradientBottom;

            skybox.SetColor("_SkyGradientTop", new Color(skyGradTop.r, skyGradTop.g, skyGradTop.b));
            skybox.SetColor("_SkyGradientBottom", new Color(skyGradBottom.r, skyGradBottom.g, skyGradBottom.b));
        }           
    }
}

//a class whos object holds two colors at once
[System.Serializable]
public class GradientSet {

    //the two colors corresponding to the sky gradients 
    public Color gradientTop;
    public Color gradientBottom;

    //default constructor for gradient set
    public GradientSet() {
        gradientTop = new Color(0, 0, 0);
        gradientBottom = new Color(0, 0, 0);
    }

    //constructor that takes in two inputs for the gradient colors
    public GradientSet(Color top, Color bottom) {
        gradientTop = top;
        gradientBottom = bottom; 
    }
}
