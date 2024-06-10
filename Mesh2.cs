using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Mesh2 : MonoBehaviour
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

        vertices = new Vector3[35];
        triangles = new int[93];
        uvs = new Vector2[35];
        float meshScale = 4f;



        vertices[0] = new Vector3(-0.7078899f, 0.53802f, -0.9270834f);
        vertices[1] = new Vector3(-0.6187184f, 0.6553554f, -0.9270834f);
        vertices[2] = new Vector3(-0.514312f, 0.7617989f, -0.9270834f);
        vertices[3] = new Vector3(-0.3972418f, 0.8557063f, -0.9270834f);
        vertices[4] = new Vector3(-0.2703899f, 0.9357043f, -0.9270834f);
        vertices[5] = new Vector3(-0.1368801f, 1.000718f, -0.9270834f);
        vertices[6] = new Vector3(0f, 1.04999f, -0.9270834f);
        vertices[7] = new Vector3(0.1368801f, 1.000718f, -0.9270834f);
        vertices[8] = new Vector3(0.2703899f, 0.9357044f, -0.9270834f);
        vertices[9] = new Vector3(0.3972417f, 0.8557064f, -0.9270834f);
        vertices[10] = new Vector3(0.5143121f, 0.7617989f, -0.9270834f);
        vertices[11] = new Vector3(0.6187184f, 0.6553554f, -0.9270834f);
        vertices[12] = new Vector3(0.7078899f, 0.53802f, -0.9270834f);
        vertices[13] = new Vector3(0f, 0.53802f, -0.9270834f);
        vertices[14] = new Vector3(-0.74375f - 0.02f, 0.2783045f, -0.9270834f);
        vertices[15] = new Vector3(-0.7270986f - 0.02f, 0.3619995f, -0.9270834f);
        vertices[16] = new Vector3(-0.6796796f - 0.02f, 0.4393734f, -0.9270834f);
        vertices[17] = new Vector3(-0.608712f - 0.02f, 0.4999052f, -0.9270834f);
        vertices[18] = new Vector3(-0.525f-0.02f, 0.53802f, -0.9270834f);
        vertices[19] = new Vector3(-0.441288f - 0.04f, 0.4999053f, -0.9270834f);
        vertices[20] = new Vector3(-0.3703204f - 0.04f, 0.4393734f, -0.9270834f);
        vertices[21] = new Vector3(-0.3229013f - 0.04f, 0.3619996f, -0.9270834f);
        vertices[22] = new Vector3(-0.30625f - 0.04f, 0.2783045f, -0.9270834f);
        vertices[23] = new Vector3(-0.7078899f, 0.53802f, -0.9270834f);
        vertices[24] = new Vector3(-0.875f, 0.003662168f, -0.9270834f);
        vertices[25] = new Vector3(-0.8642273f, 0.1404191f, -0.9270834f);
        vertices[26] = new Vector3(-0.8321745f, 0.2783932f, -0.9270834f);
        vertices[27] = new Vector3(-0.7796308f, 0.4116732f, -0.9270834f);
        vertices[28] = new Vector3(-0.7078899f, 0.53802f, -0.9270834f);
        vertices[29] = new Vector3(-0.74375f-0.02f, -0.2816955f, -0.9270834f);
        vertices[30] = new Vector3(-0.86875f, -0.2816955f, -0.9270834f);
        vertices[31] = new Vector3(-0.34625f, 0.5380546f, -0.9270834f);
        vertices[32] = new Vector3(-0.24375f, 0.5380546f, -0.9270834f);
        vertices[33] = new Vector3(-0.34625f, -0.2816955f, -0.9270834f);
        vertices[34] = new Vector3(-0.24375f, -0.2816955f, -0.9270834f);


        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
        }

        for (int i = 0; i < 35; i++)
        {
            uvs[i] = new Vector2((vertices[i].x + 0.86875f * meshScale) / (1.5766339f * meshScale),
                (vertices[i].y + 0.2826955f * meshScale) / (1.3316855f * meshScale));
        }

        /*
        for (int i = 0; i < 35; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
        }
        */

        triangles[0] = 0;
        triangles[1] = 13;
        triangles[2] = 1;
        triangles[3] = 1;
        triangles[4] = 13;
        triangles[5] = 2;
        triangles[6] = 2;
        triangles[7] = 13;
        triangles[8] = 3;
        triangles[9] = 3;
        triangles[10] = 13;
        triangles[11] = 4;
        triangles[12] = 4;
        triangles[13] = 13;
        triangles[14] = 5;
        triangles[15] = 5;
        triangles[16] = 13;
        triangles[17] = 6;
        triangles[18] = 6;
        triangles[19] = 13;
        triangles[20] = 7;
        triangles[21] = 7;
        triangles[22] = 13;
        triangles[23] = 8;
        triangles[24] = 8;
        triangles[25] = 13;
        triangles[26] = 9;
        triangles[27] = 9;
        triangles[28] = 13;
        triangles[29] = 10;
        triangles[30] = 10;
        triangles[31] = 13;
        triangles[32] = 11;
        triangles[33] = 11;
        triangles[34] = 13;
        triangles[35] = 12;

        // The left arch

        triangles[36] = 15;
        triangles[37] = 23;
        triangles[38] = 14;

        triangles[39] = 16;
        triangles[40] = 23;
        triangles[41] = 15;

        triangles[42] = 17;
        triangles[43] = 23;
        triangles[44] = 16;

        triangles[45] = 18;
        triangles[46] = 23;
        triangles[47] = 17;
        // The left arch

        // Corner of arch
        triangles[48] = 14;
        triangles[49] = 28;
        triangles[50] = 27;
        
        triangles[51] = 14;
        triangles[52] = 27;
        triangles[53] = 26;
        
        triangles[54] = 14;
        triangles[55] = 26;
        triangles[56] = 25;

        triangles[57] = 14;
        triangles[58] = 25;
        triangles[59] = 24;

        triangles[60] = 29;
        triangles[61] = 14;
        triangles[62] = 25;

        triangles[63] = 29;
        triangles[64] = 25;
        triangles[65] = 24;

        triangles[66] = 24;
        triangles[67] = 30;
        triangles[68] = 29;


        //other side of arch

        triangles[69] = 19;
        triangles[70] = 31;
        triangles[71] = 18;

        triangles[72] = 20;
        triangles[73] = 31;
        triangles[74] = 19;

        triangles[75] = 21;
        triangles[76] = 31;
        triangles[77] = 20;

        triangles[78] = 22;
        triangles[79] = 31;
        triangles[80] = 21;
        //other side of arch


