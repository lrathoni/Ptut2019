using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : Singleton<EventsManager>
{
    protected EventsManager() { }

    int[] permut = { 2, 5, 1, 4, 7, 0, 8, 3, 6 };

    public GameObject[] observers;

    Transform RoomTransform;
    Transform PlayerTransform;
    int prevID = -1;

    public float timeBetweenEventChangeInSeconds = 15f;
    private void Start()
    {
        RoomTransform = GameObject.FindGameObjectWithTag("MainRoom").transform;
        PlayerTransform = GameObject.FindGameObjectWithTag("MainCharacter").transform;
    }
    public int getEventID()
    {
        Vector3 roomSize = Matrix4x4.Scale(RoomTransform.parent.localScale) * RoomTransform.localScale;
        float distX = (RoomTransform.position.x - PlayerTransform.position.x) / roomSize.x / 1.74f + 0.5f;
        float distZ = (RoomTransform.position.z - PlayerTransform.position.z) / roomSize.z / 228f + 0.5f;
        int XID = Mathf.FloorToInt(distX * 3);
        int ZID = Mathf.FloorToInt(distZ * 3);
        int cellID = XID + 3 * ZID;
        int timeID = Mathf.RoundToInt(Time.time / timeBetweenEventChangeInSeconds) % 9;
        return (cellID + permut[timeID]) % 9 + (Mathf.FloorToInt(Time.time / 60f)%2) * 9;
    }

    private void Update()
    {
        int id = getEventID();
        if (id != prevID)
        {
            Debug.Log("Entering event : " + id);
            foreach(GameObject obj in observers){
                obj.SendMessage("OnEventIDChange", id);
            }
        }
        prevID = id;
    }
}
