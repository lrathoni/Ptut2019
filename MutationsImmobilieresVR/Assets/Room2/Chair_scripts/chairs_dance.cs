using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chairs_dance : MonoBehaviour
{
    public float x;
    int id;

    // Start is called before the first frame update
    void Start()
    {
        x = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        id = EventsManager.I.getEventID();
        if(id < 25)
        {
            transform.rotation = Quaternion.Euler(x, 0, 0);
        }
        else
            transform.rotation = Quaternion.Euler(0, x, 0);

        if (x > 0 && x < 10)
            x += 1f;
        else
            x = 1f;

    }
}

//18 à 35