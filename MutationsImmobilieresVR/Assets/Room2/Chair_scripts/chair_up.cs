using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair_up : MonoBehaviour
{
    public float x;
    int id;
    bool go_up;

    // Start is called before the first frame update
    void Start()
    {
        x = 0.001f;
        go_up = true;
    }

    // Update is called once per frame
    void Update()
    {
        id = EventsManager.I.getEventID();
        if (id < 27)
        {
            transform.localPosition = new Vector3(-0.1f, -0.35f, x);
        }
        else
            transform.localPosition = new Vector3(-0.1f, -0.35f, 2*x);

        //if x between 0 and 0.3, go up
        //if x below 0, go up
        //if x over 0.3, go down
        if (x > 0f && x < 0.4f)
            go_up = true;
        else if (x > 0.3f)
            go_up = false;
        else if (x < 0f)
            go_up = true;

        if (go_up)
            x += 0.005f;
        else
            x = x-1;

    }
}
