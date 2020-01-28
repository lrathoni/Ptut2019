using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour
{
    float i = 0;
    float maxIntensity;
    public Transform playertransform;
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        maxIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        //Debug.Log("i = " + i);
        Vector3 proximity = playertransform.transform.position - transform.position;
        //Debug.Log(proximity.magnitude);
        if (proximity.magnitude < 20 && proximity.magnitude > 5)
        {
            if (i % 13 == 0)
                light.intensity = 0;
            if (i % 8 == 0)
                light.intensity = maxIntensity;
            if (i == 1000)
                i = 0;
        }
        if (proximity.magnitude < 5)
            light.intensity = 0;
        if (proximity.magnitude > 20)
            light.intensity = maxIntensity;
    }
}
