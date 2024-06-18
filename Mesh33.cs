using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh33 : MonoBehaviour
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

    public Material mat;
    GameObject gog;
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, N, N1, mat, true);
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

        vertices = new Vector3[4];
        triangles = new int[12];
        uvs = new Vector2[4];
        float meshScale = 4f;
        float moveBack = -0.0675f;
        vertices[0] = new Vector3(-0.24375f, 0.02817959f, -0.9270834f + moveBack);
        uvs[0] = new Vector2(0f, 0f);
        vertices[1] = new Vector3(0.24596f, 0.02817959f, -0.9270834f + moveBack);
        uvs[1] = new Vector2(1f, 0f);

        vertices[2] = new Vector3(-0.24375f, 0.5380546f, -0.9270834f + moveBack) + new Vector3(0f, -0.08f, 0f);
        uvs[2] = new Vector2(0f, 1f);
        
        vertices[3] = new Vector3(0.24596f, 0.5380546f, -0.9270834f + moveBack) + new Vector3(0f, -0.08f, 0f);
        
        uvs[3] = new Vector2(1f, 1f);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 3;
        triangles[4] = 2;
        triangles[5] = 1;

        triangles[6] = 0;
        triangles[7] = 2;
        triangles[8] = 1;
        triangles[9] = 3;
        triangles[10] = 1;
        triangles[11] = 2;



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
