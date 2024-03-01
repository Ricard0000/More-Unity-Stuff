using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Wall2InnerWall : MonoBehaviour
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

        vertices = new Vector3[46+5];
        triangles = new int[23*6 + 24];
        uvs = new Vector2[46+5];

        vertices[0] = new Vector3(-0.24375f, 0.1281796f, -0.9270834f);
        vertices[1] = new Vector3(0.50625f, 0.1281796f, -0.9270834f);
        vertices[2] = new Vector3(0.27275f, 0.1281796f, -0.9270834f);
        vertices[3] = new Vector3(0.27317f, 0.4068946f, -0.92708340f);
        vertices[4] = new Vector3(0.2631861f, 0.4570874f, -0.9270834f);
        vertices[5] = new Vector3(0.2347541f, 0.4996387f, -0.9270834f);
        vertices[6] = new Vector3(0.1922028f, 0.5280706f, -0.9270834f);
        vertices[7] = new Vector3(0.14201f, 0.5380546f, -0.9270834f);
        vertices[8] = new Vector3(0.1748f, 0.5380546f, -0.9270834f);
        vertices[9] = new Vector3(0.1246073f, 0.5280706f, -0.9270834f);
        vertices[10] = new Vector3(0.0820559f, 0.4996387f, -0.9270834f);
        vertices[11] = new Vector3(0.05362398f, 0.4570873f, -0.9270834f);
        vertices[12] = new Vector3(0.04364002f, 0.4068946f, -0.9270834f);
        vertices[13] = new Vector3(-0.01421997f, 0.4068946f, -0.9270834f);
        vertices[14] = new Vector3(-0.02420392f, 0.4570873f, -0.9270834f);
        vertices[15] = new Vector3(-0.05263584f, 0.4996387f, -0.9270834f);
        vertices[16] = new Vector3(-0.0951872f, 0.5280706f, -0.9270834f);
        vertices[17] = new Vector3(-0.14538f, 0.5380546f, -0.9270834f);
        vertices[18] = new Vector3(-0.11259f, 0.5380546f, -0.9270834f);
        vertices[19] = new Vector3(-0.1627827f, 0.5280706f, -0.9270834f);
        vertices[20] = new Vector3(-0.2053341f, 0.4996387f, -0.9270834f);
        vertices[21] = new Vector3(-0.233766f, 0.4570874f, -0.9270834f);
        vertices[22] = new Vector3(-0.24375f, 0.4068946f, -0.9270834f);

        float moveBack = -0.125f;
        vertices[23] = new Vector3(-0.24375f, 0.1281796f, -0.9270834f + moveBack);
        vertices[24] = new Vector3(0.50625f, 0.1281796f, -0.9270834f + moveBack);
        vertices[25] = new Vector3(0.27275f, 0.1281796f, -0.9270834f + moveBack);
        vertices[26] = new Vector3(0.27317f, 0.4068946f, -0.92708340f + moveBack);
        vertices[27] = new Vector3(0.2631861f, 0.4570874f, -0.9270834f + moveBack);
        vertices[28] = new Vector3(0.2347541f, 0.4996387f, -0.9270834f + moveBack);
        vertices[29] = new Vector3(0.1922028f, 0.5280706f, -0.9270834f + moveBack);
        vertices[30] = new Vector3(0.14201f, 0.5380546f, -0.9270834f + moveBack);
        vertices[31] = new Vector3(0.1748f, 0.5380546f, -0.9270834f + moveBack);
        vertices[32] = new Vector3(0.1246073f, 0.5280706f, -0.9270834f + moveBack);
        vertices[33] = new Vector3(0.0820559f, 0.4996387f, -0.9270834f + moveBack);
        vertices[34] = new Vector3(0.05362398f, 0.4570873f, -0.9270834f + moveBack);
        vertices[35] = new Vector3(0.04364002f, 0.4068946f, -0.9270834f + moveBack);
        vertices[36] = new Vector3(-0.01421997f, 0.4068946f, -0.9270834f + moveBack);
        vertices[37] = new Vector3(-0.02420392f, 0.4570873f, -0.9270834f + moveBack);
        vertices[38] = new Vector3(-0.05263584f, 0.4996387f, -0.9270834f + moveBack);
        vertices[39] = new Vector3(-0.0951872f, 0.5280706f, -0.9270834f + moveBack);
        vertices[40] = new Vector3(-0.14538f, 0.5380546f, -0.9270834f + moveBack);
        vertices[41] = new Vector3(-0.11259f, 0.5380546f, -0.9270834f + moveBack);
        vertices[42] = new Vector3(-0.1627827f, 0.5280706f, -0.9270834f + moveBack);
        vertices[43] = new Vector3(-0.2053341f, 0.4996387f, -0.9270834f + moveBack);
        vertices[44] = new Vector3(-0.233766f, 0.4570874f, -0.9270834f + moveBack);
        vertices[45] = new Vector3(-0.24375f, 0.4068946f, -0.9270834f + moveBack);

        for (int i = 0; i < 22; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + 0] = i;
            triangles[i3 + 1] = i + 1;
            triangles[i3 + 2] = 23 + i;
        }

        
        int nextTri = 22 * 3;
        for (int i = 0; i < 22; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3 + 0] = 23 + i + 1;
            triangles[nextTri + i3 + 1] = 23 + i;
            triangles[nextTri + i3 + 2] = i + 1;
        }

        // This is a vert closure..... Could be a problem for uploading a cad model to matlab............
        nextTri = nextTri + 3 * 22;

        triangles[nextTri + 0] = 0 ;
        triangles[nextTri + 1] = 23;
        triangles[nextTri + 2] = 45;

        triangles[nextTri + 3] = 22;
        triangles[nextTri + 4] = 0;
        triangles[nextTri + 5] = 45;


        // TO DO: Custum or not? UV coordinates?



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
