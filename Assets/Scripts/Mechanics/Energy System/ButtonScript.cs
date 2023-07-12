using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Serialized variables
    [SerializeField] private EnergySystem_Redux es;
    [SerializeField] private GameObject sub;
    [SerializeField] private GameObject self;
    [SerializeField] private bool sonarButton;
    [SerializeField] private bool lightsButton;
    [SerializeField] private bool lifeButton;
    [SerializeField] private Material highlightMat;

    // Private variables
    private GameManager gameManager;
    private Material startMat;
    private Renderer render;
    private bool pushed;

    // Public Variables
    public AudioSource clickSource; 
    public float pushOffset = 0.02f;

    public bool over = false;

    void Start() {
        // Initializes variables not defined
        if(sub == null)
            sub = GameObject.Find("Sub");
        if(self == null)
            self = gameObject.transform.parent.gameObject;
        if (es == null)
            es = sub.GetComponent<EnergySystem_Redux>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        render = gameObject.GetComponent<Renderer>();
        startMat = render.material;
        pushed = false;
    }

    //Activates whatever button was pushed 
    public void Activate() {
        // Toggles if it's pushed
        BetterPlayClipAtPoint.PlayClipAtPoint(clickSource, this.transform.position);

        // Adjusts button's push position
        if (pushed) {
            self.transform.Translate(new Vector3(0, -pushOffset, 0), Space.Self);
        } else {
            self.transform.Translate(new Vector3(0, pushOffset, 0), Space.Self);
        }

        // Determines which function to activate based on the button
        if (es.electricityAvailable) {
            if (sonarButton) {
                Debug.Log("sonar");
                sub.GetComponent<MechanicsManager>().SonarToggle();
            }
            else if (lightsButton) {
                Debug.Log("lights");
                sub.GetComponent<MechanicsManager>().LightsToggle();
            }
            else if (lifeButton) {
                Debug.Log("life");
                sub.GetComponent<MechanicsManager>().LifeToggle();
            }
        }
    }

    //Once the button is clicked then activate the function 
    public void mouseDown() {
        if (!gameManager.paused && over) {
            pushed = !pushed;
            Activate();
        }
    }
        
    //Highlights the button with a new material 
    public void mouseOver() {
        Debug.Log("Mouse Over");
        if (!gameManager.paused) {
            render.material = highlightMat;
        }
    }

    //Removes the highlight material from the button 
    public void mouseExit() {
        if (!gameManager.paused) {
            render.material = startMat;
        }
    }
}
