using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class NvrAdvancedWalk : MonoBehaviour {
    // How fast to move
    public float speed = 3.0F;
    // Is player allowed to move
    public bool allowedToMove = true;
    // Jump Feature Enabled
    public bool jumpEnabled = true;
    // Jump speed
    public float jumpSpeed = 10f;
    // Angles at which the jump will be triggered (X value of main camera)
    public float jumpMinToggleAngle = 300.0f;
    public float jumpMaxToggleAngle = 330.0f;
    // Vertical speed
    private float vSpeed;
    // Should I move forward or not
    private bool moveForward;
    // CharacterController script    
    private CharacterController myCC;
    // VR Main Camera
    private Transform vrCamera;

    string url = "file://D://Develop//google_vr_first_project/Xponential_VR//Assets//sound//gun-gunshot-01.wav";
    AudioSource audio;
    // Use this for initialization
    void Start() {
        // Find the CharacterController
        myCC = GetComponent<CharacterController>();
        // Find the VR Head
        vrCamera = Camera.main.transform;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

        // In the Google VR button, or the Gear VR touchpad is pressed
        if (Input.GetButtonDown("Fire1") && allowedToMove) {
            // Change the state of moveForward
            moveForward = !moveForward;
            Debug.Log("pressed");
        }

        if (Input.GetButtonDown("Fire2")) {
            Debug.Log("fire2");
        }

        if (Input.GetButtonDown("Fire3") && !audio.isPlaying)
        {
            audio.Play();
            audio.Play(44100);
        }
        // Make a new empty vector3
        Vector3 moveDirection = Vector3.zero;
        // If we're supposed to go forward
        if (moveForward) {
            // Find the Forward direction
            moveDirection = vrCamera.TransformDirection(Vector3.forward);
            // Add some speed
            moveDirection *= speed;
        }

        // Check if jumping is turned on
        if (jumpEnabled) {
            // If player is on the ground
            if (myCC.isGrounded) {
                // Player is not moving vertically
                vSpeed = 0f;
                // Check if a jump should be triggered
                if (vrCamera.eulerAngles.x >= jumpMinToggleAngle && vrCamera.eulerAngles.x <= jumpMaxToggleAngle || Input.GetButtonDown("Fire2")) {
                    // Add jump speed
                    vSpeed = jumpSpeed;
                }
            }
        }
        
        // Add gravity to vertical speed
        vSpeed += Physics.gravity.y * Time.deltaTime;
        // add vertical speed into movement vector
        moveDirection.y = vSpeed;
        // Move the player
        myCC.Move(moveDirection * Time.deltaTime);
    }

    // Enable or disable movement with this function
    public void AllowedToMove(bool status) {
        // Set the local variable
        allowedToMove = status;
        // If we are disabling movement
        if (status == false) {
            // Also stop movement so player is not stuck walking.
            moveForward = false;
        }
    }
}