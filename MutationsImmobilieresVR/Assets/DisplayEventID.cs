using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEventID : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
    void OnEventIDChange(int id)
    {
        text.text = id.ToString();
    }
}
