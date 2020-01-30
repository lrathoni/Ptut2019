using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnRoom1 : MonoBehaviour
{

    public Transform CubeRoom;
    public Transform Carpet;
    public Transform player;
    public Transform RoomMusic;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 proximity = player.transform.position - transform.position;
        if (proximity.magnitude < 7f)
        {
            player.transform.position = new Vector3(218.38f, -39.02f, 221.6824f);
            GetComponent<MeshRenderer>().enabled = false;
            Carpet.GetComponent<BoxCollider>().enabled = true;
            int[] indexDoor = { 20, 21, 22, 30, 31, 32 };
            Transform Wall = CubeRoom.transform.GetChild(2);
            for (int i = 0; i < indexDoor.Length; i++)
            {
                Wall.transform.GetChild(indexDoor[i]).GetComponent<MeshRenderer>().enabled = true;
                Wall.transform.GetChild(indexDoor[i]).GetComponent<BoxCollider>().enabled = true;
            }

            for (int i=0; i < CubeRoom.childCount; i++)
            {
                CubeRoom.GetComponentInChildren<MovingBlocks>().enabled = true;
            }
        }
        Debug.Log("Return proximity " + proximity.magnitude);
        
        GetComponent<ReturnRoom1>().enabled = false;
    }
}
