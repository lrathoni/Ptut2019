using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCurtainDeformation : MonoBehaviour
{
    DeformMesh script;

    private void Awake()
    {
        script = GetComponent<DeformMesh>();
    }

    void OnEventIDChange(int id)
    {
        if (id == 23)
            script.enabled = true;
        else
        {
            script.enabled = false;
            script.resetMesh();
        }
    }
}
