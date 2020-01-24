using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDeformation : MonoBehaviour
{
    private DeformMesh script;
    void Awake()
    {
        script = GetComponent<DeformMesh>();
    }

    void OnEventIDChange(int id)
    {
        if (id == 3)
            script.enabled = true;
        else
        {
            script.enabled = false;
            script.resetMesh();
        }
    }
}
