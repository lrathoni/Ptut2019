using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform playertransform;
    public Transform doortransform;
    public Transform detection;
    int i = 0;
    bool OpenActivated = false;
    bool PlayerIn = false;

    // Update is called once per frame
    void Update()
    {   
        // Get YAxis
        Vector3 proximity = playertransform.transform.position - doortransform.transform.position;
        Vector3 PlayerEntered = playertransform.transform.position - detection.transform.position;
        if (PlayerIn == false)
        {
            if (proximity.magnitude < 13 && proximity.magnitude > 1 && OpenActivated == false)
            {
                OpenActivated = true;
            }
            if (OpenActivated == true)
            {
                if (i > -100)
                {
                    transform.Rotate(0.0f, -1.0f, 0.0f, Space.World);
                    i -= 1;
                }
                if (i == -100)
                {
                    OpenActivated = false;
                }
            }
        }
        if ( (proximity.magnitude > 20 && OpenActivated == false) || (proximity.magnitude > 10 && PlayerIn == true))
        {
            if ( i < 0)
            {
                transform.Rotate(0.0f, +1.0f, 0.0f, Space.World);
                i += 1;
            }
        }
        if (PlayerEntered.magnitude < 5)
        {
            PlayerIn = true;
        }
        //Debug.Log("PlayeEntered = " + PlayerEntered.magnitude);
    }
}
