using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : Singleton<EventsManager>
{
    protected EventsManager() { }

    int[] permut = { 2, 5, 1, 4, 7, 0, 8, 3, 6 };

    public GameObject[] observers;

    Transform Room1Transform;
    Transform Room2Transform;
    Transform PlayerTransform;
    int prevID = -1;

    public float timeBetweenEventChangeInSeconds = 15f;
    private void Start()
    {
        Room1Transform = GameObject.FindGameObjectWithTag("Room1").transform;
        Room2Transform = GameObject.FindGameObjectWithTag("Room2").transform;
        PlayerTransform = GameObject.FindGameObjectWithTag("MainCharacter").transform;
    }
    public int getEventID()
    {
    	float distX, distZ;
    	int roomID = 0;
    	if( PlayerTransform.position.x > 200f){
	        Vector3 room1Size = Matrix4x4.Scale(Room1Transform.parent.localScale) * Room1Transform.localScale;
	        distX = (Room1Transform.position.x - PlayerTransform.position.x) / room1Size.x / 1.74f + 0.5f;
	        distZ = (Room1Transform.position.z - PlayerTransform.position.z) / room1Size.z / 228f + 0.5f;
	    }
	    else{
	    	roomID = 18;
	        Vector3 room2Size = Room2Transform.localScale;
	        distX = (Room2Transform.position.x - PlayerTransform.position.x) / room2Size.x / 40f;
	        distZ = (Room2Transform.position.z - PlayerTransform.position.z) / room2Size.z / 23.5f + 2f;
	    }
        int XID = Mathf.FloorToInt(distX * 3);
        int ZID = Mathf.FloorToInt(distZ * 3);
        int cellID = XID + 3 * ZID;
        int timeID = Mathf.RoundToInt(Time.time / timeBetweenEventChangeInSeconds) % 9;
        return roomID + (cellID + permut[timeID]) % 9 + (Mathf.FloorToInt(Time.time / 60f)%2) * 9;
    }

    private void Update()
    {
        int id = getEventID();
        if (id != prevID)
        {
            foreach(GameObject obj in observers){
                obj.SendMessage("OnEventIDChange", id);
            }
        }
        prevID = id;
    }
}
