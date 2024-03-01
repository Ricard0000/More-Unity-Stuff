using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HandRailStoneWall5 : MonoBehaviour
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
        //        mesh = GetComponent<MeshFilter>().mesh;
    }
    void Start()
    {


        //        UpdateMesh();
    }

    void Update()
    {
        float Pos1 = 0.1825f - 0.0625f;//Object position
        float Pos2 = -0.221875f - 0.06f;
        float Pos3 = -0.9275f;//4375f;
        Vector3 POS;
        POS = new Vector3(Pos1, Pos2, Pos3);
        float moveX = -0.04375f;
        float addLength = -0.0625f * 0.5f;
        float r = 0.1875f;
        float r1 = 0.0375f;
        float moveZ = 0.11875f;

        float dx = 0.00625f;
        float dy = 0.05f;



        //        Vector3 particlePosition = new Vector3(0f, 0.325f - r, r + 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f) + new Vector3(0.04785156f, 0f, 0f);
        //        Vector3 particlePosition = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx) + POS + new Vector3(0.01f, 0f, 0f);

        //        Vector3 particlePosition = new Vector3(0.11f, -.144375f, -0.57125f); // Need this
        //        Vector3 particlePosition = new Vector3(0.11645408f, -.144375f, -0.56130102f); // Need this
        Vector3 particlePosition = new Vector3(0.12438776f, -.144375f, -0.55288265f);
 /*
        Debug.Log(particlePosition * 100000000);
        Debug.Log(particlePosition * 100000000);
        Debug.Log(particlePosition * 100000000);
        Debug.Log(particlePosition * 100000000);
        Debug.Log(particlePosition * 100000000);*/
 //       system.Emit(new ParticleSystem.EmitParams() { position = particlePosition}, 1);
        system.Emit(new ParticleSystem.EmitParams() { position = particlePosition}, 1);




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

        vertices = new Vector3[2 * N + 12 + N1 + 3 * N1];// + 2]; /* 2 + 2 * N1*/
        triangles = new int[6 * N + 12 + 3 + 3 * N1 + 3 + 3 * N1 + 3 * N1];
        uvs = new Vector2[2 * N + 12 + N1 + 3 * N1];// + 2]; /* 2 + 2 * N1*/

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3 newPosition = new Vector3(-0.0625f, 0f, 0f);



        float moveX = -0.04375f;
        float addLength = -0.0625f * 0.5f;


        vertices[0] = new Vector3(0f, 0.325f, 0f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f) + newPosition;
        uvs[0] = new Vector2(vertices[0].x, vertices[0].z);

        vertices[1] = new Vector3(0f, 0.325f, 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f) + newPosition; // Right side
        uvs[1] = new Vector2(vertices[1].x, vertices[1].z);

        vertices[2] = new Vector3(0f, 0.325f, 0f) + POS + newPosition;
        uvs[2] = new Vector2(vertices[2].x, vertices[2].z);

        vertices[3] = new Vector3(0f, 0.325f, 0.125f) + POS + newPosition; //Left side
        uvs[3] = new Vector2(vertices[3].x, vertices[3].z);

        float r = 0.1875f;

        vertices[4] = new Vector3(.045f, 0.04312501f, -.8025f);
        vertices[4] = vertices[4] + new Vector3(((float)0 / (4 * N)) * ((float)0 / (4 * N)), 0f, 0f) + newPosition;
        uvs[4] = new Vector2(vertices[4].x, vertices[4].z);

        vertices[5] = new Vector3(.045f, -0.00554846f, -0.78826531f);
        vertices[5] = vertices[5] + new Vector3(((float)1 / (4 * N)) * ((float)1 / (4 * N)), 0f, 0f) + newPosition;
        uvs[5] = new Vector2(vertices[5].x, vertices[5].z);

        vertices[6] = new Vector3(.045f, -0.04692602f, -0.76984694f);
        vertices[6] = vertices[6] + new Vector3(((float)2 / (4 * N)) * ((float)2 / (4 * N)), 0f, 0f) + newPosition;
        uvs[6] = new Vector2(vertices[6].x, vertices[6].z);

        vertices[7] = new Vector3(.045f, -0.08100765f, -0.7472449f);
        vertices[7] = vertices[7] + new Vector3(((float)3 / (4 * N)) * ((float)3 / (4 * N)), 0f, 0f) + newPosition;
        uvs[7] = new Vector2(vertices[7].x, vertices[7].z);

        vertices[8] = new Vector3(.045f, -0.10779337f, -0.72045918f);
        vertices[8] = vertices[8] + new Vector3(((float)4 / (4 * N)) * ((float)4 / (4 * N)), 0f, 0f) + newPosition;
        uvs[8] = new Vector2(vertices[8].x, vertices[8].z);

        vertices[9] = new Vector3(.045f, -0.12728316f, -0.6894898f);
        vertices[9] = vertices[9] + new Vector3(((float)5 / (4 * N)) * ((float)5 / (4 * N)), 0f, 0f) + newPosition;
        uvs[9] = new Vector2(vertices[9].x, vertices[9].z);

        vertices[10] = new Vector3(.045f, -0.13947704f, -0.65433673f);
        vertices[10] = vertices[10] + new Vector3(((float)6 / (4 * N)) * ((float)6 / (4 * N)), 0f, 0f) + newPosition;
        uvs[10] = new Vector2(vertices[10].x, vertices[10].z);

        vertices[11] = new Vector3(.045f, -0.144375f, -0.615f);
        vertices[11] = vertices[11] + new Vector3(((float)7 / (4 * N)) * ((float)7 / (4 * N)), 0f, 0f) + newPosition;
        uvs[11] = new Vector2(vertices[11].x, vertices[11].z);




        vertices[12] = new Vector3(.12f, 0.04312501f, -.8025f);
        vertices[12] = vertices[12] + new Vector3(((float)0 / (4 * N)) * ((float)0 / (4 * N)), 0f, 0f) + newPosition;
        uvs[12] = new Vector2(vertices[12].x, vertices[12].z);

        vertices[13] = new Vector3(.12f, -0.00554846f, -0.78826531f);
        vertices[13] = vertices[13] + new Vector3(((float)1 / (4 * N)) * ((float)1 / (4 * N)), 0f, 0f) + newPosition;
        uvs[13] = new Vector2(vertices[13].x, vertices[13].z);

        vertices[14] = new Vector3(.12f, -0.04692602f, -0.76984694f);
        vertices[14] = vertices[14] + new Vector3(((float)2 / (4 * N)) * ((float)2 / (4 * N)), 0f, 0f) + newPosition;
        uvs[14] = new Vector2(vertices[14].x, vertices[14].z);

        vertices[15] = new Vector3(.12f, -0.08100765f, -0.7472449f);
        vertices[15] = vertices[15] + new Vector3(((float)3 / (4 * N)) * ((float)3 / (4 * N)), 0f, 0f) + newPosition;
        uvs[15] = new Vector2(vertices[15].x, vertices[15].z);

        vertices[16] = new Vector3(.12f, -0.10779337f, -0.72045918f);
        vertices[16] = vertices[16] + new Vector3(((float)4 / (4 * N)) * ((float)4 / (4 * N)), 0f, 0f) + newPosition;
        uvs[16] = new Vector2(vertices[16].x, vertices[16].z);

        vertices[17] = new Vector3(.12f, -0.12728316f, -0.6894898f);
        vertices[17] = vertices[17] + new Vector3(((float)5 / (4 * N)) * ((float)5 / (4 * N)), 0f, 0f) + newPosition;
        uvs[17] = new Vector2(vertices[17].x, vertices[17].z);

        vertices[18] = new Vector3(.12f, -0.13947704f, -0.65433673f);
        vertices[18] = vertices[18] + new Vector3(((float)6 / (4 * N)) * ((float)6 / (4 * N)), 0f, 0f) + newPosition;
        uvs[18] = new Vector2(vertices[18].x, vertices[18].z);

        vertices[19] = new Vector3(.12f, -0.144375f, -0.615f);
        vertices[19] = vertices[19] + new Vector3(((float)7 / (4 * N)) * ((float)7 / (4 * N)), 0f, 0f) + newPosition;
        uvs[19] = new Vector2(vertices[19].x, vertices[19].z);


        /*
        for (int i = 0; i < N; i++)
        {
            vertices[4 + i] = new Vector3(0f, 0.325f, r + 0.125f) + POS + new Vector3(0f, -r * Mathf.Cos(-PI / 2 + PI / 2 * (i) / (N - 1)), r * Mathf.Sin(-PI / 2 + PI / 2 * (i) / (N - 1))) + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);
            vertices[4 + i] = vertices[4 + i] + new Vector3(((float)i / (4 * N)) * ((float)i / (4 * N)), 0f, 0f);
            uvs[4 + i] = new Vector2(vertices[4 + i].x, vertices[4 + i].z);
        }
        */
/*
        for (int i = 0; i < N; i++)
        {
            vertices[N + 4 + i] = new Vector3(0f, 0.325f, r + 0.125f) + POS + new Vector3(0f, -r * Mathf.Cos(-PI / 2 + PI / 2 * (i) / (N - 1)), r * Mathf.Sin(-PI / 2 + PI / 2 * (i) / (N - 1)));
            vertices[N + 4 + i] = vertices[N + 4 + i] + new Vector3(((float)i / (4 * N)) * ((float)i / (4 * N)), 0f, 0f);
            uvs[N + 4 + i] = new Vector2(vertices[N + 4 + i].x, vertices[N + 4 + i].z);
//            Debug.Log(((float)i / (4 * N)) * ((float)i / (4 * N)));
        }
*/
        int nextVert = 2 * N + 5;

        vertices[nextVert + 0] = new Vector3(0f, 0.325f - r, r + 0.125f) + POS; // Checking 1
        vertices[nextVert + 0] = vertices[nextVert + 0] + new Vector3(0.04785156f, 0f, 0f) + newPosition;
        uvs[nextVert + 0] = new Vector2(vertices[nextVert + 0].x, vertices[nextVert + 0].z);

        vertices[nextVert + 1] = new Vector3(0f, 0.325f - r, r + 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f);// Checking 2
        vertices[nextVert + 1] = vertices[nextVert + 1] + new Vector3(0.04785156f, 0f, 0f) + newPosition;
        uvs[nextVert + 1] = new Vector2(vertices[nextVert + 1].x, vertices[nextVert + 1].z);

        float r1 = 0.0375f;
        float moveZ = 0.11875f;
        vertices[nextVert + 2] = new Vector3(0f, 0.325f - r, 0.125f - r1 * 2) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(0f, 0f, r + moveZ) + new Vector3(addLength, 0f, 0f);// Checking 3
        vertices[nextVert + 2] = vertices[nextVert + 2] + new Vector3(0.065f, 0f, 0f) + newPosition;
        uvs[nextVert + 2] = new Vector2(vertices[nextVert + 2].x, vertices[nextVert + 2].z);

        float dx = 0.00625f;
        float dy = 0.05f;

        vertices[nextVert + 3] = new Vector3(dx, 0.325f - r, 0.125f + r + dx) + POS;// Checking 4
        vertices[nextVert + 3] = vertices[nextVert + 3] + new Vector3(0.04785156f, 0f, 0f) + newPosition;
        uvs[nextVert + 3] = new Vector2(vertices[nextVert + 3].x, vertices[nextVert + 3].z);

        vertices[nextVert + 4] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx) + POS;// Checking 5
        vertices[nextVert + 4] = vertices[nextVert + 4] + new Vector3(0.01f, 0f, 0f) + newPosition;
        uvs[nextVert + 4] = new Vector2(vertices[nextVert + 4].x, vertices[nextVert + 4].z);

        for (int i = 0; i < N1; i++)
        {
            vertices[nextVert + 5 + i] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(-PI / 2 + PI / 2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(-PI / 2 + PI / 2 * (i) / (N1 - 1)));
            vertices[nextVert + 5 + i] = vertices[nextVert + 5 + i] + new Vector3(0.01f, 0f, 0f) + newPosition;
            uvs[nextVert + 5 + i] = new Vector2(vertices[nextVert + 5 + i].x, vertices[nextVert + 5 + i].z);
        }

        nextVert = nextVert + N1 + 5;
        for (int i = 0; i < N1; i++)
        {
            vertices[nextVert + i] = new Vector3(dx + dy, 0.325f - r, 0.125f + r + dx + r1) + POS + new Vector3(r1 * Mathf.Cos(PI / 2 * (i) / (N1 - 1)), 0f, r1 * Mathf.Sin(PI / 2 * (i) / (N1 - 1)));
            vertices[nextVert + i] = vertices[nextVert + i] + new Vector3(0.01f, 0f, 0f) + newPosition;
            uvs[nextVert + i] = new Vector2(vertices[nextVert + i].x, vertices[nextVert + i].z);
        }
        // Last Coordinate of Circle is (0.2,-0.1,-0.5) occurs at line 176 at i = N1-1.
        // Bezier Curve to coordinate (0.1,-0.1,-0.6).

        float cirOffset = 0.025f;
        nextVert = nextVert + N1;

        vertices[nextVert + 0] = new Vector3(0.18625f, -.144375f, -0.53375f) + newPosition;
        uvs[nextVert + 0] = new Vector2(vertices[nextVert + 0].x, vertices[nextVert + 0].z);

        vertices[nextVert + 1] = new Vector3(0.17091837f, -.144375f, -0.53451531f) + newPosition;
        uvs[nextVert + 1] = new Vector2(vertices[nextVert + 1].x, vertices[nextVert + 1].z);

        vertices[nextVert + 2] = new Vector3(0.15706633f, -.144375f, -0.53681122f) + newPosition;
        uvs[nextVert + 2] = new Vector2(vertices[nextVert + 2].x, vertices[nextVert + 2].z);

        vertices[nextVert + 3] = new Vector3(0.14469388f, -.144375f, -0.54063776f) + newPosition;
        uvs[nextVert + 3] = new Vector2(vertices[nextVert + 3].x, vertices[nextVert + 3].z);

        vertices[nextVert + 4] = new Vector3(0.13380102f, -.144375f, -0.5459949f) + newPosition;
        uvs[nextVert + 4] = new Vector2(vertices[nextVert + 4].x, vertices[nextVert + 4].z);

        vertices[nextVert + 5] = new Vector3(0.12438776f, -.144375f, -0.55288265f) + newPosition;
        uvs[nextVert + 5] = new Vector2(vertices[nextVert + 5].x, vertices[nextVert + 5].z);

        vertices[nextVert + 6] = new Vector3(0.11645408f, -.144375f, -0.56130102f) + newPosition;
        uvs[nextVert + 6] = new Vector2(vertices[nextVert + 6].x, vertices[nextVert + 6].z);

        vertices[nextVert + 7] = new Vector3(0.11f, -.144375f, -0.57125f) + newPosition;
        uvs[nextVert + 7] = new Vector2(vertices[nextVert + 7].x, vertices[nextVert + 7].z);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;

        for (int i = 0; i < N - 1; i++)
        {
            int i3 = i * 3;
            triangles[6 + i3 + 0] = 4 + i;
            triangles[6 + i3 + 1] = 4 + i + 1;
            triangles[6 + i3 + 2] = N + 4 + i;
        }

        int nextTri = 3 * N + 6;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 4 + i + 1;
            triangles[nextTri + i3 + 1] = N + 4 + i + 1;
            triangles[nextTri + i3 + 2] = N + 4 + i;
        }

        
        nextTri = nextTri + 3 * N;

        triangles[nextTri + 0] = 2 * N + 5;
        triangles[nextTri + 1] = 2 * N + 6;
        triangles[nextTri + 2] = 2 * N + 7;

        triangles[nextTri + 3] = 2 * N + 5;
        triangles[nextTri + 4] = 2 * N + 7;
        triangles[nextTri + 5] = 2 * N + 8;

        triangles[nextTri + 6] = 2 * N + 8;
        triangles[nextTri + 7] = 2 * N + 7;
        triangles[nextTri + 8] = 2 * N + 9;


        nextTri = nextTri + 10;
        for (int i = 0; i < 2*N1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 2 * N + 10 + i;
            triangles[nextTri + i3 + 1] = 2 * N + 9 + i;
            triangles[nextTri + i3 + 2] = 2 * N + 7;
        }
        
        nextTri = nextTri + 6 * N1 - 1;
        triangles[nextTri + 0] = nextVert + 0;
        triangles[nextTri + 1] = nextVert + 2;
        triangles[nextTri + 2] = nextVert + 1;


        triangles[nextTri + 3] = nextVert + 0;
        triangles[nextTri + 4] = nextVert + 3;
        triangles[nextTri + 5] = nextVert + 2;

        triangles[nextTri + 6] = nextVert + 0;
        triangles[nextTri + 7] = nextVert + 4;
        triangles[nextTri + 8] = nextVert + 3;
        
        triangles[nextTri + 9] = nextVert + 0;
        triangles[nextTri + 10] = nextVert + 5;
        triangles[nextTri + 11] = nextVert + 4;
        
        triangles[nextTri + 12] = nextVert + 0;
        triangles[nextTri + 13] = nextVert + 6;
        triangles[nextTri + 14] = nextVert + 5;

        triangles[nextTri + 15] = nextVert + 0;
        triangles[nextTri + 16] = nextVert + 7;
        triangles[nextTri + 17] = nextVert + 6;

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
