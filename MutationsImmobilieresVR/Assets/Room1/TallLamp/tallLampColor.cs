using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tallLampColor : MonoBehaviour
{
	public Transform player;
    public new Light light;
    public float t;
    int id;

	// Update is called once per frame
	void Update()
	{
        id = EventsManager.I.getEventID();

        t = UnityEngine.Random.Range(0.0f, 1.0f);
        light.intensity = 1.0f + t;

        if(id<3)
            light.color = Color.Lerp(Color.cyan, Color.red, t);

        else
            light.color = Color.Lerp(Color.cyan, Color.green, t);

    }
}
