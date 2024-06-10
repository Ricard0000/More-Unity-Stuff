using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Mesh26 : MonoBehaviour
{
    //Wall Entrance 2
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

    const int Nrot = 5;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");

    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot, Nrot);
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

        vertices = new Vector3[32];
        triangles = new int[48];
        uvs = new Vector2[32];
        float meshScale = 4f;










        float moveBack = -0.05f;
        //right quad
        vertices[0] = new Vector3(-0.32875f, 0.5380546f, -0.9895834f + moveBack);
        vertices[1] = new Vector3(0.40625f, 0.5380546f, -0.9895834f + moveBack);

        vertices[2] = new Vector3(-0.32875f, 0.5380546f + 0.5f + 0.5f, -0.9895834f + moveBack);
        vertices[3] = new Vector3(0.40625f, 0.5380546f + 0.5f + 0.5f, -0.9895834f + moveBack);

        float moveleft = -0.05f;
        vertices[4] = new Vector3(-0.24375f, 0.5380546f, -0.9895834f + moveBack);
//        vertices[5] = new Vector3(-0.24375f + moveleft - 0.05f, 0.5380546f, -0.9895834f + moveBack);
  //      vertices[6] = new Vector3(-0.24375f + moveleft - 0.05f, -0.24375f, -0.9895834f + moveBack);
        vertices[5] = new Vector3(-0.32875f, 0.5380546f, -0.9895834f + moveBack);
        vertices[6] = new Vector3(-0.32875f, -0.24375f, -0.9895834f + moveBack);
        vertices[7] = new Vector3(-0.24375f, -0.24375f, -0.9895834f + moveBack);


        //Top left quad
        vertices[8] = new Vector3(-0.32875f, 0.5380546f + 0.5f + 0.5f, -0.9895834f + moveBack);
        vertices[9] = new Vector3(-0.32875f, 0.5380546f + 0.0125f + 0.1f, -0.9895834f + moveBack);
        vertices[10] = new Vector3(-0.7825f, 0.5380546f + 0.0125f + 0.1f, -0.9895834f + moveBack);
        vertices[11] = new Vector3(-0.7825f, 0.5380546f + 0.5f + 0.5f, -0.9895834f + moveBack);


        // UV Change 11 - 14 Top detail
        vertices[12] = new Vector3(-0.875f + 0.075f, 0.5380546f + 0.1f, -0.9895834f);
        vertices[13] = new Vector3(-0.32875f, 0.5380546f + 0.1f, -0.9895834f);
        vertices[14] = new Vector3(-0.875f + 0.075f, 0.5380546f + 0.0125f + 0.1f, -0.9895834f + moveBack);
        vertices[15] = new Vector3(-0.32875f, 0.5380546f + 0.0125f + 0.1f, -0.9895834f + moveBack);

        // UV Change 15 - 18 right side detail
        vertices[16] = new Vector3(-0.24375f + moveleft - 0.0125f - 0.035f, 0.5380546f + 0.1f, -0.9895834f); // near outside
        vertices[17] = new Vector3(-0.24375f + moveleft - 0.035f, 0.5380546f + 0.0125f + 0.1f, -0.9895834f + moveBack);
        vertices[18] = new Vector3(-0.24375f + moveleft - 0.035f, -0.24375f, -0.9895834f + moveBack);
        vertices[19] = new Vector3(-0.24375f + moveleft - 0.0125f - 0.035f, -0.24375f, -0.9895834f);

        // Very left quad
        vertices[20] = new Vector3(-0.7825f, 0.5380546f + 0.5f + 0.5f, -0.9895834f + moveBack);
        vertices[21] = new Vector3(-0.875f + 0.075f - 0.125f, 0.5380546f + 0.5f + 0.5f, -0.9895834f + moveBack);
        vertices[22] = new Vector3(-0.875f + 0.075f - 0.125f, -0.24375f, -0.9895834f + moveBack);
        vertices[23] = new Vector3(-0.7825f, -0.24375f, -0.9895834f + moveBack);

        //Left detail
        vertices[24] = new Vector3(-0.875f + 0.075f + 0.03f -0.0125f, -0.24375f, -0.9895834f + moveBack);
        vertices[25] = new Vector3(-0.875f + 0.075f + 0.0125f + 0.03f - 0.0125f, -0.24375f, -0.9895834f);
        vertices[26] = new Vector3(-0.875f + 0.075f + 0.03f + 0.0125f - 0.0125f, 0.5380546f + 0.0125f + 0.1f, -0.9895834f);
        vertices[27] = new Vector3(-0.875f + 0.075f + 0.03f - 0.0125f, 0.5380546f + 0.0125f + 0.1f, -0.9895834f + moveBack);


        // Last Quad
        vertices[28] = new Vector3(-0.875f + 0.075f, 0.5380546f + 0.1f, -0.9895834f);
        vertices[29] = new Vector3(-0.32875f, 0.5380546f + 0.1f, -0.9895834f);
        vertices[30] = new Vector3(-0.875f + 0.075f, 0.5380546f, -0.9895834f);
        vertices[31] = new Vector3(-0.32875f, 0.5380546f, -0.9895834f);

        for (int i = 0; i < vertices.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
        }

        triangles[0] = 2;
        triangles[1] = 1;
        triangles[2] = 0;

        triangles[3] = 2;
        triangles[4] = 3;
        triangles[5] = 1;

        triangles[6] = 4;
        triangles[7] = 6;
        triangles[8] = 5;

        triangles[9] = 4;
        triangles[10] = 7;
        triangles[11] = 6;

        triangles[12] = 8;
        triangles[13] = 9;
        triangles[14] = 10;

        triangles[15] = 8;
        triangles[16] = 10;
        triangles[17] = 11;

        triangles[18] = 12;
        triangles[19] = 14;
        triangles[20] = 13;

        triangles[21] = 15;
        triangles[22] = 13;
        triangles[23] = 14;

        triangles[24] = 16;
        triangles[25] = 17;
        triangles[26] = 18;

        triangles[27] = 18;
        triangles[28] = 19;
        triangles[29] = 16;
        
        triangles[30] = 20;
        triangles[31] = 22;
        triangles[32] = 21;

        triangles[33] = 23;
        triangles[34] = 22;
        triangles[35] = 20;

        triangles[36] = 24;
        triangles[37] = 26;
        triangles[38] = 25;

        triangles[39] = 27;
        triangles[40] = 26;
        triangles[41] = 24;

        triangles[42] = 28;
        triangles[43] = 29;
        triangles[44] = 30;

        triangles[45] = 29;
        triangles[46] = 31;
        triangles[47] = 30;


        for (int i = 0; i < 32; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
        }

        uvs[12] = new Vector2(vertices[12].x, vertices[12].z);
        uvs[13] = new Vector2(vertices[13].x, vertices[13].z);
        uvs[14] = new Vector2(vertices[14].x, vertices[14].z);
        uvs[15] = new Vector2(vertices[15].x, vertices[15].z);

        uvs[16] = new Vector2(vertices[16].y, vertices[16].z);
        uvs[17] = new Vector2(vertices[17].y, vertices[17].z);
        uvs[18] = new Vector2(vertices[18].y, vertices[18].z);
        uvs[19] = new Vector2(vertices[19].y, vertices[19].z);

        uvs[24] = new Vector2(vertices[24].y, vertices[24].z);
        uvs[25] = new Vector2(vertices[25].y, vertices[25].z);
        uvs[26] = new Vector2(vertices[26].y, vertices[26].z);
        uvs[27] = new Vector2(vertices[27].y, vertices[27].z);


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


