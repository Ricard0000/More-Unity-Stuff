using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Mesh31 : MonoBehaviour
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

        vertices = new Vector3[12];
        triangles = new int[18];
        uvs = new Vector2[12];
        float meshScale = 4f;


        float moveback = -1.9604166f;
        vertices[0] = new Vector3(0.40625f, 1.5380546f, -1.0395834f);
        uvs[0] = new Vector2(vertices[0].x, vertices[0].z);
        vertices[1] = new Vector3(-0.925f, 1.5380546f, -1.0395834f);
        uvs[1] = new Vector2(vertices[1].x, vertices[1].z);
        vertices[2] = new Vector3(0.40625f, 1.5380546f, -1.0395834f + moveback);
        uvs[2] = new Vector2(vertices[2].x, vertices[2].z);
        vertices[3] = new Vector3(-0.925f, 1.5380546f, -1.0395834f + moveback);
        uvs[3] = new Vector2(vertices[3].x, vertices[3].z);


        vertices[4] = new Vector3(0.40625f, 1.5380546f, -1.0395834f);
        uvs[4] = new Vector2(vertices[4].y, vertices[4].z);
        vertices[5] = new Vector3(0.40625f, 1.5380546f, -1.0395834f + moveback);
        uvs[5] = new Vector2(vertices[5].y, vertices[5].z);
        vertices[6] = new Vector3(0.40625f, -0.1566955f, -1.0395834f);
        uvs[6] = new Vector2(vertices[6].y, vertices[6].z);
        vertices[7] = new Vector3(0.40625f, -0.1566955f, -1.0395834f + moveback);
        uvs[7] = new Vector2(vertices[7].y, vertices[7].z);


        vertices[8] = new Vector3(-0.925f, 1.5380546f, -1.0395834f);
        uvs[8] = new Vector2(vertices[8].y, vertices[8].z);
        vertices[9] = new Vector3(-0.925f, 1.5380546f, -1.0395834f + moveback);
        uvs[9] = new Vector2(vertices[9].y, vertices[9].z);
        vertices[10] = new Vector3(-0.925f, -0.1566955f, -1.0395834f);
        uvs[10] = new Vector2(vertices[10].y, vertices[10].z);
        vertices[11] = new Vector3(-0.925f, -0.1566955f, -1.0395834f + moveback);
        uvs[11] = new Vector2(vertices[11].y, vertices[11].z);



        triangles[0] = 1;
        triangles[1] = 2;
        triangles[2] = 0;

        triangles[3] = 3;
        triangles[4] = 2;
        triangles[5] = 1;


        triangles[6] = 5;
        triangles[7] = 6;
        triangles[8] = 4;

        triangles[9] = 7;
        triangles[10] = 6;
        triangles[11] = 5;

        triangles[12] = 8;
        triangles[13] = 10;
        triangles[14] = 9;

        triangles[15] = 10;
        triangles[16] = 11;
        triangles[17] = 9;




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


