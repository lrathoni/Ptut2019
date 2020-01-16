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
    public float maxXZMovementRadius = 2f;
    public float heightPuls = 0.8f;
    public float xzPuls = 0.02f;

    void Update()
    {
        Vector2 playerXZ = new Vector2(player.position.x, player.position.z);
        Vector2 chairXZ = new Vector2(transform.position.x, transform.position.z);
        float t = Mathf.Max(1f - (playerXZ - chairXZ).magnitude / minDist, 0f);
        t = Mathf.Pow(t, 3f);
        // Height variation
        float minHeight = t * minFlightHeight;
        float maxHeight = t * maxFlightHeight;
        float actualHeight = Mathf.Lerp(minHeight, maxHeight, Mathf.PerlinNoise(Time.time * heightPuls, Time.time * heightPuls));
        // XZ movement
        float movRadius = t * maxXZMovementRadius;
        float angle = Mathf.Lerp(0, Mathf.PI, Mathf.PerlinNoise(Time.time * xzPuls + 50f, Time.time * xzPuls));
        float actualRadius = Mathf.Lerp(0, movRadius, Mathf.PerlinNoise(Time.time * xzPuls + 100f, Time.time * xzPuls));
        Vector2 XZpos = actualRadius * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        // Set transform
        transform.localPosition = new Vector3(XZpos.x, actualHeight, XZpos.y);
        // Wings scale
        float tWings = Mathf.Min(t * 5f, 1f);
        float scl = maxWingsScale * tWings;
        wings.localScale = new Vector3(scl, scl, scl);
    }
}
