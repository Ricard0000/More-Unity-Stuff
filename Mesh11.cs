using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMainArch : MonoBehaviour
{


    //Define public variables
    public float Pos1;//Object position
    public float Pos2;//Object position
    public float Pos3;//Object position

    public float c1 = 1.25f;//x-direction
    public float c2 = 1.5f;//y-direction
    public float c3 = 0.75f;//z-direction
    public float c4 = -1f;//from the start of the arch and downwards.
    public float s = 0.5f;//Thickness of sides
    public float t = 0.5f;//Thickness of Top of arch
    public float req_dist = 40f;

    //Define parameters needed to create object
    const float PI = 3.1415926535897931f;
    const int N = 10;
    float delta_theta = (PI / 2) / N;
    public int rot = 0;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot);
    }


    public static Vector3 Arch_eq_6_A(float x, float z, float c1, float c2, float angle)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;

        float temp = x;
        x = x * Mathf.Cos(angle) - z * Mathf.Sin(angle);
        z = temp * Mathf.Sin(angle) + z * Mathf.Cos(angle);
        return new Vector3(x, y, z);
    }

    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, float c1, float c2, float c3, float c4, float s, float t, float delta_theta, int N, bool collider, Material mat, int rot)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;


        Mesh m = new Mesh();

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

        vertices = new Vector3[12];
        triangles = new int[24];
        uvs = new Vector2[12];
        float meshScale = 4f;


        vertices[0] = new Vector3(-1.5f, 0.004008672f, -0.0625f);
        vertices[1] = new Vector3(-1.5f, 0.004008672f, 0.03125f);
        vertices[2] = new Vector3(-1.25f, 0.004008672f, 0.03125f);
        vertices[3] = new Vector3(-0.78f, 0.003613972f, -0.2395833f);
        vertices[4] = new Vector3(-0.78f, 0.003613972f, -0.4270833f);
        vertices[5] = new Vector3(-0.90625f, 0.003693585f, -0.4270833f);
        vertices[6] = new Vector3(1.5f, 0.004008672f, -0.0625f);
        vertices[7] = new Vector3(1.5f, 0.004008672f, 0.03125f);
        vertices[8] = new Vector3(1.25f, 0.004008672f, 0.03125f);
        vertices[9] = new Vector3(0.78f, 0.003613972f, -0.2395833f);
        vertices[10] = new Vector3(0.78f, 0.003613972f, -0.4270833f);
        vertices[11] = new Vector3(0.90625f, 0.003693585f, -0.4270833f);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 5;
        triangles[6] = 5;
        triangles[7] = 2;
        triangles[8] = 3;
        triangles[9] = 5;
        triangles[10] = 3;
        triangles[11] = 4;
        triangles[12] = 7;
        triangles[13] = 6;
        triangles[14] = 8;
        triangles[15] = 8;
        triangles[16] = 6;
        triangles[17] = 11;
        triangles[18] = 11;
        triangles[19] = 9;
        triangles[20] = 8;
        triangles[21] = 10;
        triangles[22] = 9;
        triangles[23] = 11;



        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
        }

        for (int i = 0; i < 12; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }

        /*
        uvs[0] = new Vector2(0f, 0.25f);
        uvs[1] = new Vector2(0f, 0f);
        uvs[2] = new Vector2(0.25f, 0f);
        uvs[3] = new Vector2(1f, 0.75f);
        uvs[4] = new Vector2(1f, 1f);
        uvs[5] = new Vector2(0.75f, 1f);
        uvs[6] = new Vector2(0f, 0.25f);
        uvs[7] = new Vector2(0f, 0f);
        uvs[8] = new Vector2(0.25f, 0f);
        uvs[9] = new Vector2(1f, 0.75f);
        uvs[10] = new Vector2(1f, 1f);
        uvs[11] = new Vector2(0.75f, 1f);
*/

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



/*
Length
Out[8]: 0.8361311504699118

dz
Out[9]: 0.0625

c1
Out[10]: 1.25

*/