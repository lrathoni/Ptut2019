using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBook : MonoBehaviour
{
    OpenDoor scriptInstance = null;
    public Transform playerTransform;
    public Transform CornerRightBackTransform;


    bool BooksMove = true;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 proximity = CornerRightBackTransform.transform.position - playerTransform.transform.position;
            if (proximity.magnitude < 3 && BooksMove == true)
            {
                GetComponent<Animator>().enabled = true;
                BooksMove = false;
            }
        
    }
}
