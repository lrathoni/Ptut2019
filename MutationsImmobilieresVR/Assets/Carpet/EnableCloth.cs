using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCloth : MonoBehaviour
{
    public Transform playertransform;
    int waiting = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Cloth>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Cloth>().enabled == false)
        {
            Debug.Log("Cloth distance entrée dans le code");
                Vector3 collision = playertransform.position;
                Vector3 center = transform.position;
            Debug.Log("DistanceCloth = " + (center - collision).magnitude);
            if ((center - collision).magnitude < 3)
            {
                 Debug.Log("waiting = " + waiting);
                 GetComponent<Cloth>().enabled = true;
            }
            
        }
    }
}
