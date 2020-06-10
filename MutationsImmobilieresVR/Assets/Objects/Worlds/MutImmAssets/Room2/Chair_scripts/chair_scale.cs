using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair_scale : MonoBehaviour
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
        if (id < 22)
        {
            transform.localScale = new Vector3(x, 0, x);
        }
        else
            transform.localScale = new Vector3(0, x, x);

        if (x > 0 && x < 2.5f)
            x += 0.1f;
        else
            x = 1f;

    }
}
