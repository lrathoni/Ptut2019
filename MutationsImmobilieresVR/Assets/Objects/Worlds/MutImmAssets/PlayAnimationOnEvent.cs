using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnEvent : MonoBehaviour
{
    Animator animator;
    public int eventPeriod;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    void OnEventIDChange(int id)
    {
        if (id % eventPeriod == 0)
        {
            animator.SetBool("Play", true);
        }
        else
        {
            animator.SetBool("Play", false);
        }
    }
}
