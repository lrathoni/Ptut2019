using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughMirror : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    public Transform mirrorTransform;
    void Start()
    {
        GetComponent<MeshCollider>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 proximity = playerTransform.transform.position - mirrorTransform.transform.position;
        if (proximity.magnitude < 6)
        {
            GetComponent<MeshCollider>().enabled = false;
            mirrorTransform.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponent<MeshCollider>().enabled = true;
            mirrorTransform.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
