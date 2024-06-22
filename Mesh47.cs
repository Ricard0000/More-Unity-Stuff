using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh47 : MonoBehaviour
{

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

        vertices = new Vector3[13 * 6 * 2];

        triangles = new int[252 * 3];
        uvs = new Vector2[13 * 6 * 2];
        float meshScale = 4f;



        float moveBack = -0.0675f;

        Vector3 recenter1 = new Vector3(0.14259f, -0.233117095f, 0f);




        vertices[0] = new Vector3(-0.24375f, 0.065f, 0f) + recenter1;
        vertices[1] = new Vector3(-0.24375f, 0.3068946f, 0f) + recenter1;
        vertices[2] = new Vector3(-0.241266f, 0.3570874f, 0f) + recenter1;
        vertices[3] = new Vector3(-0.2203341f, 0.3996387f, 0f) + recenter1;
        vertices[4] = new Vector3(-0.1852827f, 0.4280706f, 0f) + recenter1;
        vertices[5] = new Vector3(-0.14259f, 0.4380546f, 0f) + recenter1;
        vertices[6] = new Vector3(-0.14259f, 0.4380546f, 0f) + recenter1;
        vertices[7] = new Vector3(-0.0998973f, 0.4280706f, 0f) + recenter1;
        vertices[8] = new Vector3(-0.0648459f, 0.3996387f, 0f) + recenter1;
        vertices[9] = new Vector3(-0.04391401f, 0.3570873f, 0f) + recenter1;
        vertices[10] = new Vector3(-0.04143f, 0.3068946f, 0f) + recenter1;
        vertices[11] = new Vector3(-0.04143f, 0.065f, 0f) + recenter1;
        vertices[12] = new Vector3(-0.24375f, 0.065f, 0f) + recenter1;

        float scale1 = 1.05f;
        for (int i = 0; i < 13; i++)
        {
            vertices[i] = vertices[i] * scale1;
        }


        float scale2 = 0.8f;
        for (int i = 0; i < 13; i++)
        {
            vertices[i + 13] = vertices[i] * scale2 / scale1;
        }

        for (int i = 0; i < 13; i++)
        {
            vertices[i + 26] = vertices[i] + new Vector3(0f, 0f, -0.025f);
        }

        for (int i = 0; i < 13; i++)
        {
            vertices[i + 39] = vertices[i + 13] + new Vector3(0f, 0f, -0.025f);
        }


        for (int i = 0; i < 13; i++)
        {
            vertices[i + 39 + 13] = vertices[i + 13];
        }


        for (int i = 0; i < 13; i++)
        {
            vertices[i + 39 + 26] = vertices[i + 39];
        }

        float temp;
        for (int i = 0; i < 13 * 8; i++)
        {
            temp = vertices[i].x;
            vertices[i].x = Mathf.Cos(-Mathf.PI / 4f) * vertices[i].x + Mathf.Sin(-Mathf.PI / 4f) * vertices[i].z;
            vertices[i].z = -Mathf.Sin(-Mathf.PI / 4f) * temp + Mathf.Cos(-Mathf.PI / 4f) * vertices[i].z;
        }



        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale + new Vector3(2.429f, 1.149f + 0.125f, -3.172f);
        }

        for (int i = 0; i < 13; i++)
        {
            triangles[0 + i * 6] = 1 + i;
            triangles[1 + i * 6] = 0 + i;
            triangles[2 + i * 6] = 13 + i;
            triangles[3 + i * 6] = 1 + i;
            triangles[4 + i * 6] = 13 + i;
            triangles[5 + i * 6] = 14 + i;
        }





        for (int i = 0; i < 13; i++)
        {
            triangles[0 + i * 6 + 6 * 14] = 0 + i + 26;
            triangles[1 + i * 6 + 6 * 14] = 1 + i + 26;
            triangles[2 + i * 6 + 6 * 14] = 13 + i + 26;
            triangles[3 + i * 6 + 6 * 14] = 1 + i + 26;
            triangles[4 + i * 6 + 6 * 14] = 14 + i + 26;
            triangles[5 + i * 6 + 6 * 14] = 13 + i + 26;
        }


        for (int i = 0; i < 13; i++)
        {
            triangles[0 + i * 6 + 6 * 28] = 1 + i + 26 * 2;
            triangles[1 + i * 6 + 6 * 28] = 0 + i + 26 * 2;
            triangles[2 + i * 6 + 6 * 28] = 13 + i + 26 * 2;
            triangles[3 + i * 6 + 6 * 28] = 1 + i + 26 * 2;
            triangles[4 + i * 6 + 6 * 28] = 13 + i + 26 * 2;
            triangles[5 + i * 6 + 6 * 28] = 14 + i + 26 * 2;
        }


        for (int i = 0; i < 13 * 8; i++)
        {
            uvs[i] = new Vector2(vertices[i].z, vertices[i].y);
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



    public static float twoDDistance(float x, float y)
    {
        return Mathf.Sqrt(x * x + y * y);
    }


}
