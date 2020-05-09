using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomtoFlatSound : MonoBehaviour
{
    public Transform player;
    public Transform RoomMusic;
    public Transform FlatMusic;

    bool playerIn = false;
    // Start is called before the first frame update
    void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 proximity = player.transform.position - transform.position;
            Debug.Log("approche " + proximity.magnitude);
            if (proximity.magnitude < 7f && RoomMusic.GetComponent<AudioSource>().volume == 0f)
                playerIn = true;

            if (playerIn == true)
            {
                RoomMusic.GetComponent<AudioSource>().enabled = true;

                if (RoomMusic.GetComponent<AudioSource>().volume < 0.8f && playerIn == true)
                {
                    RoomMusic.GetComponent<AudioSource>().volume += Time.deltaTime * 0.1f;
                    Debug.Log("j'ajoute");
                    FlatMusic.GetComponent<AudioSource>().volume -= Time.deltaTime * 0.3f;
                    Debug.Log("ICI ça monte" + RoomMusic.GetComponent<AudioSource>().volume + "   "+ proximity.magnitude);
                }

                if (GetComponent<AudioSource>().volume >= 0.8f && playerIn == true)
                {
                    FlatMusic.GetComponent<AudioSource>().volume = 0;
                    playerIn = false;
                    FlatMusic.GetComponent<AudioSource>().enabled = false;
                }
            }
        }
    
}

