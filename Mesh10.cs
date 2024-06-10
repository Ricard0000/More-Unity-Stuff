using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Mesh10 : MonoBehaviour
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

    const int Nrot = 10;

    public Material mat;



    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot, Nrot);
    }
    public void Start()
    {
       
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

        vertices = new Vector3[25];
        triangles = new int[48];
        uvs = new Vector2[25];
        float meshScale = 4f;





        //        0.40625f

        float length = Mathf.Abs(0.865625f - 0.50625f);
        float up = 0.1f;
//        vertices[0] = new Vector3(0.50625f * 0f + 0.40625f, 0.7755546f, -0.9270834f);
//        vertices[1] = new Vector3(0.50625f * 0f + 0.40625f, -0.2816955f, -0.9270834f);
  //      vertices[2] = new Vector3(0.50625f * 0f + 0.40625f, 0.1581796f, -0.9270834f);

        vertices[0] = new Vector3(0.865625f * (0.50625f - 0.50625f) / length + 0.40625f * (1f - (0.50625f - 0.50625f) / length), 0.7755546f + up, -0.9270834f);
        vertices[1] = new Vector3(0.865625f * (0.50625f - 0.50625f) / length + 0.40625f * (1f - (0.50625f - 0.50625f) / length), -0.2816955f, -0.9270834f);
        vertices[2] = new Vector3(0.865625f * (0.50625f - 0.50625f) / length + 0.40625f * (1f - (0.50625f - 0.50625f) / length), 0.1581796f, -0.9270834f);

//        vertices[3] = new Vector3(0.865625f, -0.2816955f, -0.4270834f);
//        vertices[4] = new Vector3(0.865625f, 0.1581796f, -0.4270834f);
//        vertices[5] = new Vector3(0.865625f, 0.7755546f, -0.4270834f);
        vertices[3] = new Vector3(0.865625f * (0.865625f - 0.50625f) / length + 0.40625f * (1f - (0.865625f - 0.50625f) / length), -0.2816955f, -0.4270834f);
        vertices[4] = new Vector3(0.865625f * (0.865625f - 0.50625f) / length + 0.40625f * (1f - (0.865625f - 0.50625f) / length), 0.1581796f, -0.4270834f);
        vertices[5] = new Vector3(0.865625f * (0.865625f - 0.50625f) / length + 0.40625f * (1f - (0.865625f - 0.50625f) / length), 0.7755546f + up, -0.4270834f);

//        vertices[6] = new Vector3(0.6859375f, 0.7755546f, -0.6770834f);
//        vertices[7] = new Vector3(0.6859375f, 0.1581796f, -0.6770834f);
        vertices[6] = new Vector3(0.865625f * (0.6859375f - 0.50625f) / length + 0.40625f * (1f - (0.6859375f - 0.50625f) / length), 0.7755546f + up, -0.6770834f);
        vertices[7] = new Vector3(0.865625f * (0.6859375f - 0.50625f) / length + 0.40625f * (1f - (0.6859375f - 0.50625f) / length), 0.1581796f, -0.6770834f);


//        vertices[8] = new Vector3(0.5781251f, 0.7755547f, -0.8270834f);
//        vertices[9] = new Vector3(0.5781251f, 0.1581796f, -0.8270834f);
        vertices[8] = new Vector3(0.865625f * (0.5781251f - 0.50625f) / length + 0.40625f * (1f - (0.5781251f - 0.50625f) / length), 0.7755547f + up, -0.8270834f);
        vertices[9] = new Vector3(0.865625f * (0.5781251f - 0.50625f) / length + 0.40625f * (1f - (0.5781251f - 0.50625f) / length), 0.1581796f, -0.8270834f);


//        vertices[10] = new Vector3(0.6859375f, 0.4977359f, -0.6770834f);
//        vertices[11] = new Vector3(0.5781251f, 0.4977359f, -0.8270834f);
        vertices[10] = new Vector3(0.865625f * (0.6859375f - 0.50625f) / length + 0.40625f * (1f - (0.6859375f - 0.50625f) / length), 0.4977359f, -0.6770834f);
        vertices[11] = new Vector3(0.865625f * (0.5781251f - 0.50625f) / length + 0.40625f * (1f - (0.5781251f - 0.50625f) / length), 0.4977359f, -0.8270834f);


/*
        vertices[12] = new Vector3(0.6320313f, 0.4977359f, -0.7520834f);
        vertices[13] = new Vector3(0.6859375f, 0.4039859f, -0.6770834f);
        vertices[14] = new Vector3(0.6320313f, 0.4977359f, -0.7520834f);
        vertices[15] = new Vector3(0.6556153f, 0.4918765f, -0.7192709f);
        vertices[16] = new Vector3(0.672461f, 0.4742984f, -0.6958334f);
        vertices[17] = new Vector3(0.6825684f, 0.4450015f, -0.6817709f);
        vertices[18] = new Vector3(0.6859375f, 0.4039859f, -0.6770834f);
*/


        vertices[12] = new Vector3(0.865625f * (0.6320313f - 0.50625f) / length + 0.40625f * (1f - (0.6320313f - 0.50625f) / length), 0.4977359f, -0.7520834f);
        vertices[13] = new Vector3(0.865625f * (0.6859375f - 0.50625f) / length + 0.40625f * (1f - (0.6859375f - 0.50625f) / length), 0.4039859f, -0.6770834f);
        vertices[14] = new Vector3(0.865625f * (0.6320313f - 0.50625f) / length + 0.40625f * (1f - (0.6320313f - 0.50625f) / length), 0.4977359f, -0.7520834f);
        vertices[15] = new Vector3(0.865625f * (0.6556153f - 0.50625f) / length + 0.40625f * (1f - (0.6556153f - 0.50625f) / length), 0.4918765f, -0.7192709f);
        vertices[16] = new Vector3(0.865625f * (0.672461f - 0.50625f) / length + 0.40625f * (1f - (0.672461f - 0.50625f) / length), 0.4742984f, -0.6958334f);
        vertices[17] = new Vector3(0.865625f * (0.6825684f - 0.50625f) / length + 0.40625f * (1f - (0.6825684f - 0.50625f) / length), 0.4450015f, -0.6817709f);
        vertices[18] = new Vector3(0.865625f * (0.6859375f - 0.50625f) / length + 0.40625f * (1f - (0.6859375f - 0.50625f) / length), 0.4039859f, -0.6770834f);




/*
        vertices[19] = new Vector3(0.5781251f, 0.4039859f, -0.8270834f);
        vertices[20] = new Vector3(0.6320313f, 0.4977359f, -0.7520834f);
        vertices[21] = new Vector3(0.6084473f, 0.4918765f, -0.7848959f);
        vertices[22] = new Vector3(0.5916017f, 0.4742984f, -0.8083334f);
        vertices[23] = new Vector3(0.5814942f, 0.4450015f, -0.8223959f);
        vertices[24] = new Vector3(0.5781251f, 0.4039859f, -0.8270834f);
*/

        vertices[19] = new Vector3(0.865625f * (0.5781251f - 0.50625f) / length + 0.40625f * (1f - (0.5781251f - 0.50625f) / length), 0.4039859f, -0.8270834f);
        vertices[20] = new Vector3(0.865625f * (0.6320313f - 0.50625f) / length + 0.40625f * (1f - (0.6320313f - 0.50625f) / length), 0.4977359f, -0.7520834f);
        vertices[21] = new Vector3(0.865625f * (0.6084473f - 0.50625f) / length + 0.40625f * (1f - (0.6084473f - 0.50625f) / length), 0.4918765f, -0.7848959f);
        vertices[22] = new Vector3(0.865625f * (0.5916017f - 0.50625f) / length + 0.40625f * (1f - (0.5916017f - 0.50625f) / length), 0.4742984f, -0.8083334f);
        vertices[23] = new Vector3(0.865625f * (0.5814942f - 0.50625f) / length + 0.40625f * (1f - (0.5814942f - 0.50625f) / length), 0.4450015f, -0.8223959f);
        vertices[24] = new Vector3(0.865625f * (0.5781251f - 0.50625f) / length + 0.40625f * (1f - (0.5781251f - 0.50625f) / length), 0.4039859f, -0.8270834f);




        triangles[0] = 1;
        triangles[1] = 3;
        triangles[2] = 2;
        triangles[3] = 4;
        triangles[4] = 2;
        triangles[5] = 3;
        triangles[6] = 0;
        triangles[7] = 2;
        triangles[8] = 9;
        triangles[9] = 0;
        triangles[10] = 9;
        triangles[11] = 8;
        triangles[12] = 6;
        triangles[13] = 7;
        triangles[14] = 4;
        triangles[15] = 6;
        triangles[16] = 4;
        triangles[17] = 5;
        triangles[18] = 6;
        triangles[19] = 8;
        triangles[20] = 10;
        triangles[21] = 8;
        triangles[22] = 11;
        triangles[23] = 10;
        triangles[24] = 14;
        triangles[25] = 15;
        triangles[26] = 10;
        triangles[27] = 15;
        triangles[28] = 16;
        triangles[29] = 10;
        triangles[30] = 16;
        triangles[31] = 17;
        triangles[32] = 10;
        triangles[33] = 17;
        triangles[34] = 18;
        triangles[35] = 10;
        triangles[36] = 11;
        triangles[37] = 21;
        triangles[38] = 20;
        triangles[39] = 11;
        triangles[40] = 22;
        triangles[41] = 21;
        triangles[42] = 11;
        triangles[43] = 23;
        triangles[44] = 22;
        triangles[45] = 11;
        triangles[46] = 24;
        triangles[47] = 23;





        uvs[0] = new Vector2(0.7755546f, -0.9270834f);
        uvs[1] = new Vector2(-0.2816955f, -0.9270834f);
        uvs[2] = new Vector2(0.1581796f, -0.9270834f);
        uvs[3] = new Vector2(-0.2816955f, -0.4270834f);
        uvs[4] = new Vector2(0.1581796f, -0.4270834f);
        uvs[5] = new Vector2(0.7755546f, -0.4270834f);
        uvs[6] = new Vector2(0.7755546f, -0.6770834f);
        uvs[7] = new Vector2(0.1581796f, -0.6770834f);
        uvs[8] = new Vector2(0.7755547f, -0.8270834f);
        uvs[9] = new Vector2(0.1581796f, -0.8270834f);
        uvs[10] = new Vector2(0.4977359f, -0.6770834f);
        uvs[11] = new Vector2(0.4977359f, -0.8270834f);
        uvs[12] = new Vector2(0.4977359f, -0.7520834f);
        uvs[13] = new Vector2(0.4039859f, -0.6770834f);
        uvs[14] = new Vector2(0.4977359f, -0.7520834f);
        uvs[15] = new Vector2(0.4918765f, -0.7192709f);
        uvs[16] = new Vector2(0.4742984f, -0.6958334f);
        uvs[17] = new Vector2(0.4450015f, -0.6817709f);
        uvs[18] = new Vector2(0.4039859f, -0.6770834f);
        uvs[19] = new Vector2(0.4039859f, -0.8270834f);
        uvs[20] = new Vector2(0.4977359f, -0.7520834f);
        uvs[21] = new Vector2(0.4918765f, -0.7848959f);
        uvs[22] = new Vector2(0.4742984f, -0.8083334f);
        uvs[23] = new Vector2(0.4450015f, -0.8223959f);
        uvs[24] = new Vector2(0.4039859f, -0.8270834f);





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


