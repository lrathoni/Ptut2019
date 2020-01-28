using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnEventIDChange(int id)
    {
        if (id%3 == 0 && id / 9 == 1)
        {
            //transform.localScale = new Vector3(2, 1 , 1);
            animator.SetBool("Grow", true);
        }
        else
        {
            //transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("Grow", false);
        }
    }
}
