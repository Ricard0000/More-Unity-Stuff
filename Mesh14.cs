using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Mesh14 : MonoBehaviour
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
    const int N = 14;
    const int NN = 6;
    float delta_theta = (PI / 2) / N;
    public int rot = 0;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, NN, true, mat, rot);
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
//        vertices = new Vector3[84];
  //      triangles = new int[417];
    //    uvs = new Vector2[84];

        //        POS = new Vector3(0f, -0.0625f, 0f);

        vertices = new Vector3[6 * N];
        triangles = new int[6 * N + 6 * N + 6 * N + 6 * N + 6 * N];
        uvs = new Vector2[6 * N];
        float meshScale = 4f;

        float dx = 0.00625f;
        float dy = 0.03125f * 0.25f;
        float dz = 0.00625f;
        float r = 0.03f;
        float moveback = 0.0625f;

        Vector3 center = 0.25f * (new Vector3(.04364003f + dx * 0.75f, .4068946f, -.9270834f + dz * 0.75f) + new Vector3(-.01421997f - dx * 0.75f, .4068946f, -.9270834f + dz * 0.75f) + new Vector3(.04364003f + dx * 0.75f, .4068946f, -.9270834f - dz * 0.75f - moveback) + new Vector3(-.01421997f - dx * 0.75f, .4068946f, -.9270834f - dz * 0.75f - moveback));

        for (int i = 0; i < N; i++)
        {
            vertices[i] = new Vector3(1.1f * r * Mathf.Cos(2f * PI * i / (float)(N - 1)) + center[0], center[1] - 0.02f - dy * 5f, 1.1f * r * Mathf.Sin(2f * PI * i / (float)(N - 1)) + center[2]);
        }
        int nextVert = N;
        for (int i = 0; i < N; i++)
        {
            vertices[nextVert + i] = new Vector3(1.2f * r * Mathf.Cos(2f * PI * i / (float)(N - 1)) + center[0], center[1] - 0.02f - dy * 5.25f, 1.2f * r * Mathf.Sin(2f * PI * i / (float)(N - 1)) + center[2]);
        }

        nextVert = nextVert + N;
        for (int i = 0; i < N; i++)
        {
            vertices[nextVert + i] = new Vector3(1.235f * r * Mathf.Cos(2f * PI * i / (float)(N - 1)) + center[0], center[1] - 0.02f - dy * 5.5f, 1.235f * r * Mathf.Sin(2f * PI * i / (float)(N - 1)) + center[2]);
        }

        nextVert = nextVert + N;
        for (int i = 0; i < N; i++)
        {
            vertices[nextVert + i] = new Vector3(1.235f * r * Mathf.Cos(2f * PI * i / (float)(N - 1)) + center[0], center[1] - 0.02f - dy * 5.75f, 1.235f * r * Mathf.Sin(2f * PI * i / (float)(N - 1)) + center[2]);
        }

        nextVert = nextVert + N;
        for (int i = 0; i < N; i++)
        {
            vertices[nextVert + i] = new Vector3(1.2f * r * Mathf.Cos(2f * PI * i / (float)(N - 1)) + center[0], center[1] - 0.02f - dy * 6f, 1.2f * r * Mathf.Sin(2f * PI * i / (float)(N - 1)) + center[2]);
        }

        nextVert = nextVert + N;
        for (int i = 0; i < N; i++)
        {
            vertices[nextVert + i] = new Vector3(1.1f * r * Mathf.Cos(2f * PI * i / (float)(N - 1)) + center[0], center[1] - 0.02f - dy * 6.25f, 1.1f * r * Mathf.Sin(2f * PI * i / (float)(N - 1)) + center[2]);
        }


        for (int i = 0; i<vertices.Length; i++)
        {
            vertices[i] = vertices[i] + POS;
        }

        //        uvs[0] = new Vector2(vertices[0].x, vertices[0].y);

        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3] = i;
            triangles[i3 + 1] = i + 1;
            triangles[i3 + 2] = N + i;
        }
        int nextTri = 3 * N;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3] = N + i;
            triangles[nextTri + i3 + 1] = i + 1;
            triangles[nextTri + i3 + 2] = N + i + 1;
        }

        nextTri = nextTri + 3 * N;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3] = N + i;
            triangles[nextTri + i3 + 1] = N + i + 1;
            triangles[nextTri + i3 + 2] = 2 * N + i;
        }
        nextTri = nextTri + 3 * N;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3] = 2 * N + i;
            triangles[nextTri + i3 + 1] = N + i + 1;
            triangles[nextTri + i3 + 2] = 2 * N + i + 1;
        }

        nextTri = nextTri + 3 * N;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3] = 2 * N + i;
            triangles[nextTri + i3 + 1] = 2 * N + i + 1;
            triangles[nextTri + i3 + 2] = 3 * N + i;
        }
        nextTri = nextTri + 3 * N;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3] = 3 * N + i;
            triangles[nextTri + i3 + 1] = 2 * N + i + 1;
            triangles[nextTri + i3 + 2] = 3 * N + i + 1;
        }

        nextTri = nextTri + 3 * N;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3] = 3 * N + i;
            triangles[nextTri + i3 + 1] = 3 * N + i + 1;
            triangles[nextTri + i3 + 2] = 4 * N + i;
        }
        nextTri = nextTri + 3 * N;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3] = 4 * N + i;
            triangles[nextTri + i3 + 1] = 3 * N + i + 1;
            triangles[nextTri + i3 + 2] = 4 * N + i + 1;
        }

        nextTri = nextTri + 3 * N;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3] = 4 * N + i;
            triangles[nextTri + i3 + 1] = 4 * N + i + 1;
            triangles[nextTri + i3 + 2] = 5 * N + i;
        }
        nextTri = nextTri + 3 * N;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3] = 5 * N + i;
            triangles[nextTri + i3 + 1] = 4 * N + i + 1;
            triangles[nextTri + i3 + 2] = 5 * N + i + 1;
        }


        /*
        vertices[0] = new Vector3(0.04221003f, 0.3478321f, -0.9583334f) + POS;
        vertices[1] = new Vector3(0.03906007f, 0.3478321f, -0.9455535f) + POS;
        vertices[2] = new Vector3(0.03033181f, 0.3478321f, -0.9357013f) + POS;
        vertices[3] = new Vector3(0.01802479f, 0.3478321f, -0.9310338f) + POS;
        vertices[4] = new Vector3(0.004958391f, 0.3478321f, -0.9326204f) + POS;
        vertices[5] = new Vector3(-0.00587402f, 0.3478321f, -0.9400975f) + POS;
        vertices[6] = new Vector3(-0.01199087f, 0.3478321f, -0.9517522f) + POS;
        vertices[7] = new Vector3(-0.01199087f, 0.3478321f, -0.9649146f) + POS;
        vertices[8] = new Vector3(-0.005874016f, 0.3478321f, -0.9765692f) + POS;
        vertices[9] = new Vector3(0.004958401f, 0.3478321f, -0.9840463f) + POS;
        vertices[10] = new Vector3(0.01802479f, 0.3478321f, -0.9856329f) + POS;
        vertices[11] = new Vector3(0.03033181f, 0.3478321f, -0.9809654f) + POS;
        vertices[12] = new Vector3(0.03906007f, 0.3478321f, -0.9711133f) + POS;
        vertices[13] = new Vector3(0.04221003f, 0.3478321f, -0.9583334f) + POS;
        vertices[14] = new Vector3(0.04471003f, 0.345879f, -0.9583334f) + POS;
        vertices[15] = new Vector3(0.04127371f, 0.345879f, -0.9443917f) + POS;
        vertices[16] = new Vector3(0.03175197f, 0.345879f, -0.9336439f) + POS;
        vertices[17] = new Vector3(0.01832613f, 0.345879f, -0.9285521f) + POS;
        vertices[18] = new Vector3(0.004071878f, 0.345879f, -0.9302829f) + POS;
        vertices[19] = new Vector3(-0.007745297f, 0.345879f, -0.9384397f) + POS;
        vertices[20] = new Vector3(-0.01441823f, 0.345879f, -0.9511539f) + POS;
        vertices[21] = new Vector3(-0.01441823f, 0.345879f, -0.9655129f) + POS;
        vertices[22] = new Vector3(-0.007745293f, 0.345879f, -0.9782271f) + POS;
        vertices[23] = new Vector3(0.00407189f, 0.345879f, -0.9863839f) + POS;
        vertices[24] = new Vector3(0.01832613f, 0.345879f, -0.9881147f) + POS;
        vertices[25] = new Vector3(0.03175198f, 0.345879f, -0.9830229f) + POS;
        vertices[26] = new Vector3(0.04127371f, 0.345879f, -0.9722751f) + POS;
        vertices[27] = new Vector3(0.04471003f, 0.345879f, -0.9583334f) + POS;
        vertices[28] = new Vector3(0.04558503f, 0.3439258f, -0.9583334f) + POS;
        vertices[29] = new Vector3(0.04204848f, 0.3439258f, -0.943985f) + POS;
        vertices[30] = new Vector3(0.03224903f, 0.3439258f, -0.9329237f) + POS;
        vertices[31] = new Vector3(0.0184316f, 0.3439258f, -0.9276835f) + POS;
        vertices[32] = new Vector3(0.003761599f, 0.3439258f, -0.9294648f) + POS;
        vertices[33] = new Vector3(-0.008400243f, 0.3439258f, -0.9378595f) + POS;
        vertices[34] = new Vector3(-0.0152678f, 0.3439258f, -0.9509445f) + POS;
        vertices[35] = new Vector3(-0.0152678f, 0.3439258f, -0.9657223f) + POS;
        vertices[36] = new Vector3(-0.008400239f, 0.3439258f, -0.9788073f) + POS;
        vertices[37] = new Vector3(0.003761611f, 0.3439258f, -0.987202f) + POS;
        vertices[38] = new Vector3(0.0184316f, 0.3439258f, -0.9889833f) + POS;
        vertices[39] = new Vector3(0.03224903f, 0.3439258f, -0.983743f) + POS;
        vertices[40] = new Vector3(0.04204848f, 0.3439258f, -0.9726817f) + POS;
        vertices[41] = new Vector3(0.04558503f, 0.3439258f, -0.9583334f) + POS;
        vertices[42] = new Vector3(0.04558503f, 0.3419727f, -0.9583334f) + POS;
        vertices[43] = new Vector3(0.04204848f, 0.3419727f, -0.943985f) + POS;
        vertices[44] = new Vector3(0.03224903f, 0.3419727f, -0.9329237f) + POS;
        vertices[45] = new Vector3(0.0184316f, 0.3419727f, -0.9276835f) + POS;
        vertices[46] = new Vector3(0.003761599f, 0.3419727f, -0.9294648f) + POS;
        vertices[47] = new Vector3(-0.008400243f, 0.3419727f, -0.9378595f) + POS;
        vertices[48] = new Vector3(-0.0152678f, 0.3419727f, -0.9509445f) + POS;
        vertices[49] = new Vector3(-0.0152678f, 0.3419727f, -0.9657223f) + POS;
        vertices[50] = new Vector3(-0.008400239f, 0.3419727f, -0.9788073f) + POS;
        vertices[51] = new Vector3(0.003761611f, 0.3419727f, -0.987202f) + POS;
        vertices[52] = new Vector3(0.0184316f, 0.3419727f, -0.9889833f) + POS;
        vertices[53] = new Vector3(0.03224903f, 0.3419727f, -0.983743f) + POS;
        vertices[54] = new Vector3(0.04204848f, 0.3419727f, -0.9726817f) + POS;
        vertices[55] = new Vector3(0.04558503f, 0.3419727f, -0.9583334f) + POS;
        vertices[56] = new Vector3(0.04471003f, 0.3400196f, -0.9583334f) + POS;
        vertices[57] = new Vector3(0.04127371f, 0.3400196f, -0.9443917f) + POS;
        vertices[58] = new Vector3(0.03175197f, 0.3400196f, -0.9336439f) + POS;
        vertices[59] = new Vector3(0.01832613f, 0.3400196f, -0.9285521f) + POS;
        vertices[60] = new Vector3(0.004071878f, 0.3400196f, -0.9302829f) + POS;
        vertices[61] = new Vector3(-0.007745297f, 0.3400196f, -0.9384397f) + POS;
        vertices[62] = new Vector3(-0.01441823f, 0.3400196f, -0.9511539f) + POS;
        vertices[63] = new Vector3(-0.01441823f, 0.3400196f, -0.9655129f) + POS;
        vertices[64] = new Vector3(-0.007745293f, 0.3400196f, -0.9782271f) + POS;
        vertices[65] = new Vector3(0.00407189f, 0.3400196f, -0.9863839f) + POS;
        vertices[66] = new Vector3(0.01832613f, 0.3400196f, -0.9881147f) + POS;
        vertices[67] = new Vector3(0.03175198f, 0.3400196f, -0.9830229f) + POS;
        vertices[68] = new Vector3(0.04127371f, 0.3400196f, -0.9722751f) + POS;
        vertices[69] = new Vector3(0.04471003f, 0.3400196f, -0.9583334f) + POS;
        vertices[70] = new Vector3(0.04221003f, 0.3380665f, -0.9583334f) + POS;
        vertices[71] = new Vector3(0.03906007f, 0.3380665f, -0.9455535f) + POS;
        vertices[72] = new Vector3(0.03033181f, 0.3380665f, -0.9357013f) + POS;
        vertices[73] = new Vector3(0.01802479f, 0.3380665f, -0.9310338f) + POS;
        vertices[74] = new Vector3(0.004958391f, 0.3380665f, -0.9326204f) + POS;
        vertices[75] = new Vector3(-0.00587402f, 0.3380665f, -0.9400975f) + POS;
        vertices[76] = new Vector3(-0.01199087f, 0.3380665f, -0.9517522f) + POS;
        vertices[77] = new Vector3(-0.01199087f, 0.3380665f, -0.9649146f) + POS;
        vertices[78] = new Vector3(-0.005874016f, 0.3380665f, -0.9765692f) + POS;
        vertices[79] = new Vector3(0.004958401f, 0.3380665f, -0.9840463f) + POS;
        vertices[80] = new Vector3(0.01802479f, 0.3380665f, -0.9856329f) + POS;
        vertices[81] = new Vector3(0.03033181f, 0.3380665f, -0.9809654f) + POS;
        vertices[82] = new Vector3(0.03906007f, 0.3380665f, -0.9711133f) + POS;
        vertices[83] = new Vector3(0.04221003f, 0.3380665f, -0.9583334f) + POS;





        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 14;
        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 15;
        triangles[6] = 2;
        triangles[7] = 3;
        triangles[8] = 16;
        triangles[9] = 3;
        triangles[10] = 4;
        triangles[11] = 17;
        triangles[12] = 4;
        triangles[13] = 5;
        triangles[14] = 18;
        triangles[15] = 5;
        triangles[16] = 6;
        triangles[17] = 19;
        triangles[18] = 6;
        triangles[19] = 7;
        triangles[20] = 20;
        triangles[21] = 7;
        triangles[22] = 8;
        triangles[23] = 21;
        triangles[24] = 8;
        triangles[25] = 9;
        triangles[26] = 22;
        triangles[27] = 9;
        triangles[28] = 10;
        triangles[29] = 23;
        triangles[30] = 10;
        triangles[31] = 11;
        triangles[32] = 24;
        triangles[33] = 11;
        triangles[34] = 12;
        triangles[35] = 25;
        triangles[36] = 12;
        triangles[37] = 13;
        triangles[38] = 26;
        triangles[39] = 0;
        triangles[40] = 0;
        triangles[41] = 0;
        triangles[42] = 14;
        triangles[43] = 1;
        triangles[44] = 15;
        triangles[45] = 15;
        triangles[46] = 2;
        triangles[47] = 16;
        triangles[48] = 16;
        triangles[49] = 3;
        triangles[50] = 17;
        triangles[51] = 17;
        triangles[52] = 4;
        triangles[53] = 18;
        triangles[54] = 18;
        triangles[55] = 5;
        triangles[56] = 19;
        triangles[57] = 19;
        triangles[58] = 6;
        triangles[59] = 20;
        triangles[60] = 20;
        triangles[61] = 7;
        triangles[62] = 21;
        triangles[63] = 21;
        triangles[64] = 8;
        triangles[65] = 22;
        triangles[66] = 22;
        triangles[67] = 9;
        triangles[68] = 23;
        triangles[69] = 23;
        triangles[70] = 10;
        triangles[71] = 24;
        triangles[72] = 24;
        triangles[73] = 11;
        triangles[74] = 25;
        triangles[75] = 25;
        triangles[76] = 12;
        triangles[77] = 26;
        triangles[78] = 26;
        triangles[79] = 13;
        triangles[80] = 27;
        triangles[84] = 14;
        triangles[85] = 15;
        triangles[86] = 28;
        triangles[87] = 15;
        triangles[88] = 16;
        triangles[89] = 29;
        triangles[90] = 16;
        triangles[91] = 17;
        triangles[92] = 30;
        triangles[93] = 17;
        triangles[94] = 18;
        triangles[95] = 31;
        triangles[96] = 18;
        triangles[97] = 19;
        triangles[98] = 32;
        triangles[99] = 19;
        triangles[100] = 20;
        triangles[101] = 33;
        triangles[102] = 20;
        triangles[103] = 21;
        triangles[104] = 34;
        triangles[105] = 21;
        triangles[106] = 22;
        triangles[107] = 35;
        triangles[108] = 22;
        triangles[109] = 23;
        triangles[110] = 36;
        triangles[111] = 23;
        triangles[112] = 24;
        triangles[113] = 37;
        triangles[114] = 24;
        triangles[115] = 25;
        triangles[116] = 38;
        triangles[117] = 25;
        triangles[118] = 26;
        triangles[119] = 39;
        triangles[120] = 26;
        triangles[121] = 27;
        triangles[122] = 40;
        triangles[126] = 28;
        triangles[127] = 15;
        triangles[128] = 29;
        triangles[129] = 29;
        triangles[130] = 16;
        triangles[131] = 30;
        triangles[132] = 30;
        triangles[133] = 17;
        triangles[134] = 31;
        triangles[135] = 31;
        triangles[136] = 18;
        triangles[137] = 32;
        triangles[138] = 32;
        triangles[139] = 19;
        triangles[140] = 33;
        triangles[141] = 33;
        triangles[142] = 20;
        triangles[143] = 34;
        triangles[144] = 34;
        triangles[145] = 21;
        triangles[146] = 35;
        triangles[147] = 35;
        triangles[148] = 22;
        triangles[149] = 36;
        triangles[150] = 36;
        triangles[151] = 23;
        triangles[152] = 37;
        triangles[153] = 37;
        triangles[154] = 24;
        triangles[155] = 38;
        triangles[156] = 38;
        triangles[157] = 25;
        triangles[158] = 39;
        triangles[159] = 39;
        triangles[160] = 26;
        triangles[161] = 40;
        triangles[162] = 40;
        triangles[163] = 27;
        triangles[164] = 41;
        triangles[165] = 0;
        triangles[166] = 0;
        triangles[167] = 0;
        triangles[168] = 28;
        triangles[169] = 29;
        triangles[170] = 42;
        triangles[171] = 29;
        triangles[172] = 30;
        triangles[173] = 43;
        triangles[174] = 30;
        triangles[175] = 31;
        triangles[176] = 44;
        triangles[177] = 31;
        triangles[178] = 32;
        triangles[179] = 45;
        triangles[180] = 32;
        triangles[181] = 33;
        triangles[182] = 46;
        triangles[183] = 33;
        triangles[184] = 34;
        triangles[185] = 47;
        triangles[186] = 34;
        triangles[187] = 35;
        triangles[188] = 48;
        triangles[189] = 35;
        triangles[190] = 36;
        triangles[191] = 49;
        triangles[192] = 36;
        triangles[193] = 37;
        triangles[194] = 50;
        triangles[195] = 37;
        triangles[196] = 38;
        triangles[197] = 51;
        triangles[198] = 38;
        triangles[199] = 39;
        triangles[200] = 52;
        triangles[201] = 39;
        triangles[202] = 40;
        triangles[203] = 53;
        triangles[204] = 40;
        triangles[205] = 41;
        triangles[206] = 54;
        triangles[210] = 42;
        triangles[211] = 29;
        triangles[212] = 43;
        triangles[213] = 43;
        triangles[214] = 30;
        triangles[215] = 44;
        triangles[216] = 44;
        triangles[217] = 31;
        triangles[218] = 45;
        triangles[219] = 45;
        triangles[220] = 32;
        triangles[221] = 46;
        triangles[222] = 46;
        triangles[223] = 33;
        triangles[224] = 47;
        triangles[225] = 47;
        triangles[226] = 34;
        triangles[227] = 48;
        triangles[228] = 48;
        triangles[229] = 35;
        triangles[230] = 49;
        triangles[231] = 49;
        triangles[232] = 36;
        triangles[233] = 50;
        triangles[234] = 50;
        triangles[235] = 37;
        triangles[236] = 51;
        triangles[237] = 51;
        triangles[238] = 38;
        triangles[239] = 52;
        triangles[240] = 52;
        triangles[241] = 39;
        triangles[242] = 53;
        triangles[243] = 53;
        triangles[244] = 40;
        triangles[245] = 54;
        triangles[246] = 54;
        triangles[247] = 41;
        triangles[248] = 55;
        triangles[252] = 42;
        triangles[253] = 43;
        triangles[254] = 56;
        triangles[255] = 43;
        triangles[256] = 44;
        triangles[257] = 57;
        triangles[258] = 44;
        triangles[259] = 45;
        triangles[260] = 58;
        triangles[261] = 45;
        triangles[262] = 46;
        triangles[263] = 59;
        triangles[264] = 46;
        triangles[265] = 47;
        triangles[266] = 60;
        triangles[267] = 47;
        triangles[268] = 48;
        triangles[269] = 61;
        triangles[270] = 48;
        triangles[271] = 49;
        triangles[272] = 62;
        triangles[273] = 49;
        triangles[274] = 50;
        triangles[275] = 63;
        triangles[276] = 50;
        triangles[277] = 51;
        triangles[278] = 64;
        triangles[279] = 51;
        triangles[280] = 52;
        triangles[281] = 65;
        triangles[282] = 52;
        triangles[283] = 53;
        triangles[284] = 66;
        triangles[285] = 53;
        triangles[286] = 54;
        triangles[287] = 67;
        triangles[288] = 54;
        triangles[289] = 55;
        triangles[290] = 68;
        triangles[294] = 56;
        triangles[295] = 43;
        triangles[296] = 57;
        triangles[297] = 57;
        triangles[298] = 44;
        triangles[299] = 58;
        triangles[300] = 58;
        triangles[301] = 45;
        triangles[302] = 59;
        triangles[303] = 59;
        triangles[304] = 46;
        triangles[305] = 60;
        triangles[306] = 60;
        triangles[307] = 47;
        triangles[308] = 61;
        triangles[309] = 61;
        triangles[310] = 48;
        triangles[311] = 62;
        triangles[312] = 62;
        triangles[313] = 49;
        triangles[314] = 63;
        triangles[315] = 63;
        triangles[316] = 50;
        triangles[317] = 64;
        triangles[318] = 64;
        triangles[319] = 51;
        triangles[320] = 65;
        triangles[321] = 65;
        triangles[322] = 52;
        triangles[323] = 66;
        triangles[324] = 66;
        triangles[325] = 53;
        triangles[326] = 67;
        triangles[327] = 67;
        triangles[328] = 54;
        triangles[329] = 68;
        triangles[330] = 68;
        triangles[331] = 55;
        triangles[332] = 69;
        triangles[336] = 56;
        triangles[337] = 57;
        triangles[338] = 70;
        triangles[339] = 57;
        triangles[340] = 58;
        triangles[341] = 71;
        triangles[342] = 58;
        triangles[343] = 59;
        triangles[344] = 72;
        triangles[345] = 59;
        triangles[346] = 60;
        triangles[347] = 73;
        triangles[348] = 60;
        triangles[349] = 61;
        triangles[350] = 74;
        triangles[351] = 61;
        triangles[352] = 62;
        triangles[353] = 75;
        triangles[354] = 62;
        triangles[355] = 63;
        triangles[356] = 76;
        triangles[357] = 63;
        triangles[358] = 64;
        triangles[359] = 77;
        triangles[360] = 64;
        triangles[361] = 65;
        triangles[362] = 78;
        triangles[363] = 65;
        triangles[364] = 66;
        triangles[365] = 79;
        triangles[366] = 66;
        triangles[367] = 67;
        triangles[368] = 80;
        triangles[369] = 67;
        triangles[370] = 68;
        triangles[371] = 81;
        triangles[372] = 68;
        triangles[373] = 69;
        triangles[374] = 82;
        triangles[378] = 70;
        triangles[379] = 57;
        triangles[380] = 71;
        triangles[381] = 71;
        triangles[382] = 58;
        triangles[383] = 72;
        triangles[384] = 72;
        triangles[385] = 59;
        triangles[386] = 73;
        triangles[387] = 73;
        triangles[388] = 60;
        triangles[389] = 74;
        triangles[390] = 74;
        triangles[391] = 61;
        triangles[392] = 75;
        triangles[393] = 75;
        triangles[394] = 62;
        triangles[395] = 76;
        triangles[396] = 76;
        triangles[397] = 63;
        triangles[398] = 77;
        triangles[399] = 77;
        triangles[400] = 64;
        triangles[401] = 78;
        triangles[402] = 78;
        triangles[403] = 65;
        triangles[404] = 79;
        triangles[405] = 79;
        triangles[406] = 66;
        triangles[407] = 80;
        triangles[408] = 80;
        triangles[409] = 67;
        triangles[410] = 81;
        triangles[411] = 81;
        triangles[412] = 68;
        triangles[413] = 82;
        triangles[414] = 82;
        triangles[415] = 69;
        triangles[416] = 83;





        uvs[0] = new Vector2(0f, 0f);
        uvs[1] = new Vector2(0f, 0f);
        uvs[2] = new Vector2(0f, 0f);
        uvs[3] = new Vector2(0f, 0f);
        uvs[4] = new Vector2(0f, 0f);
        uvs[5] = new Vector2(0f, 0f);
        uvs[6] = new Vector2(0f, 0f);
        uvs[7] = new Vector2(0f, 0f);
        uvs[8] = new Vector2(0f, 0f);
        uvs[9] = new Vector2(0f, 0f);
        uvs[10] = new Vector2(0f, 0f);
        uvs[11] = new Vector2(0f, 0f);
        uvs[12] = new Vector2(0f, 0f);
        uvs[13] = new Vector2(0f, 0f);
        uvs[14] = new Vector2(0f, 0f);
        uvs[15] = new Vector2(0f, 0f);
        uvs[16] = new Vector2(0f, 0f);
        uvs[17] = new Vector2(0f, 0f);
        uvs[18] = new Vector2(0f, 0f);
        uvs[19] = new Vector2(0f, 0f);
        uvs[20] = new Vector2(0f, 0f);
        uvs[21] = new Vector2(0f, 0f);
        uvs[22] = new Vector2(0f, 0f);
        uvs[23] = new Vector2(0f, 0f);
        uvs[24] = new Vector2(0f, 0f);
        uvs[25] = new Vector2(0f, 0f);
        uvs[26] = new Vector2(0f, 0f);
        uvs[27] = new Vector2(0f, 0f);
        uvs[28] = new Vector2(0f, 0f);
        uvs[29] = new Vector2(0f, 0f);
        uvs[30] = new Vector2(0f, 0f);
        uvs[31] = new Vector2(0f, 0f);
        uvs[32] = new Vector2(0f, 0f);
        uvs[33] = new Vector2(0f, 0f);
        uvs[34] = new Vector2(0f, 0f);
        uvs[35] = new Vector2(0f, 0f);
        uvs[36] = new Vector2(0f, 0f);
        uvs[37] = new Vector2(0f, 0f);
        uvs[38] = new Vector2(0f, 0f);
        uvs[39] = new Vector2(0f, 0f);
        uvs[40] = new Vector2(0f, 0f);
        uvs[41] = new Vector2(0f, 0f);
        uvs[42] = new Vector2(0f, 0f);
        uvs[43] = new Vector2(0f, 0f);
        uvs[44] = new Vector2(0f, 0f);
        uvs[45] = new Vector2(0f, 0f);
        uvs[46] = new Vector2(0f, 0f);
        uvs[47] = new Vector2(0f, 0f);
        uvs[48] = new Vector2(0f, 0f);
        uvs[49] = new Vector2(0f, 0f);
        uvs[50] = new Vector2(0f, 0f);
        uvs[51] = new Vector2(0f, 0f);
        uvs[52] = new Vector2(0f, 0f);
        uvs[53] = new Vector2(0f, 0f);
        uvs[54] = new Vector2(0f, 0f);
        uvs[55] = new Vector2(0f, 0f);
        uvs[56] = new Vector2(0f, 0f);
        uvs[57] = new Vector2(0f, 0f);
        uvs[58] = new Vector2(0f, 0f);
        uvs[59] = new Vector2(0f, 0f);
        uvs[60] = new Vector2(0f, 0f);
        uvs[61] = new Vector2(0f, 0f);
        uvs[62] = new Vector2(0f, 0f);
        uvs[63] = new Vector2(0f, 0f);
        uvs[64] = new Vector2(0f, 0f);
        uvs[65] = new Vector2(0f, 0f);
        uvs[66] = new Vector2(0f, 0f);
        uvs[67] = new Vector2(0f, 0f);
        uvs[68] = new Vector2(0f, 0f);
        uvs[69] = new Vector2(0f, 0f);
        uvs[70] = new Vector2(0f, 0f);
        uvs[71] = new Vector2(0f, 0f);
        uvs[72] = new Vector2(0f, 0f);
        uvs[73] = new Vector2(0f, 0f);
        uvs[74] = new Vector2(0f, 0f);
        uvs[75] = new Vector2(0f, 0f);
        uvs[76] = new Vector2(0f, 0f);
        uvs[77] = new Vector2(0f, 0f);
        uvs[78] = new Vector2(0f, 0f);
        uvs[79] = new Vector2(0f, 0f);
        uvs[80] = new Vector2(0f, 0f);
        uvs[81] = new Vector2(0f, 0f);
        uvs[82] = new Vector2(0f, 0f);
        uvs[83] = new Vector2(0f, 0f);
        */

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