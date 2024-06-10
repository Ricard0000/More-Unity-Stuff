using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class WhiteWall1 : MonoBehaviour
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
    const int NN = 6;
    float delta_theta = (PI / 2) / N;
    public int rot = 0;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, NN, true, mat, rot);
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

    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, float c1, float c2, float c3, float c4, float s, float t, float delta_theta, int N, int NN, bool collider, Material mat, int rot)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;


        Mesh m = new Mesh();

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;
        /*
        vertices = new Vector3[3*(2 * N+1)];
        triangles = new int[12 * N+1000];
        uvs = new Vector2[3 * (2 * N + 1)];
        */
        vertices = new Vector3[66];
        triangles = new int[180];
        uvs = new Vector2[66];
        float meshScale = 4f;


        vertices[0] = new Vector3(-0.875f, 0.003662168f, -0.4270833f);
        vertices[1] = new Vector3(-0.8642273f, 0.1404191f, -0.4270833f);
        vertices[2] = new Vector3(-0.8321745f, 0.2783932f, -0.4270833f);
        vertices[3] = new Vector3(-0.7796308f, 0.4116732f, -0.4270833f);
        vertices[4] = new Vector3(-0.7078899f, 0.53802f, -0.4270833f);
        vertices[5] = new Vector3(-0.6187184f, 0.6553554f, -0.4270833f);
        vertices[6] = new Vector3(-0.514312f, 0.7617989f, -0.4270833f);
        vertices[7] = new Vector3(-0.3972418f, 0.8557063f, -0.4270833f);
        vertices[8] = new Vector3(-0.2703899f, 0.9357043f, -0.4270833f);
        vertices[9] = new Vector3(-0.1368801f, 1.000718f, -0.4270833f);
        vertices[10] = new Vector3(-3.824746E-08f, 1.04999f, -0.4270833f);
        vertices[11] = new Vector3(0.1368801f, 1.000718f, -0.4270833f);
        vertices[12] = new Vector3(0.2703899f, 0.9357044f, -0.4270833f);
        vertices[13] = new Vector3(0.3972417f, 0.8557064f, -0.4270833f);
        vertices[14] = new Vector3(0.5143121f, 0.7617989f, -0.4270833f);
        vertices[15] = new Vector3(0.6187184f, 0.6553554f, -0.4270833f);
        vertices[16] = new Vector3(0.7078899f, 0.53802f, -0.4270833f);
        vertices[17] = new Vector3(0.7796307f, 0.4116734f, -0.4270833f);
        vertices[18] = new Vector3(0.8321745f, 0.2783934f, -0.4270833f);
        vertices[19] = new Vector3(0.8642273f, 0.1404191f, -0.4270833f);
        vertices[20] = new Vector3(0.875f, 0.003662168f, -0.4270833f);
        vertices[21] = new Vector3(-0.875f, 0.003662168f, -0.9270833f);
        vertices[22] = new Vector3(-0.8642273f, 0.1404191f, -0.9270833f);
        vertices[23] = new Vector3(-0.8321745f, 0.2783932f, -0.9270833f);
        vertices[24] = new Vector3(-0.7796308f, 0.4116732f, -0.9270833f);
        vertices[25] = new Vector3(-0.7078899f, 0.53802f, -0.9270833f);
        vertices[26] = new Vector3(-0.6187184f, 0.6553554f, -0.9270833f);
        vertices[27] = new Vector3(-0.514312f, 0.7617989f, -0.9270833f);
        vertices[28] = new Vector3(-0.3972418f, 0.8557063f, -0.9270833f);
        vertices[29] = new Vector3(-0.2703899f, 0.9357043f, -0.9270833f);
        vertices[30] = new Vector3(-0.1368801f, 1.000718f, -0.9270833f);
        vertices[31] = new Vector3(-3.824746E-08f, 1.04999f, -0.9270833f);
        vertices[32] = new Vector3(0.1368801f, 1.000718f, -0.9270833f);
        vertices[33] = new Vector3(0.2703899f, 0.9357044f, -0.9270833f);
        vertices[34] = new Vector3(0.3972417f, 0.8557064f, -0.9270833f);
        vertices[35] = new Vector3(0.5143121f, 0.7617989f, -0.9270833f);
        vertices[36] = new Vector3(0.6187184f, 0.6553554f, -0.9270833f);
        vertices[37] = new Vector3(0.7078899f, 0.53802f, -0.9270833f);
        vertices[38] = new Vector3(0.7796307f, 0.4116734f, -0.9270833f);
        vertices[39] = new Vector3(0.8321745f, 0.2783934f, -0.9270833f);
        vertices[40] = new Vector3(0.8642273f, 0.1404191f, -0.9270833f);
        vertices[41] = new Vector3(0.875f, 0.003662168f, -0.9270833f);
        vertices[42] = new Vector3(-0.875f, 0.003662168f, -0.5520833f);
        vertices[43] = new Vector3(-0.8642273f, 0.1404191f, -0.5520833f);
        vertices[44] = new Vector3(-0.8321745f, 0.2783932f, -0.5520833f);
        vertices[45] = new Vector3(-0.7796308f, 0.4116732f, -0.5520833f);
        vertices[46] = new Vector3(-0.7078899f, 0.53802f, -0.5520833f);
        vertices[47] = new Vector3(-0.875f, 0.003662168f, -0.8020833f);
        vertices[48] = new Vector3(-0.8642273f, 0.1404191f, -0.8020833f);
        vertices[49] = new Vector3(-0.8321745f, 0.2783932f, -0.8020833f);
        vertices[50] = new Vector3(-0.7796308f, 0.4116732f, -0.8020833f);
        vertices[51] = new Vector3(-0.7078899f, 0.53802f, -0.8020833f);
        vertices[52] = new Vector3(-0.7796308f, 0.4116732f, -0.5520833f);
        vertices[53] = new Vector3(-0.7574616f, 0.4509184f, -0.5582013f);
        vertices[54] = new Vector3(-0.7374625f, 0.486322f, -0.5759562f);
        vertices[55] = new Vector3(-0.7215912f, 0.5144184f, -0.6036102f);
        vertices[56] = new Vector3(-0.7114012f, 0.5324574f, -0.6384562f);
        vertices[57] = new Vector3(-0.7078899f, 0.5386732f, -0.6770833f);
        vertices[58] = new Vector3(-0.7078899f, 0.53802f, -0.5520833f);
        vertices[59] = new Vector3(-0.7796308f, 0.4116732f, -0.8020833f);
        vertices[60] = new Vector3(-0.7574616f, 0.4509184f, -0.7959654f);
        vertices[61] = new Vector3(-0.7374625f, 0.486322f, -0.7782105f);
        vertices[62] = new Vector3(-0.7215912f, 0.5144184f, -0.7505565f);
        vertices[63] = new Vector3(-0.7114012f, 0.5324574f, -0.7157105f);
        vertices[64] = new Vector3(-0.7078899f, 0.5386732f, -0.6770833f);
        vertices[65] = new Vector3(-0.7078899f, 0.53802f, -0.8020833f);






        triangles[0] = 4;
        triangles[1] = 25;
        triangles[2] = 5;
        triangles[3] = 5;
        triangles[4] = 26;
        triangles[5] = 6;
        triangles[6] = 6;
        triangles[7] = 27;
        triangles[8] = 7;
        triangles[9] = 7;
        triangles[10] = 28;
        triangles[11] = 8;
        triangles[12] = 8;
        triangles[13] = 29;
        triangles[14] = 9;
        triangles[15] = 9;
        triangles[16] = 30;
        triangles[17] = 10;
        triangles[18] = 10;
        triangles[19] = 31;
        triangles[20] = 11;
        triangles[21] = 11;
        triangles[22] = 32;
        triangles[23] = 12;
        triangles[24] = 12;
        triangles[25] = 33;
        triangles[26] = 13;
        triangles[27] = 13;
        triangles[28] = 34;
        triangles[29] = 14;
        triangles[30] = 14;
        triangles[31] = 35;
        triangles[32] = 15;
        triangles[33] = 15;
        triangles[34] = 36;
        triangles[35] = 16;
        triangles[36] = 16;
        triangles[37] = 37;
        triangles[38] = 17;
        triangles[39] = 17;
        triangles[40] = 38;
        triangles[41] = 18;
        triangles[42] = 18;
        triangles[43] = 39;
        triangles[44] = 19;
        triangles[45] = 19;
        triangles[46] = 40;
        triangles[47] = 20;
        triangles[48] = 5;
        triangles[49] = 25;
        triangles[50] = 26;
        triangles[51] = 6;
        triangles[52] = 26;
        triangles[53] = 27;
        triangles[54] = 7;
        triangles[55] = 27;
        triangles[56] = 28;
        triangles[57] = 8;
        triangles[58] = 28;
        triangles[59] = 29;
        triangles[60] = 9;
        triangles[61] = 29;
        triangles[62] = 30;
        triangles[63] = 10;
        triangles[64] = 30;
        triangles[65] = 31;
        triangles[66] = 11;
        triangles[67] = 31;
        triangles[68] = 32;
        triangles[69] = 12;
        triangles[70] = 32;
        triangles[71] = 33;
        triangles[72] = 13;
        triangles[73] = 33;
        triangles[74] = 34;
        triangles[75] = 14;
        triangles[76] = 34;
        triangles[77] = 35;
        triangles[78] = 15;
        triangles[79] = 35;
        triangles[80] = 36;
        triangles[81] = 16;
        triangles[82] = 36;
        triangles[83] = 37;
        triangles[84] = 17;
        triangles[85] = 37;
        triangles[86] = 38;
        triangles[87] = 18;
        triangles[88] = 38;
        triangles[89] = 39;
        triangles[90] = 19;
        triangles[91] = 39;
        triangles[92] = 40;
        triangles[93] = 20;
        triangles[94] = 40;
        triangles[95] = 41;
        triangles[96] = 0;
        triangles[97] = 42;
        triangles[98] = 43;
        triangles[99] = 1;
        triangles[100] = 43;
        triangles[101] = 44;
        triangles[102] = 2;
        triangles[103] = 44;
        triangles[104] = 45;
        triangles[105] = 3;
        triangles[106] = 45;
        triangles[107] = 46;
        triangles[108] = 1;
        triangles[109] = 0;
        triangles[110] = 43;
        triangles[111] = 2;
        triangles[112] = 1;
        triangles[113] = 44;
        triangles[114] = 3;
        triangles[115] = 2;
        triangles[116] = 45;
        triangles[117] = 4;
        triangles[118] = 3;
        triangles[119] = 46;
        triangles[120] = 47;
        triangles[121] = 21;
        triangles[122] = 22;
        triangles[123] = 48;
        triangles[124] = 22;
        triangles[125] = 23;
        triangles[126] = 49;
        triangles[127] = 23;
        triangles[128] = 24;
        triangles[129] = 50;
        triangles[130] = 24;
        triangles[131] = 25;
        triangles[132] = 48;
        triangles[133] = 47;
        triangles[134] = 22;
        triangles[135] = 49;
        triangles[136] = 48;
        triangles[137] = 23;
        triangles[138] = 50;
        triangles[139] = 49;
        triangles[140] = 24;
        triangles[141] = 51;
        triangles[142] = 50;
        triangles[143] = 25;
        triangles[144] = 53;
        triangles[145] = 58;
        triangles[146] = 52;
        triangles[147] = 54;
        triangles[148] = 58;
        triangles[149] = 53;
        triangles[150] = 55;
        triangles[151] = 58;
        triangles[152] = 54;
        triangles[153] = 56;
        triangles[154] = 58;
        triangles[155] = 55;
        triangles[156] = 57;
        triangles[157] = 58;
        triangles[158] = 56;
        triangles[159] = 58;
        triangles[160] = 58;
        triangles[161] = 57;
        triangles[162] = 59;
        triangles[163] = 65;
        triangles[164] = 60;
        triangles[165] = 60;
        triangles[166] = 65;
        triangles[167] = 61;
        triangles[168] = 61;
        triangles[169] = 65;
        triangles[170] = 62;
        triangles[171] = 62;
        triangles[172] = 65;
        triangles[173] = 63;
        triangles[174] = 63;
        triangles[175] = 65;
        triangles[176] = 64;
        triangles[177] = 64;
        triangles[178] = 65;
        triangles[179] = 65;






        uvs[0] = new Vector2(0f, 0f);
        uvs[1] = new Vector2(0.04999975f, 0f);
        uvs[2] = new Vector2(0.0999995f, 0f);
        uvs[3] = new Vector2(0.1499993f, 0f);
        uvs[4] = new Vector2(0.199999f, 0f);
        uvs[5] = new Vector2(0.2499988f, 0f);
        uvs[6] = new Vector2(0.2999985f, 0f);
        uvs[7] = new Vector2(0.3499983f, 0f);
        uvs[8] = new Vector2(0.399998f, 0f);
        uvs[9] = new Vector2(0.4499978f, 0f);
        uvs[10] = new Vector2(0.4999975f, 0f);
        uvs[11] = new Vector2(0.5499973f, 0f);
        uvs[12] = new Vector2(0.599997f, 0f);
        uvs[13] = new Vector2(0.6499968f, 0f);
        uvs[14] = new Vector2(0.6999965f, 0f);
        uvs[15] = new Vector2(0.7499963f, 0f);
        uvs[16] = new Vector2(0.799996f, 0f);
        uvs[17] = new Vector2(0.8499958f, 0f);
        uvs[18] = new Vector2(0.8999956f, 0f);
        uvs[19] = new Vector2(0.9499953f, 0f);
        uvs[20] = new Vector2(0.9999951f, 0f);
        uvs[21] = new Vector2(0f, 0.25f);
        uvs[22] = new Vector2(0.04999975f, 0.25f);
        uvs[23] = new Vector2(0.0999995f, 0.25f);
        uvs[24] = new Vector2(0.1499993f, 0.25f);
        uvs[25] = new Vector2(0.199999f, 0.25f);
        uvs[26] = new Vector2(0.2499988f, 0.25f);
        uvs[27] = new Vector2(0.2999985f, 0.25f);
        uvs[28] = new Vector2(0.3499983f, 0.25f);
        uvs[29] = new Vector2(0.399998f, 0.25f);
        uvs[30] = new Vector2(0.4499978f, 0.25f);
        uvs[31] = new Vector2(0.4999975f, 0.25f);
        uvs[32] = new Vector2(0.5499973f, 0.25f);
        uvs[33] = new Vector2(0.599997f, 0.25f);
        uvs[34] = new Vector2(0.6499968f, 0.25f);
        uvs[35] = new Vector2(0.6999965f, 0.25f);
        uvs[36] = new Vector2(0.7499963f, 0.25f);
        uvs[37] = new Vector2(0.799996f, 0.25f);
        uvs[38] = new Vector2(0.8499958f, 0.25f);
        uvs[39] = new Vector2(0.8999956f, 0.25f);
        uvs[40] = new Vector2(0.9499953f, 0.25f);
        uvs[41] = new Vector2(0.9999951f, 0.25f);
        uvs[42] = new Vector2(0f, 0.0625f);
        uvs[43] = new Vector2(0.04999975f, 0.0625f);
        uvs[44] = new Vector2(0.0999995f, 0.0625f);
        uvs[45] = new Vector2(0.1499993f, 0.0625f);
        uvs[46] = new Vector2(0.199999f, 0.0625f);
        uvs[47] = new Vector2(0f, 0.1875f);
        uvs[48] = new Vector2(0.04999975f, 0.1875f);
        uvs[49] = new Vector2(0.0999995f, 0.1875f);
        uvs[50] = new Vector2(0.1499993f, 0.1875f);
        uvs[51] = new Vector2(0.199999f, 0.1875f);
        uvs[52] = new Vector2(0.1499992f, 0.0625f);
        uvs[53] = new Vector2(0.1664992f, 0.06875f);
        uvs[54] = new Vector2(0.1774991f, 0.078125f);
        uvs[55] = new Vector2(0.1874991f, 0.09375f);
        uvs[56] = new Vector2(0.194999f, 0.110625f);
        uvs[57] = new Vector2(0.199999f, 0.125f);
        uvs[58] = new Vector2(0.199999f, 0.0625f);
        uvs[59] = new Vector2(0.1499992f, 0.1875f);
        uvs[60] = new Vector2(0.1664992f, 0.18125f);
        uvs[61] = new Vector2(0.1774991f, 0.171875f);
        uvs[62] = new Vector2(0.1874991f, 0.15625f);
        uvs[63] = new Vector2(0.194999f, 0.139375f);
        uvs[64] = new Vector2(0.199999f, 0.125f);
        uvs[65] = new Vector2(0.199999f, 0.1875f);


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



/*
Length
Out[8]: 0.8361311504699118

dz
Out[9]: 0.0625

c1
Out[10]: 1.25

*/