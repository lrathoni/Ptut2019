using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CharacterControls : MonoBehaviour
{
    public float speed = 25.0f;
    public CharacterController controller;
    public Transform cameraTransform;

    public SteamVR_Action_Vector2 moveAction;
    public SteamVR_Action_Single jumpAction;
    public SteamVR_Input_Sources handType;

    void Update(){
        // Move X and Z
        Vector2 dlVR = speed * Time.deltaTime * moveAction.GetAxis(handType);
        Vector2 dlKeyboard = speed * Time.deltaTime * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 dl = dlVR + dlKeyboard;
        Vector3 move = cameraTransform.right * dl.x + cameraTransform.forward * dl.y;
        move.y = 0;
        controller.Move(move);
        // Jump
        float jumpIntensity = jumpAction.GetAxis(handType) + Input.GetAxis("Jump");
        controller.Move(Vector3.up * jumpIntensity);
    }
}