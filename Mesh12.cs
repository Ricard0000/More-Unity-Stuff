using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchSideWall : MonoBehaviour
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

        vertices = new Vector3[24];
        triangles = new int[60];
        uvs = new Vector2[24];
        float meshScale = 4f;




        //Top Right side
        vertices[0] = new Vector3(-1.5f, 0.004008672f, -0.0625f);
        vertices[1] = new Vector3(-1.5f, 0.004008672f, 0.03125f);
        vertices[2] = new Vector3(-1.25f, 0.004008672f, 0.03125f);
        vertices[3] = new Vector3(-0.78f, 0.003613972f, -0.2395833f);
        vertices[4] = new Vector3(-0.78f, 0.003613972f, -0.4270833f);
        vertices[5] = new Vector3(-0.90625f, 0.003693585f, -0.4270833f);        

        // Other side Top
        vertices[6] = new Vector3(1.5f, 0.004008672f, -0.0625f);
        vertices[7] = new Vector3(1.5f, 0.004008672f, 0.03125f);
        vertices[8] = new Vector3(1.25f, 0.004008672f, 0.03125f);
        vertices[9] = new Vector3(0.78f, 0.003613972f, -0.2395833f);
        vertices[10] = new Vector3(0.78f, 0.003613972f, -0.4270833f);
        vertices[11] = new Vector3(0.90625f, 0.003693585f, -0.4270833f);


        // Bottom Right side
        vertices[12] = new Vector3(-1.5f, -0.6209913f, -0.0625f);
        vertices[13] = new Vector3(-1.5f, -0.6209913f, 0.03125f);
        vertices[14] = new Vector3(-1.25f, -0.6209913f, 0.03125f);
        vertices[15] = new Vector3(-0.78f, -0.6213861f, -0.2395833f);
        vertices[16] = new Vector3(-0.78f, -0.6213861f, -0.4270833f);
        vertices[17] = new Vector3(-0.90625f, -0.6213064f, -0.4270833f) + new Vector3(0f, 0f, -0.00125f);

        // Other side Bottom
        vertices[18] = new Vector3(1.5f, -0.6209913f, -0.0625f);
        vertices[19] = new Vector3(1.5f, -0.6209913f, 0.03125f);
        vertices[20] = new Vector3(1.25f, -0.6209913f, 0.03125f);
        vertices[21] = new Vector3(0.78f, -0.6213861f, -0.2395833f);
        vertices[22] = new Vector3(0.78f, -0.6213861f, -0.4270833f);
        vertices[23] = new Vector3(0.90625f, -0.6213064f, -0.4270833f) + new Vector3(0f,0f,-0.00125f);

        triangles[0] = 0;
        triangles[1] = 12;
        triangles[2] = 13;
        triangles[3] = 1;
        triangles[4] = 0;
        triangles[5] = 13;
        triangles[6] = 1;
        triangles[7] = 13;
        triangles[8] = 14;
        triangles[9] = 2;
        triangles[10] = 1;
        triangles[11] = 14;
        triangles[12] = 2;
        triangles[13] = 14;
        triangles[14] = 15;
        triangles[15] = 3;
        triangles[16] = 2;
        triangles[17] = 15;
        triangles[18] = 3;
        triangles[19] = 15;
        triangles[20] = 16;
        triangles[21] = 4;
        triangles[22] = 3;
        triangles[23] = 16;
        triangles[24] = 4;
        triangles[25] = 16;
        triangles[26] = 17;
        triangles[27] = 5;
        triangles[28] = 4;
        triangles[29] = 17;
        triangles[30] = 6;
        triangles[31] = 19;
        triangles[32] = 18;
        triangles[33] = 6;
        triangles[34] = 7;
        triangles[35] = 19;
        triangles[36] = 7;
        triangles[37] = 20;
        triangles[38] = 19;
        triangles[39] = 7;
        triangles[40] = 8;
        triangles[41] = 20;
        triangles[42] = 8;
        triangles[43] = 21;
        triangles[44] = 20;
        triangles[45] = 8;
        triangles[46] = 9;
        triangles[47] = 21;
        triangles[48] = 9;
        triangles[49] = 22;
        triangles[50] = 21;
        triangles[51] = 9;
        triangles[52] = 10;
        triangles[53] = 22;
        triangles[54] = 10;
        triangles[55] = 23;
        triangles[56] = 22;
        triangles[57] = 10;
        triangles[58] = 11;
        triangles[59] = 23;





        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
        }





        // total path length:
        float length = 0f;
        for (int i = 0; i < 6; i++)
        {
            length = length + twoDDistance(vertices[i + 1].x - vertices[i].x, vertices[i + 1].z - vertices[i].z);
        }
        // setting uvs for Right side:
        float dist = 0;
        for (int i = 0; i < 6; i++)
        {
            uvs[i] = new Vector2(dist, 0f) / length;
            dist = dist + twoDDistance(vertices[i + 1].x - vertices[i].x, vertices[i + 1].z - vertices[i].z);
        }

        dist = 0;
        for (int i = 0; i < 6; i++)
        {
            uvs[i + 12] = new Vector2(dist, 1f) / length;
            dist = dist + twoDDistance(vertices[i + 1].x - vertices[i].x, vertices[i + 1].z - vertices[i].z);
        }


        // setting uvs for Left side:
        dist = 0;
        for (int i = 0; i < 6; i++)
        {
            uvs[i + 6] = new Vector2(dist, 0f) / length;
            dist = dist + twoDDistance(vertices[i + 1].x - vertices[i].x, vertices[i + 1].z - vertices[i].z);
        }

        dist = 0;
        for (int i = 0; i < 6; i++)
        {
            uvs[i + 18] = new Vector2(dist, 1f) / length;
            dist = dist + twoDDistance(vertices[i + 1].x - vertices[i].x, vertices[i + 1].z - vertices[i].z);
        }









        /*
        uvs[0] = new Vector2(0f, 0f);
        uvs[1] = new Vector2(0.05f, 0f);
        uvs[2] = new Vector2(0.15f, 0f);
        uvs[3] = new Vector2(0.75f, 0f);
        uvs[4] = new Vector2(0.9f, 0f);
        uvs[5] = new Vector2(1f, 0f);
        uvs[6] = new Vector2(0f, 0f);
        uvs[7] = new Vector2(0.05f, 0f);
        uvs[8] = new Vector2(0.15f, 0f);
        uvs[9] = new Vector2(0.75f, 0f);
        uvs[10] = new Vector2(0.9f, 0f);
        uvs[11] = new Vector2(1f, 0f);
        uvs[12] = new Vector2(0f, 0.999999f);
        uvs[13] = new Vector2(0.05f, 0.999999f);
        uvs[14] = new Vector2(0.15f, 0.999999f);
        uvs[15] = new Vector2(0.75f, 0.999999f);
        uvs[16] = new Vector2(0.9f, 0.999999f);
        uvs[17] = new Vector2(1f, 0.999999f);
        uvs[18] = new Vector2(0f, 0.999999f);
        uvs[19] = new Vector2(0.05f, 0.999999f);
        uvs[20] = new Vector2(0.15f, 0.999999f);
        uvs[21] = new Vector2(0.75f, 0.999999f);
        uvs[22] = new Vector2(0.9f, 0.999999f);
        uvs[23] = new Vector2(1f, 0.999999f);
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



    public static float twoDDistance(float x, float z)
    {
        return Mathf.Sqrt(x * x + z * z);
    }


}


