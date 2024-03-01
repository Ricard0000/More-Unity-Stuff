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

        vertices = new Vector3[2 * N1 + 16];
        triangles = new int[12 * N1];
        uvs = new Vector2[2 * N1 + 16];

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3 newPosition = new Vector3(-0.0625f, 0f, 0f);

        float dx = 0.00625f;
        float dy = 0.05f;
        float r = 0.1875f;

        float r1 = 0.0375f;
        float addLength = -0.0625f*0.5f;


        
        for (int i = 0; i < N1; i++)
        {
            vertices[i] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(PI / 2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(PI / 2 * (i) / (N1 - 1)));
            vertices[i] = vertices[i] + new Vector3(0.01f, 0f, 0f) + newPosition;
            uvs[i] = new Vector2(vertices[i].y, vertices[i].z);
        }

        int nextVert = N1;
        for (int i = 0; i < N1; i++)
        {
            vertices[nextVert + i] = new Vector3(dx + dy, 0f, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(PI / 2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(PI / 2 * (i) / (N1 - 1)));
            vertices[nextVert + i] = vertices[nextVert + i] + new Vector3(0.01f, 0f, 0f) + newPosition;
            uvs[nextVert + i] = new Vector2(vertices[nextVert + i].y, vertices[nextVert + i].z);
        }

        nextVert = nextVert + N1;

        vertices[nextVert + 0] = new Vector3(0.18625f, -.144375f, -0.53375f) + newPosition;
        uvs[nextVert + 0] = new Vector2(vertices[nextVert + 0].y, vertices[nextVert + 0].z);

        vertices[nextVert + 1] = new Vector3(0.17091837f, -.144375f, -0.53451531f) + newPosition;
        uvs[nextVert + 1] = new Vector2(vertices[nextVert + 1].y, vertices[nextVert + 1].z);

        vertices[nextVert + 2] = new Vector3(0.15706633f, -.144375f, -0.53681122f) + newPosition;
        uvs[nextVert + 2] = new Vector2(vertices[nextVert + 2].y, vertices[nextVert + 2].z);

        vertices[nextVert + 3] = new Vector3(0.14469388f, -.144375f, -0.54063776f) + newPosition;
        uvs[nextVert + 3] = new Vector2(vertices[nextVert + 3].y, vertices[nextVert + 3].z);

        vertices[nextVert + 4] = new Vector3(0.13380102f, -.144375f, -0.5459949f) + newPosition;
        uvs[nextVert + 4] = new Vector2(vertices[nextVert + 4].y, vertices[nextVert + 4].z);

        vertices[nextVert + 5] = new Vector3(0.12438776f, -.144375f, -0.55288265f) + newPosition;
        uvs[nextVert + 5] = new Vector2(vertices[nextVert + 5].y, vertices[nextVert + 5].z);

        vertices[nextVert + 6] = new Vector3(0.11645408f, -.144375f, -0.56130102f) + newPosition;
        uvs[nextVert + 6] = new Vector2(vertices[nextVert + 6].y, vertices[nextVert + 6].z);

        vertices[nextVert + 7] = new Vector3(0.11f, -.144375f, -0.57125f) + newPosition;
        uvs[nextVert + 7] = new Vector2(vertices[nextVert + 7].y, vertices[nextVert + 7].z);


        vertices[nextVert + 8] = new Vector3(0.18625f, Pos2, -0.53375f) + newPosition;
        uvs[nextVert + 8] = new Vector2(vertices[nextVert + 8].y, vertices[nextVert + 8].z);

        vertices[nextVert + 9] = new Vector3(0.17091837f, Pos2, - 0.53451531f) + newPosition;
        uvs[nextVert + 9] = new Vector2(vertices[nextVert + 9].y, vertices[nextVert + 9].z);

        vertices[nextVert + 10] = new Vector3(0.15706633f, Pos2, -0.53681122f) + newPosition;
        uvs[nextVert + 10] = new Vector2(vertices[nextVert + 10].y, vertices[nextVert + 10].z);

        vertices[nextVert + 11] = new Vector3(0.14469388f, Pos2, -0.54063776f) + newPosition;
        uvs[nextVert + 11] = new Vector2(vertices[nextVert + 11].y, vertices[nextVert + 11].z);
        
        vertices[nextVert + 12] = new Vector3(0.13380102f, Pos2, -0.5459949f) + newPosition;
        uvs[nextVert + 12] = new Vector2(vertices[nextVert + 12].y, vertices[nextVert + 12].z);

        vertices[nextVert + 13] = new Vector3(0.12438776f, Pos2, -0.55288265f) + newPosition;
        uvs[nextVert + 13] = new Vector2(vertices[nextVert + 13].y, vertices[nextVert + 13].z);

        vertices[nextVert + 14] = new Vector3(0.11645408f, Pos2, -0.56130102f) + newPosition;
        uvs[nextVert + 14] = new Vector2(vertices[nextVert + 14].y, vertices[nextVert + 14].z);

        vertices[nextVert + 15] = new Vector3(0.11f, Pos2, -0.57125f) + newPosition;
        uvs[nextVert + 15] = new Vector2(vertices[nextVert + 15].y, vertices[nextVert + 15].z);


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
            triangles[nextTri + i3 + 0] = i + 1;
            triangles[nextTri + i3 + 1] = N1 + 1 + i;
            triangles[nextTri + i3 + 2] = N1 + i;
        }
        nextTri = 3 * N1 + nextTri;
        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = nextVert + 8 + i;
            triangles[nextTri + i3 + 1] = nextVert + i;
            triangles[nextTri + i3 + 2] = nextVert + i + 1;
        }
        nextTri = 3 * N1 + nextTri;
        
        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = nextVert + 1 + i;
            triangles[nextTri + i3 + 1] = nextVert + 9 + i;
            triangles[nextTri + i3 + 2] = nextVert + i + 8;
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
