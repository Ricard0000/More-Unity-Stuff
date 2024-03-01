using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WallEntrance3 : MonoBehaviour
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
        /*
        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " already exists.");
            return;
        }
        var sr = File.CreateText(fileName);

        Vector3 pos1 = 

        sr.WriteLine("This is my file.");
        sr.WriteLine("I can write ints {0} or floats {1}, and so on.",
            1, 4.2);
        sr.Close();
*/
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


        float angle1 = -45f / 180f * PI;


        float angle = rot * angle1;
        float x;
        float y;
        float z;
        float dz = 0.0625f;

        vertices[0] = new Vector3(.50625f,.5380546f,-.9270834f) + new Vector3(0f, 0.2375f, 0f);
        uvs[0] = new Vector2(vertices[0].y, vertices[0].z);

        vertices[1] = new Vector3(.50625f, -.22169550f, -.9270834f) + new Vector3(0f, -.060f, 0f);
        uvs[1] = new Vector2(vertices[1].y, vertices[1].z);

        vertices[2] = new Vector3(.50625f, .1581796f, -.9270834f);
        uvs[2] = new Vector2(vertices[2].y, vertices[2].z);

        vertices[3] = new Vector3(.50625f, -.22169550f, -.9270834f) + new Vector3(0.375f - 0.015625f,0f,0.375f + 0.015625f*8f) + new Vector3(0f, -.060f, 0f);
        uvs[3] = new Vector2(vertices[3].y, vertices[3].z);

        vertices[4] = new Vector3(.50625f, .1581796f, -.9270834f) + new Vector3(0.375f - 0.015625f, 0f, 0.375f + 0.015625f * 8f);
        uvs[4] = new Vector2(vertices[4].y, vertices[4].z);

        vertices[5] = new Vector3(.50625f, .5380546f, -.9270834f) + new Vector3(0.375f - 0.015625f, 0.2375f, 0.375f + 0.015625f * 8f);
        uvs[5] = new Vector2(vertices[5].y, vertices[5].z);

        vertices[6] = 0.5f * vertices[5] + 0.5f * vertices[0];
        uvs[6] = new Vector2(vertices[6].y, vertices[6].z);

        vertices[7] = 0.5f * vertices[4] + 0.5f * vertices[2];
        uvs[7] = new Vector2(vertices[7].y, vertices[7].z);


        vertices[8] = 0.2f * vertices[5] + 0.8f * vertices[0];
        uvs[8] = new Vector2(vertices[8].y, vertices[8].z);

        vertices[9] = 0.2f * vertices[4] + 0.8f * vertices[2];
        uvs[9] = new Vector2(vertices[9].y, vertices[9].z);

        vertices[10] = 0.55f * vertices[6] + 0.45f * vertices[7];
        uvs[10] = new Vector2(vertices[10].y, vertices[10].z);

        vertices[11] = 0.55f * vertices[8] + 0.45f * vertices[9];
        uvs[11] = new Vector2(vertices[11].y, vertices[11].z);

        Vector3 aTemp = vertices[6] - vertices[8];
        float radius = aTemp.magnitude * 0.5f;

//        Vector3 probe = new Vector3(0f, -0.125f, 0f);
//        vertices[0] = vertices[0] + probe;




        vertices[12] = (vertices[10] + vertices[11]) * 0.5f;//Midpoint of Arch.
        uvs[12] = new Vector2(vertices[12].y, vertices[12].z);

        vertices[13] = vertices[10] + new Vector3(0f, -0.09375f, 0f);
        uvs[13] = new Vector2(vertices[13].y, vertices[13].z);

        vertices[14] = new Vector3(0.6320313f, 0.4977359f, -0.7520834f);
        uvs[14] = new Vector2(vertices[14].y, vertices[14].z);

        vertices[15] = new Vector3(0.65561526f, 0.49187653f, -0.7192709f);
        uvs[15] = new Vector2(vertices[15].y, vertices[15].z);

        vertices[16] = new Vector3(0.67246095f, 0.4742984f, -0.6958334f);
        uvs[16] = new Vector2(vertices[16].y, vertices[16].z);

        vertices[17] = new Vector3(0.68256836f, 0.44500153f, -0.6817709f);
        uvs[17] = new Vector2(vertices[17].y, vertices[17].z);

        vertices[18] = new Vector3(0.6859375f, 0.4039859f, -0.6770834f);
        uvs[18] = new Vector2(vertices[18].y, vertices[18].z);

        vertices[19] = vertices[11] + new Vector3(0f, -0.09375f, 0f);
        uvs[19] = new Vector2(vertices[19].y, vertices[19].z);


        vertices[20] = new Vector3(0.6320313f, 0.4977359f, -0.7520834f);
        uvs[20] = new Vector2(vertices[20].y, vertices[20].z);

        vertices[21] = new Vector3(0.60844734f, 0.49187653f, -0.7848959f);
        uvs[21] = new Vector2(vertices[21].y, vertices[21].z);

        vertices[22] = new Vector3(0.59160165f, 0.4742984f, -0.8083334f);
        uvs[22] = new Vector2(vertices[22].y, vertices[22].z);

        vertices[23] = new Vector3(0.58149424f, 0.44500153f, -0.8223959f);
        uvs[23] = new Vector2(vertices[23].y, vertices[23].z);

        vertices[24] = new Vector3(0.5781251f, 0.4039859f, -0.8270834f);
        uvs[24] = new Vector2(vertices[24].y, vertices[24].z);


        // 12 is probably a dead vert. It might be the mid vert.
        // 13 is probably a dead vert. It might be the mid vert.
        // 19 is probably a dead vert.

        //        Vector3 probe = new Vector3(0f, -0.125f, 0f);


        //        Vector3 probe = new Vector3(0.125f, 0f, 0f);
        //        vertices[25] = vertices[25] + probe;



        // Need to Bezier Curve this:

        //   Left =  Vector3( 0.6859375f, 0.4977359f, -.6770834f)

        //  Right =  Vector3( 0.5781251f, 0.4977359f, -0.8270834f)


        //Midpoint=  Vector3( 0.6320313f, 0.4977359f,-0.7520834f)

        // BotLeft=  Vector3( 0.6859375f, 0.4039859f,-0.6770834f)

        string fileName = "VertRecords4.txt";

        var sr = File.CreateText(fileName);

        Vector3 pos1;

        float xx;
        float yy;
        float zz;
        pos1 = vertices[9];
        xx = pos1[0];
        yy = pos1[1];
        zz = pos1[2];
        sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
        //      24 to 20
        for (int L = 0; L < 5; L++)
        {
            pos1 = vertices[24 - L];
            xx = pos1[0];
            yy = pos1[1];
            zz = pos1[2];
            sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
        }
        //      14 to 18
        for (int L = 0; L < 5; L++)
        {
            pos1 = vertices[14 + L];
            xx = pos1[0];
            yy = pos1[1];
            zz = pos1[2];
            sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
        }
        pos1 = vertices[7];
        xx = pos1[0];
        yy = pos1[1];
        zz = pos1[2];
        sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
        sr.Close();


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


