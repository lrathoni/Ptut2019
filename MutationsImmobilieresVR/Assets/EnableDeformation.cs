using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDeformation : MonoBehaviour
{
    private DeformMesh script;
    private Animator animator;
    void Awake()
    {
        script = GetComponent<DeformMesh>();
        animator = GetComponent<Animator>();
    }

    void OnEventIDChange(int id)
    {
        if (id == 17)
        {
            //script.enabled = true;
            //animator.Play("DeformationIn", 0, 1f - Mathf.Min(1f, animator.GetCurrentAnimatorStateInfo(0).normalizedTime));
            animator.SetBool("WallsDeforming", true);
        }
        else
        {
            //script.enabled = false;
            //animator.Play("DeformationOut", 0, 1f - Mathf.Min(1f, animator.GetCurrentAnimatorStateInfo(0).normalizedTime));
            //script.resetMesh();
            animator.SetBool("WallsDeforming", false);
        }
    }
}
