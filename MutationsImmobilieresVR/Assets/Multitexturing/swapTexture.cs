using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class swapTexture : MonoBehaviour
{

    public Texture[] textures;
    public Renderer m_Renderer;
    public float changeInterval = 0.033F;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textures.Length == 0)
            return;

        int index = Mathf.FloorToInt(Time.time / changeInterval);
        index = index % textures.Length;
        m_Renderer.material.mainTexture = textures[index];
    }
}
