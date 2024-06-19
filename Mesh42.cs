using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh42 : MonoBehaviour
{

    Mesh mesh;
    Vector3[] vertices;
    Vector2[] uvs;
    int[] triangles;

    const float PI = 3.1415926535897931f;


    const int N = 8;
    const int N1 = 16;


    float Pos1 = 0.1825f - 0.0625f;//Object position
    float Pos2 = -0.221875f - 0.06f;
    float Pos3 = -0.9275f;//4375f;


    public float c1 = 4.25f;//x-direction
    public float c2 = 2.75f;//y-direction
    public float c3 = 3.75f;//z-direction
    public float R = 0.125f;

    public Material mat;
    GameObject gog;
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, N, N1, mat, true);
    }

    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, int N, int N1, Material mat, bool collider)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

        Mesh m = new Mesh();

        vertices = new Vector3[13 * 6 * 2];

        triangles = new int[252 * 3];
        uvs = new Vector2[13 * 6 * 2];
        float meshScale = 4f;



        float moveBack = -0.0675f;

        Vector3 recenter1 = new Vector3(0.14259f, -0.233117095f, 0f);




        vertices[0] = new Vector3(-0.24375f, 0.02817959f, 0f) + recenter1;
        vertices[1] = new Vector3(-0.24375f, 0.3068946f, 0f) + recenter1;
        vertices[2] = new Vector3(-0.241266f, 0.3570874f, 0f) + recenter1;
        vertices[3] = new Vector3(-0.2203341f, 0.3996387f, 0f) + recenter1;
        vertices[4] = new Vector3(-0.1852827f, 0.4280706f, 0f) + recenter1;
        vertices[5] = new Vector3(-0.14259f, 0.4380546f, 0f) + recenter1;
        vertices[6] = new Vector3(-0.14259f, 0.4380546f, 0f) + recenter1;
        vertices[7] = new Vector3(-0.0998973f, 0.4280706f, 0f) + recenter1;
        vertices[8] = new Vector3(-0.0648459f, 0.3996387f, 0f) + recenter1;
        vertices[9] = new Vector3(-0.04391401f, 0.3570873f, 0f) + recenter1;
        vertices[10] = new Vector3(-0.04143f, 0.3068946f, 0f) + recenter1;
        vertices[11] = new Vector3(-0.04143f, 0.02817959f, 0f) + recenter1;
        vertices[12] = new Vector3(-0.24375f, 0.02817959f, 0f) + recenter1;


        float scale1 = 1.25f;
        for (int i = 0; i < 13; i++)
        {
            vertices[i] = vertices[i] * scale1;
        }


        float scale2 = 0.8f;
        for(int i = 0; i < 13; i++)
        {
            vertices[i+13] = vertices[i] * scale2 / scale1;
        }

        for (int i = 0; i < 13; i++)
        {
            vertices[i + 26] = vertices[i] + new Vector3(0f,0f,-0.025f);
        }

        for (int i = 0; i < 13; i++)
        {
            vertices[i + 39] = vertices[i + 13] + new Vector3(0f, 0f, -0.025f);
        }


        for (int i = 0; i < 13; i++)
        {
            vertices[i + 39 + 13] = vertices[i + 13];
        }


        for (int i = 0; i < 13; i++)
        {
            vertices[i + 39 + 26] = vertices[i + 39];
        }





        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale + new Vector3(-0.574f,0.992f,-3.933f);
        }

        for (int i = 0; i < 13; i++)
        {
            triangles[0 + i * 6] = 1 + i;
            triangles[1 + i * 6] = 0 + i;
            triangles[2 + i * 6] = 13 + i;
            triangles[3 + i * 6] = 1 + i;
            triangles[4 + i * 6] = 13 + i;
            triangles[5 + i * 6] = 14 + i;
        }





        for (int i = 0; i < 13; i++)
        {
            triangles[0 + i * 6 + 6 * 14] = 0 + i + 26;
            triangles[1 + i * 6 + 6 * 14] = 1 + i + 26;
            triangles[2 + i * 6 + 6 * 14] = 13 + i + 26;
            triangles[3 + i * 6 + 6 * 14] = 1 + i + 26;
            triangles[4 + i * 6 + 6 * 14] = 14 + i + 26;
            triangles[5 + i * 6 + 6 * 14] = 13 + i + 26;
        }


        for (int i = 0; i < 13; i++)
        {
            triangles[0 + i * 6 + 6 * 28] = 1 + i + 26 * 2;
            triangles[1 + i * 6 + 6 * 28] = 0 + i + 26 * 2;
            triangles[2 + i * 6 + 6 * 28] = 13 + i + 26 * 2;
            triangles[3 + i * 6 + 6 * 28] = 1 + i + 26 * 2;
            triangles[4 + i * 6 + 6 * 28] = 13 + i + 26 * 2;
            triangles[5 + i * 6 + 6 * 28] = 14 + i + 26 * 2;
        }


        for (int i = 0; i < 13 * 8; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
        }




        /*
        vertices[11] = new Vector3(0.04364002f, 0.3068946f, -0.9270834f);
        vertices[12] = new Vector3(0.04612403f, 0.3570873f, -0.9270834f);
        vertices[13] = new Vector3(0.06705593f, 0.3996387f, -0.9270834f);
        vertices[14] = new Vector3(0.1021073f, 0.4280706f, -0.9270834f);
        vertices[15] = new Vector3(0.14201f, 0.4380546f, -0.9270834f);
        vertices[16] = new Vector3(0.1874927f, 0.4280706f, -0.9270834f);
        vertices[17] = new Vector3(0.2225441f, 0.3996387f, -0.9270834f);
        vertices[18] = new Vector3(0.243476f, 0.3570874f, -0.9270834f);
        vertices[19] = new Vector3(0.24596f, 0.3068946f, -0.9270834f);
        vertices[20] = new Vector3(0.24596f, 0.02817959f, -0.9270834f);
        vertices[21] = new Vector3(-0.24375f, 0.02817959f, -0.9270834f);
*/

        /*
        vertices[22] = new Vector3(-0.24375f, 0.02817959f, -0.9270834f + moveBack);
        vertices[23] = new Vector3(-0.24375f, 0.3068946f, -0.9270834f + moveBack);
        vertices[24] = new Vector3(-0.241266f, 0.3570874f, -0.9270834f + moveBack);
        vertices[25] = new Vector3(-0.2203341f, 0.3996387f, -0.9270834f + moveBack);
        vertices[26] = new Vector3(-0.1852827f, 0.4280706f, -0.9270834f + moveBack);
        vertices[27] = new Vector3(-0.14259f, 0.4380546f, -0.9270834f + moveBack);
        vertices[28] = new Vector3(-0.14259f, 0.4380546f, -0.9270834f + moveBack);
        vertices[29] = new Vector3(-0.0998973f, 0.4280706f, -0.9270834f + moveBack);
        vertices[30] = new Vector3(-0.0648459f, 0.3996387f, -0.9270834f + moveBack);
        vertices[31] = new Vector3(-0.04391401f, 0.3570873f, -0.9270834f + moveBack);
        vertices[32] = new Vector3(-0.04143f, 0.3068946f, -0.9270834f + moveBack);
*/

        /*
        vertices[33] = new Vector3(0.04364002f, 0.3068946f, -0.9270834f + moveBack);
        vertices[34] = new Vector3(0.04612403f, 0.3570873f, -0.9270834f + moveBack);
        vertices[35] = new Vector3(0.06705593f, 0.3996387f, -0.9270834f + moveBack);
        vertices[36] = new Vector3(0.1021073f, 0.4280706f, -0.9270834f + moveBack);
        vertices[37] = new Vector3(0.14201f, 0.4380546f, -0.9270834f + moveBack);
        vertices[38] = new Vector3(0.1874927f, 0.4280706f, -0.9270834f + moveBack);
        vertices[39] = new Vector3(0.2225441f, 0.3996387f, -0.9270834f + moveBack);
        vertices[40] = new Vector3(0.243476f, 0.3570874f, -0.9270834f + moveBack);
        vertices[41] = new Vector3(0.24596f, 0.3068946f, -0.9270834f + moveBack);
        vertices[42] = new Vector3(0.24596f, 0.02817959f, -0.9270834f + moveBack);
        vertices[43] = new Vector3(-0.24375f, 0.02817959f, -0.9270834f + moveBack);
        */




        /*
        triangles[6] = 1 + 1;
        triangles[7] = 0 + 1;
        triangles[8] = 22 + 1;
        triangles[9] = 23 + 1;
        triangles[10] = 1 + 1;
        triangles[11] = 22 + 1;

        triangles[12] = 1 + 2;
        triangles[13] = 0 + 2;
        triangles[14] = 22 + 2;
        triangles[15] = 23 + 2;
        triangles[16] = 1 + 2;
        triangles[17] = 22 + 2;

        triangles[18] = 1 + 3;
        triangles[19] = 0 + 3;
        triangles[20] = 22 + 3;
        triangles[21] = 23 + 3;
        triangles[22] = 1 + 3;
        triangles[23] = 22 + 3;

        triangles[24] = 1 + 4;
        triangles[25] = 0 + 4;
        triangles[26] = 22 + 4;
        triangles[27] = 23 + 4;
        triangles[28] = 1 + 4;
        triangles[29] = 22 + 4;

        triangles[30] = 1 + 5;
        triangles[31] = 0 + 5;
        triangles[32] = 22 + 5;
        triangles[33] = 23 + 5;
        triangles[34] = 1 + 5;
        triangles[35] = 22 + 5;

        triangles[36] = 1 + 6;
        triangles[37] = 0 + 6;
        triangles[38] = 22 + 6;
        triangles[39] = 23 + 6;
        triangles[40] = 1 + 6;
        triangles[41] = 22 + 6;

        triangles[42] = 1 + 7;
        triangles[43] = 0 + 7;
        triangles[44] = 22 + 7;
        triangles[45] = 23 + 7;
        triangles[46] = 1 + 7;
        triangles[47] = 22 + 7;

        triangles[48] = 1 + 8;
        triangles[49] = 0 + 8;
        triangles[50] = 22 + 8;
        triangles[51] = 23 + 8;
        triangles[52] = 1 + 8;
        triangles[53] = 22 + 8;

        triangles[54] = 1 + 9;
        triangles[55] = 0 + 9;
        triangles[56] = 22 + 9;
        triangles[57] = 23 + 9;
        triangles[58] = 1 + 9;
        triangles[59] = 22 + 9;

        triangles[60] = 1 + 10;
        triangles[61] = 0 + 10;
        triangles[62] = 22 + 10;
        triangles[63] = 23 + 10;
        triangles[64] = 1 + 10;
        triangles[65] = 22 + 10;

        triangles[66] = 1 + 11;
        triangles[67] = 0 + 11;
        triangles[68] = 22 + 11;
        triangles[69] = 23 + 11;
        triangles[70] = 1 + 11;
        triangles[71] = 22 + 11;

        triangles[72] = 1 + 12;
        triangles[73] = 0 + 12;
        triangles[74] = 22 + 12;
        triangles[75] = 23 + 12;
        triangles[76] = 1 + 12;
        triangles[77] = 22 + 12;

        triangles[78] = 1 + 13;
        triangles[79] = 0 + 13;
        triangles[80] = 22 + 13;
        triangles[81] = 23 + 13;
        triangles[82] = 1 + 13;
        triangles[83] = 22 + 13;

        triangles[84] = 1 + 14;
        triangles[85] = 0 + 14;
        triangles[86] = 22 + 14;
        triangles[87] = 23 + 14;
        triangles[88] = 1 + 14;
        triangles[89] = 22 + 14;

        triangles[90] = 1 + 15;
        triangles[91] = 0 + 15;
        triangles[92] = 22 + 15;
        triangles[93] = 23 + 15;
        triangles[94] = 1 + 15;
        triangles[95] = 22 + 15;

        triangles[96] = 1 + 16;
        triangles[97] = 0 + 16;
        triangles[98] = 22 + 16;
        triangles[99] = 23 + 16;
        triangles[100] = 1 + 16;
        triangles[101] = 22 + 16;

        triangles[102] = 1 + 17;
        triangles[103] = 0 + 17;
        triangles[104] = 22 + 17;
        triangles[105] = 23 + 17;
        triangles[106] = 1 + 17;
        triangles[107] = 22 + 17;

        triangles[108] = 1 + 18;
        triangles[109] = 0 + 18;
        triangles[110] = 22 + 18;
        triangles[111] = 23 + 18;
        triangles[112] = 1 + 18;
        triangles[113] = 22 + 18;

        triangles[114] = 1 + 19;
        triangles[115] = 0 + 19;
        triangles[116] = 22 + 19;
        triangles[117] = 23 + 19;
        triangles[118] = 1 + 19;
        triangles[119] = 22 + 19;

        triangles[120] = 1 + 20;
        triangles[121] = 0 + 20;
        triangles[122] = 22 + 20;
        triangles[123] = 23 + 20;
        triangles[124] = 1 + 20;
        triangles[125] = 22 + 20;
        */


        /*

        // total path length:
        float length = 0f;
        for (int i = 0; i < 21; i++)
        {
            length = length + twoDDistance(vertices[i + 1].x - vertices[i].x, vertices[i + 1].y - vertices[i].y);
        }
        // setting uvs:
        float dist = 0;
        for (int i = 0; i < 22; i++)
        {
            uvs[i] = new Vector2(dist, 0f) / length;
            dist = dist + twoDDistance(vertices[i + 1].x - vertices[i].x, vertices[i + 1].y - vertices[i].y);
            Debug.Log(dist * 100);
        }

        dist = 0;
        for (int i = 0; i < 22; i++)
        {
            uvs[i + 22] = new Vector2(dist, 1f) / length;
            dist = dist + twoDDistance(vertices[i + 1].x - vertices[i].x, vertices[i + 1].y - vertices[i].y);
        }
        */


        /*
                for (int i = 0; i < 22; i++)
                {
                    uvs[i] = new Vector2((float)i / 22f, 0f);
                }

                for (int i = 0; i < 22; i++)
                {
                    uvs[i + 22] = new Vector2((float)i / 22f, 1f);
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



    public static float twoDDistance(float x, float y)
    {
        return Mathf.Sqrt(x * x + y * y);
    }


}