// Quad side of door entrance

        triangles[81] = 31;
        triangles[82] = 33;
        triangles[83] = 32;

        triangles[84] = 32;
        triangles[85] = 33;
        triangles[86] = 34;

        // Quad side of door entrance




        // Save Vertices for Ray Tracing:
        string fileName = "RTMesh2.txt";

        var sr = File.CreateText(fileName);

        float xx;
        float yy;
        float zz;


        sr.Write((int)vertices.Length);
        sr.Write("\n");
        for (int L = 0; L < vertices.Length; L++)
        {
            Vector3 pos = vertices[L];

            xx = pos[0];
            yy = pos[1];
            zz = pos[2];
            sr.Write((float)xx);
            sr.Write("\n");
            sr.Write((float)yy);
            sr.Write("\n");
            sr.Write((float)zz);
            sr.Write("\n");
        }
        sr.Write((int)triangles.Length);
        sr.Write("\n");
        for (int L = 0; L < triangles.Length; L++)
        {
            int triPos = triangles[L];
            sr.Write((int)triPos);
            sr.Write("\n");
        }
        sr.Close();
        /*
        sr.Write("\n"); sr.Write("\n"); sr.Write("\n"); sr.Write("\n"); sr.Write("\n");

        for (int L = 0; L < triangles.Length; L++)
        {
            int posTri = triangles[L];
            sr.Write("triangles[");
            sr.Write((int)L);
            sr.Write("] = ");
            sr.Write((int)posTri);
            sr.Write(";\n");
        }
        sr.Write("\n"); sr.Write("\n"); sr.Write("\n"); sr.Write("\n"); sr.Write("\n");
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



