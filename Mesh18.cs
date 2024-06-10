using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        float meshScale = 4f;

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);


        vertices[0] = new Vector3(0.50625f, -0.28125f, -0.927125f);
        vertices[1] = new Vector3(0.8655f, -0.28125f, -0.427125f);
        vertices[2] = new Vector3(0.50625f, -0.28125f, -0.427125f);
        vertices[3] = new Vector3(-0.86875f, -0.28125f, -0.427125f);
        vertices[4] = new Vector3(-0.86875f, -0.28125f, -0.927125f);





        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;
        triangles[3] = 0;
        triangles[4] = 3;
        triangles[5] = 1;
        triangles[6] = 3;
        triangles[7] = 0;
        triangles[8] = 4;





        uvs[0] = new Vector2(0.50625f, -0.927125f);
        uvs[1] = new Vector2(0.8655f, -0.427125f);
        uvs[2] = new Vector2(0.50625f, -0.427125f);
        uvs[3] = new Vector2(-0.86875f, -0.427125f);
        uvs[4] = new Vector2(-0.86875f, -0.927125f);



        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] * meshScale;
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
