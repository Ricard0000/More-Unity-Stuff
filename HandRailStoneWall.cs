using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HandRailStoneWall : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    Vector2[] uvs;
    int[] triangles;

    const float PI = 3.1415926535897931f;


    const int N = 8;
    const int N1 = 16;


    float Pos1 = 0.1825f - 0.0625f;//Object position
    float Pos2 = -0.221875f-0.06f;
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

        vertices = new Vector3[20];// + 2]; /* 2 + 2 * N1*/
        triangles = new int[3*2 + 6 * N];
        uvs = new Vector2[20];// + 2]; /* 2 + 2 * N1*/

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3 newPosition = new Vector3(-0.0625f, 0f, 0f);

        vertices[0] = new Vector3(0f,0f,0f) + POS + newPosition;
        uvs[0] = new Vector2(vertices[0].y, vertices[0].z);

        vertices[1] = new Vector3(0f, 0.325f, 0f) + POS + newPosition;
        uvs[1] = new Vector2(vertices[1].y, vertices[1].z);

        vertices[2] = new Vector3(0f, 0f, 0.125f) + POS + newPosition;
        uvs[2] = new Vector2(vertices[2].y, vertices[2].z);

        vertices[3] = new Vector3(0f, 0.325f, 0.125f) + POS + newPosition;
        uvs[3] = new Vector2(vertices[3].y, vertices[3].z);

        float r = 0.1875f;

        vertices[4] = new Vector3(.12f, 0.04312501f, -.8025f);
        vertices[4] = vertices[4] + new Vector3(((float)0 / (4 * N)) * ((float)0 / (4 * N)), 0f, 0f) + newPosition;
        uvs[4] = new Vector2(vertices[4].y, vertices[4].z);

        vertices[5] = new Vector3(.12f, -0.00554846f, -0.78826531f);
        vertices[5] = vertices[5] + new Vector3(((float)1 / (4 * N)) * ((float)1 / (4 * N)), 0f, 0f) + newPosition;
        uvs[5] = new Vector2(vertices[5].y, vertices[5].z);

        vertices[6] = new Vector3(.12f, -0.04692602f, -0.76984694f);
        vertices[6] = vertices[6] + new Vector3(((float)2 / (4 * N)) * ((float)2 / (4 * N)), 0f, 0f) + newPosition;
        uvs[6] = new Vector2(vertices[6].y, vertices[6].z);

        vertices[7] = new Vector3(.12f, -0.08100765f, -0.7472449f);
        vertices[7] = vertices[7] + new Vector3(((float)3 / (4 * N)) * ((float)3 / (4 * N)), 0f, 0f) + newPosition;
        uvs[7] = new Vector2(vertices[7].y, vertices[7].z);

        vertices[8] = new Vector3(.12f, -0.10779337f, -0.72045918f);
        vertices[8] = vertices[8] + new Vector3(((float)4 / (4 * N)) * ((float)4 / (4 * N)), 0f, 0f) + newPosition;
        uvs[8] = new Vector2(vertices[8].y, vertices[8].z);

        vertices[9] = new Vector3(.12f, -0.12728316f, -0.6894898f);
        vertices[9] = vertices[9] + new Vector3(((float)5 / (4 * N)) * ((float)5 / (4 * N)), 0f, 0f) + newPosition;
        uvs[9] = new Vector2(vertices[9].y, vertices[9].z);

        vertices[10] = new Vector3(.12f, -0.13947704f, -0.65433673f);
        vertices[10] = vertices[10] + new Vector3(((float)6 / (4 * N)) * ((float)6 / (4 * N)), 0f, 0f) + newPosition;
        uvs[10] = new Vector2(vertices[10].y, vertices[10].z);

        vertices[11] = new Vector3(.12f, -0.144375f, -0.615f);
        vertices[11] = vertices[11] + new Vector3(((float)7 / (4 * N)) * ((float)7 / (4 * N)), 0f, 0f) + newPosition;
        uvs[11] = new Vector2(vertices[11].y, vertices[11].z);







        vertices[12] = new Vector3(.12f, Pos2, -.8025f);
        vertices[12] = vertices[12] + new Vector3(((float)0 / (4 * N)) * ((float)0 / (4 * N)), 0f, 0f) + newPosition;
        uvs[12] = new Vector2(vertices[12].y, vertices[12].z);

        vertices[13] = new Vector3(.12f, Pos2, -0.78826531f);
        vertices[13] = vertices[13] + new Vector3(((float)1 / (4 * N)) * ((float)1 / (4 * N)), 0f, 0f) + newPosition;
        uvs[13] = new Vector2(vertices[13].y, vertices[13].z);

        vertices[14] = new Vector3(.12f, Pos2, -0.76984694f);
        vertices[14] = vertices[14] + new Vector3(((float)2 / (4 * N)) * ((float)2 / (4 * N)), 0f, 0f) + newPosition;
        uvs[14] = new Vector2(vertices[14].y, vertices[14].z);

        vertices[15] = new Vector3(.12f, Pos2, -0.7472449f);
        vertices[15] = vertices[15] + new Vector3(((float)3 / (4 * N)) * ((float)3 / (4 * N)), 0f, 0f) + newPosition;
        uvs[15] = new Vector2(vertices[15].y, vertices[15].z);

        vertices[16] = new Vector3(.12f, Pos2, -0.72045918f);
        vertices[16] = vertices[16] + new Vector3(((float)4 / (4 * N)) * ((float)4 / (4 * N)), 0f, 0f) + newPosition;
        uvs[16] = new Vector2(vertices[16].y, vertices[16].z);

        vertices[17] = new Vector3(.12f, Pos2, -0.6894898f);
        vertices[17] = vertices[17] + new Vector3(((float)5 / (4 * N)) * ((float)5 / (4 * N)), 0f, 0f) + newPosition;
        uvs[17] = new Vector2(vertices[17].y, vertices[17].z);

        vertices[18] = new Vector3(.12f, Pos2, -0.65433673f);
        vertices[18] = vertices[18] + new Vector3(((float)6 / (4 * N)) * ((float)6 / (4 * N)), 0f, 0f) + newPosition;
        uvs[18] = new Vector2(vertices[18].y, vertices[18].z);

        vertices[19] = new Vector3(.12f, Pos2, -0.615f);
        vertices[19] = vertices[19] + new Vector3(((float)7 / (4 * N)) * ((float)7 / (4 * N)), 0f, 0f) + newPosition;
        uvs[19] = new Vector2(vertices[19].y, vertices[19].z);


        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;
        
        int nextVert = 4;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = i * 3;
            triangles[6 + i3 + 0] = nextVert + N + i;
            triangles[6 + i3 + 1] = nextVert + i;
            triangles[6 + i3 + 2] = nextVert + i + 1;
        }

        nextVert = nextVert + N;
        int nextTri = 3 * N + 6;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = nextVert + i + 1;
            triangles[nextTri + i3 + 1] = nextVert + i;
            triangles[nextTri + i3 + 2] = 4 + i +1;
        }

        /*
                int nextTri = 6 + 3 * N;
                triangles[nextTri + 0] = 1 + nextVert;
                triangles[nextTri + 1] = 2 + nextVert;
                triangles[nextTri + 2] = 3 + nextVert;

                triangles[nextTri + 3] = 3 + nextVert;
                triangles[nextTri + 4] = 2 + nextVert;
                triangles[nextTri + 5] = 4 + nextVert;
        */

        /*
        triangles[nextTri + 6] = 2 + nextVert;
        triangles[nextTri + 7] = 5 + nextVert;
        triangles[nextTri + 8] = 6 + nextVert;

        triangles[nextTri + 9] = 5 + nextVert;
        triangles[nextTri + 10] = 2 + nextVert;
        triangles[nextTri + 11] = 1 + nextVert;


        triangles[nextTri + 12] = 7 + nextVert;
        triangles[nextTri + 13] = 6 + nextVert;
        triangles[nextTri + 14] = 5 + nextVert;

        triangles[nextTri + 15] = 6 + nextVert;
        triangles[nextTri + 16] = 7 + nextVert;
        triangles[nextTri + 17] = 8 + nextVert;
        /*
/*
        nextTri = nextTri + 18;
        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 9 + nextVert + i;
            triangles[nextTri + i3 + 1] = 10 + nextVert + i;
            triangles[nextTri + i3 + 2] = N1 + 9 + nextVert + i;
        }
        nextTri = nextTri + 3*N1;
        for (int i = 0; i < N1 - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 10 + nextVert + i;
            triangles[nextTri + i3 + 1] = N1 + 10 + nextVert + i;
            triangles[nextTri + i3 + 2] = N1 + 9 + nextVert + i;


        }
*/

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
