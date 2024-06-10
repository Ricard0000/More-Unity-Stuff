using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Mesh8 : MonoBehaviour
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
        triangles = new int[78];
        uvs = new Vector2[32];
        float meshScale = 4f;









        float moveBack = -0.05f;

        vertices[0] = new Vector3(-0.24375f, 0.4380546f, -0.9895834f);
        vertices[1] = new Vector3(-0.24375f, -0.2816955f, -0.9895834f);
        vertices[2] = new Vector3(-0.24375f, 0.02817959f, -0.9895834f);
        vertices[3] = new Vector3(0.40625f, 0.02817959f, -0.9895834f);
        vertices[4] = new Vector3(0.40625f, -0.2816955f, -0.9895834f);
        vertices[5] = new Vector3(0.40625f, 0.4380546f, -0.9895834f);
        vertices[6] = new Vector3(-0.24375f, 0.3068946f, -0.9895834f);
        vertices[7] = new Vector3(-0.241266f, 0.3570874f, -0.9895834f);
        vertices[8] = new Vector3(-0.2203341f, 0.3996387f, -0.9895834f);
        vertices[9] = new Vector3(-0.1852827f, 0.4280706f, -0.9895834f);
        vertices[10] = new Vector3(-0.14259f, 0.4380546f, -0.9895834f);
        vertices[11] = new Vector3(-0.14259f, 0.4380546f, -0.9895834f);
        vertices[12] = new Vector3(-0.0998973f, 0.4280706f, -0.9895834f);
        vertices[13] = new Vector3(-0.0648459f, 0.3996387f, -0.9895834f);
        vertices[14] = new Vector3(-0.04391401f, 0.3570873f, -0.9895834f);
        vertices[15] = new Vector3(-0.04143f, 0.3068946f, -0.9895834f);
        vertices[16] = new Vector3(0.04364002f, 0.4380546f, -0.9895834f);
        vertices[17] = new Vector3(0.24596f, 0.4380546f, -0.9895834f);
        vertices[18] = new Vector3(0.24596f, 0.02817959f, -0.9895834f);
        vertices[19] = new Vector3(0.24596f, 0.3068946f, -0.9895834f);
        vertices[20] = new Vector3(0.243476f, 0.3570874f, -0.9895834f);
        vertices[21] = new Vector3(0.2225441f, 0.3996387f, -0.9895834f);
        vertices[22] = new Vector3(0.1874927f, 0.4280706f, -0.9895834f);
        vertices[23] = new Vector3(0.14201f, 0.4380546f, -0.9895834f);
        vertices[24] = new Vector3(0.1448f, 0.4380546f, -0.9895834f);
        vertices[25] = new Vector3(0.1021073f, 0.4280706f, -0.9895834f);
        vertices[26] = new Vector3(0.06705593f, 0.3996387f, -0.9895834f);
        vertices[27] = new Vector3(0.04612403f, 0.3570873f, -0.9895834f);
        vertices[28] = new Vector3(0.04364002f, 0.3068946f, -0.9895834f);
        vertices[29] = new Vector3(-0.04143f, 0.4380546f, -0.9895834f);
        vertices[30] = new Vector3(-0.24375f, 0.5380546f, -0.9895834f);
        vertices[31] = new Vector3(0.40625f, 0.5380546f, -0.9895834f);

        for (int i = 0; i < 32; i++)
        {
            vertices[i] = vertices[i] + new Vector3(0f,0f,moveBack);
        }

        for (int i = 0; i < 32; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
        }


        triangles[0] = 2;
        triangles[1] = 3;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 4;

        triangles[6] = 0;
        triangles[7] = 7;
        triangles[8] = 6;

        triangles[9] = 0;
        triangles[10] = 8;
        triangles[11] = 7;

        triangles[12] = 0;
        triangles[13] = 9;
        triangles[14] = 8;

        triangles[15] = 9;
        triangles[16] = 0;
        triangles[17] = 10;

        triangles[18] = 16;
        triangles[19] = 12;
        triangles[20] = 11;

        triangles[21] = 16;
        triangles[22] = 13;
        triangles[23] = 12;

        triangles[24] = 16;
        triangles[25] = 14;
        triangles[26] = 13;

        triangles[27] = 16;
        triangles[28] = 15;
        triangles[29] = 14;

        triangles[30] = 17;
        triangles[31] = 5;
        triangles[32] = 3;

        triangles[33] = 17;
        triangles[34] = 3;
        triangles[35] = 18;

        triangles[36] = 17;
        triangles[37] = 19;
        triangles[38] = 20;

        triangles[39] = 17;
        triangles[40] = 20;
        triangles[41] = 21;

        triangles[42] = 17;
        triangles[43] = 21;
        triangles[44] = 22;

        triangles[45] = 17;
        triangles[46] = 22;
        triangles[47] = 23;

        triangles[48] = 16;
        triangles[49] = 24;
        triangles[50] = 25;

        triangles[51] = 16;
        triangles[52] = 25;
        triangles[53] = 26;

        triangles[54] = 16;
        triangles[55] = 26;
        triangles[56] = 27;

        triangles[57] = 16;
        triangles[58] = 27;
        triangles[59] = 28;

        triangles[60] = 29;
        triangles[61] = 16;
        triangles[62] = 28;

        triangles[63] = 29;
        triangles[64] = 28;
        triangles[65] = 15;

        triangles[66] = 30;
        triangles[67] = 31;
        triangles[68] = 0;

        triangles[69] = 0;
        triangles[70] = 31;
        triangles[71] = 5;







        for (int i = 0; i < 32; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
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


