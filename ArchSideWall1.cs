using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ArchSideWall1 : MonoBehaviour
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
    void Start()
    {

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

        vertices = new Vector3[8];// + 2];
        triangles = new int[12];
        uvs = new Vector2[8];

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);


        vertices[0] = new Vector3(-0.875f, 0.003662168f, -0.4270834f);
        uvs[0] = new Vector2(vertices[0].y, vertices[0].z);

        vertices[1] = new Vector3(-0.875f, 0.003662168f, -0.9270833f);
        uvs[1] = new Vector2(vertices[1].y, vertices[1].z);

        vertices[2] = new Vector3(-0.875f, 0.003662168f - 0.03125f, -0.9270833f) + new Vector3(0.001f, 0f, 0f);
        uvs[2] = new Vector2(vertices[2].y, vertices[2].z);

        vertices[3] = new Vector3(-0.875f, 0.003662168f - 0.03125f, -0.4270834f); // needs to be modded
        uvs[3] = new Vector2(vertices[3].y, vertices[3].z);

        float lambda = 0.25f;
        vertices[4] = new Vector3(-0.875f, 0.003662168f, -0.4270834f * lambda -0.9270833f * (1-lambda));
        uvs[4] = new Vector2(vertices[4].x, vertices[4].z);

        vertices[5] = new Vector3(-0.875f, 0.003662168f, -0.4270834f * (1 - lambda) - 0.9270833f * lambda);
        uvs[5] = new Vector2(vertices[5].x, vertices[5].z);

        vertices[6] = new Vector3(-0.875f - 0.0625f, 0.003662168f, -0.4270834f * lambda - 0.9270833f * (1 - lambda));
        uvs[6] = new Vector2(vertices[6].x, vertices[6].z);

        vertices[7] = new Vector3(-0.875f - 0.0625f, 0.003662168f, -0.4270834f * (1 - lambda) - 0.9270833f * lambda);
        uvs[7] = new Vector2(vertices[7].x, vertices[7].z);

        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 2;
        triangles[4] = 0;
        triangles[5] = 3;

        triangles[6] = 5;
        triangles[7] = 4;
        triangles[8] = 6;

        triangles[9] = 5;
        triangles[10] = 6;
        triangles[11] = 7;


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
