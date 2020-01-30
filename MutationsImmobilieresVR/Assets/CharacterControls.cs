using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CharacterControls : MonoBehaviour
{
    public float speed = 25.0f;
    public float jumpStrength = 10.0f;
    public float gravity = -20.0f;
    public CharacterController controller;
    public Transform cameraTransform;
    public Transform groundCheck;
    public float groundDistance = 2.5f;
    public LayerMask groundMask;

    public SteamVR_Action_Vector2 moveAction;
    public SteamVR_Action_Single jumpAction;
    public SteamVR_Input_Sources handType;

    float yVelocity = 0f;

    void Update(){
        // Move X and Z
        Vector2 dlVR = speed * Time.deltaTime * moveAction.GetAxis(handType);
        Vector2 dlKeyboard = speed * Time.deltaTime * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 dl = dlVR + dlKeyboard;
        Vector3 move = cameraTransform.right * dl.x + cameraTransform.forward * dl.y;
        move.y = 0;
        controller.Move(move);
        if (move.magnitude > 0.001f)
            GetComponent<AudioSource>().enabled = true;
        if (move.magnitude < 0.001f)
            GetComponent<AudioSource>().enabled = false;
        // Jump
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float jumpIntensity = 0f;
        if (isGrounded){
            yVelocity = -2f;
            jumpIntensity = Mathf.Pow(jumpAction.GetAxis(handType), 0.02f) + Input.GetAxis("Jump");
        }
        yVelocity += gravity * Time.deltaTime + jumpIntensity * jumpStrength;
        controller.Move(Vector3.up * (yVelocity*Time.deltaTime));
    }
}