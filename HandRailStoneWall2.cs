using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HandRailStoneWall2 : MonoBehaviour
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

        vertices = new Vector3[4 + N + 1 + 3 + 1 + 2 + 2 * N1];// + 2]; /* 2 + 2 * N1*/
        triangles = new int[3 * 2 + 3 * N + 3 + 3 + 6 + 6 + 6 * N1];
        uvs = new Vector2[4 + N + 1 + 3 + 1 + 2 + 2 * N1];// + 2]; /* 2 + 2 * N1*/

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);


        float dx = 0.00625f;
        float dy = 0.05f;
        float r = 0.1875f;


        vertices[0] = new Vector3(0f, 0.325f - r, 0.125f + r) + POS;
        uvs[0] = new Vector2(vertices[0].x, vertices[0].y);

        vertices[1] = new Vector3(0f, 0f, 0.125f + r) + POS;
        uvs[1] = new Vector2(vertices[1].x, vertices[1].y);


        vertices[2] = new Vector3(dx, 0.325f - r, 0.125f + r + dx) + POS;
        uvs[2] = new Vector2(vertices[2].x, vertices[2].y);

        vertices[3] = new Vector3(dx, 0f, 0.125f + r + dx) + POS;
        uvs[3] = new Vector2(vertices[3].x, vertices[3].y);

        vertices[4] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx) + POS;
        uvs[4] = new Vector2(vertices[4].x, vertices[4].y);

        vertices[5] = new Vector3(dx + dy, 0f, 0.125f + r + dx) + POS;
        uvs[5] = new Vector2(vertices[5].x, vertices[5].y);

        float r1 = 0.0375f;
        
        for (int i = 0; i < N1; i++)
        {
            vertices[6 + i] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(-PI / 2 + PI/2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(-PI / 2 + PI/2 * (i) / (N1 - 1)));
            uvs[6 + i] = new Vector2(vertices[6 + i].x, vertices[6 + i].y);
        }
        
        for (int i = 0; i < N1; i++)
        {
            vertices[N1 + 6 + i] = new Vector3(dx + dy, 0f, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(-PI / 2 + PI/2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(-PI / 2 + PI/2 * (i) / (N1 - 1)));
            uvs[N1 + 6 + i] = new Vector2(vertices[N1 + 6 + i].x, vertices[N1 + 6 + i].y);
        }

        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 2;
        triangles[4] = 3;
        triangles[5] = 1;

        triangles[6] = 3;
        triangles[7] = 2;
        triangles[8] = 4;

        triangles[9] = 3;
        triangles[10] = 4;
        triangles[11] = 5;

        int nextTri = 12;

        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 6 + i;
            triangles[nextTri + i3 + 1] = 7 + i;
            triangles[nextTri + i3 + 2] = N1 + 6 + i;
        }

        nextTri = nextTri + 3 * N1;
        int nextVert = 0;
        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 7 + nextVert + i;
            triangles[nextTri + i3 + 1] = N1 + 7 + nextVert + i;
            triangles[nextTri + i3 + 2] = N1 + 6 + nextVert + i;
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
