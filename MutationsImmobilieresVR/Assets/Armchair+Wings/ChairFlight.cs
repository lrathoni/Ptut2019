using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairFlight : MonoBehaviour
{
    public Transform player;
    public float minDist = 10f;
    public float maxFlightHeight = 3f;

    void Update()
    {
        float t = Mathf.Max(1f - (player.position - transform.position).magnitude / minDist, 0f);
        //Debug.Log((player.position - transform.position).magnitude);
    }
}
