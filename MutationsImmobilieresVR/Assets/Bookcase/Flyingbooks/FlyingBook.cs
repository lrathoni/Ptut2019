using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBook : MonoBehaviour
{
    OpenDoor scriptInstance = null;
    public Transform playTransform;
    public Transform book1Transform;
    public Transform book2Transform;
    public Transform book3Transform;

    bool PlayerIn;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tmpObject = GameObject.Find("pivot");
        scriptInstance = tmpObject.GetComponent<OpenDoor>();
        PlayerIn = scriptInstance.valuePlayerIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIn == true)
        {
            //if ()
        }
    }
}
