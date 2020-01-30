using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnableCloth : MonoBehaviour
{
    public Transform FloorRoom2;
    public Transform playertransform;

    bool falling = false;
    float timer = 0;
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
                FloorRoom2.GetComponent<BoxCollider>().enabled = false;
                falling = true;
            }
        }
        if (falling == true)
        {
            timer += Time.deltaTime;
        }

/*        if (timer <7f && playertransform.transform.position.y<-620f)
            playertransform.transform.position += new Vector3(0f, 50f, 0f);*/

        if (timer > 7f)
        {
            playertransform.transform.position = new Vector3(68.7f, 2.5f, 195.9f);
            GetComponent<EnableCloth>().enabled = false;
            FloorRoom2.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
