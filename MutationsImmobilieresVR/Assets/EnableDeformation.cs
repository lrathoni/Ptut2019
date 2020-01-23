using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDeformation : MonoBehaviour
{
    private DeformMesh script;
    private EventsManager eventsManager;
    void Awake()
    {
        eventsManager = GameObject.FindObjectOfType<EventsManager>();
        script = GetComponent<DeformMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventsManager.getEventID() == 3)
            script.enabled = true;
        else
            script.enabled = false;
    }
}
