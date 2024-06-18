using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh40 : MonoBehaviour
{


    //Define public variables
    float c1 = 0.5f * (0.40625f + 0.925f);//x-direction
    float c2 = 0.875f;//y-direction
    float c3 = 0.75f;//z-direction
    float c4 = -1f;//from the start of the arch and downwards.
    float s = 0.5f;//Thickness of sides
    float t = 0.5f;//Thickness of Top of arch

    //Define parameters needed to create object
    const float PI = 3.1415926535897931f;
    const int N = 10;
    float delta_theta = (PI / 2) / N;
    public int rot = 0;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot);
    }


    public static Vector3 Arch_eq_6(float x, float z, float c1, float c2)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;
        return new Vector3(x, y, z);
    }

    public static Vector3 Arch_eq_6_1(float x, float z, float c1, float c2)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;
        return new Vector3(z, y, x);
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
    public static GameObject MakeDiscreteProceduralGrid(float c1, float c2, float c3, float c4, float s, float t, float delta_theta, int N, bool collider, Material mat, int rot)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Mesh m = new Mesh();

//        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;
        
        vertices = new Vector3[2 * (2 * N + 1) + 2 * (2 * N + 1 - 2)];
        triangles = new int[6 * (2 * N + 1) + 6 * (2 * N + 1 - 2)];
        uvs = new Vector2[2 * (2 * N + 1) + 2 * (2 * N + 1 - 2)];
        
        float meshScale = 4f;

        Vector3 Position = new Vector3(-1.05f, 2.0f, -11.0f);

        float angle1 = 0f;// -45f / 180f * PI;
        float x;
        float z;
        float angle = rot * angle1;





        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0f;
            vertices[i] = Arch_eq_6_A(x, z, c1, c2, angle);
        }
        int nextVert = 2 * N + 1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.25f + 0.125f;
            vertices[i + nextVert] = Arch_eq_6_A(x, z, c1, c2, angle);
        }

        nextVert = nextVert + 2 * N + 1;
        for (int i = 0; i < 2 * N + 1 - 2; i++)
        {
            x = c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0f;
            vertices[i + nextVert] = Arch_eq_6_A(x, z, c1, c2, angle);
        }





        nextVert = nextVert + 2 * N + 1 - 2;
        for (int i = 0; i < 2 * N + 1 - 2; i++)
        {
            x = c1 * Mathf.Cos(PI - i * delta_theta);
            z = -0.125f;
            vertices[i + nextVert] = Arch_eq_6_A(x, z, c1, c2, angle);
        }



        for (int i = 0; i < 2 * N; i++)
        {
            triangles[3 * i + 0] = 0 + i;
            triangles[3 * i + 1] = 1 + i;
            triangles[3 * i + 2] = 2 * N + 1 + i;
        }

        int nextTri = 3 * (2 * N + 1);
        for (int i = 0; i < 2 * N; i++)
        {
            triangles[3 * i + 0 + nextTri] = 1 + i;
            triangles[3 * i + 1 + nextTri] = 2 * N + 2 + i;
            triangles[3 * i + 2 + nextTri] = 2 * N + 1 + i;
        }
        nextTri = 3 * (2 * N + 1) + nextTri;
        for (int i = 0; i < 2 * N - 2; i++)
        {
            triangles[3 * i + 0 + nextTri] = 1 + i + 2 * (2 * N + 1);
            triangles[3 * i + 1 + nextTri] = 0 + i + 2 * (2 * N + 1);
            triangles[3 * i + 2 + nextTri] = 2 * N + 1 - 2 + i + 2 * (2 * N + 1);
        }
        nextTri = 3 * (2 * N + 1 - 2) + nextTri;
        for (int i = 0; i < 2 * N - 2; i++)
        {
            triangles[3 * i + 0 + nextTri] = 1 + i + 2 * (2 * N + 1);
            triangles[3 * i + 1 + nextTri] = 2 * N + 1 - 2 + i + 2 * (2 * N + 1);
            triangles[3 * i + 2 + nextTri] = 2 * N + 2 - 2 + i + 2 * (2 * N + 1);
        }









        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale + Position;
        }


        for (int i = 0; i < 2 * N + 1; i++)
        {
            uvs[i] = new Vector2(i/(float)(2*N), 0f);
            uvs[i + 2 * N + 1] = new Vector2(i / (float)(2 * N), 0.5f);
        }

        for (int i = 0; i < 2 * N + 1 - 2; i++)
        {
            uvs[i + 2 * (2 * N + 1)] = new Vector2(i / (float)(2 * N), 0f);
            uvs[i + 2 * N + 1 + 2 * (2 * N + 1) - 2] = new Vector2(i / (float)(2 * N), 0.5f);
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



/*
Length
Out[8]: 0.8361311504699118

dz
Out[9]: 0.0625

c1
Out[10]: 1.25

*/