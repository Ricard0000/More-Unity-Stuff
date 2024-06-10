using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Mesh16 : MonoBehaviour
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
        vertices = new Vector3[2 * N];
        triangles = new int[6 * N];
        uvs = new Vector2[2 * N];
        float meshScale = 4f;

        float dx = 0.00625f;
        float dy = 0.03125f * 0.25f;
        float dz = 0.00625f;
        float r = 0.03f;

        float moveback = 0.0625f;

        Vector3 center = 0.25f * (new Vector3(.04364003f + dx * 0.75f, .4068946f, -.9270834f + dz * 0.75f) + new Vector3(-.01421997f - dx * 0.75f, .4068946f, -.9270834f + dz * 0.75f) + new Vector3(.04364003f + dx * 0.75f, .4068946f, -.9270834f - dz * 0.75f - moveback) + new Vector3(-.01421997f - dx * 0.75f, .4068946f, -.9270834f - dz * 0.75f - moveback));

        for (int i = 0; i < N; i++)
        {
            vertices[i] = new Vector3(1.1f * r * Mathf.Cos(2f * PI * i / (float)(N - 1)) + center[0], center[1] - 0.02f - dy * 6.25f, 1.1f * r * Mathf.Sin(2f * PI * i / (float)(N - 1)) + center[2]);
        }
        int nextVert = N;

        for (int i = 0; i < N; i++)
        {
            vertices[nextVert + i] = new Vector3(1.1f * r * Mathf.Cos(2f * PI * i / (float)(N - 1)) + center[0], center[1] - 0.02f - dy * 33f, 1.1f * r * Mathf.Sin(2f * PI * i / (float)(N - 1)) + center[2]);
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] + POS;
        }

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