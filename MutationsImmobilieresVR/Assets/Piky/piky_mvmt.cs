using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piky_mvmt : MonoBehaviour
{
    public CharacterController charCtrl;
    public Transform player;
    public float x;
    public Light light;
    int id;

	// Start is called before the first frame update
	void Start()
    {
        x = 1;
    }


    // Update is called once per frame
    void Update()
    {
        //light changes depending on the event
        id = EventsManager.I.getEventID();
        if (id < 3)
        {
            light.color = Color.red;
            light.intensity = 5.2f * x;
        }
        else
        {
            light.color = Color.yellow;
            light.intensity = 4.2f * x;
        }

        //if the player is far enough the object will increase in size
        if ((player.position - transform.position).magnitude > 25)
        {
            x += 0.02f;
        }
        else
        {
            x -= 0.02f;
        }

        if (x > 2) x = 0;
        if (x < 0) x = 0;

		charCtrl.Move(new Vector3(x/10f, x/100f, x/10f));
		transform.localScale = new Vector3(5*x, 5*x, 5*x);
    }
}
