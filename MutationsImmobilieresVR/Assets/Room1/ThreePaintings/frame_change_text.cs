using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frame_change_text : MonoBehaviour
{
    public Transform player;
	public Material[] materials;
    public Renderer m_Renderer;
    float value;

    private void Start()
	{
		m_Renderer = GetComponent<MeshRenderer>();
        value = 0.1f;
	}

	// Update is called once per frame
	void Update()
    {
        if (player.position.x - transform.position.x < 5)
		{
            materials[0].SetTextureScale("_MainTex", new Vector2(value, value));
            materials[1].SetTextureScale("_MainTex", new Vector2(value, value));
            value += 0.001f;
        }
        if (System.Math.Abs(value - 1) < 0.1f) value = 0.1f;
        m_Renderer.materials = materials;

    }
}
