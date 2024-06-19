using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh25 : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    Vector2[] uvs;
    int[] triangles;

    const float PI = 3.1415926535897931f;


    const int N = 8;
    const int N1 = 16;


    public Material mat;
    GameObject gog;
    void Awake()
    {

        gog = MakeDiscreteProceduralGrid( N, N1, mat, true);
    }
    void Start()
    {

    }

    public static GameObject MakeDiscreteProceduralGrid(int N, int N1, Material mat, bool collider)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

        Mesh m = new Mesh();

        vertices = new Vector3[8];
        triangles = new int[12];
        uvs = new Vector2[8];
        float meshScale = 4f;

        vertices[0] = new Vector3(-0.875f, -0.02758783f, -0.4270834f);
        vertices[1] = new Vector3(-0.875f, -0.02758783f, -0.9270833f);
        vertices[2] = new Vector3(-0.84375f, -0.02758783f, -0.9270833f);
        vertices[3] = new Vector3(-0.84375f, -0.02758783f, -0.4270834f);
        vertices[4] = new Vector3(-0.84375f, -0.02758783f, -0.9270833f);
        vertices[5] = new Vector3(-0.84375f, -0.02758783f, -0.4270834f);
        vertices[6] = new Vector3(-0.84375f, -0.2775878f, -0.9270833f);
        vertices[7] = new Vector3(-0.84375f, -0.2775878f, -0.4270834f);


        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;
        triangles[3] = 2;
        triangles[4] = 0;
        triangles[5] = 3;
        triangles[6] = 4;
        triangles[7] = 5;
        triangles[8] = 6;
        triangles[9] = 5;
        triangles[10] = 7;
        triangles[11] = 6;




        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
        }

        /*
        uvs[0] = new Vector2(vertices[0].x, vertices[0].z) / 2f;
        uvs[1] = new Vector2(vertices[1].x, vertices[1].z) / 2f;
        uvs[2] = new Vector2(vertices[2].x, vertices[2].z) / 2f;
        uvs[3] = new Vector2(vertices[3].x, vertices[3].z) / 2f;

        uvs[4] = new Vector2(vertices[4].y, vertices[4].z) / 2f;
        uvs[5] = new Vector2(vertices[5].y, vertices[5].z) / 2f;
        uvs[6] = new Vector2(vertices[6].y, vertices[6].z) / 2f;
        uvs[7] = new Vector2(vertices[7].y, vertices[7].z) / 2f;
        */

        uvs[0] = new Vector2(vertices[0].z, vertices[0].x) / 2f;
        uvs[1] = new Vector2(vertices[1].z, vertices[1].x) / 2f;
        uvs[2] = new Vector2(vertices[2].z, vertices[2].x) / 2f;
        uvs[3] = new Vector2(vertices[3].z, vertices[3].x) / 2f;

        uvs[4] = new Vector2(vertices[4].z, vertices[4].y) / 2f;
        uvs[5] = new Vector2(vertices[5].z, vertices[5].y) / 2f;
        uvs[6] = new Vector2(vertices[6].z, vertices[6].y) / 2f;
        uvs[7] = new Vector2(vertices[7].z, vertices[7].y) / 2f;



        m.vertices = vertices;
        m.triangles = triangles;
        m.uv = uvs;
        if (collider)
        {
            (go.AddComponent(typeof(MeshCollider)) as MeshCollider).sharedMesh = m;
        }









        mf.mesh = m;
        mr.material = mat;
        m.RecalculateBounds();
        m.RecalculateNormals();

        return go;
    }
}
