using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh45 : MonoBehaviour
{

    Mesh mesh;
    Vector3[] vertices;
    Vector2[] uvs;
    int[] triangles;

    const float PI = 3.1415926535897931f;

    public Material mat;
    GameObject gog;
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(mat, true);
    }

    public static GameObject MakeDiscreteProceduralGrid(Material mat, bool collider)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

        Mesh m = new Mesh();

        vertices = new Vector3[4];
        triangles = new int[6];
        uvs = new Vector2[4];


        Vector3 Pos = new Vector3(-3.836f, 0.425f, -2.727f);

        float scaleHorizontal = 0.85f;
        float scaleVertical = 1.75f;
        vertices[0] = new Vector3(0f, 1f * scaleVertical, -0.5f * scaleHorizontal) + Pos;
        vertices[1] = new Vector3(0f, 0f , -0.5f * scaleHorizontal) + Pos;
        vertices[2] = new Vector3(0f, 1f * scaleVertical,  0.5f * scaleHorizontal) + Pos;
        vertices[3] = new Vector3(0f, 0f,  0.5f * scaleHorizontal) + Pos;


        uvs[0] = new Vector2(0f, 1f);
        uvs[1] = new Vector2(0f, 0f);
        uvs[2] = new Vector2(1f, 1f);
        uvs[3] = new Vector2(1f, 0f);


        triangles[0] = 1;
        triangles[1] = 0;
        triangles[2] = 2;

        triangles[3] = 2;
        triangles[4] = 3;
        triangles[5] = 1;

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



    public static float twoDDistance(float x, float y)
    {
        return Mathf.Sqrt(x * x + y * y);
    }


}
