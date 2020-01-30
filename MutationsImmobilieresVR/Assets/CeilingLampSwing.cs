using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingLampSwing : MonoBehaviour
{
    public float puls = 2f;
    public float amplitude = 30f;

    void Update()
    {
        if (EventsManager.I.getEventID() % 3 == 0)
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, amplitude * Mathf.Sin(Time.time * puls), transform.localRotation.eulerAngles.z);
    }
}
