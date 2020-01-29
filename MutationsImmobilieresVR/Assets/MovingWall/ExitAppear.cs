using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAppear : MonoBehaviour
{

    Transform Wall;
    Transform Cube;

    float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<6; i++)
        {
            Wall = this.gameObject.transform.GetChild(i);
            for (int j=0; j<100; j++)
            {
                Cube = Wall.transform.GetChild(j);
                if (Cube.transform.localScale.z > 100)
                    Cube.transform.localScale = new Vector3(100f, 100f, Cube.transform.localScale.z - 3f);
                if (Cube.transform.localScale.z < 103f)
                {
                    Cube.transform.localScale = new Vector3(100f, 100f, 100f); 
                }
            }
        }

/*        if ( transform.localScale != new Vector3(4f, 4f, 4f))
        {
            transform.localScale = transform.localScale + new Vector3(4f, 4f, -0.05f);
            if (transform.localScale.z < 4.05f)
                transform.localScale = new Vector3(4f, 4f, 4f);
        }
*/
        timer += Time.deltaTime;

        if (timer > 30f)
        {
            int[] indexDoor = { 20, 21, 22, 30, 31, 32 };
            Wall = this.gameObject.transform.GetChild(2);
            for (int i = 0; i < indexDoor.Length; i++)
            {
                Wall.transform.GetChild(indexDoor[i]).GetComponent<MeshRenderer>().enabled = false;
                Wall.transform.GetChild(indexDoor[i]).GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
