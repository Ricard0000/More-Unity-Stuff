using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh5 : MonoBehaviour
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

        vertices = new Vector3[65];
        triangles = new int[138];
        uvs = new Vector2[65];
        float meshScale = 4f;



        float moveBack = -0.05f;
        vertices[0] = new Vector3(0f, 0f, 0f);
        vertices[1] = new Vector3(0f, 0f, 0f);
        vertices[2] = new Vector3(-0.24375f, 0.02817959f, -0.9270834f);
        vertices[3] = new Vector3(0.40625f, 0.02817959f, -0.9270834f);
        vertices[4] = new Vector3(0.40625f, -0.2816955f, -0.9270834f);
        vertices[5] = new Vector3(0.40625f, 0.4380546f, -0.9270834f);

        vertices[6] = new Vector3(-0.24375f, 0.3068946f, -0.9270834f);
        vertices[7] = new Vector3(-0.241266f, 0.3570874f, -0.9270834f);
        vertices[8] = new Vector3(-0.2203341f, 0.3996387f, -0.9270834f);

        vertices[9] = new Vector3(-0.1852827f, 0.4280706f, -0.9270834f);
        vertices[10] = new Vector3(-0.14259f, 0.4380546f, -0.9270834f);
        vertices[11] = new Vector3(-0.14259f, 0.4380546f, -0.9270834f);
        vertices[12] = new Vector3(-0.0998973f, 0.4280706f, -0.9270834f);
        vertices[13] = new Vector3(-0.0648459f, 0.3996387f, -0.9270834f);
        vertices[14] = new Vector3(-0.04391401f, 0.3570873f, -0.9270834f);
        vertices[15] = new Vector3(-0.04143f, 0.3068946f, -0.9270834f);

        vertices[16] = new Vector3(0.04364002f, 0.4380546f, -0.9270834f);
        vertices[17] = new Vector3(0.24596f, 0.4380546f, -0.9270834f);
        vertices[18] = new Vector3(0.24596f, 0.02817959f, -0.9270834f);
        vertices[19] = new Vector3(0.24596f, 0.3068946f, -0.9270834f);
        vertices[20] = new Vector3(0.243476f, 0.3570874f, -0.9270834f);
        vertices[21] = new Vector3(0.2225441f, 0.3996387f, -0.9270834f);
        vertices[22] = new Vector3(0.1874927f, 0.4280706f, -0.9270834f);
        vertices[23] = new Vector3(0.14201f, 0.4380546f, -0.9270834f);
        vertices[24] = new Vector3(0.1448f, 0.4380546f, -0.9270834f);
        vertices[25] = new Vector3(0.1021073f, 0.4280706f, -0.9270834f);
        vertices[26] = new Vector3(0.06705593f, 0.3996387f, -0.9270834f);
        vertices[27] = new Vector3(0.04612403f, 0.3570873f, -0.9270834f);
        vertices[28] = new Vector3(0.04364002f, 0.3068946f, -0.9270834f);
        vertices[29] = new Vector3(-0.04143f, 0.4380546f, -0.9270834f);
        vertices[30] = new Vector3(-0.24375f, 0.5380546f, -0.9270834f);
        vertices[31] = new Vector3(0.40625f, 0.5380546f, -0.9270834f);


        vertices[32] = new Vector3(0f, 0f, 0f);
        vertices[33] = new Vector3(-0.24375f, -0.2816955f, -0.9895834f + moveBack);
        vertices[34] = new Vector3(-0.24375f, 0.02817959f, -0.9895834f + moveBack);
        vertices[35] = new Vector3(0.40625f, 0.02817959f, -0.9895834f + moveBack);
        vertices[36] = new Vector3(0.40625f, -0.2816955f, -0.9895834f + moveBack);
        vertices[37] = new Vector3(0.40625f, 0.4380546f, -0.9895834f + moveBack);
        vertices[38] = new Vector3(-0.24375f, 0.3068946f, -0.9895834f + moveBack);
        vertices[39] = new Vector3(-0.241266f, 0.3570874f, -0.9895834f + moveBack);
        vertices[40] = new Vector3(-0.2203341f, 0.3996387f, -0.9895834f + moveBack);
        vertices[41] = new Vector3(-0.1852827f, 0.4280706f, -0.9895834f + moveBack);
        vertices[42] = new Vector3(-0.14259f, 0.4380546f, -0.9895834f + moveBack);
        vertices[43] = new Vector3(-0.14259f, 0.4380546f, -0.9895834f + moveBack);
        vertices[44] = new Vector3(-0.0998973f, 0.4280706f, -0.9895834f + moveBack);
        vertices[45] = new Vector3(-0.0648459f, 0.3996387f, -0.9895834f + moveBack);
        vertices[46] = new Vector3(-0.04391401f, 0.3570873f, -0.9895834f + moveBack);
        vertices[47] = new Vector3(-0.04143f, 0.3068946f, -0.9895834f + moveBack);
        vertices[48] = new Vector3(0.04364002f, 0.4380546f, -0.9895834f + moveBack);
        vertices[49] = new Vector3(0.24596f, 0.4380546f, -0.9895834f + moveBack);
        vertices[50] = new Vector3(0.24596f, 0.02817959f, -0.9895834f + moveBack);
        vertices[51] = new Vector3(0.24596f, 0.3068946f, -0.9895834f + moveBack);
        vertices[52] = new Vector3(0.243476f, 0.3570874f, -0.9895834f + moveBack);
        vertices[53] = new Vector3(0.2225441f, 0.3996387f, -0.9895834f + moveBack);
        vertices[54] = new Vector3(0.1874927f, 0.4280706f, -0.9895834f + moveBack);
        vertices[55] = new Vector3(0.14201f, 0.4380546f, -0.9895834f + moveBack);
        vertices[56] = new Vector3(0.1448f, 0.4380546f, -0.9895834f + moveBack);
        vertices[57] = new Vector3(0.1021073f, 0.4280706f, -0.9895834f + moveBack);
        vertices[58] = new Vector3(0.06705593f, 0.3996387f, -0.9895834f + moveBack);
        vertices[59] = new Vector3(0.04612403f, 0.3570873f, -0.9895834f + moveBack);
        vertices[60] = new Vector3(0.04364002f, 0.3068946f, -0.9895834f + moveBack);
        vertices[61] = new Vector3(-0.04143f, 0.4380546f, -0.9895834f + moveBack);
        vertices[62] = new Vector3(-0.24375f, 0.5380546f, -0.9895834f + moveBack);
        vertices[63] = new Vector3(0.40625f, 0.5380546f, -0.9895834f + moveBack);




        // Right arch Tris
        triangles[0] = 6;
        triangles[1] = 38;
        triangles[2] = 39;

        triangles[3] = 6;
        triangles[4] = 39;
        triangles[5] = 7;



        triangles[6] = 7;
        triangles[7] = 39;
        triangles[8] = 40;

        triangles[9] = 7;
        triangles[10] = 40;
        triangles[11] = 8;


        triangles[12] = 8;
        triangles[13] = 40;
        triangles[14] = 41;

        triangles[15] = 8;
        triangles[16] = 41;
        triangles[17] = 9;


        triangles[18] = 9;
        triangles[19] = 41;
        triangles[20] = 42;

        triangles[21] = 9;
        triangles[22] = 42;
        triangles[23] = 10;

        
        triangles[24] = 11;
        triangles[25] = 43;
        triangles[26] = 12;

        triangles[27] = 12;
        triangles[28] = 43;
        triangles[29] = 44;

        triangles[30] = 12;
        triangles[31] = 44;
        triangles[32] = 13;

        triangles[33] = 13;
        triangles[34] = 44;
        triangles[35] = 45;


        triangles[36] = 13;
        triangles[37] = 45;
        triangles[38] = 14;

        triangles[39] = 14;
        triangles[40] = 45;
        triangles[41] = 46;

        triangles[42] = 14;
        triangles[43] = 46;
        triangles[44] = 15;

        triangles[45] = 15;
        triangles[46] = 46;
        triangles[47] = 47;
        // Right arch Tris
        
        triangles[48] = 18;
        triangles[49] = 51;
        triangles[50] = 50;




        triangles[51] = 18;
        triangles[52] = 19;
        triangles[53] = 51;

        triangles[54] = 19;
        triangles[55] = 52;
        triangles[56] = 51;

        triangles[57] = 19;
        triangles[58] = 20;
        triangles[59] = 52;


        triangles[60] = 20;
        triangles[61] = 53;
        triangles[62] = 52;

        triangles[63] = 20;
        triangles[64] = 21;
        triangles[65] = 53;



        triangles[66] = 21;
        triangles[67] = 54;
        triangles[68] = 53;

        triangles[69] = 21;
        triangles[70] = 22;
        triangles[71] = 54;

        triangles[72] = 22;
        triangles[73] = 55;
        triangles[74] = 54;

        triangles[75] = 22;
        triangles[76] = 23;
        triangles[77] = 55;


        triangles[78] = 23;
        triangles[79] = 25;
        triangles[80] = 55;

        triangles[81] = 55;
        triangles[82] = 25;
        triangles[83] = 57;

        triangles[84] = 25;
        triangles[85] = 26;
        triangles[86] = 57;
        
        triangles[87] = 57;
        triangles[88] = 26;
        triangles[89] = 58;

        triangles[90] = 26;
        triangles[91] = 27;
        triangles[92] = 58;

        triangles[93] = 58;
        triangles[94] = 27;
        triangles[95] = 59;

        triangles[96] = 27;
        triangles[97] = 28;
        triangles[98] = 59;

        triangles[99] = 59;
        triangles[100] = 28;
        triangles[101] = 60;


        triangles[102] = 15;
        triangles[103] = 47;
        triangles[104] = 60;

        triangles[105] = 15;
        triangles[106] = 60;
        triangles[107] = 28;





        triangles[108] = 6;
        triangles[109] = 34;
        triangles[110] = 38;


        triangles[111] = 2;
        triangles[112] = 34;
        triangles[113] = 6;


        triangles[114] = 50;
        triangles[115] = 2;
        triangles[116] = 18;

        triangles[117] = 34;
        triangles[118] = 2;
        triangles[119] = 50;



        /*
        vertices[8] = new Vector3(-0.2203341f, 0.3996387f + low, -0.9270834f);
        vertices[9] = new Vector3(-0.1852827f, 0.4280706f + low, -0.9270834f);
        vertices[10] = new Vector3(-0.14259f, 0.4380546f + low, -0.9270834f);
        vertices[11] = new Vector3(-0.14259f, 0.4380546f + low, -0.9270834f);
        vertices[12] = new Vector3(-0.0998973f, 0.4280706f + low, -0.9270834f);
        */



        /*
        float low = -0.1f;
        vertices[0] = new Vector3(-0.24375f, 0.1281796f + low, -0.9270834f);
        vertices[1] = new Vector3(0.50625f, 0.1281796f + low, -0.9270834f);

        vertices[2] = new Vector3(0.27275f, 0.1281796f + low, -0.9270834f);
        vertices[3] = new Vector3(0.27317f, 0.4068946f + low, -0.9270834f);
        vertices[4] = new Vector3(0.2631861f, 0.4570874f + low, -0.9270834f);
        vertices[5] = new Vector3(0.2347541f, 0.4996387f + low, -0.9270834f);
        vertices[6] = new Vector3(0.1922028f, 0.5280706f + low, -0.9270834f);
        vertices[7] = new Vector3(0.14201f, 0.5380546f + low, -0.9270834f);
        vertices[8] = new Vector3(0.1748f, 0.5380546f + low, -0.9270834f);
        vertices[9] = new Vector3(0.1246073f, 0.5280706f + low, -0.9270834f);
        vertices[10] = new Vector3(0.0820559f, 0.4996387f + low, -0.9270834f);
        vertices[11] = new Vector3(0.05362398f, 0.4570873f + low, -0.9270834f);
        vertices[12] = new Vector3(0.04364002f, 0.4068946f + low, -0.9270834f);

        vertices[13] = new Vector3(-0.01421997f, 0.4068946f + low, -0.9270834f);
        vertices[14] = new Vector3(-0.02420392f, 0.4570873f + low, -0.9270834f);
        vertices[15] = new Vector3(-0.05263584f, 0.4996387f + low, -0.9270834f);
        vertices[16] = new Vector3(-0.0951872f, 0.5280706f + low, -0.9270834f);
        vertices[17] = new Vector3(-0.14538f, 0.5380546f + low, -0.9270834f);
        vertices[18] = new Vector3(-0.11259f, 0.5380546f + low, -0.9270834f);
        vertices[19] = new Vector3(-0.1627827f, 0.5280706f + low, -0.9270834f);
        vertices[20] = new Vector3(-0.2053341f, 0.4996387f + low, -0.9270834f);
        vertices[21] = new Vector3(-0.233766f, 0.4570874f + low, -0.9270834f);
        vertices[22] = new Vector3(-0.24375f, 0.4068946f + low, -0.9270834f);

        vertices[23] = new Vector3(-0.24375f, 0.1281796f + low, -0.9895834f);
        vertices[24] = new Vector3(0.50625f, 0.1281796f + low, -0.9895834f);
        vertices[25] = new Vector3(0.27275f, 0.1281796f + low, -0.9895834f);
        vertices[26] = new Vector3(0.27317f, 0.4068946f + low, -0.9895834f);
        vertices[27] = new Vector3(0.2631861f, 0.4570874f + low, -0.9895834f);
        vertices[28] = new Vector3(0.2347541f, 0.4996387f + low, -0.9895834f);
        vertices[29] = new Vector3(0.1922028f, 0.5280706f + low, -0.9895834f);
        vertices[30] = new Vector3(0.14201f, 0.5380546f + low, -0.9895834f);
        vertices[31] = new Vector3(0.1748f, 0.5380546f + low, -0.9895834f);
        vertices[32] = new Vector3(0.1246073f, 0.5280706f + low, -0.9895834f);
        vertices[33] = new Vector3(0.0820559f, 0.4996387f + low, -0.9895834f);
        vertices[34] = new Vector3(0.05362398f, 0.4570873f + low, -0.9895834f);
        vertices[35] = new Vector3(0.04364002f, 0.4068946f + low, -0.9895834f);
        vertices[36] = new Vector3(-0.01421997f, 0.4068946f + low, -0.9895834f);
        vertices[37] = new Vector3(-0.02420392f, 0.4570873f + low, -0.9895834f);
        vertices[38] = new Vector3(-0.05263584f, 0.4996387f + low, -0.9895834f);
        vertices[39] = new Vector3(-0.0951872f, 0.5280706f + low, -0.9895834f);
        vertices[40] = new Vector3(-0.14538f, 0.5380546f + low, -0.9895834f);
        vertices[41] = new Vector3(-0.11259f, 0.5380546f + low, -0.9895834f);
        vertices[42] = new Vector3(-0.1627827f, 0.5280706f + low, -0.9895834f);
        vertices[43] = new Vector3(-0.2053341f, 0.4996387f + low, -0.9895834f);
        vertices[44] = new Vector3(-0.233766f, 0.4570874f + low, -0.9895834f);
        vertices[45] = new Vector3(-0.24375f, 0.4068946f + low, -0.9895834f);
*/



        /*
                triangles[0] = 0;
                triangles[1] = 1;
                triangles[2] = 23;

                triangles[3] = 1;
                triangles[4] = 2;
                triangles[5] = 24;

        //6 - 35 are left arch tris (2-12; 25 - 34)
        
                triangles[6] = 2;
                triangles[7] = 3;
                triangles[8] = 25;

                triangles[9] = 3;
                triangles[10] = 4;
                triangles[11] = 26;

        triangles[12] = 4;
        triangles[13] = 5;
        triangles[14] = 27;

        triangles[15] = 5;
        triangles[16] = 6;
        triangles[17] = 28;

        triangles[18] = 6;
        triangles[19] = 7;
        triangles[20] = 29;

        triangles[21] = 7;
        triangles[22] = 8;
        triangles[23] = 30;

        triangles[24] = 8;
        triangles[25] = 9;
        triangles[26] = 31;

        triangles[27] = 9;
        triangles[28] = 10;
        triangles[29] = 32;

        triangles[30] = 10;
        triangles[31] = 11;
        triangles[32] = 33;

        triangles[33] = 11;
        triangles[34] = 12;
        triangles[35] = 34;
                                
        triangles[36] = 12;
        triangles[37] = 13;
        triangles[38] = 35;
        triangles[39] = 13;
        triangles[40] = 14;
        triangles[41] = 36;
        triangles[42] = 14;
        triangles[43] = 15;
        triangles[44] = 37;
        triangles[45] = 15;
        triangles[46] = 16;
        triangles[47] = 38;
        triangles[48] = 16;
        triangles[49] = 17;
        triangles[50] = 39;
        triangles[51] = 17;
        triangles[52] = 18;
        triangles[53] = 40;
        triangles[54] = 18;
        triangles[55] = 19;
        triangles[56] = 41;
        triangles[57] = 19;
        triangles[58] = 20;
        triangles[59] = 42;
        triangles[60] = 20;
        triangles[61] = 21;
        triangles[62] = 43;
        triangles[63] = 21;
        triangles[64] = 22;
        triangles[65] = 44;
        triangles[66] = 24;
        triangles[67] = 23;
        triangles[68] = 1;
        triangles[69] = 25;
        triangles[70] = 24;
        triangles[71] = 2;
        triangles[72] = 26;
        triangles[73] = 25;
        triangles[74] = 3;
        triangles[75] = 27;
        triangles[76] = 26;
        triangles[77] = 4;
        triangles[78] = 28;
        triangles[79] = 27;
        triangles[80] = 5;
        triangles[81] = 29;
        triangles[82] = 28;
        triangles[83] = 6;
        triangles[84] = 30;
        triangles[85] = 29;
        triangles[86] = 7;
        triangles[87] = 31;
        triangles[88] = 30;
        triangles[89] = 8;
        triangles[90] = 32;
        triangles[91] = 31;
        triangles[92] = 9;
        triangles[93] = 33;
        triangles[94] = 32;
        triangles[95] = 10;
        triangles[96] = 34;
        triangles[97] = 33;
        triangles[98] = 11;
        triangles[99] = 35;
        triangles[100] = 34;
        triangles[101] = 12;
        triangles[102] = 36;
        triangles[103] = 35;
        triangles[104] = 13;
        triangles[105] = 37;
        triangles[106] = 36;
        triangles[107] = 14;
        triangles[108] = 38;
        triangles[109] = 37;
        triangles[110] = 15;
        triangles[111] = 39;
        triangles[112] = 38;
        triangles[113] = 16;
        triangles[114] = 40;
        triangles[115] = 39;
        triangles[116] = 17;
        triangles[117] = 41;
        triangles[118] = 40;
        triangles[119] = 18;
        triangles[120] = 42;
        triangles[121] = 41;
        triangles[122] = 19;
        triangles[123] = 43;
        triangles[124] = 42;
        triangles[125] = 20;
        triangles[126] = 44;
        triangles[127] = 43;
        triangles[128] = 21;
        triangles[129] = 45;
        triangles[130] = 44;
        triangles[131] = 22;
        triangles[132] = 0;
        triangles[133] = 23;
        triangles[134] = 45;
        triangles[135] = 22;
        triangles[136] = 0;
        triangles[137] = 45;
        */






        uvs[0] = new Vector2(-0.04545455f, 0f);
        uvs[1] = new Vector2(0f, 0f);
        uvs[2] = new Vector2(0.04545455f, 0f);
        uvs[3] = new Vector2(0.09090909f, 0f);
        uvs[4] = new Vector2(0.1363636f, 0f);
        uvs[5] = new Vector2(0.1818182f, 0f);
        uvs[6] = new Vector2(0.2272727f, 0f);
        uvs[7] = new Vector2(0.2727273f, 0f);
        uvs[8] = new Vector2(0.3181818f, 0f);
        uvs[9] = new Vector2(0.3636364f, 0f);
        uvs[10] = new Vector2(0.4090909f, 0f);
        uvs[11] = new Vector2(0.4545455f, 0f);
        uvs[12] = new Vector2(0.5f, 0f);
        uvs[13] = new Vector2(0.5454546f, 0f);
        uvs[14] = new Vector2(0.5909091f, 0f);
        uvs[15] = new Vector2(0.6363636f, 0f);
        uvs[16] = new Vector2(0.6818182f, 0f);
        uvs[17] = new Vector2(0.7272727f, 0f);
        uvs[18] = new Vector2(0.7727273f, 0f);
        uvs[19] = new Vector2(0.8181818f, 0f);
        uvs[20] = new Vector2(0.8636364f, 0f);
        uvs[21] = new Vector2(0.9090909f, 0f);
        uvs[22] = new Vector2(0.9545454f, 0f);
        uvs[23] = new Vector2(0f, 0.25f);
        uvs[24] = new Vector2(0.04545455f, 0.25f);
        uvs[25] = new Vector2(0.09090909f, 0.25f);
        uvs[26] = new Vector2(0.1363636f, 0.25f);
        uvs[27] = new Vector2(0.1818182f, 0.25f);
        uvs[28] = new Vector2(0.2272727f, 0.25f);
        uvs[29] = new Vector2(0.2727273f, 0.25f);
        uvs[30] = new Vector2(0.3181818f, 0.25f);
        uvs[31] = new Vector2(0.3636364f, 0.25f);
        uvs[32] = new Vector2(0.4090909f, 0.25f);
        uvs[33] = new Vector2(0.4545455f, 0.25f);
        uvs[34] = new Vector2(0.5f, 0.25f);
        uvs[35] = new Vector2(0.5454546f, 0.25f);
        uvs[36] = new Vector2(0.5909091f, 0.25f);
        uvs[37] = new Vector2(0.6363636f, 0.25f);
        uvs[38] = new Vector2(0.6818182f, 0.25f);
        uvs[39] = new Vector2(0.7272727f, 0.25f);
        uvs[40] = new Vector2(0.7727273f, 0.25f);
        uvs[41] = new Vector2(0.8181818f, 0.25f);
        uvs[42] = new Vector2(0.8636364f, 0.25f);
        uvs[43] = new Vector2(0.9090909f, 0.25f);
        uvs[44] = new Vector2(0.9545454f, 0.25f);
        uvs[45] = new Vector2(1f, 0.25f);



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
