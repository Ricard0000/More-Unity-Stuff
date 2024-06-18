using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class TopOfPillar : MonoBehaviour
{


    //Define public variables
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
        gog = MakeDiscreteProceduralGrid(c1, c2, c3, c4, s, t, delta_theta, N, NN, true, mat, rot);
    }




    public static GameObject MakeDiscreteProceduralGrid(float c1, float c2, float c3, float c4, float s, float t, float delta_theta, int N, int NN, bool collider, Material mat, int rot)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;


        Mesh m = new Mesh();

        Vector3 POS = new Vector3(0f, -0.1f, 0f);
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
        float meshScale = 4f;

        float negativeMostX = -0.028f;




        vertices[0] = new Vector3(0.04832753f, 0.4068946f, -0.9223959f) + POS;
        vertices[1] = new Vector3(-0.01890747f + negativeMostX, 0.4068946f, -0.9223959f) + POS;
        vertices[2] = new Vector3(0.04989003f, 0.3912696f, -0.9208333f) + POS;
        vertices[3] = new Vector3(-0.02046997f + negativeMostX, 0.3912696f, -0.9208333f) + POS;
        vertices[4] = new Vector3(0.04832753f, 0.4068946f, -0.9942709f) + POS;
        vertices[5] = new Vector3(-0.01890747f + negativeMostX, 0.4068946f, -0.9942709f) + POS;
        vertices[6] = new Vector3(0.04989003f, 0.3912696f, -0.9958334f) + POS;
        vertices[7] = new Vector3(-0.02046997f + negativeMostX, 0.3912696f, -0.9958334f) + POS;
        vertices[8] = new Vector3(0.04832753f, 0.4068946f, -0.9223959f) + POS;
        vertices[9] = new Vector3(0.04989003f, 0.3912696f, -0.9208333f) + POS;
        vertices[10] = new Vector3(0.04832753f, 0.4068946f, -0.9942709f) + POS;
        vertices[11] = new Vector3(0.04989003f, 0.3912696f, -0.9958334f) + POS;
        vertices[12] = new Vector3(-0.01890747f + negativeMostX, 0.4068946f, -0.9223959f) + POS;
        vertices[13] = new Vector3(-0.02046997f + negativeMostX, 0.3912696f, -0.9208333f) + POS;
        vertices[14] = new Vector3(-0.01890747f + negativeMostX, 0.4068946f, -0.9942709f) + POS;
        vertices[15] = new Vector3(-0.02046997f + negativeMostX, 0.3912696f, -0.9958334f) + POS;
        vertices[16] = new Vector3(0.04832753f, 0.4068946f, -0.9223959f) + POS;
        vertices[17] = new Vector3(-0.01890747f + negativeMostX, 0.4068946f, -0.9223959f) + POS;
        vertices[18] = new Vector3(0.04832753f, 0.4068946f, -0.9942709f) + POS;
        vertices[19] = new Vector3(-0.01890747f + negativeMostX, 0.4068946f, -0.9942709f) + POS;
        vertices[20] = new Vector3(0.04989003f, 0.3912696f, -0.9208333f) + POS;
        vertices[21] = new Vector3(-0.02046997f + negativeMostX, 0.3912696f, -0.9208333f) + POS;
        vertices[22] = new Vector3(0.04520253f, 0.3912696f, -0.9255209f) + POS;
        vertices[23] = new Vector3(-0.01578247f + negativeMostX, 0.3912696f, -0.9255209f) + POS;
        vertices[24] = new Vector3(0.04989003f, 0.3912696f, -0.9958334f) + POS;
        vertices[25] = new Vector3(-0.02046997f + negativeMostX, 0.3912696f, -0.9958334f) + POS;
        vertices[26] = new Vector3(0.04520253f, 0.3912696f, -0.9911458f) + POS;
        vertices[27] = new Vector3(-0.01578247f + negativeMostX, 0.3912696f, -0.9911458f) + POS;
        vertices[28] = new Vector3(0.04989003f, 0.3912696f, -0.9208333f) + POS;
        vertices[29] = new Vector3(0.04989003f, 0.3912696f, -0.9958334f) + POS;
        vertices[30] = new Vector3(0.04520253f, 0.3912696f, -0.9255209f) + POS;
        vertices[31] = new Vector3(0.04520253f, 0.3912696f, -0.9911458f) + POS;
        vertices[32] = new Vector3(-0.02046997f + negativeMostX, 0.3912696f, -0.9208333f) + POS;
        vertices[33] = new Vector3(-0.01578247f + negativeMostX, 0.3912696f, -0.9255209f) + POS;
        vertices[34] = new Vector3(-0.02046997f + negativeMostX, 0.3912696f, -0.9958334f) + POS;
        vertices[35] = new Vector3(-0.01578247f + negativeMostX, 0.3912696f, -0.9911458f) + POS;
        vertices[36] = new Vector3(0.04520253f, 0.3912696f, -0.9255209f) + POS;
        vertices[37] = new Vector3(-0.01578247f + negativeMostX, 0.3912696f, -0.9255209f) + POS;
        vertices[38] = new Vector3(0.04207753f, 0.3850196f, -0.9286458f) + POS;
        vertices[39] = new Vector3(-0.01265747f + negativeMostX, 0.3850196f, -0.9286458f) + POS;
        vertices[40] = new Vector3(0.04520253f, 0.3912696f, -0.9911458f) + POS;
        vertices[41] = new Vector3(-0.01578247f + negativeMostX, 0.3912696f, -0.9911458f) + POS;
        vertices[42] = new Vector3(0.04207753f, 0.3850196f, -0.9895834f) + POS;
        vertices[43] = new Vector3(-0.01265747f + negativeMostX, 0.3850196f, -0.9895834f) + POS;
        vertices[44] = new Vector3(0.04520253f, 0.3912696f, -0.9255209f) + POS;
        vertices[45] = new Vector3(0.04207753f, 0.3850196f, -0.9286458f) + POS;
        vertices[46] = new Vector3(0.04520253f, 0.3912696f, -0.9911458f) + POS;
        vertices[47] = new Vector3(0.04207753f, 0.3850196f, -0.9895834f) + POS;
        vertices[48] = new Vector3(-0.01578247f + negativeMostX, 0.3912696f, -0.9255209f) + POS;
        vertices[49] = new Vector3(-0.01265747f + negativeMostX, 0.3850196f, -0.9286458f) + POS;
        vertices[50] = new Vector3(-0.01578247f + negativeMostX, 0.3912696f, -0.9911458f) + POS;
        vertices[51] = new Vector3(-0.01265747f + negativeMostX, 0.3850196f, -0.9895834f) + POS;
        vertices[52] = new Vector3(0.04207753f, 0.3850196f, -0.9286458f) + POS;
        vertices[53] = new Vector3(-0.01265747f + negativeMostX, 0.3850196f, -0.9286458f) + POS;
        vertices[54] = new Vector3(0.04207753f, 0.3850196f, -0.9895834f) + POS;
        vertices[55] = new Vector3(-0.01265747f + negativeMostX, 0.3850196f, -0.9895834f) + POS;





        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;
        triangles[6] = 5;
        triangles[7] = 4;
        triangles[8] = 6;
        triangles[9] = 5;
        triangles[10] = 6;
        triangles[11] = 7;
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





        uvs[0] = new Vector2(0.04832753f, 0.4068946f);
        uvs[1] = new Vector2(-0.01890747f, 0.4068946f);
        uvs[2] = new Vector2(0.04989003f, 0.3912696f);
        uvs[3] = new Vector2(-0.02046997f, 0.3912696f);
        uvs[4] = new Vector2(0.04832753f, 0.4068946f);
        uvs[5] = new Vector2(-0.01890747f, 0.4068946f);
        uvs[6] = new Vector2(0.04989003f, 0.3912696f);
        uvs[7] = new Vector2(-0.02046997f, 0.3912696f);
        uvs[8] = new Vector2(0.4068946f, -0.9223959f);
        uvs[9] = new Vector2(0.3912696f, -0.9208333f);
        uvs[10] = new Vector2(0.4068946f, -0.9942709f);
        uvs[11] = new Vector2(0.3912696f, -0.9958334f);
        uvs[12] = new Vector2(0.4068946f, -0.9223959f);
        uvs[13] = new Vector2(0.3912696f, -0.9208333f);
        uvs[14] = new Vector2(0.4068946f, -0.9942709f);
        uvs[15] = new Vector2(0.3912696f, -0.9958334f);
        uvs[16] = new Vector2(0.04832753f, -0.9223959f);
        uvs[17] = new Vector2(-0.01890747f, -0.9223959f);
        uvs[18] = new Vector2(0.04832753f, -0.9942709f);
        uvs[19] = new Vector2(-0.01890747f, -0.9942709f);
        uvs[20] = new Vector2(0.04989003f, -0.9208333f);
        uvs[21] = new Vector2(-0.02046997f, -0.9208333f);
        uvs[22] = new Vector2(0.04520253f, -0.9255209f);
        uvs[23] = new Vector2(-0.01578247f, -0.9255209f);
        uvs[24] = new Vector2(0.04989003f, -0.9958334f);
        uvs[25] = new Vector2(-0.02046997f, -0.9958334f);
        uvs[26] = new Vector2(0.04520253f, -0.9911458f);
        uvs[27] = new Vector2(-0.01578247f, -0.9911458f);
        uvs[28] = new Vector2(0.3912696f, -0.9208333f);
        uvs[29] = new Vector2(0.3912696f, -0.9958334f);
        uvs[30] = new Vector2(0.3912696f, -0.9255209f);
        uvs[31] = new Vector2(0.3912696f, -0.9911458f);
        uvs[32] = new Vector2(0.3912696f, -0.9208333f);
        uvs[33] = new Vector2(0.3912696f, -0.9255209f);
        uvs[34] = new Vector2(0.3912696f, -0.9958334f);
        uvs[35] = new Vector2(0.3912696f, -0.9911458f);
        uvs[36] = new Vector2(0.04520253f, 0.3912696f);
        uvs[37] = new Vector2(-0.01578247f, 0.3912696f);
        uvs[38] = new Vector2(0.04207753f, 0.3850196f);
        uvs[39] = new Vector2(-0.01265747f, 0.3850196f);
        uvs[40] = new Vector2(0.04520253f, 0.3912696f);
        uvs[41] = new Vector2(-0.01578247f, 0.3912696f);
        uvs[42] = new Vector2(0.04207753f, 0.3850196f);
        uvs[43] = new Vector2(-0.01265747f, 0.3850196f);
        uvs[44] = new Vector2(0.3912696f, -0.9255209f);
        uvs[45] = new Vector2(0.3850196f, -0.9286458f);
        uvs[46] = new Vector2(0.3912696f, -0.9911458f);
        uvs[47] = new Vector2(0.3850196f, -0.9895834f);
        uvs[48] = new Vector2(0.3912696f, -0.9255209f);
        uvs[49] = new Vector2(0.3850196f, -0.9286458f);
        uvs[50] = new Vector2(0.3912696f, -0.9911458f);
        uvs[51] = new Vector2(0.3850196f, -0.9895834f);
        uvs[52] = new Vector2(0.04207753f, -0.9286458f);
        uvs[53] = new Vector2(-0.01265747f, -0.9286458f);
        uvs[54] = new Vector2(0.04207753f, -0.9895834f);
        uvs[55] = new Vector2(-0.01265747f, -0.9895834f);





        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
            uvs[i] = uvs[i] * meshScale;
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