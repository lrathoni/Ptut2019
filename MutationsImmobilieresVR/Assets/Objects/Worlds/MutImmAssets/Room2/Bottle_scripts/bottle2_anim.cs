using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle2_anim : MonoBehaviour
{
    float x;
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
            transform.localScale = new Vector3(1f, 1f, x);
            if (x > 100f)
                x = 1f;
            else
                x += 1f;
        }
        else
            transform.localScale = new Vector3(0,0,0);

    }
}
