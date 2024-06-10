using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh28 : MonoBehaviour
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

        vertices = new Vector3[28];
        triangles = new int[42];
        uvs = new Vector2[28];
        float meshScale = 4f;


        vertices[0] = new Vector3(-0.875f -0.025f, -0.1566955f, -1.75f);
        vertices[1] = new Vector3(-0.875f + 0.1875f, -0.1566955f, -1.75f);
        vertices[2] = new Vector3(-0.875f - 0.025f, -0.1566955f + 0.25f, -1.75f);
        vertices[3] = new Vector3(-0.875f + 0.1875f, -0.1566955f + 0.25f, -1.75f);

        vertices[4] = new Vector3(-0.875f - 0.025f, -0.1566955f + 0.25f, -1.75f);
        vertices[5] = new Vector3(-0.875f + 0.1875f, -0.1566955f + 0.25f, -1.75f);
        vertices[6] = new Vector3(-0.875f - 0.025f, -0.1566955f + 0.25f, -3f);
        vertices[7] = new Vector3(-0.875f + 0.1875f, -0.1566955f + 0.25f, -3f);

        vertices[8] = new Vector3(0.40625f + 0.025f, -0.1566955f, -1.75f);
        vertices[9] = new Vector3(0.40625f - 0.1875f, -0.1566955f, -1.75f);
        vertices[10] = new Vector3(0.40625f + 0.025f, -0.1566955f + 0.25f, -1.75f);
        vertices[11] = new Vector3(0.40625f - 0.1875f, -0.1566955f + 0.25f, -1.75f);

        vertices[12] = new Vector3(0.40625f + 0.025f, -0.1566955f + 0.25f, -1.75f);
        vertices[13] = new Vector3(0.40625f - 0.1875f, -0.1566955f + 0.25f, -1.75f);
        vertices[14] = new Vector3(0.40625f + 0.025f, -0.1566955f + 0.25f, -3f);
        vertices[15] = new Vector3(0.40625f - 0.1875f, -0.1566955f + 0.25f, -3f);


        vertices[16] = new Vector3(0.40625f - 0.1875f, -0.1566955f + 0.25f, -3f);
        vertices[17] = new Vector3(-0.875f + 0.1875f, -0.1566955f + 0.25f, -3f);
        vertices[18] = new Vector3(0.40625f - 0.1875f, -0.1566955f + 0.25f, -2.25f);
        vertices[19] = new Vector3(-0.875f + 0.1875f, -0.1566955f + 0.25f, -2.25f);


        vertices[20] = new Vector3(-0.875f + 0.1875f, -0.1566955f, -1.75f);
        vertices[21] = new Vector3(-0.875f + 0.1875f, -0.1566955f + 0.25f, -1.75f);
        vertices[22] = new Vector3(-0.875f + 0.1875f, -0.1566955f, -2.25f);
        vertices[23] = new Vector3(-0.875f + 0.1875f, -0.1566955f + 0.25f, -2.25f);

        vertices[24] = new Vector3(0.40625f - 0.1875f, -0.1566955f, -1.75f);
        vertices[25] = new Vector3(0.40625f - 0.1875f, -0.1566955f + 0.25f, -1.75f);
        vertices[26] = new Vector3(0.40625f - 0.1875f, -0.1566955f, -2.25f);
        vertices[27] = new Vector3(0.40625f  - 0.1875f, -0.1566955f + 0.25f, -2.25f);


        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        triangles[6] = 4;
        triangles[7] = 5;
        triangles[8] = 6;

        triangles[9] = 5;
        triangles[10] = 7;
        triangles[11] = 6;


        triangles[12] = 9;
        triangles[13] = 8;
        triangles[14] = 10;

        triangles[15] = 9;
        triangles[16] = 10;
        triangles[17] = 11;


        triangles[18] = 13;
        triangles[19] = 12;
        triangles[20] = 14;

        triangles[21] = 13;
        triangles[22] = 14;
        triangles[23] = 15;



        triangles[24] = 16;
        triangles[25] = 17;
        triangles[26] = 18;

        triangles[27] = 18;
        triangles[28] = 17;
        triangles[29] = 19;


        triangles[30] = 21;
        triangles[31] = 20;
        triangles[32] = 22;

        triangles[33] = 21;
        triangles[34] = 22;
        triangles[35] = 23;


        triangles[36] = 24;
        triangles[37] = 25;
        triangles[38] = 26;

        triangles[39] = 26;
        triangles[40] = 25;
        triangles[41] = 27;



        uvs[0] = new Vector2(vertices[0].x, vertices[0].y);
        uvs[1] = new Vector2(vertices[1].x, vertices[1].y);
        uvs[2] = new Vector2(vertices[2].x, vertices[2].y);
        uvs[3] = new Vector2(vertices[3].x, vertices[3].y);

        uvs[4] = new Vector2(vertices[4].x, vertices[4].z);
        uvs[5] = new Vector2(vertices[5].x, vertices[5].z);
        uvs[6] = new Vector2(vertices[6].x, vertices[6].z);
        uvs[7] = new Vector2(vertices[7].x, vertices[7].z);

        uvs[8] = new Vector2(vertices[8].x, vertices[8].y);
        uvs[9] = new Vector2(vertices[9].x, vertices[9].y);
        uvs[10] = new Vector2(vertices[10].x, vertices[10].y);
        uvs[11] = new Vector2(vertices[11].x, vertices[11].y);

        uvs[12] = new Vector2(vertices[12].x, vertices[12].z);
        uvs[13] = new Vector2(vertices[13].x, vertices[13].z);
        uvs[14] = new Vector2(vertices[14].x, vertices[14].z);
        uvs[15] = new Vector2(vertices[15].x, vertices[15].z);

        uvs[16] = new Vector2(vertices[16].x, vertices[16].z);
        uvs[17] = new Vector2(vertices[17].x, vertices[17].z);
        uvs[18] = new Vector2(vertices[18].x, vertices[18].z);
        uvs[19] = new Vector2(vertices[19].x, vertices[19].z);

        uvs[20] = new Vector2(vertices[20].y, vertices[20].z);
        uvs[21] = new Vector2(vertices[21].y, vertices[21].z);
        uvs[22] = new Vector2(vertices[22].y, vertices[22].z);
        uvs[23] = new Vector2(vertices[23].y, vertices[23].z);

        uvs[24] = new Vector2(vertices[24].y, vertices[24].z);
        uvs[25] = new Vector2(vertices[25].y, vertices[25].z);
        uvs[26] = new Vector2(vertices[26].y, vertices[26].z);
        uvs[27] = new Vector2(vertices[27].y, vertices[27].z);


        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].x = vertices[i].x - 0.025f;
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
