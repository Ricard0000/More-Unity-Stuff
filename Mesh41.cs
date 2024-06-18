using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh41 : MonoBehaviour
{


    //Define public variables
    float c1 = 0.5f * (0.40625f + 0.925f);//x-direction
    float c2 = 0.875f;//y-direction
    float c3 = 0.75f;//z-direction
    float c4 = -1f;//from the start of the arch and downwards.
    float s = 0.5f;//Thickness of sides
    float t = 0.5f;//Thickness of Top of arch

    //Define parameters needed to create object
    const float PI = 3.1415926535897931f;
    const int N = 10;
    float delta_theta = (PI / 2) / N;
    public int rot = 0;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot);
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
    public static GameObject MakeDiscreteProceduralGrid(float c1, float c2, float c3, float c4, float s, float t, float delta_theta, int N, bool collider, Material mat, int rot)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Mesh m = new Mesh();

        //        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

//        vertices = new Vector3[(2 * N + 1) + (2 * N + 1 - 2) + 3 + 100];
 //       triangles = new int[6 * N + 3 + 300];
  //      uvs = new Vector2[(2 * N + 1) + (2 * N + 1 - 2) + 3 + 100];

        vertices = new Vector3[56 + 3];
        triangles = new int[129 + 6 + 6 + 3];
        uvs = new Vector2[56 + 3];


        float meshScale = 4f;

        Vector3 Position = new Vector3(-1.05f, 2.0f, -11.0f);

        float angle1 = 0f;// -45f / 180f * PI;
        float x;
        float z;
        float angle = rot * angle1;

        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.25f + 0.125f;
            vertices[i] = Arch_eq_6_A(x, z, c1, c2, angle);
        }

        int nextVert = 2 * N + 1;
        for (int i = 0; i < 2 * N + 1 - 2; i++)
        {
            x = c1 * Mathf.Cos(PI - i * delta_theta);
            z = -0.125f;
            vertices[i + nextVert] = Arch_eq_6_A(x, z, c1, c2, angle);
        }



        nextVert = nextVert + 2 * N + 1 - 2;



        // 4 * N
        vertices[nextVert] = new Vector3(-0.925f, 1.5380546f, 0.25f + 0.125f) - new Vector3(Position.x, Position.y, 0f) / meshScale;
        vertices[nextVert + 1] = new Vector3(0.40625f, 1.5380546f, 0.25f + 0.125f) - new Vector3(Position.x, Position.y, 0f) / meshScale;
        vertices[nextVert + 2] = vertices[N];

        vertices[nextVert + 3] = vertices[nextVert] + new Vector3(0f, 0f, -0.5f);
        vertices[nextVert + 4] = vertices[nextVert + 1] + new Vector3(0f, 0f, -0.5f);
        vertices[nextVert + 5] = vertices[nextVert + 2] + new Vector3(0f, 0f, -0.5f);
        vertices[nextVert + 6] = new Vector3(vertices[4 * N - 1].x, vertices[4 * N - 1].y, vertices[4 * N - 1].z); // cut part
        vertices[nextVert + 7] = new Vector3(vertices[nextVert + 4].x, vertices[4 * N - 1].y, vertices[4 * N - 1].z); // near cut part on wall


        vertices[nextVert + 8] = new Vector3(vertices[4 * N - 1].x, vertices[4 * N - 1].y, vertices[4 * N - 1].z); // cut part
        vertices[nextVert + 9] = new Vector3(vertices[nextVert + 4].x, vertices[4 * N - 1].y, vertices[4 * N - 1].z); // near cut part on wall
        vertices[nextVert + 10] = new Vector3(vertices[4 * N - 1].x, vertices[4 * N - 1].y, vertices[4 * N - 1].z + 0.125f); // cut part
        vertices[nextVert + 11] = new Vector3(vertices[nextVert + 4].x, vertices[4 * N - 1].y, vertices[4 * N - 1].z + 0.125f); // near cut part on wall

        vertices[nextVert + 12] = new Vector3(vertices[4 * N - 1].x, vertices[4 * N - 1].y, vertices[4 * N - 1].z + 0.125f); // cut part
        vertices[nextVert + 13] = new Vector3(vertices[nextVert + 4].x, vertices[4 * N - 1].y, vertices[4 * N - 1].z + 0.125f); // near cut part on wall
        vertices[nextVert + 14] = new Vector3(0.65743f,0.1170341f,0.3750f-0.25f-0.125f);
        vertices[nextVert + 15] = new Vector3(vertices[nextVert + 4].x, 0.1170341f, 0.3750f - 0.25f - 0.125f);
        vertices[nextVert + 16] = new Vector3(0.65743f, 0.1170341f, 0.3750f - 0.25f - 0.125f);
        vertices[nextVert + 17] = new Vector3(vertices[nextVert + 4].x, 0.1170341f, 0.3750f - 0.25f - 0.125f);
        vertices[nextVert + 18] = new Vector3(vertices[nextVert + 4].x, 0.003763763f, 0.3750f - 0.25f - 0.125f);





        for (int i = 0; i < N; i++)
        {
            triangles[3 * i + 0] = 0 + i;
            triangles[3 * i + 1] = 1 + i;
            triangles[3 * i + 2] = 4 * N;
        }

        int nextTri = 3 * N;
        
        for (int i = 0; i < N; i++)
        {
            triangles[3 * i + 0 + nextTri] = 0 + i + 1 * N;
            triangles[3 * i + 1 + nextTri] = 1 + i + 1 * N;
            triangles[3 * i + 2 + nextTri] = 4 * N + 1;
        }
        
        nextTri = 3 * N + nextTri;
        triangles[0 + nextTri] = 4 * N + 1;
        triangles[1 + nextTri] = 4 * N;
        triangles[2 + nextTri] = 4 * N + 2;

        
        nextTri = 3 + nextTri;
        for (int i = 0; i < N; i++)
        {
            triangles[3 * i + 0 + nextTri] = 1 + i + 2 * N + 1;
            triangles[3 * i + 1 + nextTri] = 0 + i + 2 * N + 1;
            triangles[3 * i + 2 + nextTri] = 4 * N + 3;
        }
        
        nextTri = 3 * N + nextTri;
        for (int i = 0; i < N - 2; i++)
        {
            triangles[3 * i + 0 + nextTri] = 2 + i + 3 * N;
            triangles[3 * i + 1 + nextTri] = 1 + i + 3 * N;
            triangles[3 * i + 2 + nextTri] = 4 * N + 4;
        }

        nextTri = 3 * N + nextTri;
        triangles[0 + nextTri] = 4 * N + 3;
        triangles[1 + nextTri] = 4 * N + 4;
        triangles[2 + nextTri] = 4 * N + 5;


        triangles[3 + nextTri] = 4 * N + 4;
        triangles[4 + nextTri] = 4 * N + 7;
        triangles[5 + nextTri] = 4 * N + 6;

        triangles[6 + nextTri] = 4 * N + 10;
        triangles[7 + nextTri] = 4 * N + 8;
        triangles[8 + nextTri] = 4 * N + 9;


        triangles[9 + nextTri] = 4 * N + 11;
        triangles[10 + nextTri] = 4 * N + 10;
        triangles[11 + nextTri] = 4 * N + 9;


        triangles[12 + nextTri] = 4 * N + 12;
        triangles[13 + nextTri] = 4 * N + 13;
        triangles[14 + nextTri] = 4 * N + 14;
        triangles[15 + nextTri] = 4 * N + 13;
        triangles[16 + nextTri] = 4 * N + 15;
        triangles[17 + nextTri] = 4 * N + 14;
        triangles[18 + nextTri] = 4 * N + 16;
        triangles[19 + nextTri] = 4 * N + 17;
        triangles[20 + nextTri] = 4 * N + 18;



        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale + Position;
        }


        for (int i = 0; i < vertices.Length - 4 - 7; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
        }
        for (int i = vertices.Length - 4 - 7; i < vertices.Length - 7; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }

        for (int i = vertices.Length - 7; i < vertices.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
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