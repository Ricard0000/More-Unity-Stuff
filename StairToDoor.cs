using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class StairToDoor : MonoBehaviour
{

    public ParticleSystem system;

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

    float delta_theta = (PI / 2) / N;
    float delta_circ = (PI / 2) / N;
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

        //N=number of splits per quarter.

        vertices = new Vector3[8];
        triangles = new int[15];
        uvs = new Vector2[8];

        vertices[0] = new Vector3(-0.74375f, -0.2816955f, -0.9270834f) + new Vector3(-0.1f, 0.125f, 0f);
        uvs[0] = new Vector2(vertices[0].x, vertices[0].z);

        vertices[1] = new Vector3(-0.30625f, -0.2816955f, -0.9270834f) + new Vector3(0.28875f, 0.125f, 0f);
        uvs[1] = new Vector2(vertices[1].x, vertices[1].z);

        vertices[2] = new Vector3(-0.74375f, -0.2816955f, -0.8025f) + new Vector3(-0.1f, 0.125f, 0f);
        uvs[2] = new Vector2(vertices[2].x, vertices[2].z);

        vertices[3] = new Vector3(-0.30625f, -0.2816955f, -0.8025f) + new Vector3(0.28875f, 0.125f, 0f);
        uvs[3] = new Vector2(vertices[3].x, vertices[3].z);

        vertices[4] = new Vector3(-0.74375f - 0.1f, -0.1566955f, -0.7882653f);
        uvs[4] = new Vector2(vertices[4].x, vertices[4].z);

        vertices[5] = new Vector3(-0.30625f + 0.28875f, -0.1566955f, -0.7882653f);
        uvs[5] = new Vector2(vertices[5].x, vertices[5].z);




        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;

        triangles[6] = 5;
        triangles[7] = 3;
        triangles[8] = 2;

        triangles[9] = 4;
        triangles[10] = 5;
        triangles[11] = 2;

//        triangles[12] = 5;
//        triangles[13] = 7;
//        triangles[14] = 6;


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
    /*
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
    */
}
