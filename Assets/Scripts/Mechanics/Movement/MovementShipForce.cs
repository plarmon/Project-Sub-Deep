using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class MovementShipForce : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    // Movement speed in meters/second
    public float moveSpeed = 0;
    public float maxSpeed = 15.0f;
    public float maxAltSpeed = 7.5f;
    public float accelerationSpeed = 0.1f;
    public float altitudeChangeSpeed = 0.0f;

    public RoomManager currentRoom;

    // Rotation variables 
    // Controls how quickly camera goes between min and max angles 
    public float rotationSensitivityX = 35.0f;
    public float rotationSensitivityY = 35.0f;

    // Controls the range of camera movement possible
    public float minAngleX = -45.0f;
    public float maxAngleX = 45.0f;
    public float minAngleY = -45.0f;
    public float maxAngleY = 45.0f;

    // Camera inversion options
    public static bool invertX = false;
    public static bool invertY = false;

    // Player Input variables
    private float xInput, zInput;
    private float mouseX, mouseY;

    // Rotation values
    private float yRotateShip = 0;
    private float xRotateShip = 0;

    // Sub Rigidbody
    private Rigidbody objectBody;

    // Initializes the variables needed for camera reset
    public GameObject mainCamera;
    private GameObject insideCam;
    public float resetTime = 0.1f;

    // Variables that control the bonk factor
    public float bonkForce = 3.0f;
    public float bonkTime = 1.0f;
    private bool bonked = false;

    public bool freeze = false;

    // Variables that control the impact sound effect
    public AudioSource impactSource;

    private Vector3 boidPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Defining Rigidbody
        objectBody = gameObject.GetComponent<Rigidbody>();

        // Defines camera objects
        mainCamera = GameObject.Find("Main Camera");
        insideCam = GameObject.Find("Inside Cam");        
    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze)
        {
            // Keeps player within the top bound of the map
            if (transform.position.y < gm.maxHeight)
            {
                // If the player isn't bonked
                if (!bonked)
                {
                    if (objectBody.velocity != Vector3.zero)
                    {
                        objectBody.velocity = Vector3.zero;
                    }

                    // If there isn't any input to move forward/backwards
                    if (zInput == 0)
                    {
                        // Slows the sub to a stop if the sub is moving forward
                        if (moveSpeed > 0)
                        {
                            moveSpeed -= accelerationSpeed;
                            // Makes the sub stop 
                            if (moveSpeed < 0) moveSpeed = 0;
                        }
                        // If the sub is moving backwards
                        else if (moveSpeed < 0)
                        {
                            moveSpeed += accelerationSpeed;
                            // Makes the sub stop
                            if (moveSpeed > 0) moveSpeed = 0;
                        }
                    }
                    // If there is an input to move forward/backwards
                    else
                    {
                        // If the sub's speed is less than the max speed increases the speed in a certain direction
                        if (Mathf.Abs(moveSpeed) < maxSpeed)
                        {
                            moveSpeed += accelerationSpeed * zInput;
                            // If moving forward but input is backwards, apply's breaks
                            if (moveSpeed > 0 && zInput < 0)
                            {
                                moveSpeed -= accelerationSpeed;
                            }
                        }
                    }

                    // Moves the sub 
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                    transform.Translate(Vector3.up * Time.deltaTime * altitudeChangeSpeed, Space.World);
                }


                // If control key is toggled off, rotate the object
                if (!mainCamera.GetComponent<Movement_Camera>().controlToggle)
                {
                    // Allows for rotation in both x and y direction while zeroing out the z direction
                    float zAxisValue = transform.localEulerAngles.z;
                    Quaternion lookDirection = Quaternion.Lerp(Quaternion.Euler(yRotateShip, xRotateShip, -zAxisValue), transform.rotation, 0.75f);
                    transform.localEulerAngles = lookDirection.eulerAngles;

                    // Snaps camera back to center
                    mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, transform.rotation, resetTime);
                    insideCam.transform.rotation = Quaternion.Lerp(insideCam.transform.rotation, transform.rotation, resetTime);
                }
            } else
            {
                // Bonks the player down if player tries to go out the top
                objectBody.AddForce(Vector3.down * bonkForce, ForceMode.Impulse);
                bonked = true;
                StartCoroutine("CancelBonk");
            }
        } else
        {
            Vector3 lookDirection = boidPosition - transform.position;
            Vector3 rotateDirection = Vector3.RotateTowards(transform.forward, lookDirection, 5 * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(rotateDirection);
        }
    }

    public void ReceiveInput(float _horizontalInput, float _verticalInput)
    {
        zInput = _horizontalInput;

        if (_verticalInput != 0)
        {
            altitudeChangeSpeed = Mathf.Clamp(altitudeChangeSpeed + accelerationSpeed * _verticalInput, -maxAltSpeed, maxAltSpeed);
        }
        else
        {
            if (altitudeChangeSpeed > 0)
            {
                altitudeChangeSpeed = Mathf.Max(altitudeChangeSpeed - accelerationSpeed, 0);
            }
            else if (altitudeChangeSpeed < 0)
            {
                altitudeChangeSpeed = Mathf.Min(altitudeChangeSpeed + accelerationSpeed, 0);
            }
        }
    }

    public void RecieveMouseInput(Vector2 mouseInput)
    {
        if (!mainCamera.GetComponent<Movement_Camera>().controlToggle)
        {
            mouseX = mouseInput.x * rotationSensitivityX;
            mouseY = mouseInput.y * rotationSensitivityY;

            //set mouseX and mouseY either to normal value or negate it based off of inversion variable 
            mouseX = invertX ? -mouseX : mouseX;
            mouseY = invertY ? mouseY : -mouseY;

            // Rotate y-view
            yRotateShip += mouseY * Time.deltaTime;
            yRotateShip = Mathf.Clamp(yRotateShip, minAngleY, maxAngleY);
            // Rotate x-view
            xRotateShip += mouseX * rotationSensitivityX * Time.deltaTime;

            
        }
    }

    //i do not want to make yRotate and xRotate modifable because that is 
    //not its purpose
    //so here is a set of getters to serve that function 
    public float getMovementShipYRotate()
    {
        return yRotateShip;
    }

    public float getMovementShipXRotate()
    {
        return xRotateShip;
    }

    //Bonks the player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        } else if (collision.gameObject.CompareTag("EnvCollider"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        } else
        {
            altitudeChangeSpeed = 0.0f;
            // Adds force in direction of colliders normal vector 
            objectBody.AddForce(collision.contacts[0].normal * bonkForce, ForceMode.Impulse);
            // Plays bonk sound            
            BetterPlayClipAtPoint.PlayClipAtPoint(impactSource, collision.GetContact(0).point);
            bonked = true;
            StartCoroutine("CancelBonk");
        }
    }

    public void Death(Vector3 bp)
    {
        if (!gm.testing)
        {
            boidPosition = bp - (Vector3.up * 2);
            freeze = true;
        }
    }

    //Wait specified time after bonk then give player control again
    IEnumerator CancelBonk()
    {
        // Wait
        yield return new WaitForSeconds(bonkTime);
        // Cancel Bonk force
        objectBody.velocity = Vector3.zero;
        // Give player control back
        bonked = false;
        moveSpeed = 0;
    }

}
