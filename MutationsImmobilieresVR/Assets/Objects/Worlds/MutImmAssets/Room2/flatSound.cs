using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flatSound : MonoBehaviour
{
    public Transform player;
    public Transform FlatMusic;
    public Transform RoomMusic;

    bool playerIn = false;
    // Start is called before the first frame update
    void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 proximity = player.transform.position - transform.position;
            if (proximity.magnitude < 4f && GetComponent<AudioSource>().volume == 0f)
                playerIn = true;

            if (playerIn == true)
            {
                FlatMusic.GetComponent<AudioSource>().enabled = true;

                if (FlatMusic.GetComponent<AudioSource>().volume < 0.8f && playerIn == true)
                {
                    FlatMusic.GetComponent<AudioSource>().volume += Time.deltaTime * 0.1f;
                    RoomMusic.GetComponent<AudioSource>().volume -= Time.deltaTime * 0.3f;
                }

                if (GetComponent<AudioSource>().volume > 0.8f && playerIn == true)
                {
                    RoomMusic.GetComponent<AudioSource>().volume = 0;
                    playerIn = false;
                    RoomMusic.GetComponent<AudioSource>().enabled = false;
                }
            }
        }

}