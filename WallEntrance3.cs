using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEntrance3 : MonoBehaviour
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

    const int Nrot = 10;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot, Nrot);
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

    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, float c1, float c2, float c3, float c4, float s, float t, float delta_theta, int N, bool collider, Material mat, int rot, int Nrot)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;


        Mesh m = new Mesh();

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

        vertices = new Vector3[(2 * N + 1) + 26];
        triangles = new int[3 * (2 * N - 6) + 3 + 30 + 9 + 15];
        uvs = new Vector2[(2 * N + 1) + 26];


        float angle1 = -45f / 180f * PI;


        float angle = rot * angle1;
        float x;
        float y;
        float z;
        float dz = 0.0625f;

        vertices[0] = new Vector3(.50625f,.5380546f,-.9270834f) + new Vector3(0f, 0.2375f, 0f);
        uvs[0] = new Vector2(vertices[0].y, vertices[0].z);

        vertices[1] = new Vector3(.50625f, -.22169550f, -.9270834f) + new Vector3(0f, -.060f, 0f);
        uvs[1] = new Vector2(vertices[1].y, vertices[1].z);

        vertices[2] = new Vector3(.50625f, .1581796f, -.9270834f);
        uvs[2] = new Vector2(vertices[2].y, vertices[2].z);

        vertices[3] = new Vector3(.50625f, -.22169550f, -.9270834f) + new Vector3(0.375f - 0.015625f,0f,0.375f + 0.015625f*8f) + new Vector3(0f, -.060f, 0f);
        uvs[3] = new Vector2(vertices[3].y, vertices[3].z);

        vertices[4] = new Vector3(.50625f, .1581796f, -.9270834f) + new Vector3(0.375f - 0.015625f, 0f, 0.375f + 0.015625f * 8f);
        uvs[4] = new Vector2(vertices[4].y, vertices[4].z);

        vertices[5] = new Vector3(.50625f, .5380546f, -.9270834f) + new Vector3(0.375f - 0.015625f, 0.2375f, 0.375f + 0.015625f * 8f);
        uvs[5] = new Vector2(vertices[5].y, vertices[5].z);

        vertices[6] = 0.5f * vertices[5] + 0.5f * vertices[0];
        uvs[6] = new Vector2(vertices[6].y, vertices[6].z);

        vertices[7] = 0.5f * vertices[4] + 0.5f * vertices[2];
        uvs[7] = new Vector2(vertices[7].y, vertices[7].z);


        vertices[8] = 0.2f * vertices[5] + 0.8f * vertices[0];
        uvs[8] = new Vector2(vertices[8].y, vertices[8].z);

        vertices[9] = 0.2f * vertices[4] + 0.8f * vertices[2];
        uvs[9] = new Vector2(vertices[9].y, vertices[9].z);

        vertices[10] = 0.55f * vertices[6] + 0.45f * vertices[7];
        uvs[10] = new Vector2(vertices[10].y, vertices[10].z);

        vertices[11] = 0.55f * vertices[8] + 0.45f * vertices[9];
        uvs[11] = new Vector2(vertices[11].y, vertices[11].z);

        Vector3 aTemp = vertices[6] - vertices[8];
        float radius = aTemp.magnitude * 0.5f;


        /* Dead code
        for(int i = 0; i < Nrot; i++)
        {
            t = PI / (Nrot - 1f) * (i - 1f);
            x = Mathf.Cos(t);
            y = Mathf.Sin(t);
            z = 0f;
        }
        */


        // Do rotation:


        triangles[0] = 1;
        triangles[1] = 3;
        triangles[2] = 2;

        triangles[3] = 4;
        triangles[4] = 2;
        triangles[5] = 3;

        triangles[6] = 0;
        triangles[7] = 2;
        triangles[8] = 9;

        triangles[9] = 0;
        triangles[10] = 9;
        triangles[11] = 8;


        triangles[12] = 6;
        triangles[13] = 7;
        triangles[14] = 4;

        triangles[15] = 6;
        triangles[16] = 4;
        triangles[17] = 5;

        triangles[18] = 6;
        triangles[19] = 8;
        triangles[20] = 10;
        
        triangles[21] = 8;
        triangles[22] = 11;
        triangles[23] = 10;


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


