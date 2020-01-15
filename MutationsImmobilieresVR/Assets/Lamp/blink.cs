using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour
{
    float i = 0;
    public Transform playertransform;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Light>().range = 3;
        GetComponent<Light>().intensity = 5;
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        Debug.Log("i = " + i);
        Vector3 proximity = playertransform.transform.position - transform.position;
        Debug.Log(proximity.magnitude);
        if (proximity.magnitude < 20 && proximity.magnitude > 5)
        {
            if (i % 13 == 0)
                GetComponent<Light>().intensity = 0;
            if (i % 8 == 0)
                GetComponent<Light>().intensity = 5;
            if (i == 1000)
                i = 0;
        }
        if (proximity.magnitude < 5)
            GetComponent<Light>().intensity = 0;
        if (proximity.magnitude > 20)
            GetComponent<Light>().intensity = 5;
    }
}
