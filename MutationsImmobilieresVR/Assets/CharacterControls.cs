using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CharacterControls : MonoBehaviour
{
    public float speed = 8.0f;
    public CharacterController controller;
    public Transform camTransform;

    public SteamVR_Action_Vector2 moveAction;
    public SteamVR_Input_Sources handType;


    void Update(){
        Vector2 dl = speed * Time.deltaTime * moveAction.GetAxis(handType);
        Vector3 move = camTransform.right * dl.x + camTransform.forward * dl.y;
        move.y = 0;
        controller.Move(move);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float up = Input.GetAxis("Jump");
        Vector3 movement = new Vector3(horizontal, up, vertical);
        controller.Move(movement * speed);
        //transform.position += movement * speed;
    }
}