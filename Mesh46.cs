using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh46 : MonoBehaviour
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

        vertices = new Vector3[4 * 4 * 2];
        triangles = new int[6 * 4 * 2];
        uvs = new Vector2[4 * 4 * 2];


        Vector3 Pos = new Vector3(-3.836f + 0.2f, 0.425f-0.4f, -2.727f+0.0625f/4f);

        
        Vector3 Pos1 = new Vector3(0f, 0f, -.10625f);
        Vector3 Pos2 = new Vector3(0f, 0f, -.10625f - 0.2125f);
        Vector3 Pos3 = new Vector3(0f, 0f, 0.10625f);
        Vector3 Pos4 = new Vector3(0f, 0f, .10625f + 0.2125f);

        Vector3 Pos5 = new Vector3(0f, 0.26875f + 0.15f, 0f);
        Vector3 Pos6 = new Vector3(0f, 0.26875f + 0.45f + 0.15f, 0f);
        Vector3 Pos7 = new Vector3(0f, 0.26875f + 2f * 0.45f + 0.15f, 0f);
        Vector3 Pos8 = new Vector3(0f, 0.26875f + 3f * 0.45f + 0.15f, 0f);



        float scaleHorizontal = 0.025f;
        float scaleVertical = 2.15f;

        float scaleHorizontal2 = 1.1f;
        float scaleVertical2 = 2.15f * 0.0125f;

        //frontface

        vertices[0] = new Vector3(0f, 1f * scaleVertical, -0.5f * scaleHorizontal) + Pos + Pos1; 
        vertices[1] = new Vector3(0f, 0f , -0.5f * scaleHorizontal) + Pos + Pos1;
        vertices[2] = new Vector3(0f, 1f * scaleVertical,  0.5f * scaleHorizontal) + Pos + Pos1;
        vertices[3] = new Vector3(0f, 0f,  0.5f * scaleHorizontal) + Pos + Pos1;

        vertices[4] = new Vector3(0f, 1f * scaleVertical, -0.5f * scaleHorizontal) + Pos + Pos2;
        vertices[5] = new Vector3(0f, 0f, -0.5f * scaleHorizontal) + Pos + Pos2;
        vertices[6] = new Vector3(0f, 1f * scaleVertical, 0.5f * scaleHorizontal) + Pos + Pos2;
        vertices[7] = new Vector3(0f, 0f, 0.5f * scaleHorizontal) + Pos + Pos2;

        vertices[8] = new Vector3(0f, 1f * scaleVertical, -0.5f * scaleHorizontal) + Pos + Pos3;
        vertices[9] = new Vector3(0f, 0f, -0.5f * scaleHorizontal) + Pos + Pos3;
        vertices[10] = new Vector3(0f, 1f * scaleVertical, 0.5f * scaleHorizontal) + Pos + Pos3;
        vertices[11] = new Vector3(0f, 0f, 0.5f * scaleHorizontal) + Pos + Pos3;

        vertices[12] = new Vector3(0f, 1f * scaleVertical, -0.5f * scaleHorizontal) + Pos + Pos4;
        vertices[13] = new Vector3(0f, 0f, -0.5f * scaleHorizontal) + Pos + Pos4;
        vertices[14] = new Vector3(0f, 1f * scaleVertical, 0.5f * scaleHorizontal) + Pos + Pos4;
        vertices[15] = new Vector3(0f, 0f, 0.5f * scaleHorizontal) + Pos + Pos4;

        vertices[16] = new Vector3(0f, 1f * scaleVertical2, -0.5f * scaleHorizontal2) + Pos + Pos5;
        vertices[17] = new Vector3(0f, 0f, -0.5f * scaleHorizontal2) + Pos + Pos5;
        vertices[18] = new Vector3(0f, 1f * scaleVertical2, 0.5f * scaleHorizontal2) + Pos + Pos5;
        vertices[19] = new Vector3(0f, 0f, 0.5f * scaleHorizontal2) + Pos + Pos5;

        vertices[20] = new Vector3(0f, 1f * scaleVertical2, -0.5f * scaleHorizontal2) + Pos + Pos6;
        vertices[21] = new Vector3(0f, 0f, -0.5f * scaleHorizontal2) + Pos + Pos6;
        vertices[22] = new Vector3(0f, 1f * scaleVertical2, 0.5f * scaleHorizontal2) + Pos + Pos6;
        vertices[23] = new Vector3(0f, 0f, 0.5f * scaleHorizontal2) + Pos + Pos6;

        vertices[24] = new Vector3(0f, 1f * scaleVertical2, -0.5f * scaleHorizontal2) + Pos + Pos7;
        vertices[25] = new Vector3(0f, 0f, -0.5f * scaleHorizontal2) + Pos + Pos7;
        vertices[26] = new Vector3(0f, 1f * scaleVertical2, 0.5f * scaleHorizontal2) + Pos + Pos7;
        vertices[27] = new Vector3(0f, 0f, 0.5f * scaleHorizontal2) + Pos + Pos7;

        vertices[28] = new Vector3(0f, 1f * scaleVertical2, -0.5f * scaleHorizontal2) + Pos + Pos8;
        vertices[29] = new Vector3(0f, 0f, -0.5f * scaleHorizontal2) + Pos + Pos8;
        vertices[30] = new Vector3(0f, 1f * scaleVertical2, 0.5f * scaleHorizontal2) + Pos + Pos8;
        vertices[31] = new Vector3(0f, 0f, 0.5f * scaleHorizontal2) + Pos + Pos8;

        for (int i = 0; i < 8; i++)
        {
            triangles[0 + 6 * i] = 1 + 4 * i;
            triangles[1 + 6 * i] = 0 + 4 * i;
            triangles[2 + 6 * i] = 2 + 4 * i;
            triangles[3 + 6 * i] = 2 + 4 * i;
            triangles[4 + 6 * i] = 3 + 4 * i;
            triangles[5 + 6 * i] = 1 + 4 * i;
        }


        for (int i = 0; i < 32; i++)
        {
            uvs[i] = new Vector2(vertices[i].y, vertices[i].z);
        }

        //TO DO: Add depth?


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
    public static Vector3[] BuildQuad()
    {
        Vector3[] vect;
        return vect;
    }
    */





    public static float twoDDistance(float x, float y)
    {
        return Mathf.Sqrt(x * x + y * y);
    }


}
