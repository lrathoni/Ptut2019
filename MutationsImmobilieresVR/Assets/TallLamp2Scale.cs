using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallLamp2Scale : MonoBehaviour
{
    float Frac(float x)
    {
        return x - Mathf.Floor(x);
    }
    // Update is called once per frame
    void Update()
    {
        if (EventsManager.I.getEventID() % 6 == 0)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 2.54f * Frac(Mathf.Sin(Time.time * 5000f)));
    }
}
