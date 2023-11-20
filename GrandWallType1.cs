using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandWallType1 : MonoBehaviour
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
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, true, mat,rot);
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
        vertices = new Vector3[18*(2 * N + 1)];
        triangles = new int[3*(2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1)];
        uvs = new Vector2[18*(2 * N + 1)];


        float angle1 = -45f / 180f * PI;


        float angle = rot * angle1;
        float x;
        float z;
        float dz = 0.0625f;

        int itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz;
            vertices[i] = Arch_eq_6_A(x, z, c1, c2, angle) + POS;
        }
        
        itsize1 = 2 * N + 1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, c1, c2, angle) + POS;
        }
        

        // First Top arch part
        
        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.9f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.9f * c1, 0.9f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.9f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.9f * c1, 0.9f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.87f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz * 0.33333333f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.87f * c1, 0.87f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.8625f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.8625f * c1, 0.8625f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.85f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.85f * c1, 0.85f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.8375f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz*0.66666666f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.8375f * c1, 0.8375f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.8f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.8f * c1, 0.8f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.8f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - 0.5f * dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.8f * c1, 0.8f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.775f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - 0.75f * dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.775f * c1, 0.775f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.75f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz*0.3333333f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.75f * c1, 0.75f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.725f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.725f * c1, 0.725f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.7125f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.6666666f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.7125f * c1, 0.7125f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.6666666f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.6875f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.6875f * c1, 0.6875f * c2, angle) + POS;
        }

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.6625f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS;
        }


        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.6625f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz*2f;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS;
        }



        // First Top arch part (Right Side)
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3] = i + 0;
            triangles[i3 + 1] = 2 * N + 0 + i + 1;
            triangles[i3 + 2] = i + 1;
        }
        
        
        int skip = 3 * (2 * N + 0);
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = i + 1;
            triangles[i3 + 1 + skip] = 2 * N + i + 1;
            triangles[i3 + 2 + skip] = 2 * N + i + 2;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 2 * N + i + 2;
            triangles[i3 + 1 + skip] = 2 * N + i + 1;
            triangles[i3 + 2 + skip] = 4 * N + i + 2;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 2 * N + i + 2;
            triangles[i3 + 1 + skip] = 4 * N + i + 2;
            triangles[i3 + 2 + skip] = 4 * N + i + 3;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 4 * N + i + 3;
            triangles[i3 + 1 + skip] = 4 * N + i + 2;
            triangles[i3 + 2 + skip] = 6 * N + i + 3;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 4 * N + i + 3;
            triangles[i3 + 1 + skip] = 6 * N + i + 3;
            triangles[i3 + 2 + skip] = 6 * N + i + 4;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 6 * N + i + 4;
            triangles[i3 + 1 + skip] = 6 * N + i + 3;
            triangles[i3 + 2 + skip] = 8 * N + i + 4;
        }
        
        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 6 * N + i + 4;
            triangles[i3 + 1 + skip] = 8 * N + i + 4;
            triangles[i3 + 2 + skip] = 8 * N + i + 5;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 8 * N + i + 5;
            triangles[i3 + 1 + skip] = 8 * N + i + 4;
            triangles[i3 + 2 + skip] = 10 * N + i + 5;
        }

        
        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 8 * N + i + 5;
            triangles[i3 + 1 + skip] = 10 * N + i + 5;
            triangles[i3 + 2 + skip] = 10 * N + i + 6;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 10 * N + i + 6;
            triangles[i3 + 1 + skip] = 10 * N + i + 5;
            triangles[i3 + 2 + skip] = 12 * N + i + 6;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 10 * N + i + 6;
            triangles[i3 + 1 + skip] = 12 * N + i + 6;
            triangles[i3 + 2 + skip] = 12 * N + i + 7;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 12 * N + i + 7;
            triangles[i3 + 1 + skip] = 12 * N + i + 6;
            triangles[i3 + 2 + skip] = 14 * N + i + 7;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 12 * N + i + 7;
            triangles[i3 + 1 + skip] = 14 * N + i + 7;
            triangles[i3 + 2 + skip] = 14 * N + i + 8;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 14 * N + i + 8;
            triangles[i3 + 1 + skip] = 14 * N + i + 7;
            triangles[i3 + 2 + skip] = 16 * N + i + 8;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 14 * N + i + 8;
            triangles[i3 + 1 + skip] = 16 * N + i + 8;
            triangles[i3 + 2 + skip] = 16 * N + i + 9;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 16 * N + i + 9;
            triangles[i3 + 1 + skip] = 16 * N + i + 8;
            triangles[i3 + 2 + skip] = 18 * N + i + 9;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 16 * N + i + 9;
            triangles[i3 + 1 + skip] = 18 * N + i + 9;
            triangles[i3 + 2 + skip] = 18 * N + i + 10;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 18 * N + i + 10;
            triangles[i3 + 1 + skip] = 18 * N + i + 9;
            triangles[i3 + 2 + skip] = 20 * N + i + 10;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 18 * N + i + 10;
            triangles[i3 + 1 + skip] = 20 * N + i + 10;
            triangles[i3 + 2 + skip] = 20 * N + i + 11;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 20 * N + i + 11;
            triangles[i3 + 1 + skip] = 20 * N + i + 10;
            triangles[i3 + 2 + skip] = 22 * N + i + 11;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 20 * N + i + 11;
            triangles[i3 + 1 + skip] = 22 * N + i + 11;
            triangles[i3 + 2 + skip] = 22 * N + i + 12;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 22 * N + i + 12;
            triangles[i3 + 1 + skip] = 22 * N + i + 11;
            triangles[i3 + 2 + skip] = 24 * N + i + 12;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 22 * N + i + 12;
            triangles[i3 + 1 + skip] = 24 * N + i + 12;
            triangles[i3 + 2 + skip] = 24 * N + i + 13;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 24 * N + i + 13;
            triangles[i3 + 1 + skip] = 24 * N + i + 12;
            triangles[i3 + 2 + skip] = 26 * N + i + 13;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 24 * N + i + 13;
            triangles[i3 + 1 + skip] = 26 * N + i + 13;
            triangles[i3 + 2 + skip] = 26 * N + i + 14;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 26 * N + i + 14;
            triangles[i3 + 1 + skip] = 26 * N + i + 13;
            triangles[i3 + 2 + skip] = 28 * N + i + 14;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 26 * N + i + 14;
            triangles[i3 + 1 + skip] = 28 * N + i + 14;
            triangles[i3 + 2 + skip] = 28 * N + i + 15;
        }


        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 28 * N + i + 15;
            triangles[i3 + 1 + skip] = 28 * N + i + 14;
            triangles[i3 + 2 + skip] = 30 * N + i + 15;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 28 * N + i + 15;
            triangles[i3 + 1 + skip] = 30 * N + i + 15;
            triangles[i3 + 2 + skip] = 30 * N + i + 16;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 30 * N + i + 16;
            triangles[i3 + 1 + skip] = 30 * N + i + 15;
            triangles[i3 + 2 + skip] = 32 * N + i + 16;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 30 * N + i + 16;
            triangles[i3 + 1 + skip] = 32 * N + i + 16;
            triangles[i3 + 2 + skip] = 32 * N + i + 17;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 32 * N + i + 17;
            triangles[i3 + 1 + skip] = 32 * N + i + 16;
            triangles[i3 + 2 + skip] = 34 * N + i + 17;
        }

        skip = 3 * (2 * N) + skip;
        for (int i = 0; i < 2 * N + 0; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 32 * N + i + 17;
            triangles[i3 + 1 + skip] = 34 * N + i + 17;
            triangles[i3 + 2 + skip] = 34 * N + i + 18;
        }



        float Length = dz + .1f * c1 + dz + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
            + 0.0125f* c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
            + 0.5f* dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.583333f, 2) + Mathf.Pow(0.025f * c1, 2))
            + 0.05f*c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + 0.0125f* c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2))
            + 0.025f*c1 + 2f*dz;

        
        for (int i = 0; i < 2 * N + 1; i++)
        {
//            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float) i / (2 * N + 1);
            uvs[i] = new Vector2(x, 0f);
        }
        
        int uvskip = 2 * N + 1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
