using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveKeys : MonoBehaviour
{
	public CharacterController controller;

	public float speed = 12f;


	void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		float y = Input.GetAxis("Jump");

		Vector3 move = transform.right * x + transform.forward * z + transform.up * y;

		controller.Move(move * speed * Time.deltaTime);

		
	}
}
