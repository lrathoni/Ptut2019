using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    private EventsManager eventsManager;
    void Awake()
    {
        eventsManager = GameObject.FindObjectOfType<EventsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Event id : " + eventsManager.getEventID());
    }
}
