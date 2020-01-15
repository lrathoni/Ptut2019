using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform playertransform;
    public Transform doortransform;
    int i = 0;
    bool Open = false;

    // Update is called once per frame
    void Update()
    {   
        // Get YAxis
        Vector3 proximity = playertransform.transform.position - doortransform.transform.position;
        if ( proximity.magnitude < 10 && proximity.magnitude > 1 && Open == false ) {
            if ( i > -100) {
                transform.Rotate(0.0f, -1.0f, 0.0f, Space.World);
                i-=1;
            }
            if (i == -100) 
            {
                Open = true;
            }
        }
        if (proximity.magnitude > 10 && Open == true ) {
            if ( i < 0)
            {
                transform.Rotate(0.0f, +2.0f, 0.0f, Space.World);
                i += 2;
            }
            if ( i == 0) 
            {
                Open = false;
            }
        } 
    }
}
