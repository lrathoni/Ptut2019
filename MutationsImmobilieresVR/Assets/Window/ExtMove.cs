using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtMove : MonoBehaviour
{
    public Transform player;
    public Texture[] ExtTexture = new Texture[4];
    Transform[] Glasses = new Transform[2];
    float flash = Time.time;
    

    // Start is called before the first frame update
    void Start()
    {
        Glasses[0] = transform.GetChild(1).GetChild(1);
        Glasses[1] = transform.GetChild(2).GetChild(1);
        if (ExtTexture.Length == 0)
            return;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 proximity = player.transform.position - transform.position;
        if ( proximity.magnitude < 15 && proximity.magnitude > 14)
        {
            Glasses[0].GetComponent<MeshRenderer>().material.mainTexture = ExtTexture[0];
            Glasses[1].GetComponent<MeshRenderer>().material.mainTexture = ExtTexture[0];
        }
        if (proximity.magnitude <= 14)
        {
            Glasses[0].GetComponent<MeshRenderer>().material.mainTexture = ExtTexture[1];
            Glasses[1].GetComponent<MeshRenderer>().material.mainTexture = ExtTexture[3];
        }
        else
        {
            Glasses[0].GetComponent<MeshRenderer>().material.mainTexture = ExtTexture[2];
            Glasses[1].GetComponent<MeshRenderer>().material.mainTexture = ExtTexture[2];
        }

    }
}
