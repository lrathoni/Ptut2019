using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAppear : MonoBehaviour
{

    Transform Wall;
    Transform Cube;

    public Transform ExitDoor;
    public Transform ExitDoor2;

    float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        ExitDoor.GetComponent<MeshRenderer>().enabled = false;
        ExitDoor.GetComponent<ReturnRoom1>().enabled = false;

        ExitDoor2.GetComponent<MeshRenderer>().enabled = false;
        ExitDoor2.GetComponent<ExitRoomToLaby>().enabled = false;
    
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

        timer += Time.deltaTime;

        if (timer > 30f)
        {
            int[] indexDoor = { 20, 21, 22, 30, 31, 32 };
            int[] indexDoor2 = { 60, 61, 62, 70, 71, 72 };
            Wall = this.gameObject.transform.GetChild(2);
            for (int i = 0; i < indexDoor.Length; i++)
            {
                Wall.transform.GetChild(indexDoor[i]).GetComponent<MeshRenderer>().enabled = false;
                Wall.transform.GetChild(indexDoor[i]).GetComponent<BoxCollider>().enabled = false;
            
                Wall.transform.GetChild(indexDoor2[i]).GetComponent<MeshRenderer>().enabled = false;
                Wall.transform.GetChild(indexDoor2[i]).GetComponent<BoxCollider>().enabled = false;
            
            }

            ExitDoor.GetComponent<MeshRenderer>().enabled = true;
            ExitDoor.GetComponent<ReturnRoom1>().enabled = true;

            ExitDoor2.GetComponent<MeshRenderer>().enabled = true;
            ExitDoor2.GetComponent<ExitRoomToLaby>().enabled = true;

            timer = 0f;
            GetComponent<ExitAppear>().enabled = false;
        }
    }
}
