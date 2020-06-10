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

    public bool valuePlayerIn()
    {
        return PlayerIn;
    }

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
        if ( (proximity.magnitude > 20 && OpenActivated == false) || (proximity.magnitude > 5 && PlayerIn == true))
        {
            if ( i < 0)
            {
                transform.Rotate(0.0f, +2.0f, 0.0f, Space.World);
                i += 2;
            }
        }
        if (PlayerEntered.magnitude < 5)
        {
            PlayerIn = true;
            GetComponentInParent<AudioSource>().enabled = true;
        }

        if (GetComponentInParent<AudioSource>().enabled == true && GetComponentInParent<AudioSource>().volume < 0.8 && PlayerIn == true)
            GetComponentInParent<AudioSource>().volume += Time.deltaTime * 0.5f;

        if (playertransform.transform.position.x < 200)
        {
            PlayerIn = false;
            GetComponent<OpenDoor>().enabled = false;
        }
    }
}
