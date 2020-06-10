using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle1_anim : MonoBehaviour
{
    public double x;
    float px, py;
    int id;

    private void Start()
    {
        x = 1f;
    }

    void Update()
    {
        id = EventsManager.I.getEventID();

        px = transform.localPosition.x;
        py = transform.localPosition.y;

        x = NoiseS3D.Noise(Time.time);

        if(id<20)
            transform.localPosition = new Vector3(px, py, 1f+(float)x);
        else
            transform.localPosition = new Vector3(px, py, 1f + (float)x/10f);

    }
}
