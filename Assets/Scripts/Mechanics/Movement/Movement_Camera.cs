using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_Camera : MonoBehaviour {
    //controls the speed of camera rotation
    public float rotateSpeed = 100;

    public bool controlToggle = false;

    //variable to help in assisting with getting the right
    //x and y rotational values when switching into this 'special'
    //mode
    bool controlToggleSpecial = false;

    //rotation variables 
    //controls how quickly camera goes between min and max angles 
    public float rotationSensitivityX = 35.0f;
    public float rotationSensitivityY = 35.0f;

    //controls the range of camera movement possible
    public float maxXInc = 80.0f;
    public float minAngleX = -45.0f;
    public float maxAngleX = 45.0f;
    public float minAngleY = -45.0f;
    public float maxAngleY = 45.0f;

    //MovementShipForce variable for calling the functions in there
    private MovementShipForce movementShipForce;
    private GameObject mainShip;

    //rotation values    
    private float yRotateCamera = 0;
    private float xRotateCamera = 0;

    // mouse x and y input values
    private float mouseX, mouseY;

    public GameObject crosshair;

    private ButtonScript currentButton;

    // Start is called before the first frame update
    void Start() {        
        //putting the rotation of camera at (0,0,0) when game starts
        // transform.Rotate(new Vector3(0, 0, 0));

        // This isn't working for some reason
        if (crosshair == null)
        {
            crosshair = GameObject.Find("Crosshair");
        }

        //making a movementShip object and giving it the components 
        //of MovementShipForce script
        try {
            //the way this should work is that a parent contains the camera
            //GameObject that this script is attached to
            //so it will find that parent and then get its MovementShipForce component
            if (transform.parent.gameObject.GetComponent<MovementShipForce>() != null)
            {
                mainShip = GameObject.Find(transform.parent.gameObject.name);
            }
        }
        catch (Exception e) {
            //if you get here, thats a big problem because your parent doesnt not have 
            //a MovementShipForce script, and das really bad
            Debug.Log("bruh you is missing a necessary parent here" +
                "\nhere is the error: " + e.Message);            
        }
    }

    // Update is called once per frame
    void Update() {
        if (controlToggle && controlToggleSpecial) {
            if(movementShipForce != null)
            {
                yRotateCamera = movementShipForce.getMovementShipYRotate();
                xRotateCamera = movementShipForce.getMovementShipXRotate();
                minAngleX = xRotateCamera - maxXInc;
                maxAngleX = xRotateCamera + maxXInc;
            }
            controlToggleSpecial = false; 
        }

        //if control key is toggled on, rotate the camera around
        if (controlToggle) {
            //used to 'cancel' out the change on the z-axis
            float zAxisValue = transform.localEulerAngles.z;

            //allows for rotation in both x and y direction while
            //zeroing out the z direction cause no rotation there 
            //no roll-y boios in here yo
            transform.localEulerAngles = new Vector3(yRotateCamera, xRotateCamera, -zAxisValue);

            // Checks if the camera is pointed over a button
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.GetComponent<ButtonScript>())
                {
                    if (currentButton == null)
                    {
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                        Debug.Log("Mouse Over " + hit.transform.gameObject.name);
                        currentButton = hit.transform.gameObject.GetComponent<ButtonScript>();
                        currentButton.over = true;
                        currentButton.mouseOver();
                    }
                }
                else
                {
                    if (currentButton != null)
                    {
                        currentButton.mouseExit();
                        currentButton.over = false;
                        currentButton = null;
                    }
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
                }
            }
        }

        
    }

    // Toggles the controlToggle variable and features associated with that toggle
    public void viewToggle()
    {
        if (controlToggle == false)
        {
            yRotateCamera = 0;
            xRotateCamera = 0;
            crosshair.SetActive(true);
            controlToggle = true;
            controlToggleSpecial = true;
        }
        else
        {
            crosshair.SetActive(false);
            controlToggle = false;
        }
    }

    // pushes the current button
    public void pushButton()
    {
        if (currentButton != null)
        {
            currentButton.mouseDown();
        }
    }

    // Gets the mouse input from the input manager 
    public void RecieveMouseInput(Vector2 mouseInput) {
        //set mouseX and mouseY either to normal value or negate it based off of inversion variable 
        mouseX = MovementShipForce.invertX ? -mouseInput.x : mouseInput.x;
        mouseY = MovementShipForce.invertY ? mouseInput.y : -mouseInput.y;

        //mouseX = mouseInput.x;        
        //mouseY = -mouseInput.y;

        //rotate y-view            
        yRotateCamera += mouseY * rotationSensitivityY * Time.deltaTime;
        yRotateCamera = Mathf.Clamp(yRotateCamera, minAngleY, maxAngleY);
        //rotate x-view  
        xRotateCamera += mouseX * rotationSensitivityX * Time.deltaTime;
        xRotateCamera = Mathf.Clamp(xRotateCamera, minAngleX, maxAngleX);       
    }

}
