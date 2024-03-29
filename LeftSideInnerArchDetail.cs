using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class LeftSideInnerArchDetail : MonoBehaviour
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

        vertices = new Vector3[36];
        triangles = new int[17*6];
        uvs = new Vector2[36];















        vertices[0] = new Vector3(0.5781251f, 0.1581796f, -0.8270834f);
        vertices[1] = new Vector3(0.5781251f, 0.4039859f, -0.8270834f);
        vertices[2] = new Vector3(0.5814942f, 0.4450015f, -0.8223959f);
        vertices[3] = new Vector3(0.5916017f, 0.4742984f, -0.8083334f);
        vertices[4] = new Vector3(0.6084473f, 0.4918765f, -0.7848959f);
        vertices[5] = new Vector3(0.6320313f, 0.4977359f, -0.7520834f);
        vertices[6] = new Vector3(0.6320313f, 0.4977359f, -0.7520834f);
        vertices[7] = new Vector3(0.6556153f, 0.4918765f, -0.7192709f);
        vertices[8] = new Vector3(0.672461f, 0.4742984f, -0.6958334f);
        vertices[9] = new Vector3(0.6825684f, 0.4450015f, -0.6817709f);
        vertices[10] = new Vector3(0.6859375f, 0.4039859f, -0.6770834f);
        vertices[11] = new Vector3(0.6859375f, 0.1581796f, -0.6770834f);

        float moveBackX = 0.0625f;
        float moveBackZ = -0.0625f;
        vertices[12] = new Vector3(0.5781251f + moveBackX, 0.1581796f, -0.8270834f + moveBackZ);
        vertices[13] = new Vector3(0.5781251f + moveBackX, 0.4039859f, -0.8270834f + moveBackZ);
        vertices[14] = new Vector3(0.5814942f + moveBackX, 0.4450015f, -0.8223959f + moveBackZ);
        vertices[15] = new Vector3(0.5916017f + moveBackX, 0.4742984f, -0.8083334f + moveBackZ);
        vertices[16] = new Vector3(0.6084473f + moveBackX, 0.4918765f, -0.7848959f + moveBackZ);
        vertices[17] = new Vector3(0.6320313f + moveBackX, 0.4977359f, -0.7520834f + moveBackZ);
        vertices[18] = new Vector3(0.6320313f + moveBackX, 0.4977359f, -0.7520834f + moveBackZ);
        vertices[19] = new Vector3(0.6556153f + moveBackX, 0.4918765f, -0.7192709f + moveBackZ);
        vertices[20] = new Vector3(0.672461f + moveBackX, 0.4742984f, -0.6958334f + moveBackZ);
        vertices[21] = new Vector3(0.6825684f + moveBackX, 0.4450015f, -0.6817709f + moveBackZ);
        vertices[22] = new Vector3(0.6859375f + moveBackX, 0.4039859f, -0.6770834f + moveBackZ);
        vertices[23] = new Vector3(0.6859375f + moveBackX, 0.1581796f, -0.6770834f + moveBackZ);

        for (int i = 0; i < 11; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + 0] = i + 1;
            triangles[i3 + 1] = i;
            triangles[i3 + 2] = 12 + i;
        }
        
        int nextTri = 11 * 3;
        for (int i = 0; i < 11; i++)
        {
            int i3 = 3 * i;
            triangles[nextTri + i3 + 0] = 12 + i;
            triangles[nextTri + i3 + 1] = 12 + i + 1;
            triangles[nextTri + i3 + 2] = i + 1;
        }

        /*
        // This is a vert closure..... Could be a problem for uploading a cad model to matlab............
        nextTri = nextTri + 3 * 22;

        triangles[nextTri + 0] = 0 ;
        triangles[nextTri + 1] = 23;
        triangles[nextTri + 2] = 45;

        triangles[nextTri + 3] = 22;
        triangles[nextTri + 4] = 0;
        triangles[nextTri + 5] = 45;
*/

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
