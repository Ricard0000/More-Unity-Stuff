using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh6 : MonoBehaviour
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

        vertices = new Vector3[36];
        triangles = new int[102];
        uvs = new Vector2[36];
        float meshScale = 4f;

        vertices[0] = new Vector3(-0.875f, 0.003662168f, -0.5520833f);
        vertices[1] = new Vector3(-0.8642273f, 0.1404191f, -0.5520833f);
        vertices[2] = new Vector3(-0.8321745f, 0.2783932f, -0.5520833f);
        vertices[3] = new Vector3(-0.7796308f, 0.4116732f, -0.5520833f);
        vertices[4] = new Vector3(-0.7574616f, 0.4509184f, -0.5582013f);
        vertices[5] = new Vector3(-0.7374625f, 0.486322f, -0.5759562f);
        vertices[6] = new Vector3(-0.7215912f, 0.5144184f, -0.6036102f);
        vertices[7] = new Vector3(-0.7114012f, 0.5324574f, -0.6384562f);
        vertices[8] = new Vector3(-0.7078899f, 0.5386732f, -0.6770833f);
        vertices[9] = new Vector3(-0.7078899f, 0.5386732f, -0.6770833f);
        vertices[10] = new Vector3(-0.7114012f, 0.5324574f, -0.7157105f);
        vertices[11] = new Vector3(-0.7215912f, 0.5144184f, -0.7505565f);
        vertices[12] = new Vector3(-0.7374625f, 0.486322f, -0.7782105f);
        vertices[13] = new Vector3(-0.7574616f, 0.4509184f, -0.7959654f);
        vertices[14] = new Vector3(-0.7796308f, 0.4116732f, -0.8020833f);
        vertices[15] = new Vector3(-0.8321745f, 0.2783932f, -0.8020833f);
        vertices[16] = new Vector3(-0.8642273f, 0.1404191f, -0.8020833f);
        vertices[17] = new Vector3(-0.875f, 0.003662168f, -0.8020833f);
        vertices[18] = new Vector3(-0.9375f, 0.003662168f, -0.5520833f);
        vertices[19] = new Vector3(-0.9375f, 0.1404191f, -0.5520833f);
        vertices[20] = new Vector3(-0.9375f, 0.2783932f, -0.5520833f);
        vertices[21] = new Vector3(-0.9375f, 0.4116732f, -0.5520833f);
        vertices[22] = new Vector3(-0.9375f, 0.4509184f, -0.5582013f);
        vertices[23] = new Vector3(-0.9375f, 0.486322f, -0.5759562f);
        vertices[24] = new Vector3(-0.9375f, 0.5144184f, -0.6036102f);
        vertices[25] = new Vector3(-0.9375f, 0.5324574f, -0.6384562f);
        vertices[26] = new Vector3(-0.9375f, 0.5386732f, -0.6770833f);
        vertices[27] = new Vector3(-0.9375f, 0.5386732f, -0.6770833f);
        vertices[28] = new Vector3(-0.9375f, 0.5324574f, -0.7157105f);
        vertices[29] = new Vector3(-0.9375f, 0.5144184f, -0.7505565f);
        vertices[30] = new Vector3(-0.9375f, 0.486322f, -0.7782105f);
        vertices[31] = new Vector3(-0.9375f, 0.4509184f, -0.7959654f);
        vertices[32] = new Vector3(-0.9375f, 0.4116732f, -0.8020833f);
        vertices[33] = new Vector3(-0.9375f, 0.2783932f, -0.8020833f);
        vertices[34] = new Vector3(-0.9375f, 0.1404191f, -0.8020833f);
        vertices[35] = new Vector3(-0.9375f, 0.003662168f, -0.8020833f);





        triangles[0] = 1;
        triangles[1] = 0;
        triangles[2] = 18;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 19;
        triangles[6] = 3;
        triangles[7] = 2;
        triangles[8] = 20;
        triangles[9] = 4;
        triangles[10] = 3;
        triangles[11] = 21;
        triangles[12] = 5;
        triangles[13] = 4;
        triangles[14] = 22;
        triangles[15] = 6;
        triangles[16] = 5;
        triangles[17] = 23;
        triangles[18] = 7;
        triangles[19] = 6;
        triangles[20] = 24;
        triangles[21] = 8;
        triangles[22] = 7;
        triangles[23] = 25;
        triangles[24] = 9;
        triangles[25] = 8;
        triangles[26] = 26;
        triangles[27] = 10;
        triangles[28] = 9;
        triangles[29] = 27;
        triangles[30] = 11;
        triangles[31] = 10;
        triangles[32] = 28;
        triangles[33] = 12;
        triangles[34] = 11;
        triangles[35] = 29;
        triangles[36] = 13;
        triangles[37] = 12;
        triangles[38] = 30;
        triangles[39] = 14;
        triangles[40] = 13;
        triangles[41] = 31;
        triangles[42] = 15;
        triangles[43] = 14;
        triangles[44] = 32;
        triangles[45] = 16;
        triangles[46] = 15;
        triangles[47] = 33;
        triangles[48] = 17;
        triangles[49] = 16;
        triangles[50] = 34;
        triangles[51] = 18;
        triangles[52] = 19;
        triangles[53] = 1;
        triangles[54] = 19;
        triangles[55] = 20;
        triangles[56] = 2;
        triangles[57] = 20;
        triangles[58] = 21;
        triangles[59] = 3;
        triangles[60] = 21;
        triangles[61] = 22;
        triangles[62] = 4;
        triangles[63] = 22;
        triangles[64] = 23;
        triangles[65] = 5;
        triangles[66] = 23;
        triangles[67] = 24;
        triangles[68] = 6;
        triangles[69] = 24;
        triangles[70] = 25;
        triangles[71] = 7;
        triangles[72] = 25;
        triangles[73] = 26;
        triangles[74] = 8;
        triangles[75] = 26;
        triangles[76] = 27;
        triangles[77] = 9;
        triangles[78] = 27;
        triangles[79] = 28;
        triangles[80] = 10;
        triangles[81] = 28;
        triangles[82] = 29;
        triangles[83] = 11;
        triangles[84] = 29;
        triangles[85] = 30;
        triangles[86] = 12;
        triangles[87] = 30;
        triangles[88] = 31;
        triangles[89] = 13;
        triangles[90] = 31;
        triangles[91] = 32;
        triangles[92] = 14;
        triangles[93] = 32;
        triangles[94] = 33;
        triangles[95] = 15;
        triangles[96] = 33;
        triangles[97] = 34;
        triangles[98] = 16;
        triangles[99] = 34;
        triangles[100] = 35;
        triangles[101] = 17;





        uvs[0] = new Vector2(-0.875f, 0.003662168f);
        uvs[1] = new Vector2(-0.8642273f, 0.1404191f);
        uvs[2] = new Vector2(-0.8321745f, 0.2783932f);
        uvs[3] = new Vector2(-0.7796308f, 0.4116732f);
        uvs[4] = new Vector2(-0.7574616f, 0.4509184f);
        uvs[5] = new Vector2(-0.7374625f, 0.486322f);
        uvs[6] = new Vector2(-0.7215912f, 0.5144184f);
        uvs[7] = new Vector2(-0.7114012f, 0.5324574f);
        uvs[8] = new Vector2(-0.7078899f, 0.5386732f);
        uvs[9] = new Vector2(-0.7078899f, 0.5386732f);
        uvs[10] = new Vector2(-0.7114012f, 0.5324574f);
        uvs[11] = new Vector2(-0.7215912f, 0.5144184f);
        uvs[12] = new Vector2(-0.7374625f, 0.486322f);
        uvs[13] = new Vector2(-0.7574616f, 0.4509184f);
        uvs[14] = new Vector2(-0.7796308f, 0.4116732f);
        uvs[15] = new Vector2(-0.8321745f, 0.2783932f);
        uvs[16] = new Vector2(-0.8642273f, 0.1404191f);
        uvs[17] = new Vector2(-0.875f, 0.003662168f);
        uvs[18] = new Vector2(-0.9375f, 0.003662168f);
        uvs[19] = new Vector2(-0.9375f, 0.1404191f);
        uvs[20] = new Vector2(-0.9375f, 0.2783932f);
        uvs[21] = new Vector2(-0.9375f, 0.4116732f);
        uvs[22] = new Vector2(-0.9375f, 0.4509184f);
        uvs[23] = new Vector2(-0.9375f, 0.486322f);
        uvs[24] = new Vector2(-0.9375f, 0.5144184f);
        uvs[25] = new Vector2(-0.9375f, 0.5324574f);
        uvs[26] = new Vector2(-0.9375f, 0.5386732f);
        uvs[27] = new Vector2(-0.9375f, 0.5386732f);
        uvs[28] = new Vector2(-0.9375f, 0.5324574f);
        uvs[29] = new Vector2(-0.9375f, 0.5144184f);
        uvs[30] = new Vector2(-0.9375f, 0.486322f);
        uvs[31] = new Vector2(-0.9375f, 0.4509184f);
        uvs[32] = new Vector2(-0.9375f, 0.4116732f);
        uvs[33] = new Vector2(-0.9375f, 0.2783932f);
        uvs[34] = new Vector2(-0.9375f, 0.1404191f);
        uvs[35] = new Vector2(-0.9375f, 0.003662168f);



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
