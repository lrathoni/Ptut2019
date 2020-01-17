using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveTable : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        //calculate distance
        double a = (double)(player.position.x - transform.position.x);
        double b = (double)(player.position.z - transform.position.z);

        double distance_player_table = Math.Sqrt(a * a + b * b);

        //if the player gets closer to the table, it'll disappear and be behind him
        if (distance_player_table < 8)
        {
            Debug.Log(player.position.z);
            //if the player is facing in the direction of the z axis
            if (player.position.z < 184)
                transform.position = new Vector3(player.position.x, transform.position.y, player.position.z - 8);
            else
                transform.position = new Vector3(player.position.x, transform.position.y, player.position.z + 8);
        }

    }
}
