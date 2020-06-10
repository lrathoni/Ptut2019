using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnableCloth : MonoBehaviour
{
    public Transform FloorRoom2;
    public Transform playertransform;
    public Transform MusicCubeRoom;
    public Transform MusicFlat;

    Vector3 center;
    bool teleportation = false;
    bool falling = false;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Cloth>().enabled = false;
        GetComponent<BoxCollider>().enabled = true;
        MusicCubeRoom.GetComponent<AudioSource>().volume = 0;
        MusicCubeRoom.GetComponent<AudioSource>().enabled = false;
        center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 collision = playertransform.position;
        if ((center - collision).magnitude < 3)
        {
                GetComponent<Cloth>().enabled = true;
                GetComponent<BoxCollider>().enabled = false;
                FloorRoom2.GetComponent<BoxCollider>().enabled = false;
                falling = true;
                MusicCubeRoom.GetComponent<AudioSource>().enabled = true;
        }

        if (falling == false)
        {
            timer = 0f;
            teleportation = false;
            
        }

        if (falling == true)
        {
            timer += Time.deltaTime;
        }


        if (timer > 7f)
        {
            if (teleportation == false)
            {
                playertransform.transform.position = new Vector3(68.7f, 2.5f, 195.9f);
                teleportation = true;
                falling = false;
            }
            FloorRoom2.GetComponent<BoxCollider>().enabled = true;
        }

        if (MusicCubeRoom.GetComponent<AudioSource>().volume < 0.8f && GetComponent<BoxCollider>().enabled == false)
        {
            MusicCubeRoom.GetComponent<AudioSource>().enabled = true;
            MusicCubeRoom.GetComponent<AudioSource>().volume += Time.deltaTime * 0.2f;
            MusicFlat.GetComponent<AudioSource>().volume -= Time.deltaTime * 0.4f;
        }

        if (MusicCubeRoom.GetComponent<AudioSource>().volume >= 0.8f )
        {
            MusicFlat.GetComponent<AudioSource>().volume = 0;
            MusicFlat.GetComponent<AudioSource>().enabled = false;


        }
    }
}
