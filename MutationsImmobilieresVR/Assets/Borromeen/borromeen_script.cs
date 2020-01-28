using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borromeen_script : MonoBehaviour
{
    public Transform player;
    public float x;

    private void Start()
    {
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is far enough the object will increase in size
        if (player.position.x - transform.position.x < -5) 
        {
            x += 0.002f;
            transform.localScale = new Vector3(x, x, x);
            if (x > 3) x = 0;
            transform.position = new Vector3(transform.position.x+0.5f, transform.position.y, transform.position.z+0.5f);
            if (transform.position.x < 205 || transform.position.z < 153
                || transform.position.x > 240 || transform.position.z > 219)
            {
                transform.position = new Vector3(220, transform.position.y, 200);
            }
        }
        else
        {
            x = 0.2f;
            transform.localScale = new Vector3(x, x, x);
        }


    }

}
