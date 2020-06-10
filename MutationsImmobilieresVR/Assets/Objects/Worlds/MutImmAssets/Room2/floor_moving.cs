using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_moving : MonoBehaviour
{
	public Material material;
	public Renderer m_Renderer;
	float value;

	private void Start()
	{
		m_Renderer = GetComponent<MeshRenderer>();
		value = 0.1f;
	}

	// Update is called once per frame
	void Update()
	{
		material.SetTextureScale("_MainTex", new Vector2(value, value));
		value += 0.002f;
		
		if (System.Math.Abs(value - 1) < 0.1f) value = 0.1f;
		m_Renderer.material = material;

	}
}
