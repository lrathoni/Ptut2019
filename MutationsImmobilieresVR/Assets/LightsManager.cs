using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Event id : " + EventsManager.I.getEventID());
    }
}
