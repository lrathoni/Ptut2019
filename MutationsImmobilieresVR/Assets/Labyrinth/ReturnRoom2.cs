using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnRoom2 : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 proximity = player.transform.position - transform.position;
        Debug.Log("proxy :" + proximity.magnitude );
        if (proximity.magnitude < 9f)
        {
            player.transform.position = new Vector3(178.7f, -39.4f, 183.5f);
        }
    }
}

