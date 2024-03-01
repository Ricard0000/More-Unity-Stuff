using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Wall1InnerWall : MonoBehaviour
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

        vertices = new Vector3[22];
        triangles = new int[66];
        uvs = new Vector2[22];

        // TO DO: Probe Verts in on wall. Then print out verts




        vertices[0] = new Vector3(-0.74375f, -0.2816955f, -0.9270834f);
        vertices[1] = new Vector3(-0.74375f, 0.2783045f, -0.9270834f);
        vertices[2] = new Vector3(-0.7270986f, 0.3619995f, -0.9270834f);
        vertices[3] = new Vector3(-0.6796796f, 0.4393734f, -0.9270834f);
        vertices[4] = new Vector3(-0.608712f, 0.4999052f, -0.9270834f);
        vertices[5] = new Vector3(-0.525f, 0.53802f, -0.9270834f);
        vertices[6] = new Vector3(-0.441288f, 0.4999053f, -0.9270834f);
        vertices[7] = new Vector3(-0.3703204f, 0.4393734f, -0.9270834f);
        vertices[8] = new Vector3(-0.3229013f, 0.3619996f, -0.9270834f);
        vertices[9] = new Vector3(-0.30625f, 0.2783045f, -0.9270834f);
        vertices[10] = new Vector3(-0.30625f, -0.2816955f, -0.9270834f);

        float moveBack = -0.125f;
        vertices[11] = new Vector3(-0.74375f, -0.2816955f, -0.9270834f + moveBack);
        vertices[12] = new Vector3(-0.74375f, 0.2783045f, -0.9270834f + moveBack);
        vertices[13] = new Vector3(-0.7270986f, 0.3619995f, -0.9270834f + moveBack);
        vertices[14] = new Vector3(-0.6796796f, 0.4393734f, -0.9270834f + moveBack);
        vertices[15] = new Vector3(-0.608712f, 0.4999052f, -0.9270834f + moveBack);
        vertices[16] = new Vector3(-0.525f, 0.53802f, -0.9270834f + moveBack);
        vertices[17] = new Vector3(-0.441288f, 0.4999053f, -0.9270834f + moveBack);
        vertices[18] = new Vector3(-0.3703204f, 0.4393734f, -0.9270834f + moveBack);
        vertices[19] = new Vector3(-0.3229013f, 0.3619996f, -0.9270834f + moveBack);
        vertices[20] = new Vector3(-0.30625f, 0.2783045f, -0.9270834f + moveBack);
        vertices[21] = new Vector3(-0.30625f, -0.2816955f, -0.9270834f + moveBack);



        for (int i = 0; i < 10; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + 0] = i + 1;
            triangles[i3 + 1] = i;
            triangles[i3 + 2] = 11 + i;
        }
        int nextTri = 10 * 3;
        for (int i = 0; i < 10; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3 + 0] = i + 1;
            triangles[nextTri + i3 + 1] = 11 + i;
            triangles[nextTri + i3 + 2] = 11 + i + 1;
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
