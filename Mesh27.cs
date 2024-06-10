using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh27 : MonoBehaviour
{
    // StairToDoor

    Mesh mesh;
    Vector3[] vertices;
    Vector2[] uvs;
    int[] triangles;

    const float PI = 3.1415926535897931f;


    const int N = 8;
    const int N1 = 16;


    float Pos1 = 0.1825f - 0.0625f;//Object position
    float Pos2 = -0.221875f - 0.06f;
    float Pos3 = -0.9275f;//4375f;


    public float c1 = 4.25f;//x-direction
    public float c2 = 2.75f;//y-direction
    public float c3 = 3.75f;//z-direction
    public float R = 0.125f;

    public Material mat;
    GameObject gog;
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, N, N1, mat, true);
    }

    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, int N, int N1, Material mat, bool collider)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

        Mesh m = new Mesh();

        vertices = new Vector3[6];
        triangles = new int[12];
        uvs = new Vector2[6];
        float meshScale = 4f;


        vertices[0] = new Vector3(- 0.925f, -0.1566955f, -0.9270834f);
        vertices[1] = new Vector3( 0.40625f, -0.1566955f, -0.9270834f);
        vertices[2] = new Vector3(-0.925f, -0.1566955f, -1.75f);
        vertices[3] = new Vector3( 0.40625f, -0.1566955f, -1.75f);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;


        uvs[0] = new Vector2(vertices[0].x, vertices[0].z);
        uvs[1] = new Vector2(vertices[1].x, vertices[1].z);
        uvs[2] = new Vector2(vertices[2].x, vertices[2].z);
        uvs[3] = new Vector2(vertices[3].x, vertices[3].z);


        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
        }


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
