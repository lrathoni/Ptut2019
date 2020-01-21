using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCloth : MonoBehaviour
{
    public Transform playertransform;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Cloth>().enabled = false;
        GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Cloth>().enabled == false)
        {
            Vector3 collision = playertransform.position;
            Vector3 center = transform.position;
            //Debug.Log("DistanceCloth = " + (center - collision).magnitude);
            if ((center - collision).magnitude < 3)
            {
                GetComponent<Cloth>().enabled = true;
                GetComponent<BoxCollider>().enabled = false;
            }
            
        }
    }
}
