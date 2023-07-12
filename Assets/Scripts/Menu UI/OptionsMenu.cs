using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //game object variable for xInvertButton
    public Button xInvertButton;
    public Button yInvertButton;

    //color components
    public Color32 normalColor;
    public Color32 pressedColor;
    public Color32 selectedColor;
    public Color32 highlightedColor; 
    
    //runs every frame     
     public void Update() {
        //color components variable for xInvert
        ColorBlock xInvertButtonColors = xInvertButton.colors;
        //color components variable for yInvert
        ColorBlock yInvertButtonColors = yInvertButton.colors;
        if (!MovementShipForce.invertX) {
            
            xInvertButtonColors.normalColor = new Color32(normalColor.r,normalColor.g,normalColor.b,0);
            xInvertButtonColors.pressedColor = new Color32(pressedColor.r, pressedColor.g, pressedColor.b, 0);
            xInvertButtonColors.selectedColor = new Color32(selectedColor.r, selectedColor.g, selectedColor.b, 0);
            xInvertButtonColors.highlightedColor = new Color32(highlightedColor.r, highlightedColor.g, highlightedColor.b, 0);
            xInvertButton.colors = xInvertButtonColors; 
        }
        else {

            xInvertButtonColors.normalColor = new Color32(normalColor.r, normalColor.g, normalColor.b, 255);
            xInvertButtonColors.pressedColor = new Color32(pressedColor.r, pressedColor.g, pressedColor.b, 255);
            xInvertButtonColors.selectedColor = new Color32(selectedColor.r, selectedColor.g, selectedColor.b, 255);
            xInvertButtonColors.highlightedColor = new Color32(highlightedColor.r, highlightedColor.g, highlightedColor.b, 255);
            xInvertButton.colors = xInvertButtonColors;
        }

        if (!MovementShipForce.invertY) {

            yInvertButtonColors.normalColor = new Color32(normalColor.r, normalColor.g, normalColor.b, 0);
            yInvertButtonColors.pressedColor = new Color32(pressedColor.r, pressedColor.g, pressedColor.b, 0);
            yInvertButtonColors.selectedColor = new Color32(selectedColor.r, selectedColor.g, selectedColor.b, 0);
            yInvertButtonColors.highlightedColor = new Color32(highlightedColor.r, highlightedColor.g, highlightedColor.b, 0);
            yInvertButton.colors = yInvertButtonColors;
        }
        else {

            yInvertButtonColors.normalColor = new Color32(normalColor.r, normalColor.g, normalColor.b, 252);
            yInvertButtonColors.pressedColor = new Color32(pressedColor.r, pressedColor.g, pressedColor.b, 252);
            yInvertButtonColors.selectedColor = new Color32(selectedColor.r, selectedColor.g, selectedColor.b, 252);
            yInvertButtonColors.highlightedColor = new Color32(highlightedColor.r, highlightedColor.g, highlightedColor.b, 252);
            yInvertButton.colors = yInvertButtonColors;
        }
    }

    //invert camera x-axis
    public void invertXAxis() {
        MovementShipForce.invertX = MovementShipForce.invertX ? false : true;
        //write to save data          
        //if true set that float to 1, else set it to 0
        PlayerPrefs.SetFloat("invertX", MovementShipForce.invertX ? 1 : 0);
        PlayerPrefs.Save();
    }

    //invert camera y-axis
    public void invertYAxis() {
        MovementShipForce.invertY = MovementShipForce.invertY ? false : true;
        //write to save data
        //if true set that float to 1, else set it to 0
        PlayerPrefs.SetFloat("invertY", MovementShipForce.invertY ? 1 : 0);
        PlayerPrefs.Save();
    }
    
}
