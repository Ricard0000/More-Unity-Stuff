using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopStairs : MonoBehaviour
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

        vertices = new Vector3[N + 1];
        triangles = new int[3 * N];
        uvs = new Vector2[N + 1];

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
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }
        
        int skip = N;
        Vector3 temp;
        temp = new Vector3(0f, -4f * dz, 1.75f * c1 / 6f);

        vertices[skip + 0] =  temp + POS + new Vector3(0f, -dz * 0.5f, -4.33333f * dz - 9f * dz + moveForward);
        uvs[skip + 0] = new Vector2(vertices[skip + 0].x, vertices[skip + 0].z);

        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3] = i + 1;
            triangles[i3 + 1] = N;
            triangles[i3 + 2] = i;
        }





/*
        for (int i = 0; i < N; i++)
        {
            x = (float)i / (N - 1f);
            uvs[i] = new Vector2(x, 0f);
        }
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


