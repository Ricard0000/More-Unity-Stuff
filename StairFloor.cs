using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class StairFloor : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    Vector2[] uvs;
    int[] triangles;

    const float PI = 3.1415926535897931f;


    const int N = 4;
    const int N_cir = 4;

    float Pos1 = 0.50625f;//Object position
    float Pos2 = -0.28125f;
    float Pos3 = -0.927125f;//4375f;


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
//        mesh = GetComponent<MeshFilter>().mesh;
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, mat, true);
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

    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, Material mat, bool collider)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Mesh m = new Mesh();

        //N=number of splits per quarter.

        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;


        vertices = new Vector3[5];
        triangles = new int[9];
        uvs = new Vector2[5];

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);


        vertices[0] = new Vector3(0f, 0f, 0f) + POS;
        uvs[0] = new Vector2(vertices[0].x, vertices[0].z);

        vertices[1] = new Vector3(0.35925f, 0f, 0.5f) + POS;
        uvs[1] = new Vector2(vertices[1].x, vertices[1].z);

        vertices[2] = new Vector3(0f, 0f, 0.5f) + POS;
        uvs[2] = new Vector2(vertices[2].x, vertices[2].z);

        vertices[3] = new Vector3(-1.375f, 0f, 0.5f) + POS;
        uvs[3] = new Vector2(vertices[3].x, vertices[3].z);

        vertices[4] = new Vector3(-1.375f, 0f, 0f) + POS;
        uvs[4] = new Vector2(vertices[4].x, vertices[4].z);



        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 0;
        triangles[4] = 3;
        triangles[5] = 1;

        triangles[6] = 3;
        triangles[7] = 0;
        triangles[8] = 4;

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
