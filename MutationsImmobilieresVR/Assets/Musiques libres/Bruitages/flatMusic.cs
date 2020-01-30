using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flatMusic : MonoBehaviour
{
    public Transform player;
    public Transform RoomMusic;
    public Transform Carpet;

    bool playerIn = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().enabled = true;
        GetComponent<AudioSource>().volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 proximity = player.transform.position - transform.position;

        if (proximity.magnitude < 5f && GetComponent<AudioSource>().volume == 0f)
            playerIn = true;

        if (playerIn == true)
        {
            GetComponent<AudioSource>().enabled = true;

            if (GetComponent<AudioSource>().volume < 0.8f && playerIn == true)
            {
                GetComponent<AudioSource>().volume += Time.deltaTime * 0.1f;
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
