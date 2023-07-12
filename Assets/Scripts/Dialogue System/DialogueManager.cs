using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    //holds the sentences to be displayed
    private Queue<string> sentences;

    //Gameobject containing the whole textbox
    public GameObject textBox;
    //name of speaking character
    public Text nameText;
    //corresponding dialogue text
    public Text dialogueText;

    //animator for controlling dialogue box animation
    public Animator animator;

    //speed for text scrolling 
    public float textSpeed;

    public bool continueText;

    public InputAction continueInput;

    public GameManager gm;

    private void Awake()
    {
        continueInput.started += _ => DisplayNextSentence();
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        if (textBox.activeSelf)
        {
            textBox.SetActive(false);
        }

        if(gm == null)
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>();
        }
    }

    //starts the dialouge sequence
    public void StartDialogue(Dialogue dialogue) {
        if (!textBox.activeSelf)
        {
            textBox.SetActive(true);
        }

        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        if (sentences != null)
        {
            sentences.Clear();
        } else
        {
            sentences = new Queue<string>();
        }

        //adds sentence to the queue
        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    //displays the next sentence in the queue
    public void DisplayNextSentence() {
        if (!gm.paused)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            //remove current sentence from queue
            string sentence = sentences.Dequeue();
            //if player continues in the middle of a text display it stops
            //the current coroutine
            StopAllCoroutines();
            //being text display scrolling        
            StartCoroutine(DisplaySentence(sentence));
        }
    }

    //makes the animation for closing to trigger
    void EndDialogue() {
        animator.SetBool("isOpen", false);
        textBox.SetActive(false);
    }

    //thing for coroutine to display sentence
    IEnumerator DisplaySentence(string sentence) {
        dialogueText.text = "";
        //appending a letter one by one
        foreach (char letter in sentence.ToCharArray()) {
            // If paused in the middle of displaying text then wait till unpaused
            while (gm.paused)
            {
                yield return new WaitForEndOfFrame();
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed * Time.deltaTime);
        }
        if (continueText)
        {
            yield return new WaitForSeconds(1);
            DisplayNextSentence();
        }
    }

  
}
