using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh4 : MonoBehaviour
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

        //N=number of splits per quarter.

        vertices = new Vector3[22];
        triangles = new int[66];
        uvs = new Vector2[22];
        float meshScale = 4f;






        /*

                vertices[29] = new Vector3(-0.74375f - 0.02f, -0.2816955f, -0.9270834f);
                vertices[30] = new Vector3(-0.86875f, -0.2816955f, -0.9270834f);

                vertices[33] = new Vector3(-0.34625f, -0.2816955f, -0.9270834f);
                vertices[34] = new Vector3(-0.24375f, -0.2816955f, -0.9270834f);
        */

        vertices[0] = new Vector3(-0.74375f - 0.02f, -0.2816955f, -0.9270834f);
        vertices[1] = new Vector3(-0.74375f - 0.02f, 0.2783045f, -0.9270834f);
        vertices[2] = new Vector3(-0.7270986f - 0.02f, 0.3619995f, -0.9270834f);
        vertices[3] = new Vector3(-0.6796796f - 0.02f, 0.4393734f, -0.9270834f);
        vertices[4] = new Vector3(-0.608712f - 0.02f, 0.4999052f, -0.9270834f);
        vertices[5] = new Vector3(-0.525f - 0.02f, 0.53802f, -0.9270834f);
        vertices[6] = new Vector3(-0.441288f - 0.04f, 0.4999053f, -0.9270834f);
        vertices[7] = new Vector3(-0.3703204f - 0.04f, 0.4393734f, -0.9270834f);
        vertices[8] = new Vector3(-0.3229013f - 0.04f, 0.3619996f, -0.9270834f);
        vertices[9] = new Vector3(-0.30625f - 0.04f, 0.2783045f, -0.9270834f);
        vertices[10] = new Vector3(-0.30625f - 0.04f, -0.2816955f, -0.9270834f);
        vertices[11] = new Vector3(-0.74375f - 0.02f, -0.2816955f, -0.9895834f);
        vertices[12] = new Vector3(-0.74375f - 0.02f, 0.2783045f, -0.9895834f);
        vertices[13] = new Vector3(-0.7270986f - 0.02f, 0.3619995f, -0.9895834f);
        vertices[14] = new Vector3(-0.6796796f - 0.02f, 0.4393734f, -0.9895834f);
        vertices[15] = new Vector3(-0.608712f - 0.02f, 0.4999052f, -0.9895834f);
        vertices[16] = new Vector3(-0.525f - 0.04f, 0.53802f, -0.9895834f);
        vertices[17] = new Vector3(-0.441288f - 0.04f, 0.4999053f, -0.9895834f);
        vertices[18] = new Vector3(-0.3703204f - 0.04f, 0.4393734f, -0.9895834f);
        vertices[19] = new Vector3(-0.3229013f - 0.04f, 0.3619996f, -0.9895834f);
        vertices[20] = new Vector3(-0.30625f - 0.04f, 0.2783045f, -0.9895834f);
        vertices[21] = new Vector3(-0.30625f - 0.04f, -0.2816955f, -0.9895834f);
        





        triangles[0] = 1;
        triangles[1] = 0;
        triangles[2] = 11;

        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 12;

        triangles[6] = 3;
        triangles[7] = 2;
        triangles[8] = 13;

        triangles[9] = 4;
        triangles[10] = 3;
        triangles[11] = 14;

        triangles[12] = 5;
        triangles[13] = 4;
        triangles[14] = 15;

        triangles[15] = 6;
        triangles[16] = 5;
        triangles[17] = 16;

        triangles[18] = 7;
        triangles[19] = 6;
        triangles[20] = 17;

        triangles[21] = 8;
        triangles[22] = 7;
        triangles[23] = 18;

        triangles[24] = 9;
        triangles[25] = 8;
        triangles[26] = 19;

        triangles[27] = 10;
        triangles[28] = 9;
        triangles[29] = 20;
        
        triangles[30] = 1;
        triangles[31] = 11;
        triangles[32] = 12;

        triangles[33] = 2;
        triangles[34] = 12;
        triangles[35] = 13;

        triangles[36] = 3;
        triangles[37] = 13;
        triangles[38] = 14;

        triangles[39] = 4;
        triangles[40] = 14;
        triangles[41] = 15;

        triangles[42] = 5;
        triangles[43] = 15;
        triangles[44] = 16;
        
        triangles[45] = 6;
        triangles[46] = 16;
        triangles[47] = 17;
        
        triangles[48] = 7;
        triangles[49] = 17;
        triangles[50] = 18;

        triangles[51] = 8;
        triangles[52] = 18;
        triangles[53] = 19;

        triangles[54] = 9;
        triangles[55] = 19;
        triangles[56] = 20;

        triangles[57] = 10;
        triangles[58] = 20;
        triangles[59] = 21;
        
        triangles[60] = 0;
        triangles[61] = 0;
        triangles[62] = 0;
        triangles[63] = 0;
        triangles[64] = 0;
        triangles[65] = 0;





        uvs[0] = new Vector2(-0.74375f, -0.2816955f);
        uvs[1] = new Vector2(-0.74375f, 0.2783045f);
        uvs[2] = new Vector2(-0.7270986f, 0.3619995f);
        uvs[3] = new Vector2(-0.6796796f, 0.4393734f);
        uvs[4] = new Vector2(-0.608712f, 0.4999052f);
        uvs[5] = new Vector2(-0.525f, 0.53802f);
        uvs[6] = new Vector2(-0.441288f, 0.4999053f);
        uvs[7] = new Vector2(-0.3703204f, 0.4393734f);
        uvs[8] = new Vector2(-0.3229013f, 0.3619996f);
        uvs[9] = new Vector2(-0.30625f, 0.2783045f);
        uvs[10] = new Vector2(-0.30625f, -0.2816955f);
        uvs[11] = new Vector2(-0.74375f, -0.2816955f);
        uvs[12] = new Vector2(-0.74375f, 0.2783045f);
        uvs[13] = new Vector2(-0.7270986f, 0.3619995f);
        uvs[14] = new Vector2(-0.6796796f, 0.4393734f);
        uvs[15] = new Vector2(-0.608712f, 0.4999052f);
        uvs[16] = new Vector2(-0.525f, 0.53802f);
        uvs[17] = new Vector2(-0.441288f, 0.4999053f);
        uvs[18] = new Vector2(-0.3703204f, 0.4393734f);
        uvs[19] = new Vector2(-0.3229013f, 0.3619996f);
        uvs[20] = new Vector2(-0.30625f, 0.2783045f);
        uvs[21] = new Vector2(-0.30625f, -0.2816955f);



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
