using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Mesh7 : MonoBehaviour
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
    float delta_theta = (PI / 2) / N;
    public int rot = 0;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot);
    }


    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, float c1, float c2, float c3, float c4, float s, float t, float delta_theta, int N, bool collider, Material mat, int rot)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;


        Mesh m = new Mesh();

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

        vertices = new Vector3[38];
        triangles = new int[93];
        uvs = new Vector2[38];
        float meshScale = 4f;

        vertices[0] = new Vector3(-0.7078899f-0.1f, 0.53802f, -0.9895834f);//dead
        vertices[1] = new Vector3(-0.6187184f, 0.6553554f, -0.9895834f);
        vertices[2] = new Vector3(-0.514312f, 0.7617989f, -0.9895834f);
        vertices[3] = new Vector3(-0.3972418f, 0.8557063f, -0.9895834f);
        vertices[4] = new Vector3(-0.2703899f, 0.9357043f, -0.9895834f);
//        vertices[5] = new Vector3(-0.1368801f, 1.000718f, -0.9895834f);
        vertices[5] = new Vector3(-0.1368801f+0.51f, 1.000718f, -0.9895834f);//dead
        vertices[6] = new Vector3(-3.824746E-08f, 1.04999f, -0.9895834f);
        vertices[7] = new Vector3(0.1368801f + 0.51f, 1.000718f, -0.9895834f);//dead
//        vertices[7] = new Vector3(0.1368801f, 1.000718f, -0.9895834f);
        vertices[8] = new Vector3(0.2703899f, 0.9357044f, -0.9895834f);
        vertices[9] = new Vector3(0.3972417f, 0.8557064f, -0.9895834f);
        vertices[10] = new Vector3(0.5143121f, 0.7617989f, -0.9895834f);
        vertices[11] = new Vector3(0.6187184f, 0.6553554f, -0.9895834f);
        vertices[12] = new Vector3(0.7078899f-0.1f, 0.53802f, -0.9895834f);//dead
        vertices[13] = new Vector3(0f-0.02f, 0.53802f, -0.9895834f);//dead
        vertices[14] = new Vector3(-0.74375f - 0.02f, 0.2783045f, -0.9895834f);
        vertices[15] = new Vector3(-0.7270986f - 0.02f, 0.3619995f, -0.9895834f);
        vertices[16] = new Vector3(-0.6796796f - 0.02f, 0.4393734f, -0.9895834f);

        vertices[17] = new Vector3(-0.608712f - 0.02f, 0.4999052f, -0.9895834f);//
//        vertices[18] = new Vector3(-0.7078899f, 0.53802f, -0.9895834f);
        vertices[18] = new Vector3(-0.525f - 0.04f, 0.53802f, -0.9895834f);//

        vertices[19] = new Vector3(-0.441288f - 0.04f, 0.4999053f, -0.9895834f);
        vertices[20] = new Vector3(-0.3703204f - 0.04f, 0.4393734f, -0.9895834f);
        vertices[21] = new Vector3(-0.3229013f - 0.04f, 0.3619996f, -0.9895834f);
        vertices[22] = new Vector3(-0.30625f - 0.04f, 0.2783045f, -0.9895834f);

//        vertices[23] = new Vector3(-0.7078899f, 0.53802f, -0.9895834f);//
        vertices[23] = new Vector3(-0.875f, 0.53802f, -0.9895834f);//

        //        vertices[23] = new Vector3(-0.525f, 0.53802f, -0.9895834f);//

//        vertices[24] = new Vector3(-0.875f, 0.003662168f, -0.9895834f);//
        vertices[24] = new Vector3(-0.875f, 0.53802f, -0.9895834f);//
        
        vertices[25] = new Vector3(-0.8642273f, 0.1404191f, -0.9895834f);
        vertices[26] = new Vector3(-0.8321745f, 0.2783932f, -0.9895834f);
        vertices[27] = new Vector3(-0.7796308f, 0.4116732f, -0.9895834f);
        vertices[28] = new Vector3(-0.7078899f, 0.53802f, -0.9895834f);
