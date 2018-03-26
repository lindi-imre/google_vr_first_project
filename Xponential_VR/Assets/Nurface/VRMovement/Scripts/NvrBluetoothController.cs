﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class NvrBluetoothController : MonoBehaviour {
    // VR Main Camera
    private Transform vrCamera;
    // Speed to move the player
    public float speed = 3f;
    // CharacterController script
    CharacterController myCC;

    KeyCode BluetoothReturn = (KeyCode)10;

    // Use this for initialization
    void Start () {
        // Find the CharacterController
        myCC = gameObject.GetComponent<CharacterController>();
        // Find the Main Camera
        vrCamera = Camera.main.transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2")) {
            Debug.Log("Fire 2 pressed");
        }
        
        // Move with SimpleMove based on Horizontal adn Vertical input
        myCC.SimpleMove(speed * vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal")));
    }
}
