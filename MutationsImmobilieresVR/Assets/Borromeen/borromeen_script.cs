using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borromeen_script : MonoBehaviour
{
    public Transform player;
    public float x, y;

    private void Start()
    {
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        y = (player.position - transform.position).magnitude;
        //if the player is far enough the object will increase in size
        if ((player.position - transform.position).magnitude > 25) 
        {
            x += 0.02f;
            transform.localScale = new Vector3(x, x, x);
        }
        else
        {
            x -= 0.02f;
            transform.localScale = new Vector3(x, x, x);
        }
        if (x > 5) x = 0;
        if (x < 0) x = 0;

    }

}
