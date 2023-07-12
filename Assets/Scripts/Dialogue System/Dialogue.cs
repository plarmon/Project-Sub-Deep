using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class hosts all information needed about a single line of dialouge
[System.Serializable]
public class Dialogue {
    //name of the talking character
    public string name;

    //array to hold in all sentences
    public string[] sentences;
}
