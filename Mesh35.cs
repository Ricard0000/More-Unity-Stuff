using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh35 : MonoBehaviour
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

        vertices = new Vector3[6 + 2 * N1];// + 2]; /* 2 + 2 * N1*/
        triangles = new int[3 * 2 + 3 * N + 3 + 3 + 6 + 6 + 6 * N1];
        uvs = new Vector2[6 + 2 * N1];// + 2]; /* 2 + 2 * N1*/

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3 newPosition = new Vector3(-0.0625f, 0f, 0f);

        float moveX = -0.04375f;
        float addLength = -0.0625f * 0.5f;
        float meshScale = 4f;

        float dx = 0.00625f;
        float dy = 0.05f;
        float r = 0.1875f;


        vertices[0] = new Vector3(0f, 0.325f - r, r + 0.125f) + POS + new Vector3(0.04785156f, 0f, 0f) + newPosition; // Checking 1
//        uvs[0] = new Vector2(vertices[0].x, vertices[0].z);

        vertices[1] = new Vector3(dx, 0.325f - r, 0.125f + r + dx) + POS + new Vector3(0.04785156f, 0f, 0f) + newPosition;
//        uvs[1] = new Vector2(vertices[1].x, vertices[1].z);

        vertices[2] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx) + POS + new Vector3(0.01f, 0f, 0f) + newPosition;
//        uvs[2] = new Vector2(vertices[2].x, vertices[2].z);




        vertices[3] = new Vector3(0f, 0f, r + 0.125f) + POS + new Vector3(0.04785156f, 0f, 0f) + newPosition; // Checking 1
//        uvs[3] = new Vector2(vertices[3].x, vertices[3].z);

        vertices[4] = new Vector3(dx, 0f, 0.125f + r + dx) + POS + new Vector3(0.04785156f, 0f, 0f) + newPosition;
//        uvs[4] = new Vector2(vertices[4].x, vertices[4].z);

        vertices[5] = new Vector3(dx + dy, 0f, 0.125f + r + dx) + POS + new Vector3(0.01f, 0f, 0f) + newPosition;
//        uvs[5] = new Vector2(vertices[5].x, vertices[5].z);

        float r1 = 0.0375f;
        int nextVert = 6;
        for (int i = 0; i < N1; i++)
        {
            vertices[nextVert + i] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(-PI / 2 + PI / 2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(-PI / 2 + PI / 2 * (i) / (N1 - 1)));
            vertices[nextVert + i] = vertices[nextVert + i] + new Vector3(0.01f, 0f, 0f) + newPosition;
//            uvs[nextVert + i] = new Vector2(vertices[nextVert + i].x, vertices[nextVert + i].z);
        }

        nextVert = nextVert + N1;
        for (int i = 0; i < N1; i++)
        {
            vertices[nextVert + i] = new Vector3(dx + dy, 0f, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(-PI / 2 + PI / 2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(-PI / 2 + PI / 2 * (i) / (N1 - 1)));
            vertices[nextVert + i] = vertices[nextVert + i] + new Vector3(0.01f, 0f, 0f) + newPosition;
//            uvs[nextVert + i] = new Vector2(vertices[nextVert + i].x, vertices[nextVert + i].z);
        }



        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }





        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 3;

        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 4;

        triangles[6] = 4;
        triangles[7] = 3;
        triangles[8] = 1;

        triangles[9] = 5;
        triangles[10] = 4;
        triangles[11] = 2;

        triangles[12] = 2;
        triangles[13] = 6;
        triangles[14] = 5;

        triangles[15] = N1 + 6;//wierd... flip 6 and 5?
        triangles[16] = 5;
        triangles[17] = 6;



        int nextTri = 18;
        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 6 + i;
            triangles[nextTri + i3 + 1] = 7 + i;
            triangles[nextTri + i3 + 2] = N1 + 6 + i;
        }

        nextTri = nextTri + 3 * N1;
        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = N1 + 6 + i;
            triangles[nextTri + i3 + 1] = 7 + i;
            triangles[nextTri + i3 + 2] = N1 + 7 + i;
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
