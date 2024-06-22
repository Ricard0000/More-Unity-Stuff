using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh48 : MonoBehaviour
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


        Vector3 Pos = new Vector3(2.476f, 0.73f, -3.226f);

        float scaleHorizontal = 0.7f;
        float scaleVertical = 1.25f;
        vertices[0] = new Vector3(0f, 1f * scaleVertical, -0.5f * scaleHorizontal);
        vertices[1] = new Vector3(0f, 0f, -0.5f * scaleHorizontal);
        vertices[2] = new Vector3(0f, 1f * scaleVertical, 0.5f * scaleHorizontal);
        vertices[3] = new Vector3(0f, 0f, 0.5f * scaleHorizontal);


        float temp;
        for (int i = 0; i < 4; i++)
        {
            temp = vertices[i].x;
            vertices[i].x = Mathf.Cos(Mathf.PI / 4f) * vertices[i].x + Mathf.Sin(Mathf.PI / 4f) * vertices[i].z;
            vertices[i].z = -Mathf.Sin(Mathf.PI / 4f) * temp + Mathf.Cos(Mathf.PI / 4f) * vertices[i].z;
        }

        vertices[0] = vertices[0] + Pos;
        vertices[1] = vertices[1] + Pos;
        vertices[2] = vertices[2] + Pos;
        vertices[3] = vertices[3] + Pos;

        uvs[0] = new Vector2(0f, 1f);
        uvs[1] = new Vector2(0f, 0f);
        uvs[2] = new Vector2(1f, 1f);
        uvs[3] = new Vector2(1f, 0f);


        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 3;
        triangles[4] = 2;
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
