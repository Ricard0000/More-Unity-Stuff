using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandWallType30 : MonoBehaviour
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
        vertices = new Vector3[23];
        triangles = new int[63];
        uvs = new Vector2[23];
        float meshScale = 4f;

        float angle1 = -45f / 180f * PI;
        float x;
        float z;
        float angle = rot * angle1;
        float someFactor = 0.0125f;
        float dz = 0.0625f;
        /*
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = (1.25f + someFactor * 13f) * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz;
            vertices[i] = Arch_eq_6_A(x, z, (1.25f + someFactor * 13f), (1.5f + someFactor * 13f * 1.2f), angle) + POS;

        }
        */
        vertices[0] = new Vector3(-1.4125f, -0.09574088f, -0.0625f);
        vertices[1] = new Vector3(-1.39511f, 0.1346007f, -0.0625f);
        vertices[2] = new Vector3(-1.343367f, 0.3651084f, -0.0625f);
        vertices[3] = new Vector3(-1.258547f, 0.5876392f, -0.0625f);
        vertices[4] = new Vector3(-1.142737f, 0.7984059f, -0.0625f);
        vertices[5] = new Vector3(-0.9987883f, 0.9938886f, -0.0625f);
        vertices[6] = new Vector3(-0.8302466f, 1.170903f, -0.0625f);
        vertices[7] = new Vector3(-0.6412618f, 1.326666f, -0.0625f);
        vertices[8] = new Vector3(-0.4364866f, 1.458861f, -0.0625f);
        vertices[9] = new Vector3(-0.2209637f, 1.565674f, -0.0625f);
        vertices[10] = new Vector3(-6.174233E-08f, 1.64584f, -0.0625f);
        vertices[11] = new Vector3(0.2209636f, 1.565674f, -0.0625f);
        vertices[12] = new Vector3(0.4364865f, 1.458861f, -0.0625f);
        vertices[13] = new Vector3(0.6412616f, 1.326667f, -0.0625f);
        vertices[14] = new Vector3(0.8302467f, 1.170903f, -0.0625f);
        vertices[15] = new Vector3(0.9987883f, 0.9938886f, -0.0625f);
        vertices[16] = new Vector3(1.142737f, 0.7984059f, -0.0625f);
        vertices[17] = new Vector3(1.258547f, 0.5876395f, -0.0625f);
        vertices[18] = new Vector3(1.343367f, 0.3651088f, -0.0625f);
        vertices[19] = new Vector3(1.39511f, 0.1346007f, -0.0625f);
        vertices[20] = new Vector3(1.4125f, -0.09574088f, -0.0625f);

        vertices[21] = vertices[0] + new Vector3(0f, 1.64584f + 0.09574088f, 0f);
        vertices[22] = vertices[20] + new Vector3(0f, 1.64584f + 0.09574088f, 0f);


        triangles[0] = 2 * N + 1;
        triangles[1] = 0;
        triangles[2] = 1;
        triangles[3] = 2 * N + 1;
        triangles[4] = 1;
        triangles[5] = 2;
        triangles[6] = 2 * N + 1;
        triangles[7] = 2;
        triangles[8] = 3;
        triangles[9] = 2 * N + 1;
        triangles[10] = 3;
        triangles[11] = 4;
        triangles[12] = 2 * N + 1;
        triangles[13] = 4;
        triangles[14] = 5;
        triangles[15] = 2 * N + 1;
        triangles[16] = 5;
        triangles[17] = 6;
        triangles[18] = 2 * N + 1;
        triangles[19] = 6;
        triangles[20] = 7;
        triangles[21] = 2 * N + 1;
        triangles[22] = 7;
        triangles[23] = 8;
        triangles[24] = 2 * N + 1;
        triangles[25] = 8;
        triangles[26] = 9;
        triangles[27] = 2 * N + 1;
        triangles[28] = 9;
        triangles[29] = 10;


        triangles[30] = 22;
        triangles[31] = 19;
        triangles[32] = 20;
        triangles[33] = 22;
        triangles[34] = 18;
        triangles[35] = 19;
        triangles[36] = 22;
        triangles[37] = 17;
        triangles[38] = 18;

        triangles[39] = 22;
        triangles[40] = 16;
        triangles[41] = 17;

        triangles[42] = 22;
        triangles[43] = 15;
        triangles[44] = 16;

        triangles[45] = 22;
        triangles[46] = 14;
        triangles[47] = 15;

        triangles[48] = 22;
        triangles[49] = 14;
        triangles[50] = 15;

        triangles[51] = 22;
        triangles[52] = 13;
        triangles[53] = 14;

        triangles[54] = 22;
        triangles[55] = 12;
        triangles[56] = 13;

        triangles[57] = 22;
        triangles[58] = 11;
        triangles[59] = 12;

        triangles[60] = 22;
        triangles[61] = 10;
        triangles[62] = 11;

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



/*
Length
Out[8]: 0.8361311504699118

dz
Out[9]: 0.0625

c1
Out[10]: 1.25

*/