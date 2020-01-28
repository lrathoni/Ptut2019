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
            //Vector3 dir = normals[i];
            float r1 = (float)NoiseS3D.Noise(originalVertices[i].x * scale+1001.12441, originalVertices[i].y * scale, originalVertices[i].z * scale, Time.time * speed);
            float r2 = (float)NoiseS3D.Noise(originalVertices[i].x * scale +124.1278, originalVertices[i].y * scale, originalVertices[i].z * scale, Time.time * speed);
            float r3 = (float)NoiseS3D.Noise(originalVertices[i].x * scale + 5201.75141, originalVertices[i].y * scale, originalVertices[i].z * scale, Time.time * speed);
            Vector3 dir = new Vector3(r1, r2, r3).normalized;
            modifiedVertices[i] = originalVertices[i] + dir * amplitude * (float)NoiseS3D.Noise(originalVertices[i].x*scale, originalVertices[i].y*scale, originalVertices[i].z * scale, Time.time*speed);
        }

        UploadVertices();
    }

    public void resetMesh()
    {
        for (int i = 0; i < originalVertices.Count; ++i)
        {
            modifiedVertices[i] = originalVertices[i];
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
