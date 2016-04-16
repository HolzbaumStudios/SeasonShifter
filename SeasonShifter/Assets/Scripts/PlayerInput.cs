﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour {

    PlayerMovement movementScript;
    private bool isJumping;

	// Use this for initialization
	void Awake () {
        movementScript = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

        float h = Input.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        movementScript.Move(h, isJumping);
        isJumping = false;

    }
}
