using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class StairToDoor2 : MonoBehaviour
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

        vertices = new Vector3[14];
        triangles = new int[45];
        uvs = new Vector2[14];

        // TO DO: Probe Verts in on wall. Then print out verts


//        Vector3 probe = new Vector3(-0.125f, 0f, 0f);


        vertices[0] = new Vector3(-0.30625f + 0.28875f, -0.1566955f, -0.7882653f);
        vertices[3] = new Vector3(-0.74375f - 0.1f, -0.1566955f, -0.7882653f);

        vertices[1] = new Vector3(-0.01359375f, -0.1566955f, -0.7698469f);
        vertices[2] = new Vector3(-0.01359375f - 0.035f, -0.1566955f, -0.7698469f + 0.0125f);
        vertices[4] = new Vector3(-0.01359375f - 0.11f, -0.1566955f, -0.7698469f + 0.025f);
        vertices[5] = new Vector3(-0.01359375f - 0.175f, -0.1566955f, -0.7698469f + 0.03f);
        vertices[6] = new Vector3(-0.74375f - 0.1f, -0.1566955f, -0.7698469f + 0.03f);

        float down = 0.04f;
        vertices[7] = new Vector3(-0.01359375f, -0.1566955f - down, -0.7698469f);
        vertices[8] = new Vector3(-0.01359375f - 0.035f, -0.1566955f - down, -0.7698469f + 0.0125f);
        vertices[9] = new Vector3(-0.01359375f - 0.11f, -0.1566955f - down, -0.7698469f + 0.025f);
        vertices[10] = new Vector3(-0.01359375f - 0.175f, -0.1566955f - down, -0.7698469f + 0.03f);
        vertices[11] = new Vector3(-0.74375f - 0.1f, -0.1566955f - down, -0.7698469f + 0.03f);

        //        new Vector3((0.6914064f + ), (-0.1272832f + ), (-0.6894898f + ));
        vertices[12] = new Vector3(0.0125f, -0.1566955f - down, (-0.6894898f + -0.615f) * 0.5f-0.02f);
        vertices[13] = new Vector3(0.0125f - 0.035f, -0.1566955f - down, (-0.6894898f + -0.615f) * 0.5f + 0.0125f - 0.02f);
        //        vertices[12] = new Vector3(0.1765625f, -0.1566955f - down, -0.6543368f);
        //        vertices[13] = new Vector3(0.1765625f -0.035f, -0.1566955f - down, -0.6543368f + 0.0125f);


        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 2;
        triangles[4] = 0;
        triangles[5] = 3;

        triangles[6] = 2;
        triangles[7] = 3;
        triangles[8] = 4;

        triangles[9] = 3;
        triangles[10] = 5;
        triangles[11] = 4;

        triangles[12] = 3;
        triangles[13] = 6;
        triangles[14] = 5;

        triangles[15] = 1;
        triangles[16] = 2;
        triangles[17] = 7;

        triangles[18] = 2;
        triangles[19] = 8;
        triangles[20] = 7;

        triangles[21] = 2;
        triangles[22] = 4;
        triangles[23] = 8;

        triangles[24] = 4;
        triangles[25] = 9;
        triangles[26] = 8;

        triangles[27] = 4;
        triangles[28] = 5;
        triangles[29] = 9;

        triangles[30] = 5;
        triangles[31] = 10;
        triangles[32] = 9;

        triangles[33] = 5;
        triangles[34] = 6;
        triangles[35] = 10;

        triangles[36] = 6;
        triangles[37] = 11;
        triangles[38] = 10;

        triangles[39] = 7;
        triangles[40] = 13;
        triangles[41] = 12;

        triangles[42] = 8;
        triangles[43] = 13;
        triangles[44] = 7;


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
