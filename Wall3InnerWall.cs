using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Wall3InnerWall : MonoBehaviour
{

    public ParticleSystem system;

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

    float delta_theta = (PI / 2) / N;
    float delta_circ = (PI / 2) / N;
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

        //N=number of splits per quarter.

        vertices = new Vector3[36];
        triangles = new int[17*6];
        uvs = new Vector2[36];


        vertices[0] = new Vector3(-0.875f, 0.003662168f, -0.5520833f);
        vertices[1] = new Vector3(-0.8642273f, 0.1404191f, -0.5520833f);
        vertices[2] = new Vector3(-0.8321745f, 0.2783932f, -0.5520833f);
        vertices[3] = new Vector3(-0.7796308f, 0.4116732f, -0.5520833f);// TO ADD
        vertices[4] = new Vector3(-0.7574616f, 0.4509184f, -0.5582013f);
        vertices[5] = new Vector3(-0.7374625f, 0.486322f, -0.5759562f);//
        vertices[6] = new Vector3(-0.7215912f, 0.5144184f, -0.6036102f);
        vertices[7] = new Vector3(-0.7114012f, 0.5324574f, -0.6384562f);
        vertices[8] = new Vector3(-0.7078899f, 0.5386732f, -0.6770833f);
        vertices[9] = new Vector3(-0.7078899f, 0.5386732f, -0.6770833f);
        vertices[10] = new Vector3(-0.7114012f, 0.5324574f, -0.7157105f);
        vertices[11] = new Vector3(-0.7215912f, 0.5144184f, -0.7505565f);
        vertices[12] = new Vector3(-0.7374625f, 0.486322f, -0.7782105f);
        vertices[13] = new Vector3(-0.7574616f, 0.4509184f, -0.7959654f);
        vertices[14] = new Vector3(-0.7796308f, 0.4116732f, -0.8020833f);// There is no 77 up there.
        vertices[15] = new Vector3(-0.8321745f, 0.2783932f, -0.8020833f);
        vertices[16] = new Vector3(-0.8642273f, 0.1404191f, -0.8020833f);
        vertices[17] = new Vector3(-0.875f, 0.003662168f, -0.8020833f);

        float moveBack = -0.0625f;
        vertices[18] = new Vector3(-0.875f + moveBack, 0.003662168f, -0.5520833f);
        vertices[19] = new Vector3(-0.875f + moveBack, 0.1404191f, -0.5520833f);
        vertices[20] = new Vector3(-0.875f + moveBack, 0.2783932f, -0.5520833f);
        vertices[21] = new Vector3(-0.875f + moveBack, 0.4116732f, -0.5520833f);// TO ADD
        vertices[22] = new Vector3(-0.875f + moveBack, 0.4509184f, -0.5582013f);
        vertices[23] = new Vector3(-0.875f + moveBack, 0.486322f, -0.5759562f);//
        vertices[24] = new Vector3(-0.875f + moveBack, 0.5144184f, -0.6036102f);
        vertices[25] = new Vector3(-0.875f + moveBack, 0.5324574f, -0.6384562f);
        vertices[26] = new Vector3(-0.875f + moveBack, 0.5386732f, -0.6770833f);
        vertices[27] = new Vector3(-0.875f + moveBack, 0.5386732f, -0.6770833f);
        vertices[28] = new Vector3(-0.875f + moveBack, 0.5324574f, -0.7157105f);
        vertices[29] = new Vector3(-0.875f + moveBack, 0.5144184f, -0.7505565f);
        vertices[30] = new Vector3(-0.875f + moveBack, 0.486322f, -0.7782105f);
        vertices[31] = new Vector3(-0.875f + moveBack, 0.4509184f, -0.7959654f);
        vertices[32] = new Vector3(-0.875f + moveBack, 0.4116732f, -0.8020833f);// There is no 77 up there.
        vertices[33] = new Vector3(-0.875f + moveBack, 0.2783932f, -0.8020833f);
        vertices[34] = new Vector3(-0.875f + moveBack, 0.1404191f, -0.8020833f);
        vertices[35] = new Vector3(-0.875f + moveBack, 0.003662168f, -0.8020833f);

/*
        vertices[17] = new Vector3(-0.875f + moveBack, 0.003662168f, -0.5520833f);
        vertices[18] = new Vector3(-0.875f + moveBack, 0.1404191f, -0.5520833f);
        vertices[19] = new Vector3(-0.875f + moveBack, 0.2783932f, -0.5520833f);
        vertices[20] = new Vector3(-0.875f + moveBack, 0.4509184f, -0.5582013f);
        vertices[21] = new Vector3(-0.875f + moveBack, 0.486322f, -0.5759562f);
        vertices[22] = new Vector3(-0.875f + moveBack, 0.5144184f, -0.6036102f);
        vertices[23] = new Vector3(-0.875f + moveBack, 0.5324574f, -0.6384562f);
        vertices[24] = new Vector3(-0.875f + moveBack, 0.5386732f, -0.6770833f);
        vertices[25] = new Vector3(-0.875f + moveBack, 0.5386732f, -0.6770833f);
        vertices[26] = new Vector3(-0.875f + moveBack, 0.5324574f, -0.7157105f);
        vertices[27] = new Vector3(-0.875f + moveBack, 0.5144184f, -0.7505565f);
        vertices[28] = new Vector3(-0.875f + moveBack, 0.486322f, -0.7782105f);
        vertices[29] = new Vector3(-0.875f + moveBack, 0.4509184f, -0.7959654f);
        vertices[30] = new Vector3(-0.875f + moveBack, 0.4116732f, -0.8020833f);
        vertices[31] = new Vector3(-0.875f + moveBack, 0.2783932f, -0.8020833f);
        vertices[32] = new Vector3(-0.875f + moveBack, 0.1404191f, -0.8020833f);
        vertices[33] = new Vector3(-0.875f + moveBack, 0.003662168f, -0.8020833f);
*/

        for (int i = 0; i < 17; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + 0] = i + 1;
            triangles[i3 + 1] = i;
            triangles[i3 + 2] = 18 + i;
        }
        
        int nextTri = 17 * 3;
        for (int i = 0; i < 17; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3 + 0] = 18 + i;
            triangles[nextTri + i3 + 1] = 18 + i + 1;
            triangles[nextTri + i3 + 2] = i + 1;
        }
        
        /*
        // This is a vert closure..... Could be a problem for uploading a cad model to matlab............
        nextTri = nextTri + 3 * 22;

        triangles[nextTri + 0] = 0 ;
        triangles[nextTri + 1] = 23;
        triangles[nextTri + 2] = 45;

        triangles[nextTri + 3] = 22;
        triangles[nextTri + 4] = 0;
        triangles[nextTri + 5] = 45;
*/

        // TO DO: Custum or not? UV coordinates?



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
    /*
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
    */
}
