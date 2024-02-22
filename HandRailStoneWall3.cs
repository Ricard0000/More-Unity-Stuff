using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HandRailStoneWall3 : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    Vector2[] uvs;
    int[] triangles;

    const float PI = 3.1415926535897931f;


    const int N = 8;
    const int N1 = 6;


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
//        mesh = GetComponent<MeshFilter>().mesh;
    }
    void Start()
    {
//        MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, N, N1);
//        UpdateMesh();
    }

    public static float Arch_eq(float x, float c1, float c2)
    {
        float y;
        y = c2 * (1.0f - 0.5f * Mathf.Abs(x / (c1 + 0.000001f)));
        y = y + c2 * Mathf.Sqrt(1 - (x * x) / (c1 * 1.1547006f * c1 * 1.1547006f + 0.000001f));
        y = y * 0.5f - 0.5f * c2;
        return y;
    }

    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, int N, int N1, Material mat, bool collider)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Mesh m = new Mesh();

        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

        vertices = new Vector3[2 * N1 + 2 + 2 * N1];
        triangles = new int[6 * N1 + 6 + 6 * N1];
        uvs = new Vector2[2 * N1 + 2 + 2 * N1];

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);


        float dx = 0.00625f;
        float dy = 0.05f;
        float r = 0.1875f;

        float r1 = 0.0375f;
        float addLength = -0.0625f*0.5f;
        
        //circle part
        for (int i = 0; i < N1; i++)
        {
            vertices[0 + i] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(PI/2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(PI/2 * (i) / (N1 - 1)));
            uvs[0 + i] = new Vector2(vertices[0 + i].x, vertices[0 + i].y);
        }
        
        for (int i = 0; i < N1; i++)
        {
            vertices[N1 + i] = new Vector3(dx + dy, 0f, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(PI/2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(PI/2 * (i) / (N1 - 1)));
            uvs[N1 + i] = new Vector2(vertices[N1 + i].x, vertices[N1 + i].y);
        }


        //quad part
        vertices[2 * N1] = new Vector3(dx + dy, 0f, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(PI / 2), 0f, r1 * Mathf.Sin(PI / 2)) + new Vector3(-0.0625f, 0f, 0f) + new Vector3(addLength,0f,0f);
        uvs[2 * N1] = new Vector2(vertices[2 * N1].x, vertices[2 * N1].y);

        vertices[2 * N1 + 1] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(PI / 2), 0f, r1 * Mathf.Sin(PI / 2)) + new Vector3(-0.0625f, 0f, 0f) + new Vector3(addLength, 0f, 0f);
        uvs[2 * N1 + 1] = new Vector2(vertices[2 * N1 + 1].x, vertices[2 * N1 + 1].y);

        //        vertices[2 * N1 + 1] = new Vector3(dx + dy, 0f, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(PI / 2), 0f, r1 * Mathf.Sin(PI / 2)) + new Vector3(-0.5f,0f,0f);
        //        uvs[2 * N1 + 1] = new Vector2(vertices[2 * N1 + 1].x, vertices[2 * N1 + 1].y);

        for (int i = 0; i < N1; i++)
        {
            vertices[2 * N1 + 2 + i] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(PI / 2 + PI / 2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(PI / 2 + PI / 2 * (i) / (N1 - 1))) + new Vector3(-0.0625f, 0f, 0f) + new Vector3(addLength, 0f, 0f);
            uvs[2 * N1 + 2 + i] = new Vector2(vertices[2 * N1 + 2 + i].x, vertices[2 * N1 + 2 + i].y);
        }

        for (int i = 0; i < N1; i++)
        {
            vertices[3 * N1 + 2 + i] = new Vector3(dx + dy, 0f, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(PI / 2 + PI / 2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(PI / 2 + PI / 2 * (i) / (N1 - 1))) + new Vector3(-0.0625f, 0f, 0f) + new Vector3(addLength, 0f, 0f);
            uvs[3 * N1 + 2 + i] = new Vector2(vertices[3 * N1 + 2 + i].x, vertices[3 * N1 + 2 + i].y);
        }





        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[i3 + 0] = i;
            triangles[i3 + 1] = 1 + i;
            triangles[i3 + 2] = N1 + i;
        }
        int nextTri = 3 * N1;
        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 1 + i;
            triangles[nextTri + i3 + 1] = N1 + 1 + i;
            triangles[nextTri + i3 + 2] = N1 + i;
        }
        nextTri = 3 * N1 + nextTri;

        triangles[nextTri + 0] = 2 * N1;
        triangles[nextTri + 1] = 2 * N1 - 1;
        triangles[nextTri + 2] = N1 - 1;

        triangles[nextTri + 3] = 2 * N1 + 1;
        triangles[nextTri + 4] = 2 * N1;
        triangles[nextTri + 5] = N1 - 1;
        nextTri = nextTri + 6;

        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 2 * N1 + 2 + i;
            triangles[nextTri + i3 + 1] = 2 * N1 + 3 + i;
            triangles[nextTri + i3 + 2] = 3 * N1 + 2 + i;
        }

        nextTri = nextTri + 3 * N1;
        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 3 * N1 + 2 + i;
            triangles[nextTri + i3 + 1] = 2 * N1 + 3 + i;
            triangles[nextTri + i3 + 2] = 3 * N1 + 2 + i + 1;
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