//            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, dz / Length);
        }
        uvskip = 2 * N + 1 + uvskip;

        for (int i = 0; i < 2 * N + 1; i++)
        {
//            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + .1f * c1) / Length);
        }
        uvskip = 2 * N + 1 + uvskip;

        for (int i = 0; i < 2 * N + 1; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + .1f * c1 + dz) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
//            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2))) / Length);
        }
        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
//            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))) / Length);
        }
        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
//            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
//            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2))) / Length);
        }
        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
//            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
              + 0.5f * dz) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
              + 0.5f * dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2))) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
              + 0.5f * dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.583333f, 2) + Mathf.Pow(0.025f * c1, 2))) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
              + 0.5f * dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.583333f, 2) + Mathf.Pow(0.025f * c1, 2))
              + 0.05f * c1) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
              + 0.5f * dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.583333f, 2) + Mathf.Pow(0.025f * c1, 2))
              + 0.05f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2))) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
              + 0.5f * dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.583333f, 2) + Mathf.Pow(0.025f * c1, 2))
              + 0.05f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + 0.0125f * c1) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
              + 0.5f * dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.583333f, 2) + Mathf.Pow(0.025f * c1, 2))
              + 0.05f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2))) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, (dz + dz + .1f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
              + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
              + 0.5f * dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.583333f, 2) + Mathf.Pow(0.025f * c1, 2))
              + 0.05f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2))
              + 0.025f * c1) / Length);
        }

        uvskip = 2 * N + 1 + uvskip;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1f) * 0.5f;
            x = (float)i / (2 * N + 1);
            uvs[i + uvskip] = new Vector2(x, 1f);
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