using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flatMusic : MonoBehaviour
{
    public Transform player;
    public Transform RoomMusic;

    bool playerIn = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().enabled = false;
        GetComponent<AudioSource>().volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 proximity = player.transform.position - transform.position;
        if (GetComponent<AudioSource>().volume == 0)
            playerIn = false;

        if (proximity.magnitude < 10f)
            playerIn = true;

        Debug.Log("Music flat prox = " + proximity.magnitude);
        
        if (playerIn == true)
        {
            GetComponent<AudioSource>().enabled = true;
        }

        if (GetComponent<AudioSource>().volume < 0.8f && playerIn == true)
        {
            GetComponent<AudioSource>().volume += Time.deltaTime*0.1f;
            RoomMusic.GetComponent<AudioSource>().volume -= Time.deltaTime * 0.3f;
        }

        if (GetComponent<AudioSource>().volume > 0.8f && playerIn == true)
        {
            RoomMusic.GetComponent<AudioSource>().volume = 0;
            RoomMusic.GetComponent<AudioSource>().enabled = false;
        }

        Debug.Log("Music flat volume = " + GetComponent<AudioSource>().volume);
        Debug.Log("Music flat enable = " + GetComponent<AudioSource>().enabled);
    }
}
