using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class TopOfPillar : MonoBehaviour
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
        vertices = new Vector3[56];
        triangles = new int[84];
        uvs = new Vector2[56];



        float dx = 0.00625f;
        float dy = 0.00625f;
        float dz = 0.00625f;

        float moveback = 0.0625f;
        // TO DO: Double the verts to Fix the UVs

        vertices[0] = new Vector3(.04364003f + dx * 0.75f,.4068946f, -.9270834f + dz * 0.75f);
        uvs[0] = new Vector2(vertices[0].x, vertices[0].y);
        vertices[1] = new Vector3(-.01421997f - dx * 0.75f, .4068946f, -.9270834f + dz * 0.75f);
        uvs[1] = new Vector2(vertices[1].x, vertices[1].y);
        vertices[2] = new Vector3(.04364003f + dx, .4068946f - 0.0625f * 0.25f, -.9270834f + dz);
        uvs[2] = new Vector2(vertices[2].x, vertices[2].y);
        vertices[3] = new Vector3(-.01421997f - dx, .4068946f - 0.0625f * 0.25f, -.9270834f + dz);
        uvs[3] = new Vector2(vertices[3].x, vertices[3].y);

        vertices[4] = new Vector3(.04364003f + dx * 0.75f, .4068946f, -.9270834f - dz * 0.75f - moveback);
        uvs[4] = new Vector2(vertices[4].x, vertices[4].y);
        vertices[5] = new Vector3(-.01421997f - dx * 0.75f, .4068946f, -.9270834f - dz * 0.75f - moveback);
        uvs[5] = new Vector2(vertices[5].x, vertices[5].y);
        vertices[6] = new Vector3(.04364003f + dx, .4068946f - 0.0625f * 0.25f, -.9270834f - dz - moveback);
        uvs[6] = new Vector2(vertices[6].x, vertices[6].y);
        vertices[7] = new Vector3(-.01421997f - dx, .4068946f - 0.0625f * 0.25f, -.9270834f - dz - moveback);
        uvs[7] = new Vector2(vertices[7].x, vertices[7].y);

        vertices[8] = new Vector3(.04364003f + dx * 0.75f, .4068946f, -.9270834f + dz * 0.75f);  //0
        uvs[8] = new Vector2(vertices[8].y, vertices[8].z);
        vertices[9] = new Vector3(.04364003f + dx, .4068946f - 0.0625f * 0.25f, -.9270834f + dz); // 2
        uvs[9] = new Vector2(vertices[9].y, vertices[9].z);
        vertices[10] = new Vector3(.04364003f + dx * 0.75f, .4068946f, -.9270834f - dz * 0.75f - moveback); //4
        uvs[10] = new Vector2(vertices[10].y, vertices[10].z);
        vertices[11] = new Vector3(.04364003f + dx, .4068946f - 0.0625f * 0.25f, -.9270834f - dz - moveback); //6
        uvs[11] = new Vector2(vertices[11].y, vertices[11].z);

        vertices[12] = new Vector3(-.01421997f - dx * 0.75f, .4068946f, -.9270834f + dz * 0.75f); // 1
        uvs[12] = new Vector2(vertices[12].y, vertices[12].z);
        vertices[13] = new Vector3(-.01421997f - dx, .4068946f - 0.0625f * 0.25f, -.9270834f + dz); // 3
        uvs[13] = new Vector2(vertices[13].y, vertices[13].z);
        vertices[14] = new Vector3(-.01421997f - dx * 0.75f, .4068946f, -.9270834f - dz * 0.75f - moveback); // 5
        uvs[14] = new Vector2(vertices[14].y, vertices[14].z);
        vertices[15] = new Vector3(-.01421997f - dx, .4068946f - 0.0625f * 0.25f, -.9270834f - dz - moveback); // 7
        uvs[15] = new Vector2(vertices[15].y, vertices[15].z);

        vertices[16] = new Vector3(.04364003f + dx * 0.75f, .4068946f, -.9270834f + dz * 0.75f);
        uvs[16] = new Vector2(vertices[16].x, vertices[16].z);
        vertices[17] = new Vector3(-.01421997f - dx * 0.75f, .4068946f, -.9270834f + dz * 0.75f);
        uvs[17] = new Vector2(vertices[17].x, vertices[17].z);
        vertices[18] = new Vector3(.04364003f + dx * 0.75f, .4068946f, -.9270834f - dz * 0.75f - moveback);
        uvs[18] = new Vector2(vertices[18].x, vertices[18].z);
        vertices[19] = new Vector3(-.01421997f - dx * 0.75f, .4068946f, -.9270834f - dz * 0.75f - moveback);
        uvs[19] = new Vector2(vertices[19].x, vertices[19].z);

        vertices[20] = new Vector3(.04364003f + dx, .4068946f - 0.0625f * 0.25f, -.9270834f + dz);
        uvs[20] = new Vector2(vertices[20].x, vertices[20].z);
        vertices[21] = new Vector3(-.01421997f - dx, .4068946f - 0.0625f * 0.25f, -.9270834f + dz);
        uvs[21] = new Vector2(vertices[21].x, vertices[21].z);
        vertices[22] = new Vector3(.04364003f + dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f + dz * 0.25f);
        uvs[22] = new Vector2(vertices[22].x, vertices[22].z);
        vertices[23] = new Vector3(-.01421997f - dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f + dz * 0.25f);
        uvs[23] = new Vector2(vertices[23].x, vertices[23].z);

        vertices[24] = new Vector3(.04364003f + dx, .4068946f - 0.0625f * 0.25f, -.9270834f - dz - moveback);
        uvs[24] = new Vector2(vertices[24].x, vertices[24].z);
        vertices[25] = new Vector3(-.01421997f - dx, .4068946f - 0.0625f * 0.25f, -.9270834f - dz - moveback);
        uvs[25] = new Vector2(vertices[25].x, vertices[25].z);
        vertices[26] = new Vector3(.04364003f + dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f - dz * 0.25f - moveback);
        uvs[26] = new Vector2(vertices[26].x, vertices[26].z);
        vertices[27] = new Vector3(-.01421997f - dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f - dz * 0.25f - moveback);
        uvs[27] = new Vector2(vertices[27].x, vertices[27].z);

        vertices[28] = new Vector3(.04364003f + dx, .4068946f - 0.0625f * 0.25f, -.9270834f + dz);
        uvs[28] = new Vector2(vertices[28].y, vertices[28].z);
        vertices[29] = new Vector3(.04364003f + dx, .4068946f - 0.0625f * 0.25f, -.9270834f - dz - moveback);
        uvs[29] = new Vector2(vertices[29].y, vertices[29].z);
        vertices[30] = new Vector3(.04364003f + dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f + dz * 0.25f);
        uvs[30] = new Vector2(vertices[30].y, vertices[30].z);
        vertices[31] = new Vector3(.04364003f + dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f - dz * 0.25f - moveback);
        uvs[31] = new Vector2(vertices[31].y, vertices[31].z);

        vertices[32] = new Vector3(-.01421997f - dx, .4068946f - 0.0625f * 0.25f, -.9270834f + dz);
        uvs[32] = new Vector2(vertices[32].y, vertices[32].z);
        vertices[33] = new Vector3(-.01421997f - dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f + dz * 0.25f);
        uvs[33] = new Vector2(vertices[33].y, vertices[33].z);
        vertices[34] = new Vector3(-.01421997f - dx, .4068946f - 0.0625f * 0.25f, -.9270834f - dz - moveback);
        uvs[34] = new Vector2(vertices[34].y, vertices[34].z);
        vertices[35] = new Vector3(-.01421997f - dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f - dz * 0.25f - moveback);
        uvs[35] = new Vector2(vertices[35].y, vertices[35].z);





        vertices[36] = new Vector3(.04364003f + dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f + dz * 0.25f);
        uvs[36] = new Vector2(vertices[36].x, vertices[36].y);
        vertices[37] = new Vector3(-.01421997f - dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f + dz * 0.25f);
        uvs[37] = new Vector2(vertices[37].x, vertices[37].y);
        vertices[38] = new Vector3(.04364003f - dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f);
        uvs[38] = new Vector2(vertices[38].x, vertices[38].y);
        vertices[39] = new Vector3(-.01421997f + dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f);
        uvs[39] = new Vector2(vertices[39].x, vertices[39].y);


        vertices[40] = new Vector3(.04364003f + dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f - dz * 0.25f - moveback);
        uvs[40] = new Vector2(vertices[40].x, vertices[40].y);
        vertices[41] = new Vector3(-.01421997f - dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f - dz * 0.25f - moveback);
        uvs[41] = new Vector2(vertices[41].x, vertices[41].y);
        vertices[42] = new Vector3(.04364003f - dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f - moveback + dz * 0.25f);
        uvs[42] = new Vector2(vertices[42].x, vertices[42].y);
        vertices[43] = new Vector3(-.01421997f + dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f - moveback + dz * 0.25f);
        uvs[43] = new Vector2(vertices[43].x, vertices[43].y);

        vertices[44] = new Vector3(.04364003f + dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f + dz * 0.25f);
        uvs[44] = new Vector2(vertices[44].y, vertices[44].z);
        vertices[45] = new Vector3(.04364003f - dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f);
        uvs[45] = new Vector2(vertices[45].y, vertices[45].z);
        vertices[46] = new Vector3(.04364003f + dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f - dz * 0.25f - moveback);
        uvs[46] = new Vector2(vertices[46].y, vertices[46].z);
        vertices[47] = new Vector3(.04364003f - dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f - moveback + dz * 0.25f);
        uvs[47] = new Vector2(vertices[47].y, vertices[47].z);

        vertices[48] = new Vector3(-.01421997f - dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f + dz * 0.25f);
        uvs[48] = new Vector2(vertices[48].y, vertices[48].z);
        vertices[49] = new Vector3(-.01421997f + dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f);
        uvs[49] = new Vector2(vertices[49].y, vertices[49].z);
        vertices[50] = new Vector3(-.01421997f - dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f - dz * 0.25f - moveback);
        uvs[50] = new Vector2(vertices[50].y, vertices[50].z);
        vertices[51] = new Vector3(-.01421997f + dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f - moveback + dz * 0.25f);
        uvs[51] = new Vector2(vertices[51].y, vertices[51].z);

        vertices[52] = new Vector3(.04364003f - dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f);
        uvs[52] = new Vector2(vertices[52].x, vertices[52].z);
        vertices[53] = new Vector3(-.01421997f + dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f);
        uvs[53] = new Vector2(vertices[53].x, vertices[53].z);
        vertices[54] = new Vector3(.04364003f - dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f - moveback + dz * 0.25f);
        uvs[54] = new Vector2(vertices[54].x, vertices[54].z);
        vertices[55] = new Vector3(-.01421997f + dx * 0.25f, .4068946f - 0.0625f * 0.25f - dy, -.9270834f - dz * 0.25f - moveback + dz * 0.25f);
        uvs[55] = new Vector2(vertices[55].x, vertices[55].z);


        /*
                vertices[8] = new Vector3(.04364003f + dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f + dz * 0.25f);
                vertices[9] = new Vector3(-.01421997f - dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f + dz * 0.25f);

                vertices[10] = new Vector3(.04364003f + dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f - dz * 0.25f - 0.125f);
                vertices[11] = new Vector3(-.01421997f - dx * 0.25f, .4068946f - 0.0625f * 0.25f, -.9270834f - dz * 0.25f - 0.125f);
        */

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        triangles[6] = 1 + 4;
        triangles[7] = 0 + 4;
        triangles[8] = 2 + 4;

        triangles[9] = 1 + 4;
        triangles[10] = 2 + 4;
        triangles[11] = 3 + 4;

        triangles[12] = 8;
        triangles[13] = 9;
        triangles[14] = 10;

        triangles[15] = 9;
        triangles[16] = 11;
        triangles[17] = 10;

        triangles[18] = 13;
        triangles[19] = 12;
        triangles[20] = 14;

        triangles[21] = 13;
        triangles[22] = 14;
        triangles[23] = 15;

        triangles[24] = 17;
        triangles[25] = 16;
        triangles[26] = 18;

        triangles[27] = 17;
        triangles[28] = 18;
        triangles[29] = 19;

        triangles[30] = 20;
        triangles[31] = 21;
        triangles[32] = 22;

        triangles[33] = 22;
        triangles[34] = 21;
        triangles[35] = 23;

        triangles[36] = 25;
        triangles[37] = 24;
        triangles[38] = 26;

        triangles[39] = 25;
        triangles[40] = 26;
        triangles[41] = 27;

        triangles[42] = 29;
        triangles[43] = 28;
        triangles[44] = 30;

        triangles[45] = 29;
        triangles[46] = 30;
        triangles[47] = 31;

        triangles[48] = 33;
        triangles[49] = 32;
        triangles[50] = 34;

        triangles[51] = 33;
        triangles[52] = 34;
        triangles[53] = 35;

        triangles[54] = 36;
        triangles[55] = 37;
        triangles[56] = 38;

        triangles[57] = 38;
        triangles[58] = 37;
        triangles[59] = 39;

        triangles[60] = 41;
        triangles[61] = 40;
        triangles[62] = 42;

        triangles[63] = 41;
        triangles[64] = 42;
        triangles[65] = 43;

        triangles[66] = 44;
        triangles[67] = 45;
        triangles[68] = 46;

        triangles[69] = 46;
        triangles[70] = 45;
        triangles[71] = 47;

        triangles[72] = 49;
        triangles[73] = 48;
        triangles[74] = 50;

        triangles[75] = 51;
        triangles[76] = 49;
        triangles[77] = 50;

        triangles[78] = 52;
        triangles[79] = 53;
        triangles[80] = 54;

        triangles[81] = 53;
        triangles[82] = 55;
        triangles[83] = 54;

        /*
        triangles[12] = 4;
        triangles[13] = 0;
        triangles[14] = 6;

        triangles[15] = 0;
        triangles[16] = 2;
        triangles[17] = 6;

        triangles[18] = 1;
        triangles[19] = 5;
        triangles[20] = 6 + 1;

        triangles[21] = 3;
        triangles[22] = 1;
        triangles[23] = 7;

        triangles[24] = 1;
        triangles[25] = 0;
        triangles[26] = 4;

        triangles[27] = 5;
        triangles[28] = 1;
        triangles[29] = 4;

        triangles[30] = 2;
        triangles[31] = 3;
        triangles[32] = 8;

        triangles[33] = 3;
        triangles[34] = 9;
        triangles[35] = 8;

        triangles[36] = 3 + 4;
        triangles[37] = 2 + 4;
        triangles[38] = 8 + 2;

        triangles[39] = 3 + 4;
        triangles[40] = 8 + 2;
        triangles[41] = 9 + 2;

        triangles[42] = 3;
        triangles[43] = 11;
        triangles[44] = 9;

        triangles[45] = 3 + 4;
        triangles[46] = 11;
        triangles[47] = 3;

        triangles[48] = 2;
        triangles[49] = 8;
        triangles[50] = 10;

        triangles[51] = 6;
        triangles[52] = 2;
        triangles[53] = 10;
        */

        //        vertices[itsize1] = vertices[itsize1] + probe;

        //        Vector3 probe = new Vector3(0f, 0f, -0.0625f);
        //        Vector3 probe = new Vector3(0f, -0.0625f, 0f);
        //        vertices[47] = vertices[47] + probe;


        /*
                string fileName = "VertRecords3.txt";

                var sr = File.CreateText(fileName);

                Vector3 pos1;

                float xx;
                float yy;
                float zz;
                for (int L = 42; L < 45; L++)
                {
                    pos1 = vertices[L];
                    xx = pos1[0];
                    yy = pos1[1];
                    zz = pos1[2];
                    sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
                }
                for (int L = 53; L < 58; L++)
                {
                    pos1 = vertices[L];
                    xx = pos1[0];
                    yy = pos1[1];
                    zz = pos1[2];
                    sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
                }
                // 64 to 60
                for (int L = 0; L < 5; L++)
                {
                    pos1 = vertices[64 - L];
                    xx = pos1[0];
                    yy = pos1[1];
                    zz = pos1[2];
                    sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
                }
                //50 to 47
                for (int L = 0; L < 4; L++)
                {
                    pos1 = vertices[50 - L];
                    xx = pos1[0];
                    yy = pos1[1];
                    zz = pos1[2];
                    sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
                }
                sr.Close();
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



/*
Length
Out[8]: 0.8361311504699118

dz
Out[9]: 0.0625

c1
Out[10]: 1.25

*/