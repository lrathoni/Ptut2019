using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnableCloth : MonoBehaviour
{
    public Transform FloorRoom2;
    public Transform playertransform;
    public Transform MusicCubeRoom;
    public Transform MusicFlat;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Cloth>().enabled == false)
        {
            Vector3 collision = playertransform.position;
            Vector3 center = transform.position;
            if ((center - collision).magnitude < 3)
            {
                GetComponent<Cloth>().enabled = true;
                GetComponent<BoxCollider>().enabled = false;
                FloorRoom2.GetComponent<BoxCollider>().enabled = false;
                falling = true;
                MusicCubeRoom.GetComponent<AudioSource>().enabled = true;
            }
        }
        if (falling == true)
        {
            timer += Time.deltaTime;
        }


        if (timer > 7f )
        {
            if (teleportation == false)
            {
                playertransform.transform.position = new Vector3(68.7f, 2.5f, 195.9f);
                teleportation = true;
            }
            FloorRoom2.GetComponent<BoxCollider>().enabled = true;
        }

        if (MusicCubeRoom.GetComponent<AudioSource>().volume < 0.8 && falling == true)
        {
            MusicCubeRoom.GetComponent<AudioSource>().volume += Time.deltaTime * 0.2f;
            MusicFlat.GetComponent<AudioSource>().volume -= Time.deltaTime * 0.4f;
        }

        if (MusicCubeRoom.GetComponent<AudioSource>().volume >= 0.8)
        {
            MusicFlat.GetComponent<AudioSource>().enabled = false;
        }
    }
}
