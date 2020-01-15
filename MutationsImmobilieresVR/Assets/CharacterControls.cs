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

    private void Start()
    {
    }

    void Update(){
        Vector2 dl = speed * Time.deltaTime * moveAction.GetAxis(handType);
        Vector3 move = camTransform.right * dl.x + camTransform.forward * dl.y;
        Debug.Log(move);
        move.y = 0;
        controller.Move(move);
    }
}