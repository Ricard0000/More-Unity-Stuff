using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh21 : MonoBehaviour
{
//    StairToDoor2
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

        //N=number of splits per quarter.

        vertices = new Vector3[47];
        triangles = new int[189];
        uvs = new Vector2[47];
        float meshScale = 4f;



        vertices[0] = new Vector3(-0.01750001f, -0.1566955f, -0.7882653f);
        vertices[1] = new Vector3(-0.01359375f, -0.1566955f, -0.7698469f);
        vertices[2] = new Vector3(-0.04859375f, -0.1566955f, -0.7573469f);
        vertices[3] = new Vector3(-0.84375f, -0.1566955f, -0.7882653f);
        vertices[4] = new Vector3(-0.1235937f, -0.1566955f, -0.7448469f);
        vertices[5] = new Vector3(-0.1885937f, -0.1566955f, -0.7398469f);
        vertices[6] = new Vector3(-0.84375f, -0.1566955f, -0.7398469f);
        vertices[7] = new Vector3(-0.01359375f, -0.1881955f, -0.7698469f);
        vertices[8] = new Vector3(-0.04859375f, -0.1881955f, -0.7573469f);
        vertices[9] = new Vector3(-0.1235937f, -0.1881955f, -0.7448469f);
        vertices[10] = new Vector3(-0.1885937f, -0.1881955f, -0.7398469f);
        vertices[11] = new Vector3(-0.84375f, -0.1881955f, -0.7398469f);
        vertices[12] = new Vector3(0.0125f, -0.1881955f, -0.6722449f);
        vertices[13] = new Vector3(-0.0725f, -0.1881955f, -0.6527449f);
        vertices[14] = new Vector3(-0.2135938f, -0.1881955f, -0.6348469f);
        vertices[15] = new Vector3(-0.3135937f, -0.1881955f, -0.6323469f);
        vertices[16] = new Vector3(-0.84375f, -0.1881955f, -0.6323469f);
        vertices[17] = new Vector3(0.0125f, -0.2196955f, -0.6722449f);
        vertices[18] = new Vector3(-0.0725f, -0.2196955f, -0.6527449f);
        vertices[19] = new Vector3(-0.2135938f, -0.2196955f, -0.6348469f);
        vertices[20] = new Vector3(-0.3135937f, -0.2196955f, -0.6323469f);
        vertices[21] = new Vector3(-0.84375f, -0.2196955f, -0.6323469f);
        vertices[22] = new Vector3(0.0475f, -0.2196955f, -0.5732449f);
        vertices[23] = new Vector3(-0.0325f, -0.2196955f, -0.5522449f);
        vertices[24] = new Vector3(-0.145f, -0.2196955f, -0.5352449f);
        vertices[25] = new Vector3(-0.27f, -0.2196955f, -0.5302449f);
        vertices[26] = new Vector3(-0.84375f, -0.2196955f, -0.5302449f);
        vertices[27] = new Vector3(0.0475f, -0.2511955f, -0.5732449f);
        vertices[28] = new Vector3(-0.0325f, -0.2511955f, -0.5522449f);
        vertices[29] = new Vector3(-0.145f, -0.2511955f, -0.5352449f);
        vertices[30] = new Vector3(-0.27f, -0.2511955f, -0.5302449f);
        vertices[31] = new Vector3(-0.84375f, -0.2511955f, -0.5302449f);
        vertices[32] = new Vector3(0.12375f, -0.2511955f, -0.57125f);
        vertices[33] = new Vector3(0.08397527f, -0.2511955f, -0.6110248f);
        vertices[34] = new Vector3(0.1035918f, -0.2511955f, -0.6237639f);
        vertices[35] = new Vector3(0.1266939f, -0.2511955f, -0.6274229f);
        vertices[36] = new Vector3(0.149287f, -0.2511955f, -0.6213691f);
        vertices[37] = new Vector3(0.1674645f, -0.2511955f, -0.6066493f);
        vertices[38] = new Vector3(0.1780833f, -0.2511955f, -0.5858086f);
        vertices[39] = new Vector3(0.1793075f, -0.2511955f, -0.5624506f);
        vertices[40] = new Vector3(0.1709252f, -0.2511955f, -0.5406141f);
        vertices[41] = new Vector3(0.154386f, -0.2511955f, -0.5240748f);
        vertices[42] = new Vector3(0.08750001f, -0.2511955f, -0.4972449f);
        vertices[43] = new Vector3(-0.0125f, -0.2511955f, -0.4722449f);
        vertices[44] = new Vector3(-0.1125f, -0.2511955f, -0.4622449f);
        vertices[45] = new Vector3(-0.2375f, -0.2511955f, -0.4522449f);
        vertices[46] = new Vector3(-0.84375f, -0.2511955f, -0.4522449f);
        
        
        


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
        triangles[135] = 32;
        triangles[136] = 34;
        triangles[137] = 33;
        triangles[138] = 32;
        triangles[139] = 35;
        triangles[140] = 34;
        triangles[141] = 32;
        triangles[142] = 36;
        triangles[143] = 35;
        triangles[144] = 32;
        triangles[145] = 37;
        triangles[146] = 36;
        triangles[147] = 32;
        triangles[148] = 38;
        triangles[149] = 37;
        triangles[150] = 32;
        triangles[151] = 39;
        triangles[152] = 38;
        triangles[153] = 32;
        triangles[154] = 40;
        triangles[155] = 39;
        triangles[156] = 32;
        triangles[157] = 41;
        triangles[158] = 40;
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





        uvs[0] = new Vector2(-0.01750001f, -0.7882653f);
        uvs[1] = new Vector2(-0.01359375f, -0.7698469f);
        uvs[2] = new Vector2(-0.04859375f, -0.7573469f);
        uvs[3] = new Vector2(-0.84375f, -0.7882653f);
        uvs[4] = new Vector2(-0.1235937f, -0.7448469f);
        uvs[5] = new Vector2(-0.1885937f, -0.7398469f);
        uvs[6] = new Vector2(-0.84375f, -0.7398469f);
        uvs[7] = new Vector2(-0.01359375f, -0.1881955f);
        uvs[8] = new Vector2(-0.04859375f, -0.1881955f);
        uvs[9] = new Vector2(-0.1235937f, -0.1881955f);
        uvs[10] = new Vector2(-0.1885937f, -0.1881955f);
        uvs[11] = new Vector2(-0.84375f, -0.1881955f);
        uvs[12] = new Vector2(0.0125f, -0.6722449f);
        uvs[13] = new Vector2(-0.0725f, -0.6527449f);
        uvs[14] = new Vector2(-0.2135938f, -0.6348469f);
        uvs[15] = new Vector2(-0.3135937f, -0.6323469f);
        uvs[16] = new Vector2(-0.84375f, -0.6323469f);
        uvs[17] = new Vector2(0.0125f, -0.2196955f);
        uvs[18] = new Vector2(-0.0725f, -0.2196955f);
        uvs[19] = new Vector2(-0.2135938f, -0.2196955f);
        uvs[20] = new Vector2(-0.3135937f, -0.2196955f);
        uvs[21] = new Vector2(-0.84375f, -0.2196955f);
        uvs[22] = new Vector2(0.0475f, -0.5732449f);
        uvs[23] = new Vector2(-0.0325f, -0.5522449f);
        uvs[24] = new Vector2(-0.145f, -0.5352449f);
        uvs[25] = new Vector2(-0.27f, -0.5302449f);
        uvs[26] = new Vector2(-0.84375f, -0.5302449f);
        uvs[27] = new Vector2(0.0475f, -0.2511955f);
        uvs[28] = new Vector2(-0.0325f, -0.2511955f);
        uvs[29] = new Vector2(-0.145f, -0.2511955f);
        uvs[30] = new Vector2(-0.27f, -0.2511955f);
        uvs[31] = new Vector2(-0.84375f, -0.2511955f);
        uvs[32] = new Vector2(0.12375f, -0.57125f);
        uvs[33] = new Vector2(0.08397527f, -0.6110248f);
        uvs[34] = new Vector2(0.1035918f, -0.6237639f);
        uvs[35] = new Vector2(0.1266939f, -0.6274229f);
        uvs[36] = new Vector2(0.149287f, -0.6213691f);
        uvs[37] = new Vector2(0.1674645f, -0.6066493f);
        uvs[38] = new Vector2(0.1780833f, -0.5858086f);
        uvs[39] = new Vector2(0.1793075f, -0.5624506f);
        uvs[40] = new Vector2(0.1709252f, -0.5406141f);
        uvs[41] = new Vector2(0.154386f, -0.5240748f);
        uvs[42] = new Vector2(0.08750001f, -0.4972449f);
        uvs[43] = new Vector2(-0.0125f, -0.4722449f);
        uvs[44] = new Vector2(-0.1125f, -0.4622449f);
        uvs[45] = new Vector2(-0.2375f, -0.4522449f);
        uvs[46] = new Vector2(-0.84375f, -0.4522449f);






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
