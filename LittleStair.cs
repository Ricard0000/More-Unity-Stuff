using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class LittleStair : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    Vector2[] uvs;
    int[] triangles;

    const float PI = 3.1415926535897931f;


    const int N = 4;
    const int N_cir = 4;

    public float c1 = 4.25f;//x-direction
    public float c2 = 2.75f;//y-direction
    public float c3 = 3.75f;//z-direction
    public float R = 0.125f;

    float delta_theta = (PI / 2) / N;
    float delta_circ = (PI / 2) / N;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }
    void Start()
    {
        MakeDiscreteProceduralGrid();
        UpdateMesh();
    }

    public static float Arch_eq(float x, float c1, float c2)
    {
        float y;
        y = c2 * (1.0f - 0.5f * Mathf.Abs(x / (c1 + 0.000001f)));
        y = y + c2 * Mathf.Sqrt(1 - (x * x) / (c1 * 1.1547006f * c1 * 1.1547006f + 0.000001f));
        y = y * 0.5f - 0.5f * c2;
        return y;
    }

    void MakeDiscreteProceduralGrid()
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Mesh m = new Mesh();

        //N=number of splits per quarter.

        vertices = new Vector3[(2 * N + 1) * (N_cir + 1) + (2 * N + 1) * (N_cir + 1) + (2 * N + 1) * (N_cir + 1)];
        triangles = new int[12 * N * N_cir + 12 * N * N_cir + 12 * N * N_cir];
        uvs = new Vector2[(2 * N + 1) * (N_cir + 1) + (2 * N + 1) * (N_cir + 1) + (2 * N + 1) * (N_cir + 1)];

        float x;
        float y;
        float z;
        float t;
        float tt;
        for (int j = 0; j < N_cir; j++)
        {
            t = -PI * 0.5f + PI * 0.5f * (j) / (N_cir - 1);
            tt = (float)j / (float)N_cir;
            for (int i = 0; i < 2 * N + 1; i++)
            {
                x = -1.0f * c1 + 2.0f * c1 * i / (2.0f * N);
                y = R * Mathf.Sin(t) + R + Arch_eq(x, c1, c2);
                z = R * Mathf.Cos(t);
                vertices[i + j * (2 * N + 1)] = new Vector3(x, y, z);
                uvs[i + j * (2 * N + 1)] = new Vector2(0.5f + 0.5f / c1 * x, tt);
            }
        }
        int next_vert = 2 * N + 2 + (2 * N - 1) + (2 * N + 1) * (N_cir - 2) + 1;





        int next_tri;
        for (int j = 0; j < 3 * N_cir; j++)
        {
            next_tri = 12 * N * j;
            for (int i = 0; i < 2 * N; i++)
            {
                triangles[6 * i + 0 + next_tri] = 0 + i + (2 * N + 1) * j;
                triangles[6 * i + 1 + next_tri] = 1 + i + (2 * N + 1) * j;
                triangles[6 * i + 2 + next_tri] = 2 * N + 1 + i + (2 * N + 1) * j;
                triangles[6 * i + 3 + next_tri] = 2 * N + 1 + i + (2 * N + 1) * j;
                triangles[6 * i + 4 + next_tri] = 1 + i + (2 * N + 1) * j;
                triangles[6 * i + 5 + next_tri] = 2 * N + 2 + i + (2 * N + 1) * j;
            }
        }


    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
}
