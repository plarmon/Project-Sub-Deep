using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    //json file to parse through
    public TextAsset dialogueFile;

    private Dialogue dialogue;
    [SerializeField] DialogueManager dm;

    //happens before game boots up 
    void Start() {
        //converting the input json file to a Dialogue object
        dialogue = JsonUtility.FromJson<Dialogue>(dialogueFile.ToString());
    }

    //trigger for dialogue 
    public void TriggerDialogue() {
        if (!dm.gameObject.activeSelf) {
            dm.gameObject.SetActive(true);
        }
        dm.StartDialogue(dialogue);
    }
}
