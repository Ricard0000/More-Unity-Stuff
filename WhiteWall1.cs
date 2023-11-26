using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteWall1 : MonoBehaviour
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

    public static Vector3 Arch_eq_6_B(float x, float z, float c1, float c2, float angle)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;

        float temp = x;
        x = x * Mathf.Cos(-angle) - z * Mathf.Sin(-angle);
        z = temp * Mathf.Sin(-angle) + z * Mathf.Cos(-angle);
        return new Vector3(x, y, z);
    }

    public static Vector3 Arch_eq_6_C(float x, float z, float c1, float c2, float angle)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;

        float temp = x;
        x = x * Mathf.Cos(-2 * angle) - z * Mathf.Sin(-2 * angle);
        z = temp * Mathf.Sin(-2 * angle) + z * Mathf.Cos(-2 * angle);
        return new Vector3(x, y, z);
    }

    public static float Vert_Rot_x(float x, float z, float angle)
    {
        return x * Mathf.Cos(angle) - z * Mathf.Sin(angle);
    }

    public static float Vert_Rot_z(float x, float z, float angle)
    {
        return x * Mathf.Sin(angle) + z * Mathf.Cos(angle);
    }


    public static float uv_Arch_eq_6(float x)
    {
        float y;
        y = Mathf.Sqrt(1 - Mathf.Abs(x) / (1.0f + 0.00001f));
        y = y + Mathf.Sqrt(1 - Mathf.Abs((x) * (x)) / (1.0f + 0.00001f));
        y = y / 2.0f - 0.00001f;
        return y;
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
        /*
        vertices = new Vector3[3*(2 * N+1)];
        triangles = new int[12 * N+1000];
        uvs = new Vector2[3 * (2 * N + 1)];
        */
        vertices = new Vector3[2 * (2 * N + 1) + 4 * ( N / 2 + 1)];
        triangles = new int[3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1)];
        uvs = new Vector2[2 * (2 * N + 1) + 4 * (N / 2 + 1)];


        float angle1 = -45f / 180f * PI;


        float angle = rot * angle1;
        float x;
        float z;
        float dz = 0.0625f;

        int itsize1 = 0;

        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f;
            vertices[i] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS;
        }
        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f - 8*dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < N / 2 - 0; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f - 2f * dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS;
        }

        itsize1 = N / 2 + 1 + itsize1 - 0;
        for (int i = 0; i < N / 2 - 0; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f - 6f * dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS;
        }


        // First Top arch part (Right Side)
        for (int i = N / 2 - 1; i < 2 * N + 0; i++)
        {
            int i3 = 3 * (i - (N / 2 - 1));
            triangles[i3 ] = i + 0;
            triangles[i3 + 1] = 2 * N + 0 + i + 1;
            triangles[i3 + 2] = i + 1;
        }

        int skip = 3 * (2 * N - N / 2 + 1);
        for (int i = N / 2 - 1; i < 2 * N + 0; i++)
        {
            int i3 = 3 * (i - (N / 2 - 1));
            triangles[i3 + skip] = i + 1;
            triangles[i3 + 1 + skip] = 2 * N + i + 1;
            triangles[i3 + 2 + skip] = 2 * N + i + 2;
        }


        skip = 3 * (2 * N - N / 2 + 1) + skip;
        for (int i = 0; i < N / 2 - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = i + 0;
            triangles[i3 + 1 + skip] = 4 * N + i + 2;
            triangles[i3 + 2 + skip] = 4 * N + i + 3;
        }

        skip = 3 * ( N / 2 - 1) + skip;
        for (int i = 0; i < N / 2 - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = i + 1;
            triangles[i3 + 1 + skip] = i + 0;
            triangles[i3 + 2 + skip] = 4 * N + i + 3;
        }

        skip = 3 * ( N / 2 - 0) + skip;
        for (int i = 0; i < N / 2 - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 4 * N + N / 2 + N / 2 - 2 + i;
            triangles[i3 + 1 + skip] = 2 * N + i + 1;
            triangles[i3 + 2 + skip] = 2 * N + i + 2;
        }

        skip = 3 * (N / 2 - 0) + skip;
        for (int i = 0; i < N / 2 - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip]     = 4 * N + N / 2 + N / 2 - 2 + i + 1;
            triangles[i3 + 1 + skip] = 4 * N + N / 2 + N / 2 - 2 + i + 0;
            triangles[i3 + 2 + skip] = 2 * N + i + 2;
        }



        float Length = dz + .1f * c1 + dz + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
            + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
            + 0.5f * dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.583333f, 2) + Mathf.Pow(0.025f * c1, 2))
            + 0.05f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2))
            + 0.025f * c1 + 2f * dz;







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