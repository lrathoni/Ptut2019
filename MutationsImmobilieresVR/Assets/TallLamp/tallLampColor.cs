using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tallLampColor : MonoBehaviour
{
	public Transform player;
    public new Light light;
    public float t;

	// Update is called once per frame
	void Update()
	{
        t = UnityEngine.Random.Range(0.0f, 1.0f);
        light.color = Color.Lerp(Color.cyan, Color.red, t);
        light.intensity = 1.0f + t;
	}
}
