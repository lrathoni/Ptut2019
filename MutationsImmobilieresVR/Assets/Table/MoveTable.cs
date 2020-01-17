using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveTable : MonoBehaviour
{
    public Transform player;
    public Vector3 bottom_left = new Vector3(240, 0, 219);
    public Vector3 bottom_right = new Vector3(203, 0, 219);
    public Vector3 up_left = new Vector3(240, 0, 153);
    public Vector3 up_right = new Vector3(203, 0, 153);

    double distanceXZ(Vector3 point1, Vector3 point2)
    {
        double a = (double)(point1.x - point2.x);
        double b = (double)(point1.z - point2.z);

        return Math.Sqrt(a * a + b * b);
    }

    // Update is called once per frame
    void Update()
    {
        //if the player gets closer to the bottom/left, the table will go there
        if (distanceXZ(player.position, bottom_left) < 6)
            transform.position = new Vector3(transform.position.x+0.5f, transform.position.y, transform.position.z+1);
        if (distanceXZ(player.position, bottom_right) < 6)
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z + 1);
        if (distanceXZ(player.position, up_left) < 6)
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z - 1);
        if (distanceXZ(player.position, up_right) < 6)
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z - 1);

    }
}



/* (x,z)

240,153         203,153




240,219          203,219

    DOOR
*/