using UnityEngine;

public class SphereScaleAnimationCtrl : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnEventIDChange(int id)
    {
        if (id % 4 == 0)
        {
            animator.SetBool("Play", true);
            GetComponent<DeformMesh>().enabled = true;
        }
        else
        {
            animator.SetBool("Play", false);
            GetComponent<DeformMesh>().enabled = false;
        }
    }
}
