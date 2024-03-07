using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class StairToDoor2 : MonoBehaviour
{

    public ParticleSystem system;

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

    float delta_theta = (PI / 2) / N;
    float delta_circ = (PI / 2) / N;
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

        //N=number of splits per quarter.

        vertices = new Vector3[47];
        triangles = new int[189];
        uvs = new Vector2[47];

        // TO DO: Probe Verts in on wall. Then print out verts


//        Vector3 probe = new Vector3(-0.125f, 0f, 0f);


        vertices[0] = new Vector3(-0.30625f + 0.28875f, -0.1566955f, -0.7882653f);
        uvs[0] = new Vector2(vertices[0].x, vertices[0].z);

        vertices[3] = new Vector3(-0.74375f - 0.1f, -0.1566955f, -0.7882653f);
        uvs[3] = new Vector2(vertices[3].x, vertices[3].z);

        vertices[1] = new Vector3(-0.01359375f, -0.1566955f, -0.7698469f);
        uvs[1] = new Vector2(vertices[1].x, vertices[1].z);

        vertices[2] = new Vector3(-0.01359375f - 0.035f, -0.1566955f, -0.7698469f + 0.0125f);
        uvs[2] = new Vector2(vertices[2].x, vertices[2].z);

        vertices[4] = new Vector3(-0.01359375f - 0.11f, -0.1566955f, -0.7698469f + 0.025f);
        uvs[4] = new Vector2(vertices[4].x, vertices[4].z);

        vertices[5] = new Vector3(-0.01359375f - 0.175f, -0.1566955f, -0.7698469f + 0.03f);
        uvs[5] = new Vector2(vertices[5].x, vertices[5].z);

        vertices[6] = new Vector3(-0.74375f - 0.1f, -0.1566955f, -0.7698469f + 0.03f);
        uvs[6] = new Vector2(vertices[6].x, vertices[6].z);

        float down = 0.04f;
        vertices[7] = new Vector3(-0.01359375f, -0.1566955f - down, -0.7698469f);
        uvs[7] = new Vector2(vertices[7].x, vertices[7].y);

        vertices[8] = new Vector3(-0.01359375f - 0.035f, -0.1566955f - down, -0.7698469f + 0.0125f);
        uvs[8] = new Vector2(vertices[8].x, vertices[8].y);

        vertices[9] = new Vector3(-0.01359375f - 0.11f, -0.1566955f - down, -0.7698469f + 0.025f);
        uvs[9] = new Vector2(vertices[9].x, vertices[9].y);

        vertices[10] = new Vector3(-0.01359375f - 0.175f, -0.1566955f - down, -0.7698469f + 0.03f);
        uvs[10] = new Vector2(vertices[10].x, vertices[10].y);
        
        vertices[11] = new Vector3(-0.74375f - 0.1f, -0.1566955f - down, -0.7698469f + 0.03f);
        uvs[11] = new Vector2(vertices[11].x, vertices[11].y);


        vertices[12] = new Vector3(0.0125f, -0.1566955f - down, (-0.6894898f + -0.615f) * 0.5f-0.02f);
        uvs[12] = new Vector2(vertices[12].x, vertices[12].z);

        vertices[13] = new Vector3(0.0125f - 0.085f, -0.1566955f - down, (-0.6894898f + -0.615f) * 0.5f + 0.0125f - 0.013f);
        uvs[13] = new Vector2(vertices[13].x, vertices[13].z);

        vertices[14] = new Vector3(-0.01359375f - 0.2f, -0.1566955f - down, -0.7698469f + 0.135f);
        uvs[14] = new Vector2(vertices[14].x, vertices[14].z);

        vertices[15] = new Vector3(-0.21359375f-0.1f, -0.1566955f - down, -0.6298469f-0.0025f);
        uvs[15] = new Vector2(vertices[15].x, vertices[15].z);

        vertices[16] = new Vector3(-0.74375f - 0.1f, -0.1566955f - down, -0.6298469f - 0.0025f);
        uvs[16] = new Vector2(vertices[16].x, vertices[16].z);



        vertices[17] = new Vector3(0.0125f, -0.1566955f - 2f * down, (-0.6894898f + -0.615f) * 0.5f - 0.02f);
        uvs[17] = new Vector2(vertices[17].x, vertices[17].y);

        vertices[18] = new Vector3(0.0125f - 0.085f, -0.1566955f - 2f * down, (-0.6894898f + -0.615f) * 0.5f + 0.0125f - 0.013f);
        uvs[18] = new Vector2(vertices[18].x, vertices[18].y);

        vertices[19] = new Vector3(-0.01359375f - 0.2f, -0.1566955f - 2f * down, -0.7698469f + 0.135f);
        uvs[19] = new Vector2(vertices[19].x, vertices[19].y);

        vertices[20] = new Vector3(-0.21359375f - 0.1f, -0.1566955f - 2f * down, -0.6298469f - 0.0025f);
        uvs[20] = new Vector2(vertices[20].x, vertices[20].y);

        vertices[21] = new Vector3(-0.74375f - 0.1f, -0.1566955f - 2f * down, -0.6298469f - 0.0025f);
        uvs[21] = new Vector2(vertices[21].x, vertices[21].y);


        vertices[22] = new Vector3(0.0125f + 0.035f, -0.1566955f - 2f * down, -0.6722449f + 0.099f);
        uvs[22] = new Vector2(vertices[22].x, vertices[22].z);

        vertices[23] = new Vector3(0.0475f - 0.08f, -0.1566955f - 2f * down, -0.5732449f + 0.021f);
        uvs[23] = new Vector2(vertices[23].x, vertices[23].z);

        vertices[24] = new Vector3(-0.0325f- 0.1125f, -0.1566955f - 2f * down, -0.5522449f + 0.017f);
        uvs[24] = new Vector2(vertices[24].x, vertices[24].z);

        vertices[25] = new Vector3(-0.145f - 0.125f, -0.1566955f - 2f * down, -0.5352449f + 0.005f);
        uvs[25] = new Vector2(vertices[25].x, vertices[25].z);

        vertices[26] = new Vector3(-0.74375f - 0.1f, -0.1566955f - 2f * down, -0.5302449f);
        uvs[26] = new Vector2(vertices[26].x, vertices[26].z);

        vertices[27] = new Vector3(0.0125f + 0.035f, -0.1566955f - 3f * down, -0.6722449f + 0.099f);
        uvs[27] = new Vector2(vertices[27].x, vertices[27].y);

        vertices[28] = new Vector3(0.0475f - 0.08f, -0.1566955f - 3f * down, -0.5732449f + 0.021f);
        uvs[28] = new Vector2(vertices[28].x, vertices[28].y);

        vertices[29] = new Vector3(-0.0325f - 0.1125f, -0.1566955f - 3f * down, -0.5522449f + 0.017f);
        uvs[29] = new Vector2(vertices[29].x, vertices[29].y);

        vertices[30] = new Vector3(-0.145f - 0.125f, -0.1566955f - 3f * down, -0.5352449f + 0.005f);
        uvs[30] = new Vector2(vertices[30].x, vertices[30].y);

        vertices[31] = new Vector3(-0.74375f - 0.1f, -0.1566955f - 3f * down, -0.5302449f);
        uvs[31] = new Vector2(vertices[31].x, vertices[31].y);

        float r = 0.1875f;
        float dx = 0.00625f;
        float dy = 0.05f;
        float r1 = 0.0375f * 1.5f;

        Vector3 POS = new Vector3(Pos1, Pos2*0f, Pos3);
        Vector3 newPosition = new Vector3(-0.0625f, 0f, 0f);

        vertices[32] = new Vector3(dx + dy, -0.1566955f - 3f * down, 0.125f + r + dx + r1 / 1.5f) + POS;
        vertices[32] = vertices[32] + new Vector3(0.01f, 0f, 0f) + newPosition;
        uvs[32] = new Vector2(vertices[32].x, vertices[32].z);

        for (int i = 0; i < N1 - 7; i++)
        {
            vertices[33 + i] = new Vector3(dx + dy, -0.1566955f - 3f * down, 0.125f + r + dx + r1 / 1.5f) + POS + new Vector3(r1 * Mathf.Cos(1.25f * PI + 2f * PI * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(1.25f * PI + 2f * PI * (i) / (N1 - 1)));
            vertices[33 + i] = vertices[33 + i] + new Vector3(0.01f, 0f, 0f) + newPosition;
            uvs[33 + i] = new Vector2(vertices[33 + i].x, vertices[33 + i].z);
        }

        vertices[42] = new Vector3(0.0125f + 0.075f, -0.1566955f - 3f * down, -0.6722449f + 0.175f);
        uvs[42] = new Vector2(vertices[42].x, vertices[42].z);

        vertices[43] = new Vector3(0.0875f - 0.1f, -0.1566955f - 3f * down, -0.4972449f + 0.025f);
        uvs[43] = new Vector2(vertices[43].x, vertices[43].z);

        vertices[44] = new Vector3(-0.0125f - 0.1f, -0.1566955f - 3f * down, -0.4722449f +0.01f);
        uvs[44] = new Vector2(vertices[44].x, vertices[44].z);

        vertices[45] = new Vector3(-0.1125f - 0.125f, -0.1566955f - 3f * down, -0.4622449f + 0.01f);
        uvs[45] = new Vector2(vertices[45].x, vertices[45].z);

        vertices[46] = new Vector3(-0.74375f - 0.1f, -0.1566955f - 3f * down, -0.4622449f + 0.01f);
        uvs[46] = new Vector2(vertices[46].x, vertices[46].z);

        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 2;
        triangles[4] = 0;
        triangles[5] = 3;

        triangles[6] = 2;
        triangles[7] = 3;
        triangles[8] = 4;

        triangles[9] = 3;
        triangles[10] = 5;
        triangles[11] = 4;

        triangles[12] = 3;
        triangles[13] = 6;
        triangles[14] = 5;

        triangles[15] = 1;
        triangles[16] = 2;
        triangles[17] = 7;

        triangles[18] = 2;
        triangles[19] = 8;
        triangles[20] = 7;

        triangles[21] = 2;
        triangles[22] = 4;
        triangles[23] = 8;

        triangles[24] = 4;
        triangles[25] = 9;
        triangles[26] = 8;

        triangles[27] = 4;
        triangles[28] = 5;
        triangles[29] = 9;

        triangles[30] = 5;
        triangles[31] = 10;
        triangles[32] = 9;

        triangles[33] = 5;
        triangles[34] = 6;
        triangles[35] = 10;

        triangles[36] = 6;
        triangles[37] = 11;
        triangles[38] = 10;

        triangles[39] = 7;
        triangles[40] = 13;
        triangles[41] = 12;

        triangles[42] = 8;
        triangles[43] = 13;
        triangles[44] = 7;


        triangles[45] = 9;
        triangles[46] = 14;
        triangles[47] = 13;

        triangles[48] = 10;
        triangles[49] = 15;
        triangles[50] = 14;

        triangles[51] = 11;
        triangles[52] = 16;
        triangles[53] = 15;

        triangles[54] = 10;
        triangles[55] = 11;
        triangles[56] = 15;

        triangles[57] = 13;
        triangles[58] = 8;
        triangles[59] = 9;

        triangles[60] = 14;
        triangles[61] = 9;
        triangles[62] = 10;

        //12-16 17 - 21
        triangles[63] = 12;
        triangles[64] = 13;
        triangles[65] = 17;

        triangles[66] = 13;
        triangles[67] = 14;
        triangles[68] = 18;

        triangles[69] = 14;
        triangles[70] = 15;
        triangles[71] = 19;

        triangles[72] = 15;
        triangles[73] = 16;
        triangles[74] = 20;

        triangles[75] = 13;
        triangles[76] = 18;
        triangles[77] = 17;

        triangles[78] = 14;
        triangles[79] = 19;
        triangles[80] = 18;

        triangles[81] = 15;
        triangles[82] = 20;
        triangles[83] = 19;

        triangles[84] = 16;
        triangles[85] = 21;
        triangles[86] = 20;

        triangles[87] = 17;
        triangles[88] = 18;
        triangles[89] = 22;

        triangles[90] = 18;
        triangles[91] = 23;
        triangles[92] = 22;

        triangles[93] = 19;
        triangles[94] = 24;
        triangles[95] = 23;

        triangles[96] = 18;
        triangles[97] = 19;
        triangles[98] = 23;

        triangles[99] = 20;
        triangles[100] = 25;
        triangles[101] = 24;

        triangles[102] = 19;
        triangles[103] = 20;
        triangles[104] = 24;

        triangles[105] = 21;
        triangles[106] = 26;
        triangles[107] = 25;
        
        triangles[108] = 20;
        triangles[109] = 21;
        triangles[110] = 25;


        //22 - 26
        triangles[111] = 22;
        triangles[112] = 23;
        triangles[113] = 27;

        triangles[114] = 28;
        triangles[115] = 27;
        triangles[116] = 23;

        triangles[117] = 23;
        triangles[118] = 24;
        triangles[119] = 28;

        triangles[120] = 29;
        triangles[121] = 28;
        triangles[122] = 24;

        triangles[123] = 24;
        triangles[124] = 25;
        triangles[125] = 29;

        triangles[126] = 30;
        triangles[127] = 29;
        triangles[128] = 25;

        triangles[129] = 25;
        triangles[130] = 26;
        triangles[131] = 30;

        triangles[132] = 31;
        triangles[133] = 30;
        triangles[134] = 26;

        int nextTri = 135;
        for (int i = 0; i < N1 - 1 - 7; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3] = 32;
            triangles[nextTri + i3 + 1] = 34 + i;
            triangles[nextTri + i3 + 2] = 33 + i;
        }

        triangles[159] = 27;
        triangles[160] = 42;
        triangles[161] = 41;

        triangles[162] = 32;
        triangles[163] = 27;
        triangles[164] = 41;

        triangles[165] = 42;
        triangles[166] = 27;
        triangles[167] = 43;

        triangles[168] = 43;
        triangles[169] = 28;
        triangles[170] = 44;

        triangles[171] = 44;
        triangles[172] = 29;
        triangles[173] = 45;

        triangles[174] = 45;
        triangles[175] = 30;
        triangles[176] = 46;

        triangles[177] = 27;
        triangles[178] = 28;
        triangles[179] = 43;

        triangles[180] = 28;
        triangles[181] = 29;
        triangles[182] = 44;

        triangles[183] = 29;
        triangles[184] = 30;
        triangles[185] = 45;

        triangles[186] = 30;
        triangles[187] = 31;
        triangles[188] = 46;

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
    /*
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
    */
}
