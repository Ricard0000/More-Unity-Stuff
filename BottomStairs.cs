using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomStairs : MonoBehaviour
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
    const int N = 15;
    float delta_theta = (PI) / (N - 1);
    public int rot = 0;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot);
    }

    public static Vector3 Stair_eq(float x, float y, float c1, float c2)
    {
        float z;
        z = c2 / 2f * Mathf.Sqrt(1f - (x / (c1 * 1.0001f)) * (x / (c1 * 1.0001f))) + c1 / 6f;
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

        vertices = new Vector3[16 * N];
        triangles = new int[90 * N];
        uvs = new Vector2[16 * N];

        float x;
        float y;
        float dz = 0.0625f;

        float moveForward = 0.6625f * dz;
        float f = 0.6875f;


        for (int i = 0; i < N; i++)
        {
            x = (0.6625f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i] = Stair_eq(x, y, (0.6625f + dz) * c1, (0.6625f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f, -4.33333f * dz - 9f * dz + moveForward);
        }
       
        int skip = N;
        for (int i = 0; i < N; i++)
        {
            x = (0.6625f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (0.6625f + dz) * c1, (0.6625f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f, -4.33333f * dz - 9f * dz + moveForward);
        }

        skip = N + skip;

        f = 0.55f;
        for (int i = 0; i < N; i++)
        {
            x = (0.775f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (0.775f + dz) * c1, (0.775f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f, -4.33333f * dz - 9f * dz + moveForward);
        }

        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (0.775f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (0.775f + dz) * c1, (0.775f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 2f, -4.33333f * dz - 9f * dz + moveForward);
        }

        f = 0.55f;
        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (0.9f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (0.9f + dz) * c1, (0.9f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 2f, -4.33333f * dz - 9f * dz + moveForward);
        }


        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (0.9f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (0.9f + dz) * c1, (0.9f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 3f, -4.33333f * dz - 9f * dz + moveForward);
        }

        f = 0.55f;
        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (1.025f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (1.025f + dz) * c1, (1.125f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 3f, -4.33333f * dz - 9f * dz + moveForward);
        }

        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (1.025f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (1.025f + dz) * c1, (1.125f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 4f, -4.33333f * dz - 9f * dz + moveForward);
        }

        f = 0.65f;
        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (1.15f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (1.15f + dz) * c1, (1.35f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 4f, -4.33333f * dz - 9f * dz + moveForward);
        }

        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (1.15f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (1.15f + dz) * c1, (1.35f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 5f, -4.33333f * dz - 9f * dz + moveForward);
        }


        f = .7625f;
        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (1.3f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (1.3f + dz) * c1, (1.85f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 5f, -4.33333f * dz - 9f * dz + moveForward);
        }




        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (1.3f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (1.3f + dz) * c1, (1.85f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 6f, -4.33333f * dz - 9f * dz + moveForward);
        }




        f = .82125f;

        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (1.5f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (1.5f + dz) * c1, (2.25f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 6f, -4.33333f * dz - 9f * dz + moveForward);
        }

        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (1.5f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (1.5f + dz) * c1, (2.25f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 7f, -4.33333f * dz - 9f * dz + moveForward);
        }

        f = .8725f;

        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (1.75f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (1.75f + dz) * c1, (2.75f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 7f, -4.33333f * dz - 9f * dz + moveForward);
        }

        skip = N + skip;
        for (int i = 0; i < N; i++)
        {
            x = (1.75f + dz) * c1 * Mathf.Cos((PI * f + (PI - PI * f) * 0.5f - i * delta_theta * f));
            y = -4f * dz;
            vertices[i + skip] = Stair_eq(x, y, (1.75f + dz) * c1, (2.75f + dz) * c1) + POS + new Vector3(0f, -dz * 0.5f - dz * 0.625f * 8f, -4.33333f * dz - 9f * dz + moveForward);
        }


        for (int i = 0; i < N-1; i++)
        {
            int i3 = 3 * i;
            triangles[i3] = i + 0;
            triangles[i3 + 1] = N + i;
            triangles[i3 + 2] = i + 1;
        }
        int triSkip = 3 * N;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = i + 1;
            triangles[i3 + 1 + triSkip] = N + i;
            triangles[i3 + 2 + triSkip] = N + i + 1;
        }
       
        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 1 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 1 * N + N + i;
            triangles[i3 + 2 + triSkip] = 1 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 1 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 1 * N + N + i;
            triangles[i3 + 2 + triSkip] = 1 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 2 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 2 * N + N + i;
            triangles[i3 + 2 + triSkip] = 2 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 2 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 2 * N + N + i;
            triangles[i3 + 2 + triSkip] = 2 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 3 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 3 * N + N + i;
            triangles[i3 + 2 + triSkip] = 3 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 3 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 3 * N + N + i;
            triangles[i3 + 2 + triSkip] = 3 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 4 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 4 * N + N + i;
            triangles[i3 + 2 + triSkip] = 4 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 4 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 4 * N + N + i;
            triangles[i3 + 2 + triSkip] = 4 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 5 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 5 * N + N + i;
            triangles[i3 + 2 + triSkip] = 5 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 5 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 5 * N + N + i;
            triangles[i3 + 2 + triSkip] = 5 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 6 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 6 * N + N + i;
            triangles[i3 + 2 + triSkip] = 6 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 6 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 6 * N + N + i;
            triangles[i3 + 2 + triSkip] = 6 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 7 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 7 * N + N + i;
            triangles[i3 + 2 + triSkip] = 7 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 7 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 7 * N + N + i;
            triangles[i3 + 2 + triSkip] = 7 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 8 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 8 * N + N + i;
            triangles[i3 + 2 + triSkip] = 8 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 8 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 8 * N + N + i;
            triangles[i3 + 2 + triSkip] = 8 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 9 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 9 * N + N + i;
            triangles[i3 + 2 + triSkip] = 9 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 9 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 9 * N + N + i;
            triangles[i3 + 2 + triSkip] = 9 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 10 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 10 * N + N + i;
            triangles[i3 + 2 + triSkip] = 10 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 10 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 10 * N + N + i;
            triangles[i3 + 2 + triSkip] = 10 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 11 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 11 * N + N + i;
            triangles[i3 + 2 + triSkip] = 11 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 11 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 11 * N + N + i;
            triangles[i3 + 2 + triSkip] = 11 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 12 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 12 * N + N + i;
            triangles[i3 + 2 + triSkip] = 12 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 12 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 12 * N + N + i;
            triangles[i3 + 2 + triSkip] = 12 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 13 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 13 * N + N + i;
            triangles[i3 + 2 + triSkip] = 13 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 13 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 13 * N + N + i;
            triangles[i3 + 2 + triSkip] = 13 * N + N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 14 * N + i + 0;
            triangles[i3 + 1 + triSkip] = 14 * N + N + i;
            triangles[i3 + 2 + triSkip] = 14 * N + i + 1;
        }

        triSkip = 3 * N + triSkip;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = 14 * N + i + 1;
            triangles[i3 + 1 + triSkip] = 14 * N + N + i;
            triangles[i3 + 2 + triSkip] = 14 * N + N + i + 1;
        }


        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N-1f);
            uvs[i] = new Vector2(x, 0f);
        }
        int uvSkip = N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N-1f);
            uvs[i + uvSkip] = new Vector2(x, 0.04f);
        }
        f = 0.865f;
        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N-1f) * f + (1f-f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.12f);
        }
        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N-1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.16f);
        }



        f = 0.8825f;
        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N-1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.24f);
        }

        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.28f);
        }


        //Step 3
        f = 0.8655f;
        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.38f);
        }

        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.42f);
        }









        // Step 4
        f = 0.92755f;
        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.52f);
        }

        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.56f);
        }



        // Step 5
        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.77f);
        }


        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.81f);
        }




        // Step 6
        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.94f);
        }

        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 0.98f);
        }




        //Step 7

        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 1.14f);
        }

        uvSkip = uvSkip + N;
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f) * f + (1f - f) * 0.5f;
            uvs[i + uvSkip] = new Vector2(x, 1.18f);
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


