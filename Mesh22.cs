using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh22 : MonoBehaviour
{
    //StairToDoor3

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

        vertices = new Vector3[30];
        triangles = new int[78];
        uvs = new Vector2[30];
        float meshScale = 4f;






        vertices[0] = new Vector3(0.12375f, -0.2511955f, -0.57125f);
        vertices[1] = new Vector3(0.08397527f, -0.2511955f, -0.6110248f);
        vertices[2] = new Vector3(0.1035918f, -0.2511955f, -0.6237639f);
        vertices[3] = new Vector3(0.1266939f, -0.2511955f, -0.6274229f);
        vertices[4] = new Vector3(0.149287f, -0.2511955f, -0.6213691f);
        vertices[5] = new Vector3(0.1674645f, -0.2511955f, -0.6066493f);
        vertices[6] = new Vector3(0.1780833f, -0.2511955f, -0.5858086f);
        vertices[7] = new Vector3(0.1793075f, -0.2511955f, -0.5624506f);
        vertices[8] = new Vector3(0.1709252f, -0.2511955f, -0.5406141f);
        vertices[9] = new Vector3(0.154386f, -0.2511955f, -0.5240748f);
        vertices[10] = new Vector3(0.08750001f, -0.2511955f, -0.4972449f);
        vertices[11] = new Vector3(-0.0125f, -0.2511955f, -0.4722449f);
        vertices[12] = new Vector3(-0.1125f, -0.2511955f, -0.4622449f);
        vertices[13] = new Vector3(-0.2375f, -0.2511955f, -0.4522449f);
        vertices[14] = new Vector3(-0.84375f, -0.2511955f, -0.4522449f);
        vertices[15] = new Vector3(0.12375f, -0.2826955f, -0.57125f);
        vertices[16] = new Vector3(0.08397527f, -0.2826955f, -0.6110248f);
        vertices[17] = new Vector3(0.1035918f, -0.2826955f, -0.6237639f);
        vertices[18] = new Vector3(0.1266939f, -0.2826955f, -0.6274229f);
        vertices[19] = new Vector3(0.149287f, -0.2826955f, -0.6213691f);
        vertices[20] = new Vector3(0.1674645f, -0.2826955f, -0.6066493f);
        vertices[21] = new Vector3(0.1780833f, -0.2826955f, -0.5858086f);
        vertices[22] = new Vector3(0.1793075f, -0.2826955f, -0.5624506f);
        vertices[23] = new Vector3(0.1709252f, -0.2826955f, -0.5406141f);
        vertices[24] = new Vector3(0.154386f, -0.2826955f, -0.5240748f);
        vertices[25] = new Vector3(0.08750001f, -0.2826955f, -0.4972449f);
        vertices[26] = new Vector3(-0.0125f, -0.2826955f, -0.4722449f);
        vertices[27] = new Vector3(-0.1125f, -0.2826955f, -0.4622449f);
        vertices[28] = new Vector3(-0.2375f, -0.2826955f, -0.4522449f);
        vertices[29] = new Vector3(-0.84375f, -0.2826955f, -0.4522449f);





        triangles[0] = 10;
        triangles[1] = 11;
        triangles[2] = 25;
        triangles[3] = 11;
        triangles[4] = 26;
        triangles[5] = 25;
        triangles[6] = 11;
        triangles[7] = 12;
        triangles[8] = 26;
        triangles[9] = 12;
        triangles[10] = 27;
        triangles[11] = 26;
        triangles[12] = 12;
        triangles[13] = 13;
        triangles[14] = 27;
        triangles[15] = 13;
        triangles[16] = 28;
        triangles[17] = 27;
        triangles[18] = 13;
        triangles[19] = 14;
        triangles[20] = 28;
        triangles[21] = 14;
        triangles[22] = 29;
        triangles[23] = 28;
        triangles[24] = 9;
        triangles[25] = 10;
        triangles[26] = 25;
        triangles[27] = 25;
        triangles[28] = 24;
        triangles[29] = 9;
        triangles[30] = 8;
        triangles[31] = 9;
        triangles[32] = 24;
        triangles[33] = 24;
        triangles[34] = 23;
        triangles[35] = 8;
        triangles[36] = 7;
        triangles[37] = 8;
        triangles[38] = 23;
        triangles[39] = 23;
        triangles[40] = 22;
        triangles[41] = 7;
        triangles[42] = 6;
        triangles[43] = 7;
        triangles[44] = 22;
        triangles[45] = 22;
        triangles[46] = 21;
        triangles[47] = 6;
        triangles[48] = 5;
        triangles[49] = 6;
        triangles[50] = 21;
        triangles[51] = 21;
        triangles[52] = 20;
        triangles[53] = 5;
        triangles[54] = 4;
        triangles[55] = 5;
        triangles[56] = 20;
        triangles[57] = 20;
        triangles[58] = 19;
        triangles[59] = 4;
        triangles[60] = 3;
        triangles[61] = 4;
        triangles[62] = 19;
        triangles[63] = 19;
        triangles[64] = 18;
        triangles[65] = 3;
        triangles[66] = 2;
        triangles[67] = 3;
        triangles[68] = 18;
        triangles[69] = 18;
        triangles[70] = 17;
        triangles[71] = 2;
        triangles[72] = 1;
        triangles[73] = 2;
        triangles[74] = 17;
        triangles[75] = 17;
        triangles[76] = 16;
        triangles[77] = 1;





        uvs[0] = new Vector2(0.12375f, -0.57125f);
        uvs[1] = new Vector2(0.08397527f, -0.6110248f);
        uvs[2] = new Vector2(0.1035918f, -0.6237639f);
        uvs[3] = new Vector2(0.1266939f, -0.6274229f);
        uvs[4] = new Vector2(0.149287f, -0.6213691f);
        uvs[5] = new Vector2(0.1674645f, -0.6066493f);
        uvs[6] = new Vector2(0.1780833f, -0.5858086f);
        uvs[7] = new Vector2(0.1793075f, -0.5624506f);
        uvs[8] = new Vector2(0.1709252f, -0.5406141f);
        uvs[9] = new Vector2(0.154386f, -0.5240748f);
        uvs[10] = new Vector2(0.08750001f, -0.4972449f);
        uvs[11] = new Vector2(-0.0125f, -0.4722449f);
        uvs[12] = new Vector2(-0.1125f, -0.4622449f);
        uvs[13] = new Vector2(-0.2375f, -0.4522449f);
        uvs[14] = new Vector2(-0.84375f, -0.4522449f);
        uvs[15] = new Vector2(0.12375f, -0.57125f);
        uvs[16] = new Vector2(0.08397527f, -0.6110248f);
        uvs[17] = new Vector2(0.1035918f, -0.6237639f);
        uvs[18] = new Vector2(0.1266939f, -0.6274229f);
        uvs[19] = new Vector2(0.149287f, -0.6213691f);
        uvs[20] = new Vector2(0.1674645f, -0.6066493f);
        uvs[21] = new Vector2(0.1780833f, -0.5858086f);
        uvs[22] = new Vector2(0.1793075f, -0.5624506f);
        uvs[23] = new Vector2(0.1709252f, -0.5406141f);
        uvs[24] = new Vector2(0.154386f, -0.5240748f);
        uvs[25] = new Vector2(0.08750001f, -0.4972449f);
        uvs[26] = new Vector2(-0.0125f, -0.4722449f);
        uvs[27] = new Vector2(-0.1125f, -0.4622449f);
        uvs[28] = new Vector2(-0.2375f, -0.4522449f);
        uvs[29] = new Vector2(-0.84375f, -0.4522449f);



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
