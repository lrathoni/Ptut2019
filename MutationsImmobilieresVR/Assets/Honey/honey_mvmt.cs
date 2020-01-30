using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honey_mvmt : MonoBehaviour
{
    public Transform player;
    public float x;
    int id;

    // Start is called before the first frame update
    void Start()
    {
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        id = EventsManager.I.getEventID();

        if (id > 2)
            transform.rotation = new Quaternion(0, 0, 1, 0);

        //if the player is far enough the object will increase in size
        if ((player.position - transform.position).magnitude > 25)
        {
            x += 0.003f;
        }
        else
        {
            x -= 0.006f;
        }

        if (x > 2) x = 0;
        if (x < 0) x = 0;

        transform.localScale = new Vector3(2 * x, 3 * x, 2 * x);
    }
}