//        vertices[28] = new Vector3(-0.7796308f, 0.53802f, -0.9895834f);

        vertices[29] = new Vector3(-0.74375f - 0.02f, -0.2816955f, -0.9895834f);//
        vertices[30] = new Vector3(-0.86875f, -0.2816955f, -0.9895834f);//
        vertices[31] = new Vector3(-0.30625f - 0.04f, 0.5380546f, -0.9895834f);
        vertices[32] = new Vector3(-0.24375f, 0.5380546f, -0.9895834f);
        vertices[33] = new Vector3(-0.30625f - 0.04f, -0.2816955f, -0.9895834f);
        vertices[34] = new Vector3(-0.24375f, -0.2816955f, -0.9895834f);


        vertices[35] = new Vector3(-0.875f, 0.53802f, -0.9895834f);//
        vertices[36] = new Vector3(-0.74375f - 0.02f, -0.2816955f, -0.9895834f);
        vertices[37] = new Vector3(-0.74375f - 0.02f, 0.2783932f, -0.9895834f);


        // 0 - 13
       /*
                triangles[0] = 1;
                triangles[1] = 13;
                triangles[2] = 0;

                triangles[3] = 2;
                triangles[4] = 13;
                triangles[5] = 1;

                triangles[6] = 3;
                triangles[7] = 13;
                triangles[8] = 2;

                triangles[9] = 4;
                triangles[10] = 13;
                triangles[11] = 3;

                triangles[12] = 5;
                triangles[13] = 13;
                triangles[14] = 4;

                triangles[15] = 6;
                triangles[16] = 13;
                triangles[17] = 5;

                triangles[18] = 7;
                triangles[19] = 13;
                triangles[20] = 6;
       
        triangles[21] = 8;
        triangles[22] = 13;
        triangles[23] = 7;

        triangles[24] = 9;
        triangles[25] = 13;
        triangles[26] = 8;

        triangles[27] = 10;
        triangles[28] = 13;
        triangles[29] = 9;

        triangles[30] = 11;
        triangles[31] = 13;
        triangles[32] = 10;

        triangles[33] = 12;
        triangles[34] = 13;
        triangles[35] = 11;
         */

        triangles[36] = 14;
        triangles[37] = 23;
        triangles[38] = 15;

        triangles[39] = 15;
        triangles[40] = 23;
        triangles[41] = 16;

        triangles[42] = 16;
        triangles[43] = 23;
        triangles[44] = 17;
        
        triangles[45] = 17;
        triangles[46] = 23;
        triangles[47] = 18;
        /*
        triangles[48] = 14;
        triangles[49] = 27;
        triangles[50] = 28;
                
        triangles[51] = 14;
        triangles[52] = 26;
        triangles[53] = 27;

        triangles[54] = 14;
        triangles[55] = 25;
        triangles[56] = 26;

        triangles[57] = 14;
        triangles[58] = 24;
        triangles[59] = 25;

        triangles[60] = 25;
        triangles[61] = 14;
        triangles[62] = 29;
*/
        /*
        triangles[63] = 24;
        triangles[64] = 25;
        triangles[65] = 29;
*/

        triangles[66] = 24;
        triangles[67] = 29;
        triangles[68] = 30;

        triangles[69] = 18;
        triangles[70] = 31;
        triangles[71] = 19;

        triangles[72] = 19;
        triangles[73] = 31;
        triangles[74] = 20;

        triangles[75] = 20;
        triangles[76] = 31;
        triangles[77] = 21;

        triangles[78] = 21;
        triangles[79] = 31;
        triangles[80] = 22;

        triangles[81] = 32;
        triangles[82] = 33;
        triangles[83] = 31;

        triangles[84] = 33;
        triangles[85] = 32;
        triangles[86] = 34;

        triangles[87] = 35;
        triangles[88] = 37;
        triangles[89] = 36;



        uvs[0] = new Vector2(-0.7078899f, 0.53802f);
        uvs[1] = new Vector2(-0.6187184f, 0.6553554f);
        uvs[2] = new Vector2(-0.514312f, 0.7617989f);
        uvs[3] = new Vector2(-0.3972418f, 0.8557063f);
        uvs[4] = new Vector2(-0.2703899f, 0.9357043f);
        uvs[5] = new Vector2(-0.1368801f, 1.000718f);
        uvs[6] = new Vector2(-3.824746E-08f, 1.04999f);
        uvs[7] = new Vector2(0.1368801f, 1.000718f);
        uvs[8] = new Vector2(0.2703899f, 0.9357044f);
        uvs[9] = new Vector2(0.3972417f, 0.8557064f);
        uvs[10] = new Vector2(0.5143121f, 0.7617989f);
        uvs[11] = new Vector2(0.6187184f, 0.6553554f);
        uvs[12] = new Vector2(0.7078899f, 0.53802f);
        uvs[13] = new Vector2(0f, 0.53802f);
        uvs[14] = new Vector2(-0.74375f, 0.2783045f);
        uvs[15] = new Vector2(-0.7270986f, 0.3619995f);
        uvs[16] = new Vector2(-0.6796796f, 0.4393734f);
        uvs[17] = new Vector2(-0.608712f, 0.4999052f);
        uvs[18] = new Vector2(-0.525f, 0.53802f);
        uvs[19] = new Vector2(-0.441288f, 0.4999053f);
        uvs[20] = new Vector2(-0.3703204f, 0.4393734f);
        uvs[21] = new Vector2(-0.3229013f, 0.3619996f);
        uvs[22] = new Vector2(-0.30625f, 0.2783045f);
        uvs[23] = new Vector2(-0.7078899f, 0.53802f);
        uvs[24] = new Vector2(-0.875f, 0.003662168f);
        uvs[25] = new Vector2(-0.8642273f, 0.1404191f);
        uvs[26] = new Vector2(-0.8321745f, 0.2783932f);
        uvs[27] = new Vector2(-0.7796308f, 0.4116732f);
        uvs[28] = new Vector2(-0.7078899f, 0.53802f);
        uvs[29] = new Vector2(-0.74375f, -0.2816955f);
        uvs[30] = new Vector2(-0.86875f, -0.2816955f);
        uvs[31] = new Vector2(-0.30625f, 0.5380546f);
        uvs[32] = new Vector2(-0.24375f, 0.5380546f);
        uvs[33] = new Vector2(-0.30625f, -0.2816955f);
        uvs[34] = new Vector2(-0.24375f, -0.2816955f);



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



