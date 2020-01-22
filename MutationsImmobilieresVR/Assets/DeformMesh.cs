using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class DeformMesh : MonoBehaviour
{
    public float scale = 1f;
    public float amplitude = 1f;
    public float speed = 1f;

    private Mesh mesh;
    List<Vector3> normals;
    List<Vector3> originalVertices;
    List<Vector3> modifiedVertices;
    void Start()
    {
        // Get mesh
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.MarkDynamic();
        // Normals
        normals = new List<Vector3>();
        mesh.GetNormals(normals);
        //  Vertices
        originalVertices = new List<Vector3>();
        mesh.GetVertices(originalVertices);
        modifiedVertices = new List<Vector3>();
        mesh.GetVertices(modifiedVertices);
    }

    void Update()
    {
        for (int i = 0; i < originalVertices.Count; ++i)
        {
            modifiedVertices[i] = originalVertices[i] + normals[i] * amplitude * (float)NoiseS3D.Noise(originalVertices[i].x*scale, originalVertices[i].y*scale, originalVertices[i].z * scale, Time.time*speed);
        }

        UploadVertices();
    }

    void UploadVertices()
    {
        mesh.SetVertices(modifiedVertices);
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();
    }
}
