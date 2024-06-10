using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

        vertices = new Vector3[16];
        triangles = new int[45];
        uvs = new Vector2[16];
        float meshScale = 4f;

        vertices[0] = new Vector3(-0.7992412f, -0.28125f, -0.4272089f);
        vertices[1] = new Vector3(-0.7241033f, -0.28125f, -0.3683653f);
        vertices[2] = new Vector3(-0.6317654f, -0.28125f, -0.3159847f);
        vertices[3] = new Vector3(-0.524421f, -0.28125f, -0.2713156f);
        vertices[4] = new Vector3(-0.4046196f, -0.28125f, -0.235421f);
        vertices[5] = new Vector3(-0.2752071f, -0.28125f, -0.2091546f);
        vertices[6] = new Vector3(-0.1392576f, -0.28125f, -0.1931407f);
        vertices[7] = new Vector3(-3.961345E-08f, -0.28125f, -0.1877602f);
        vertices[8] = new Vector3(0.1392574f, -0.28125f, -0.1931407f);
        vertices[9] = new Vector3(0.275207f, -0.28125f, -0.2091546f);
        vertices[10] = new Vector3(0.4046195f, -0.28125f, -0.235421f);
        vertices[11] = new Vector3(0.5244209f, -0.28125f, -0.2713156f);
        vertices[12] = new Vector3(0.6317654f, -0.28125f, -0.3159847f);
        vertices[13] = new Vector3(0.7241033f, -0.28125f, -0.3683653f);
        vertices[14] = new Vector3(0.7992411f, -0.28125f, -0.4272088f);
        vertices[15] = new Vector3(0f, -0.28125f, -0.4273435f);





        triangles[0] = 1;
        triangles[1] = 15;
        triangles[2] = 0;
        triangles[3] = 2;
        triangles[4] = 15;
        triangles[5] = 1;
        triangles[6] = 3;
        triangles[7] = 15;
        triangles[8] = 2;
        triangles[9] = 4;
        triangles[10] = 15;
        triangles[11] = 3;
        triangles[12] = 5;
        triangles[13] = 15;
        triangles[14] = 4;
        triangles[15] = 6;
        triangles[16] = 15;
        triangles[17] = 5;
        triangles[18] = 7;
        triangles[19] = 15;
        triangles[20] = 6;
        triangles[21] = 8;
        triangles[22] = 15;
        triangles[23] = 7;
        triangles[24] = 9;
        triangles[25] = 15;
        triangles[26] = 8;
        triangles[27] = 10;
        triangles[28] = 15;
        triangles[29] = 9;
        triangles[30] = 11;
        triangles[31] = 15;
        triangles[32] = 10;
        triangles[33] = 12;
        triangles[34] = 15;
        triangles[35] = 11;
        triangles[36] = 13;
        triangles[37] = 15;
        triangles[38] = 12;
        triangles[39] = 14;
        triangles[40] = 15;
        triangles[41] = 13;
        triangles[42] = 0;
        triangles[43] = 0;
        triangles[44] = 0;





        uvs[0] = new Vector2(-0.7992412f, -0.4272089f);
        uvs[1] = new Vector2(-0.7241033f, -0.3683653f);
        uvs[2] = new Vector2(-0.6317654f, -0.3159847f);
        uvs[3] = new Vector2(-0.524421f, -0.2713156f);
        uvs[4] = new Vector2(-0.4046196f, -0.235421f);
        uvs[5] = new Vector2(-0.2752071f, -0.2091546f);
        uvs[6] = new Vector2(-0.1392576f, -0.1931407f);
        uvs[7] = new Vector2(-3.961345E-08f, -0.1877602f);
        uvs[8] = new Vector2(0.1392574f, -0.1931407f);
        uvs[9] = new Vector2(0.275207f, -0.2091546f);
        uvs[10] = new Vector2(0.4046195f, -0.235421f);
        uvs[11] = new Vector2(0.5244209f, -0.2713156f);
        uvs[12] = new Vector2(0.6317654f, -0.3159847f);
        uvs[13] = new Vector2(0.7241033f, -0.3683653f);
        uvs[14] = new Vector2(0.7992411f, -0.4272088f);
        uvs[15] = new Vector2(0f, -0.4273435f);


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


