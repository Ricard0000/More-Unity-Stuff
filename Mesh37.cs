using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh37 : MonoBehaviour
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
        float meshScale = 4f;
        //N=number of splits per quarter.

        vertices = new Vector3[30];
        triangles = new int[6 + 6 * N + 18];
        uvs = new Vector2[30];

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3 newPosition = new Vector3(-0.0625f, 0f, 0f);

        float moveX = -0.04375f;
        float addLength = -0.0625f * 0.5f;

        vertices[0] = new Vector3(0f, 0f, 0f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f) + newPosition;

        vertices[1] = new Vector3(0f, 0.325f, 0f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f) + newPosition;

        vertices[2] = new Vector3(0f, 0f, 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f) + newPosition;

        vertices[3] = new Vector3(0f, 0.325f, 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f) + newPosition;

        int nextVert = 4;

        vertices[4] = new Vector3(.045f, 0.04312501f, -.8025f);
        vertices[4] = vertices[4] + new Vector3(((float)0 / (4 * N)) * ((float)0 / (4 * N)), 0f, 0f) + newPosition;

        vertices[5] = new Vector3(.045f, -0.00554846f, -0.78826531f);
        vertices[5] = vertices[5] + new Vector3(((float)1 / (4 * N)) * ((float)1 / (4 * N)), 0f, 0f) + newPosition;

        vertices[6] = new Vector3(.045f, -0.04692602f, -0.76984694f);
        vertices[6] = vertices[6] + new Vector3(((float)2 / (4 * N)) * ((float)2 / (4 * N)), 0f, 0f) + newPosition;

        vertices[7] = new Vector3(.045f, -0.08100765f, -0.7472449f);
        vertices[7] = vertices[7] + new Vector3(((float)3 / (4 * N)) * ((float)3 / (4 * N)), 0f, 0f) + newPosition;

        vertices[8] = new Vector3(.045f, -0.10779337f, -0.72045918f);
        vertices[8] = vertices[8] + new Vector3(((float)4 / (4 * N)) * ((float)4 / (4 * N)), 0f, 0f) + newPosition;

        vertices[9] = new Vector3(.045f, -0.12728316f, -0.6894898f);
        vertices[9] = vertices[9] + new Vector3(((float)5 / (4 * N)) * ((float)5 / (4 * N)), 0f, 0f) + newPosition;

        vertices[10] = new Vector3(.045f, -0.13947704f, -0.65433673f);
        vertices[10] = vertices[10] + new Vector3(((float)6 / (4 * N)) * ((float)6 / (4 * N)), 0f, 0f) + newPosition;

        vertices[11] = new Vector3(.045f, -0.144375f, -0.615f);
        vertices[11] = vertices[11] + new Vector3(((float)7 / (4 * N)) * ((float)7 / (4 * N)), 0f, 0f) + newPosition;

        vertices[12] = new Vector3(.045f, Pos2, -.8025f);
        vertices[12] = vertices[12] + new Vector3(((float)0 / (4 * N)) * ((float)0 / (4 * N)), 0f, 0f) + newPosition;

        vertices[13] = new Vector3(.045f, Pos2, -0.78826531f);
        vertices[13] = vertices[13] + new Vector3(((float)1 / (4 * N)) * ((float)1 / (4 * N)), 0f, 0f) + newPosition;

        vertices[14] = new Vector3(.045f, Pos2, -0.76984694f);
        vertices[14] = vertices[14] + new Vector3(((float)2 / (4 * N)) * ((float)2 / (4 * N)), 0f, 0f) + newPosition;

        vertices[15] = new Vector3(.045f, Pos2, -0.7472449f);
        vertices[15] = vertices[15] + new Vector3(((float)3 / (4 * N)) * ((float)3 / (4 * N)), 0f, 0f) + newPosition;

        vertices[16] = new Vector3(.045f, Pos2, -0.72045918f);
        vertices[16] = vertices[16] + new Vector3(((float)4 / (4 * N)) * ((float)4 / (4 * N)), 0f, 0f) + newPosition;

        vertices[17] = new Vector3(.045f, Pos2, -0.6894898f);
        vertices[17] = vertices[17] + new Vector3(((float)5 / (4 * N)) * ((float)5 / (4 * N)), 0f, 0f) + newPosition;

        vertices[18] = new Vector3(.045f, Pos2, -0.65433673f);
        vertices[18] = vertices[18] + new Vector3(((float)6 / (4 * N)) * ((float)6 / (4 * N)), 0f, 0f) + newPosition;

        vertices[19] = new Vector3(.045f, Pos2, -0.615f);
        vertices[19] = vertices[19] + new Vector3(((float)7 / (4 * N)) * ((float)7 / (4 * N)), 0f, 0f) + newPosition;

        float r = 0.1875f;
        float r1 = 0.0375f;
        float moveZ = 0.11875f;
        vertices[20] = new Vector3(0f, 0.325f - r, r + 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f) + new Vector3(0.04785156f, 0f, 0f) + newPosition;

        vertices[21] = new Vector3(0f, 0.325f - r, 0.125f - r1 * 2) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(0f, 0f, r + moveZ) + new Vector3(addLength, 0f, 0f) + new Vector3(0.065f, 0f, 0f) + newPosition;

        vertices[22] = new Vector3(0f, 0f, r + 0.125f) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(addLength, 0f, 0f) + new Vector3(0.04785156f, 0f, 0f) + newPosition;

        vertices[23] = new Vector3(0f, 0f, 0.125f - r1 * 2) + POS + new Vector3(moveX, 0f, 0f) + new Vector3(0f, 0f, r + moveZ) + new Vector3(addLength, 0f, 0f) + new Vector3(0.065f, 0f, 0f) + newPosition;

        vertices[24] = new Vector3(0.11f, -.144375f, -0.57125f) + newPosition; // Need this

        vertices[25] = new Vector3(0.11645408f, -.144375f, -0.56130102f) + newPosition; // Need this

        vertices[26] = new Vector3(0.11f, Pos2, -0.57125f) + newPosition; // Need this

        vertices[27] = new Vector3(0.11645408f, Pos2, -0.56130102f) + newPosition; // Need this

        vertices[28] = new Vector3(0.12438776f, -.144375f, -0.55288265f) + newPosition;

        vertices[29] = new Vector3(0.12438776f, Pos2, -0.55288265f) + newPosition;


        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].y, vertices[i].z);
        }



        triangles[0] = 1;
        triangles[1] = 0;
        triangles[2] = 2;

        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;


        for (int i = 0; i < N - 1; i++)
        {
            int i3 = i * 3;
            triangles[6 + i3 + 0] = 12 + i;
            triangles[6 + i3 + 1] = 5 + i;
            triangles[6 + i3 + 2] = 4 + i;
        }
        int nextTri = 3 * N + 6;
        for (int i = 0; i < N - 1; i++)
        {
            int i3 = i * 3;
            triangles[nextTri + i3 + 0] = 12 + i;
            triangles[nextTri + i3 + 1] = 13 + i;
            triangles[nextTri + i3 + 2] = 5 + i;
        }

        nextTri = nextTri + 3 * N;

        triangles[nextTri + 0] = 20;
        triangles[nextTri + 1] = 22;
        triangles[nextTri + 2] = 21;

        triangles[nextTri + 3] = 21;
        triangles[nextTri + 4] = 22;
        triangles[nextTri + 5] = 23;

        triangles[nextTri + 6] = 24;
        triangles[nextTri + 7] = 26;
        triangles[nextTri + 8] = 25;

        triangles[nextTri + 9] = 25;
        triangles[nextTri + 10] = 26;
        triangles[nextTri + 11] = 27;

        triangles[nextTri + 12] = 29;
        triangles[nextTri + 13] = 28;
        triangles[nextTri + 14] = 27;

        triangles[nextTri + 15] = 27;
        triangles[nextTri + 16] = 28;
        triangles[nextTri + 17] = 25;


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
