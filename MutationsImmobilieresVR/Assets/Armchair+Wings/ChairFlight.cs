using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairFlight : MonoBehaviour
{
    public Transform player;
    public Transform wings;
    public float maxWingsScale = 0.381f;
    public float minDist = 35f;
    public float minFlightHeight = 0.5f;
    public float maxFlightHeight = 1.5f;
    public float flightPuls = 1.8f;

    void Update()
    {
        Vector2 playerXZ = new Vector2(player.position.x, player.position.z);
        Vector2 chairXZ = new Vector2(transform.position.x, transform.position.z);
        float t = Mathf.Max(1f - (playerXZ - chairXZ).magnitude / minDist, 0f);
        t = Mathf.Pow(t, 3f);
        float minHeight = t * minFlightHeight;
        float maxHeight = t * maxFlightHeight;
        float actualHeight = Mathf.Lerp(minHeight, maxHeight, Mathf.PerlinNoise(Time.time * flightPuls, Time.time * flightPuls));
        Debug.Log(Mathf.PerlinNoise(Time.time * flightPuls, Time.time * flightPuls));
        transform.localPosition = new Vector3(transform.localPosition.x, actualHeight, transform.localPosition.z);
        // Wings scale
        float tWings = Mathf.Min(t * 5f, 1f);
        float scl = maxWingsScale * tWings;
        wings.localScale = new Vector3(scl, scl, scl);
    }
}
