using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HandRailStoneWall4 : MonoBehaviour
{
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
        //        mesh = GetComponent<MeshFilter>().mesh;
    }
    void Start()
    {


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

        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;


        Mesh m = new Mesh();

        //N=number of splits per quarter.

        vertices = new Vector3[4 + N + 1 + 3 + 1 + 2 + 4];// + 2]; /* 2 + 2 * N1*/
        triangles = new int[3 * 2 + 3 * N + 3 + 3 + 6 + 6 + 6 * N1 + 6];
        uvs = new Vector2[4 + N + 1 + 3 + 1 + 2 + 4];// + 2]; /* 2 + 2 * N1*/

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);


        float moveX = -0.04375f;
        float addLength = -0.0625f * 0.5f;

        vertices[0] = new Vector3(0f, 0f, 0f) + POS + new Vector3(moveX,0f,0f) + new Vector3(addLength, 0f, 0f);
        uvs[0] = new Vector2(vertices[0].y, vertices[0].z);

        vertices[1] = new Vector3(0f, 0.325f, 0f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);
        uvs[1] = new Vector2(vertices[1].y, vertices[1].z);

        vertices[2] = new Vector3(0f, 0f, 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);
        uvs[2] = new Vector2(vertices[2].y, vertices[2].z);

        vertices[3] = new Vector3(0f, 0.325f, 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);
        uvs[3] = new Vector2(vertices[3].y, vertices[3].z);


        float r = 0.1875f;
        for (int i = 0; i < N; i++)
        {
            vertices[4 + i] = new Vector3(0f, 0.325f, r + 0.125f) + POS + new Vector3(0f, -r * Mathf.Cos(-PI / 2 + PI / 2 * (i) / (N - 1)), r * Mathf.Sin(-PI / 2 + PI / 2 * (i) / (N - 1))) + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);
            uvs[4 + i] = new Vector2(vertices[4 + i].y, vertices[4 + i].z);
        }

        int nextVert = 4 + N;

        vertices[nextVert] = new Vector3(0f, 0.325f - r, 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);
        uvs[nextVert] = new Vector2(vertices[nextVert].y, vertices[nextVert].z);

        vertices[nextVert + 1] = new Vector3(0f, 0.325f - r, r + 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);
        uvs[nextVert + 1] = new Vector2(vertices[nextVert + 1].y, vertices[nextVert + 1].z);

        vertices[nextVert + 2] = new Vector3(0f, 0f, r + 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);
        uvs[nextVert + 2] = new Vector2(vertices[nextVert + 2].y, vertices[nextVert + 2].z);

        vertices[nextVert + 3] = new Vector3(0f, 0.325f - r, 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);
        uvs[nextVert + 3] = new Vector2(vertices[nextVert + 3].y, vertices[nextVert + 3].z);

        vertices[nextVert + 4] = new Vector3(0f, 0f, 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);
        uvs[nextVert + 4] = new Vector2(vertices[nextVert + 4].y, vertices[nextVert + 4].z);

        float r1 = 0.0375f;

        float moveZ = 0.11875f;

        vertices[nextVert + 5] = new Vector3(0f, 0f, 0f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(0f,0f, r + moveZ) + new Vector3(addLength, 0f, 0f);
        uvs[nextVert + 5] = new Vector2(vertices[nextVert + 5].y, vertices[nextVert + 5].z);

        vertices[nextVert + 6] = new Vector3(0f, 0.325f - r, 0f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(0f, 0f, r + moveZ) + new Vector3(addLength, 0f, 0f);
        uvs[nextVert + 6] = new Vector2(vertices[nextVert + 6].y, vertices[nextVert + 6].z);

        vertices[nextVert + 7] = new Vector3(0f, 0f, 0.125f-r1*2) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(0f, 0f, r + moveZ) + new Vector3(addLength, 0f, 0f);
        uvs[nextVert + 7] = new Vector2(vertices[nextVert + 7].y, vertices[nextVert + 7].z);

        vertices[nextVert + 8] = new Vector3(0f, 0.325f - r, 0.125f-r1*2) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(0f, 0f, r + moveZ) + new Vector3(addLength, 0f, 0f);
        uvs[nextVert + 8] = new Vector2(vertices[nextVert + 8].y, vertices[nextVert + 8].z);



        triangles[0] = 1;
        triangles[1] = 0;
        triangles[2] = 2;

        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;


        for (int i = 0; i < N; i++)
        {
            int i3 = i * 3;
            triangles[6 + i3 + 0] = nextVert;
            triangles[6 + i3 + 1] = 4 + i + 1;
            triangles[6 + i3 + 2] = 4 + i;
        }

        int nextTri = 6 + 3 * N;
        triangles[nextTri + 0] = 2 + nextVert;
        triangles[nextTri + 1] = 1 + nextVert;
        triangles[nextTri + 2] = 3 + nextVert;

        triangles[nextTri + 3] = 2 + nextVert;
        triangles[nextTri + 4] = 3 + nextVert;
        triangles[nextTri + 5] = 4 + nextVert;


        nextVert = nextVert + 5;
//        nextVert = nextVert + 6;
        triangles[nextTri + 6] = 1 + nextVert;
        triangles[nextTri + 7] = 0 + nextVert;
        triangles[nextTri + 8] = 2 + nextVert;

        triangles[nextTri + 9] = 1 + nextVert;
        triangles[nextTri + 10] = 2 + nextVert;
        triangles[nextTri + 11] = 3 + nextVert;



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
