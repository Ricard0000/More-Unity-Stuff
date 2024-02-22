using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEntrance : MonoBehaviour
{


    //Define public variables
    public float Pos1;//Object position
    public float Pos2;//Object position
    public float Pos3;//Object position

    public float c1 = 1.25f;//x-direction
    public float c2 = 1.5f;//y-direction
    public float c3 = 0.75f;//z-direction
    public float c4 = -1f;//from the start of the arch and downwards.
    public float s = 0.5f;//Thickness of sides
    public float t = 0.5f;//Thickness of Top of arch
    public float req_dist = 40f;

    //Define parameters needed to create object
    const float PI = 3.1415926535897931f;
    const int N = 10;
    float delta_theta = (PI / 2) / N;
    public int rot = 0;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot);
    }


    public static Vector3 Arch_eq_6(float x, float z, float c1, float c2)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;
        return new Vector3(x, y, z);
    }

    public static Vector3 Arch_eq_6_1(float x, float z, float c1, float c2)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;
        return new Vector3(z, y, x);
    }

    public static Vector3 Arch_eq_6_A(float x, float z, float c1, float c2, float angle)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;

        float temp = x;
        x = x * Mathf.Cos(angle) - z * Mathf.Sin(angle);
        z = temp * Mathf.Sin(angle) + z * Mathf.Cos(angle);
        return new Vector3(x, y, z);
    }

    public static Vector3 Arch_eq_6_B(float x, float z, float c1, float c2, float angle)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;

        float temp = x;
        x = x * Mathf.Cos(-angle) - z * Mathf.Sin(-angle);
        z = temp * Mathf.Sin(-angle) + z * Mathf.Cos(-angle);
        return new Vector3(x, y, z);
    }

    public static Vector3 Arch_eq_6_C(float x, float z, float c1, float c2, float angle)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;

        float temp = x;
        x = x * Mathf.Cos(-2 * angle) - z * Mathf.Sin(-2 * angle);
        z = temp * Mathf.Sin(-2 * angle) + z * Mathf.Cos(-2 * angle);
        return new Vector3(x, y, z);
    }

    public static float Vert_Rot_x(float x, float z, float angle)
    {
        return x * Mathf.Cos(angle) - z * Mathf.Sin(angle);
    }

    public static float Vert_Rot_z(float x, float z, float angle)
    {
        return x * Mathf.Sin(angle) + z * Mathf.Cos(angle);
    }


    public static float uv_Arch_eq_6(float x)
    {
        float y;
        y = Mathf.Sqrt(1 - Mathf.Abs(x) / (1.0f + 0.00001f));
        y = y + Mathf.Sqrt(1 - Mathf.Abs((x) * (x)) / (1.0f + 0.00001f));
        y = y / 2.0f - 0.00001f;
        return y;
    }

    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, float c1, float c2, float c3, float c4, float s, float t, float delta_theta, int N, bool collider, Material mat, int rot)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;


        Mesh m = new Mesh();

        Vector3 POS = new Vector3(Pos1, Pos2, Pos3);
        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;
        /*
        vertices = new Vector3[3*(2 * N+1)];
        triangles = new int[12 * N+1000];
        uvs = new Vector2[3 * (2 * N + 1)];
        */
        vertices = new Vector3[(2 * N + 1) + 26];
        triangles = new int[3 * (2 * N - 6 ) + 3 + 30 + 9 + 15];
        uvs = new Vector2[(2 * N + 1) + 26];


        float angle1 = -45f / 180f * PI;


        float angle = rot * angle1;
        float x;
        float z;
        float dz = 0.0625f;

       
        for (int i = 0; i < 2 * N - 7; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - (i + 4f) * delta_theta);
            z = - dz * 4.3333333f - dz * 2.5f;
            vertices[i] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS + new Vector3(0f, 0f, -8f*dz);
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
        }
        Vector3 temp;
        temp = vertices[0];

        Vector3 temp2;
        temp2 = vertices[N-4];
        float aFloat = Mathf.Abs(temp2[1] - temp[1]);



        vertices[2 * N - 7] = new Vector3(0f, temp[1], temp[2]) + POS;
        uvs[2 * N - 7] = new Vector2(vertices[2 * N - 7].x, vertices[2 * N - 7].y);

        int nextVert = 2 * N - 6;

        for (int i = 0; i < 9; i++)
        {
            x = 0.175f * c1 * Mathf.Cos(PI - i * delta_theta * 2 * N * 1f /8.00000f);
            z = -dz * 4.3333333f - dz * 2.5f;
            vertices[i + nextVert] = Arch_eq_6_A(x, z, 0.175f * c1, 0.175f * c2, angle) + POS + new Vector3(-0.525f, -aFloat + c2*0.525f, -8f * dz);//Equation of small arch.
            uvs[i + nextVert] = new Vector2(vertices[i + nextVert].x, vertices[i + nextVert].y);
        }
        temp = vertices[nextVert];
        temp2 = vertices[nextVert + 4];
        Vector3 temp3 = vertices[nextVert + 8];

        vertices[9 + nextVert] = vertices[0];
        uvs[9 + nextVert] = new Vector2(vertices[9 + nextVert].x, vertices[9 + nextVert].y);

        nextVert = 10 + nextVert;
        for (int i = 0; i < 5; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - (i) * delta_theta);
            z = -dz * 4.3333333f - dz * 2.5f;
            vertices[i + nextVert] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS + new Vector3(0f, 0f, -8f * dz);
            uvs[i + nextVert] = new Vector2(vertices[i + nextVert].x, vertices[i + nextVert].y);
        }

        nextVert = 5 + nextVert;
        x = 0.175f * c1 * Mathf.Cos(PI - 0 * delta_theta * 2 * N * 1f / 8.00000f);
        z = -dz * 4.3333333f - dz * 2.5f;
        vertices[0 + nextVert] = Arch_eq_6_A(x, z, 0.175f * c1, 0.175f * c2, angle) + POS + new Vector3(-0.525f, -aFloat + c2 * 0.525f - 0.5f, -8f * dz) + new Vector3(0f, -.060f, 0f);//This is 2N+9. This controls the bottom
        uvs[0 + nextVert] = new Vector2(vertices[0 + nextVert].x, vertices[0 + nextVert].y);

        nextVert = 1 + nextVert;
        x = 0.175f * c1 * Mathf.Cos(PI - 0 * delta_theta * 2 * N * 1f / 8.00000f);
        z = -dz * 4.3333333f - dz * 2.5f;
        vertices[0 + nextVert] = Arch_eq_6_A(x, z, 0.175f * c1, 0.175f * c2, angle) + POS + new Vector3(-0.525f-0.125f, -aFloat + c2 * 0.525f - 0.5f, -8f * dz) + new Vector3(0f, -.060f, 0f);//This is 2N+10. This controls the bottom.
        uvs[0 + nextVert] = new Vector2(vertices[0 + nextVert].x, vertices[0 + nextVert].y);

        //        nextVert = 1 + nextVert;
        /*
        for (int i = 0; i < 5; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - (i+5) * delta_theta);
            z = -dz * 4.3333333f - dz * 2.5f;
            vertices[i + nextVert] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS + new Vector3(0f, 0f, -8f * dz);//Equation of small arch.//Vert 2N+11 to 2N+15
        }
*/
        nextVert = 1 + nextVert;
        vertices[nextVert] = temp3 + POS + new Vector3(0f, .25975f, 0f);//Equation of small arch.//Vert 2N+11
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        nextVert = 1 + nextVert;
        vertices[nextVert] = temp3 + POS + new Vector3(0.0625f, .25975f, 0f);//Equation of small arch.//Vert 2N+12
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        nextVert =  1 + nextVert;
        x = 0.175f * c1 * Mathf.Cos(0 * delta_theta * 2 * N * 1f / 8.00000f);
        z = -dz * 4.3333333f - dz * 2.5f;
        vertices[0 + nextVert] = Arch_eq_6_A(x, z, 0.175f * c1, 0.175f * c2, angle) + POS + new Vector3(-0.525f, -aFloat + c2 * 0.525f - 0.5f, -8f * dz) + new Vector3(0f, -.060f, 0f);//This is 2N+ 13. This controls the bottom.
        uvs[0 + nextVert] = new Vector2(vertices[0 + nextVert].x, vertices[0 + nextVert].y);

        nextVert = 1 + nextVert;
        x = 0.175f * c1 * Mathf.Cos(0 * delta_theta * 2 * N * 1f / 8.00000f);
        z = -dz * 4.3333333f - dz * 2.5f;
        vertices[0 + nextVert] = Arch_eq_6_A(x, z, 0.175f * c1, 0.175f * c2, angle) + POS + new Vector3(-0.525f + 0.0625f, -aFloat + c2 * 0.525f - 0.5f, -8f * dz) + new Vector3(0f, -.060f, 0f);//This is 2N+ 14
        uvs[0 + nextVert] = new Vector2(vertices[0 + nextVert].x, vertices[0 + nextVert].y);


        //        vertices[9 + nextVert] = new Vector3(-0.525f, temp[1], temp2[2]);

        // First Top arch part (Right Side)
        for (int i = 0; i < 2 * N - 6; i++)
        {
            int i3 = 3 * i;
            triangles[i3] = i + 0;
            triangles[i3 + 1] = 2 * N - 7;
            triangles[i3 + 2] = i + 1;
        }


        int nextTri = 3 * (2 * N - 6);
        for (int i = 0; i < 4; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + nextTri] = i + 1 + 2 * N - 6;
            triangles[i3 + 1 + nextTri] = 2 * N - 6  + 9;
            triangles[i3 + 2 + nextTri] = i + 0 + 2 * N - 6;
        }

        nextTri = 3 * 4 + nextTri;

        triangles[nextTri] = 0 + 0 + 2 * N - 6;
        triangles[1 + nextTri] = 1 + 2 * N + 7;
        triangles[2 + nextTri] =  0 + 2 * N + 7;


        nextTri = 3 * 1 + nextTri;
        triangles[nextTri] = 0 + 0 + 2 * N - 6;
        triangles[1 + nextTri] = 1 + 2 * N + 6;
        triangles[2 + nextTri] = 0 + 2 * N + 6;

        nextTri = 3 * 1 + nextTri;
        triangles[nextTri] = 0 + 0 + 2 * N - 6;
        triangles[1 + nextTri] = 1 + 2 * N + 5;
        triangles[2 + nextTri] = 0 + 2 * N + 5;

        nextTri = 3 * 1 + nextTri;
        triangles[nextTri] = 0 + 0 + 2 * N - 6;
        triangles[1 + nextTri] = 1 + 2 * N + 4;
        triangles[2 + nextTri] = 0 + 2 * N + 4;


        nextTri = 3 * 1 + nextTri;
        triangles[nextTri] = 0 + 0 + 2 * N + 9;
        triangles[1 + nextTri] = 0 + 2 * N - 6;
        triangles[2 + nextTri] = 0 + 2 * N + 5;

        nextTri = 3 * 1 + nextTri;
        triangles[nextTri] = 0 + 0 + 2 * N + 9;
        triangles[1 + nextTri] = 0 + 2 * N + 5;
        triangles[2 + nextTri] = 0 + 2 * N + 4;

        nextTri = 3 * 1 + nextTri;
        triangles[nextTri] = 0 + 0 + 2 * N + 4;
        triangles[1 + nextTri] = 0 + 2 * N + 10;
        triangles[2 + nextTri] = 0 + 2 * N + 9;

        nextTri = 3 * 1 + nextTri;
        for (int i = 0; i < 4; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + nextTri] = i + 1 + 2 * N - 2;
            triangles[i3 + 1 + nextTri] = 2 * N + 11;
            triangles[i3 + 2 + nextTri] = i + 0 + 2 * N - 2;
        }

        nextTri = 3 * 4 + nextTri;
        triangles[nextTri] = 0 + 2 * N + 11;
        triangles[1 + nextTri] = 0 + 2 * N + 13;
        triangles[2 + nextTri] = 0 + 2 * N + 12;

        nextTri = 3 + nextTri;
        triangles[nextTri] = 0 + 2 * N + 12;
        triangles[1 + nextTri] = 0 + 2 * N + 13;
        triangles[2 + nextTri] = 0 + 2 * N + 14;


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


