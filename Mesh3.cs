using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Mesh3 : MonoBehaviour
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
        triangles = new int[72];
        uvs = new Vector2[32];
        float meshScale = 4f;



        vertices[0] = new Vector3(-0.24375f, 0.4380546f, -0.9270834f);
        vertices[1] = new Vector3(-0.24375f, -0.2816955f, -0.9270834f);
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


        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
        }

        for (int i = 0; i < 32; i++)
        {
            uvs[i] = new Vector2((vertices[i].x + 0.86875f * meshScale) / (1.5766339f * meshScale),
                (vertices[i].y + 0.2826955f * meshScale) / (1.3316855f * meshScale));
        }

/*
        for (int i = 0; i < 32; i++)
        {
            uvs[i] = new Vector2((vertices[i].x + 0.86875f * meshScale)/(1.5766339f * meshScale), vertices[i].y);
        }
*/

        triangles[0] = 2;
        triangles[1] = 1;
        triangles[2] = 3;
        triangles[3] = 1;
        triangles[4] = 4;
        triangles[5] = 3;
        triangles[6] = 0;
        triangles[7] = 6;
        triangles[8] = 7;
        triangles[9] = 0;
        triangles[10] = 7;
        triangles[11] = 8;
        triangles[12] = 0;
        triangles[13] = 8;
        triangles[14] = 9;
        triangles[15] = 0;
        triangles[16] = 9;
        triangles[17] = 10;
        triangles[18] = 16;
        triangles[19] = 11;
        triangles[20] = 12;
        triangles[21] = 16;
        triangles[22] = 12;
        triangles[23] = 13;
        triangles[24] = 16;
        triangles[25] = 13;
        triangles[26] = 14;
        triangles[27] = 16;
        triangles[28] = 14;
        triangles[29] = 15;
        triangles[30] = 17;
        triangles[31] = 3;
        triangles[32] = 5;
        triangles[33] = 18;
        triangles[34] = 3;
        triangles[35] = 17;
        triangles[36] = 17;
        triangles[37] = 20;
        triangles[38] = 19;
        triangles[39] = 17;
        triangles[40] = 21;
        triangles[41] = 20;
        triangles[42] = 17;
        triangles[43] = 22;
        triangles[44] = 21;
        triangles[45] = 17;
        triangles[46] = 23;
        triangles[47] = 22;
        triangles[48] = 16;
        triangles[49] = 25;
        triangles[50] = 24;
        triangles[51] = 16;
        triangles[52] = 26;
        triangles[53] = 25;
        triangles[54] = 16;
        triangles[55] = 27;
        triangles[56] = 26;
        triangles[57] = 16;
        triangles[58] = 28;
        triangles[59] = 27;
        triangles[60] = 28;
        triangles[61] = 16;
        triangles[62] = 29;
        triangles[63] = 28;
        triangles[64] = 29;
        triangles[65] = 15;
        triangles[66] = 31;
        triangles[67] = 30;
        triangles[68] = 0;
        triangles[69] = 5;
        triangles[70] = 31;
        triangles[71] = 0;







        /*
        float lower = -0.1f;



        vertices[0] = new Vector3(-0.24375f, 0.5380546f + lower, -0.9270834f);// right top
        vertices[1] = new Vector3(-0.24375f, -0.2816955f, -0.9270834f); //right bottom to the left
        vertices[2] = new Vector3(-0.24375f, 0.1281796f + lower, -0.9270834f);// right inner corner
        vertices[3] = new Vector3(0.50625f -0.1f, 0.1281796f + lower, -0.9270834f); // left inner corner

        vertices[4] = new Vector3(0.50625f - 0.1f, -0.2816955f, -0.9270834f);
//        vertices[5] = new Vector3(-0.24375f, 0.3741046f + lower, -0.9270834f);
        vertices[6] = new Vector3(0.50625f - 0.1f, 0.5380546f + lower, -0.9270834f);//left top

//        vertices[7] = new Vector3(0.50625f, 0.3741046f + lower, -0.9270834f); // possibly dead
        vertices[8] = new Vector3(-0.24375f, 0.4068946f + lower, -0.9270834f);
        vertices[9] = new Vector3(-0.233766f - 0.0075f, 0.4570874f + lower, -0.9270834f);
        vertices[10] = new Vector3(-0.2053341f - 0.015f, 0.4996387f + lower, -0.9270834f);
        vertices[11] = new Vector3(-0.1627827f - 0.0225f, 0.5280706f + lower, -0.9270834f);
        vertices[12] = new Vector3(-0.11259f - 0.03f, 0.5380546f + lower, -0.9270834f);
        float diff1 = (0.1627827f + 0.0225f) - (0.14259f);
        float diff2 = (0.2053341f + 0.015f) - (0.14259f);
        float diff3 = (0.233766f + 0.0075f) - (0.14259f);
        float diff4 = (0.24375f) - (0.14259f);
        vertices[13] = new Vector3(-0.11259f - 0.03f, 0.5380546f + lower, -0.9270834f);
        float cen1 = -0.11259f - 0.03f;
        float temp1 = Mathf.Abs((-0.1627827f - 0.0225f) - (-0.11259f - 0.03f));
        float temp2 = Mathf.Abs((-0.2053341f - 0.015f) - (-0.11259f - 0.03f));
        float temp3 = Mathf.Abs((-0.233766f - 0.0075f) - (-0.11259f - 0.03f));
        float temp4 = Mathf.Abs((-0.24375f) - (-0.11259f - 0.03f));
        vertices[14] = new Vector3(cen1 + temp1, 0.5280706f + lower, -0.9270834f);
        vertices[15] = new Vector3(cen1 + temp2, 0.4996387f + lower, -0.9270834f);
        vertices[16] = new Vector3(cen1 + temp3, 0.4570873f + lower, -0.9270834f);
        vertices[17] = new Vector3(cen1 + temp4, 0.4068946f + lower, -0.9270834f);
        vertices[18] = new Vector3(0.04364002f, 0.5380546f + lower, -0.9270834f);
        vertices[19] = new Vector3(0.04364002f + diff4 + diff4, 0.5380546f + lower, -0.9270834f);
        vertices[20] = new Vector3(0.04364002f + diff4 + diff4, 0.1281796f + lower, -0.9270834f);
        vertices[21] = new Vector3(0.04364002f + diff4 + diff4, 0.4068946f + lower, -0.9270834f);
        vertices[22] = new Vector3(0.04364002f + diff4 + diff3, 0.4570874f + lower, -0.9270834f);
        vertices[23] = new Vector3(0.04364002f + diff4 + diff2, 0.4996387f + lower, -0.9270834f);
        vertices[24] = new Vector3(0.04364002f + diff4 + diff1, 0.5280706f + lower, -0.9270834f);
        vertices[25] = new Vector3(0.14201f, 0.5380546f + lower, -0.9270834f);
        vertices[26] = new Vector3(0.04364002f + diff4, 0.5380546f + lower, -0.9270834f);
        vertices[27] = new Vector3(0.04364002f + diff4 - diff1, 0.5280706f + lower, -0.9270834f);
        vertices[28] = new Vector3(0.04364002f + diff4 - diff2, 0.4996387f + lower, -0.9270834f);
        vertices[29] = new Vector3(0.04364002f + diff4 - diff3, 0.4570873f + lower, -0.9270834f);
        vertices[30] = new Vector3(0.04364002f, 0.4068946f + lower, -0.9270834f);
        vertices[31] = new Vector3(cen1 + temp4, 0.5380546f + lower, -0.9270834f);
        vertices[32] = new Vector3(-0.24375f, 0.5380546f + lower + 0.1f, -0.9270834f);// right top
        vertices[33] = new Vector3(0.50625f - 0.1f, 0.5380546f + lower + 0.1f, -0.9270834f);//left top



        // Bottom Quad
        triangles[0] = 2;
        triangles[1] = 1;
        triangles[2] = 3;
        triangles[3] = 1;
        triangles[4] = 4;
        triangles[5] = 3;
        // Bottom Quad
        // Right-right arch
        triangles[6] = 0;
        triangles[7] = 8;
        triangles[8] = 9;
        triangles[9] = 0;
        triangles[10] = 9;
        triangles[11] = 10;
        triangles[12] = 0;
        triangles[13] = 10;
        triangles[14] = 11;
        triangles[15] = 0;
        triangles[16] = 11;
        triangles[17] = 12;
        // Right-right arch
        // Right-left arch
        triangles[18] = 18;
        triangles[19] = 13;
        triangles[20] = 14;
        triangles[21] = 18;
        triangles[22] = 14;
        triangles[23] = 15;
        triangles[24] = 18;
        triangles[25] = 15;
        triangles[26] = 16;
        triangles[27] = 18;
        triangles[28] = 16;
        triangles[29] = 17;
        // Right-left arch
        // Quad next to Left-left arch
        triangles[30] = 19;
        triangles[31] = 3;
        triangles[32] = 6;
        triangles[33] = 20;
        triangles[34] = 3;
        triangles[35] = 19;
        // Quad next to Left-left arch
        // Left Left arch
        triangles[36] = 19;
        triangles[37] = 22;
        triangles[38] = 21;
        triangles[39] = 19;
        triangles[40] = 23;
        triangles[41] = 22;
        triangles[42] = 19;
        triangles[43] = 24;
        triangles[44] = 23;
        triangles[45] = 19;
        triangles[46] = 25;
        triangles[47] = 24;
        // Left Left arch
        // Left-right arch
        triangles[48] = 18;
        triangles[49] = 27;
        triangles[50] = 26;
        triangles[51] = 18;
        triangles[52] = 28;
        triangles[53] = 27;
        triangles[54] = 18;
        triangles[55] = 29;
        triangles[56] = 28;
        triangles[57] = 18;
        triangles[58] = 30;
        triangles[59] = 29;
        // Left-right arch
        // Quad in the middel of arches (needs to be fixed)
        triangles[60] = 30;
        triangles[61] = 18;
        triangles[62] = 31;
        triangles[63] = 30;
        triangles[64] = 31;
        triangles[65] = 17;
        // Top Quad
        triangles[66] = 33;
        triangles[67] = 32;
        triangles[68] = 0;
        triangles[69] = 6;
        triangles[70] = 33;
        triangles[71] = 0;
        // Top Quad

        */






        /*
        string fileName = "cleanUp.txt";

        var sr = File.CreateText(fileName);

        float xx;
        float yy;
        float zz;

        for (int L = 0; L < vertices.Length; L++)
        {
            Vector3 pos = vertices[L];

            xx = pos[0];
            yy = pos[1];
            zz = pos[2];
            sr.Write("vertices[");
            sr.Write((int)L);
            sr.Write("] = new Vector3(");
            sr.Write((float)xx);
            sr.Write("f, ");
            sr.Write((float)yy);
            sr.Write("f, ");
            sr.Write((float)zz);
            sr.Write("f");
            sr.Write(")\n");
        }
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
        /*
        float uv1;
        float uv2;
        Vector2 posUV;
        for (int L = 0; L < uvs.Length; L++)
        {
            posUV = uvs[L];
            uv1 = posUV[0];
            uv2 = posUV[1];
            sr.Write("uvs[");
            sr.Write((int)L);
            sr.Write("] = new Vector2(");
            sr.Write((float)uv1);
            sr.Write("f, ");
            sr.Write((float)uv2);
            sr.Write("f);\n");
        }
        */
        //        sr.Close();














        // Quad in the middel of arches (needs to be fixed)
        /*
                vertices[0] = new Vector3(-0.24375f, 0.5380546f + lower, -0.9270834f);
                vertices[1] = new Vector3(-0.24375f, -0.2816955f + lower, -0.9270834f);
                vertices[2] = new Vector3(-0.24375f, 0.1281796f + lower, -0.9270834f);
                vertices[3] = new Vector3(0.50625f, 0.1281796f + lower, -0.9270834f);
                vertices[4] = new Vector3(0.50625f, -0.2816955f + lower, -0.9270834f);
                vertices[5] = new Vector3(-0.24375f, 0.3741046f + lower, -0.9270834f);
                vertices[6] = new Vector3(0.50625f, 0.5380546f + lower, -0.9270834f);
                vertices[7] = new Vector3(0.50625f, 0.3741046f + lower, -0.9270834f);

                // right-right arch
                vertices[8] = new Vector3(-0.24375f, 0.4068946f + lower, -0.9270834f);
                vertices[9] = new Vector3(-0.233766f - 0.0075f, 0.4570874f + lower, -0.9270834f);
                vertices[10] = new Vector3(-0.2053341f - 0.015f, 0.4996387f + lower, -0.9270834f);
                vertices[11] = new Vector3(-0.1627827f - 0.0225f, 0.5280706f + lower, -0.9270834f);
                vertices[12] = new Vector3(-0.11259f - 0.03f, 0.5380546f + lower, -0.9270834f);
                // right-right arch


                float diff1 = (0.1627827f + 0.0225f) - (0.14259f);
                float diff2 = (0.2053341f + 0.015f) - (0.14259f);
                float diff3 = (0.233766f + 0.0075f) - (0.14259f);
                float diff4 = (0.24375f) - (0.14259f);

                vertices[13] = new Vector3(-0.11259f - 0.03f, 0.5380546f + lower, -0.9270834f);
                //        vertices[13] = new Vector3(-0.14538f, 0.5380546f + lower, -0.9270834f);

                float cen1 = -0.11259f - 0.03f;//.14259
                float temp1 = Mathf.Abs((-0.1627827f - 0.0225f) - (-0.11259f - 0.03f));//0.0426927
                float temp2 = Mathf.Abs((-0.2053341f - 0.015f) - (-0.11259f - 0.03f));//0.0477441
                float temp3 = Mathf.Abs((-0.233766f - 0.0075f) - (-0.11259f - 0.03f));//0.083666
                float temp4 = Mathf.Abs((-0.24375f) - (-0.11259f - 0.03f));//.10116//

                //        vertices[14] = new Vector3(-0.0951872f, 0.5280706f + lower, -0.9270834f);
                vertices[14] = new Vector3(cen1 + temp1, 0.5280706f + lower, -0.9270834f);
                vertices[15] = new Vector3(cen1 + temp2, 0.4996387f + lower, -0.9270834f);
                //        vertices[15] = new Vector3(-0.05263584f, 0.4996387f + lower, -0.9270834f);
                vertices[16] = new Vector3(cen1 + temp3, 0.4570873f + lower, -0.9270834f);
                vertices[17] = new Vector3(cen1 + temp4, 0.4068946f + lower, -0.9270834f);

                //        vertices[16] = new Vector3(-0.02420392f, 0.4570873f + lower, -0.9270834f);
                //      vertices[17] = new Vector3(-0.01421997f, 0.4068946f + lower, -0.9270834f);

                vertices[18] = new Vector3(0.04364002f, 0.5380546f + lower, -0.9270834f);





        //        vertices[19] = new Vector3(0.27325f, 0.5380546f + lower, -0.9270834f);
          //      vertices[20] = new Vector3(0.27275f, 0.1281796f + lower, -0.9270834f);


                vertices[19] = new Vector3(0.04364002f + diff4 + diff4, 0.5380546f + lower, -0.9270834f);
                vertices[20] = new Vector3(0.04364002f + diff4 + diff4, 0.1281796f + lower, -0.9270834f);
        */

        /*
                vertices[21] = new Vector3(0.27317f, 0.4068946f + lower, -0.9270834f);
                vertices[22] = new Vector3(0.2631861f, 0.4570874f + lower, -0.9270834f);
                vertices[23] = new Vector3(0.2347541f, 0.4996387f + lower, -0.9270834f);
                vertices[24] = new Vector3(0.1922028f, 0.5280706f + lower, -0.9270834f);
        */



        /*
        vertices[21] = new Vector3(0.04364002f + diff4 + diff4, 0.4068946f + lower, -0.9270834f);
        vertices[22] = new Vector3(0.04364002f + diff4 + diff3, 0.4570874f + lower, -0.9270834f);
        vertices[23] = new Vector3(0.04364002f + diff4 + diff2, 0.4996387f + lower, -0.9270834f);
        vertices[24] = new Vector3(0.04364002f + diff4 + diff1, 0.5280706f + lower, -0.9270834f);




        vertices[25] = new Vector3(0.14201f, 0.5380546f + lower, -0.9270834f);
        */
        /*
        vertices[26] = new Vector3(0.1748f, 0.5380546f + lower, -0.9270834f);
        vertices[27] = new Vector3(0.1246073f, 0.5280706f + lower, -0.9270834f);
        vertices[28] = new Vector3(0.0820559f, 0.4996387f + lower, -0.9270834f);
        vertices[29] = new Vector3(0.05362398f, 0.4570873f + lower, -0.9270834f);
*/

        /*
        vertices[26] = new Vector3(0.04364002f + diff4, 0.5380546f + lower, -0.9270834f);
        vertices[27] = new Vector3(0.04364002f + diff4 - diff1 , 0.5280706f + lower, -0.9270834f);
        vertices[28] = new Vector3(0.04364002f + diff4 - diff2, 0.4996387f + lower, -0.9270834f);

        vertices[29] = new Vector3(0.04364002f + diff4 - diff3, 0.4570873f + lower, -0.9270834f);

        vertices[30] = new Vector3(0.04364002f , 0.4068946f + lower, -0.9270834f);




//        vertices[31] = new Vector3(0.05643001f, 0.5380546f + lower, -0.9270834f);
        vertices[31] = new Vector3(cen1 + temp4, 0.5380546f + lower, -0.9270834f);

        // Bottom Quad
        triangles[0] = 2;
        triangles[1] = 1;
        triangles[2] = 3;

        triangles[3] = 1;
        triangles[4] = 4;
        triangles[5] = 3;
        // Bottom Quad
        
        // Right-right arch
        triangles[6] = 0;
        triangles[7] = 8;
        triangles[8] = 9;

        triangles[9] = 0;
        triangles[10] = 9;
        triangles[11] = 10;

        triangles[12] = 0;
        triangles[13] = 10;
        triangles[14] = 11;

        triangles[15] = 0;
        triangles[16] = 11;
        triangles[17] = 12;
        // Right-right arch


// Right-left arch

        triangles[30] = 18;
        triangles[31] = 13;
        triangles[32] = 14;

        triangles[33] = 18;
        triangles[34] = 14;
        triangles[35] = 15;

        triangles[36] = 18;
        triangles[37] = 15;
        triangles[38] = 16;

        triangles[39] = 18;
        triangles[40] = 16;
        triangles[41] = 17;

// Right-left arch




        // Quad next to Left-left arch
        triangles[42] = 19;
        triangles[43] = 3;
        triangles[44] = 6;

        triangles[45] = 20;
        triangles[46] = 3;
        triangles[47] = 19;
        // Quad next to Left-left arch

        // Left Left arch

        triangles[48] = 19;
        triangles[49] = 22;
        triangles[50] = 21;
        
        triangles[51] = 19;
        triangles[52] = 23;
        triangles[53] = 22;

        triangles[54] = 19;
        triangles[55] = 24;
        triangles[56] = 23;

        triangles[57] = 19;
        triangles[58] = 25;
        triangles[59] = 24;
        
        // Left Left arch



// Left-right arch

        triangles[60] = 18;
        triangles[61] = 27;
        triangles[62] = 26;
        
        triangles[63] = 18;
        triangles[64] = 28;
        triangles[65] = 27;

        triangles[66] = 18;
        triangles[67] = 29;
        triangles[68] = 28;

        triangles[69] = 18;
        triangles[70] = 30;
        triangles[71] = 29;
        
// Left-right arch


// Quad in the middel of arches (needs to be fixed)
        triangles[72] = 30;
        triangles[73] = 18;
        triangles[74] = 31;

        triangles[75] = 30;
        triangles[76] = 31;
        triangles[77] = 17;
// Quad in the middel of arches (needs to be fixed)
        */


        /*
        uvs[0] = new Vector2(-0.24375f, 0.5380546f);
        uvs[1] = new Vector2(-0.24375f, -0.2816955f);
        uvs[2] = new Vector2(-0.24375f, 0.1281796f);
        uvs[3] = new Vector2(0.50625f, 0.1281796f);
        uvs[4] = new Vector2(0.50625f, -0.2816955f);
        uvs[5] = new Vector2(-0.24375f, 0.3741046f);
        uvs[6] = new Vector2(0.50625f, 0.5380546f);
        uvs[7] = new Vector2(0.50625f, 0.3741046f);
        uvs[8] = new Vector2(-0.24375f, 0.4068946f);
        uvs[9] = new Vector2(-0.233766f, 0.4570874f);
        uvs[10] = new Vector2(-0.2053341f, 0.4996387f);
        uvs[11] = new Vector2(-0.1627827f, 0.5280706f);
        uvs[12] = new Vector2(-0.11259f, 0.5380546f);
        uvs[13] = new Vector2(-0.14538f, 0.5380546f);
        uvs[14] = new Vector2(-0.0951872f, 0.5280706f);
        uvs[15] = new Vector2(-0.05263584f, 0.4996387f);
        uvs[16] = new Vector2(-0.02420392f, 0.4570873f);
        uvs[17] = new Vector2(-0.01421997f, 0.4068946f);
        uvs[18] = new Vector2(0.01857004f, 0.5380546f);
        uvs[19] = new Vector2(0.27325f, 0.5380546f);
        uvs[20] = new Vector2(0.27275f, 0.1281796f);
        uvs[21] = new Vector2(0.27317f, 0.4068946f);
        uvs[22] = new Vector2(0.2631861f, 0.4570874f);
        uvs[23] = new Vector2(0.2347541f, 0.4996387f);
        uvs[24] = new Vector2(0.1922028f, 0.5280706f);
        uvs[25] = new Vector2(0.14201f, 0.5380546f);
        uvs[26] = new Vector2(0.1748f, 0.5380546f);
        uvs[27] = new Vector2(0.1246073f, 0.5280706f);
        uvs[28] = new Vector2(0.0820559f, 0.4996387f);
        uvs[29] = new Vector2(0.05362398f, 0.4570873f);
        uvs[30] = new Vector2(0.04364002f, 0.4068946f);
        uvs[31] = new Vector2(0.05643001f, 0.5380546f);
        */



        // Save Vertices for Ray Tracing:
        string fileName = "RTMesh3.txt";

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


