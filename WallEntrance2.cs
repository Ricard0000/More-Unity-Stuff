using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEntrance2 : MonoBehaviour
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

    const int Nrot = 5;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot, Nrot);
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

    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, float c1, float c2, float c3, float c4, float s, float t, float delta_theta, int N, bool collider, Material mat, int rot, int Nrot)
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
        triangles = new int[3 * (2 * N - 6) + 3 + 30 + 9 + 15];
        uvs = new Vector2[(2 * N + 1) + 26];


        float angle1 = -45f / 180f * PI;


        float angle = rot * angle1;
        float x;
        float y;
        float z;
        float dz = 0.0625f;


        Vector3 temp1;
        int i = 0;
        x = 0.7f * c1 * Mathf.Cos(PI - (i + 4f) * delta_theta);
        z = -dz * 4.3333333f - dz * 2.5f;
        temp1 = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS + new Vector3(0f, 0f, -8f * dz);

        Vector3 temp2;
        i = N - 4;
        x = 0.7f * c1 * Mathf.Cos(PI - (i + 4f) * delta_theta);
        z = -dz * 4.3333333f - dz * 2.5f;
        temp2 = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS + new Vector3(0f, 0f, -8f * dz);


        float aFloat = Mathf.Abs(temp2[1] - temp1[1]);

        i = 8;
        x = 0.175f * c1 * Mathf.Cos(PI - i * delta_theta * 2 * N * 1f / 8.00000f);
        z = -dz * 4.3333333f - dz * 2.5f;
        vertices[i - 8] = Arch_eq_6_A(x, z, 0.175f * c1, 0.175f * c2, angle) + POS + new Vector3(-0.525f, -aFloat + c2 * 0.525f, -8f * dz);//Vert 0

        Vector3 temp3 = vertices[0];

        int nextVert = 0;
        vertices[nextVert] = temp3 + POS + new Vector3(0.0625f, .25975f, 0f);//Vert 0
        uvs[0] = new Vector2(vertices[0].x, vertices[0].y);

        nextVert = 1 + nextVert;
        x = 0.175f * c1 * Mathf.Cos(0 * delta_theta * 2 * N * 1f / 8.00000f);
        z = -dz * 4.3333333f - dz * 2.5f;
        vertices[0 + nextVert] = Arch_eq_6_A(x, z, 0.175f * c1, 0.175f * c2, angle) + POS + new Vector3(-0.525f + 0.0625f, -aFloat + c2 * 0.525f - 0.5f, -8f * dz);//Vert 1
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);


        nextVert = 1 + nextVert;
        vertices[0 + nextVert] = 0.5f * (vertices[0] + vertices[1]);//Vert 2
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        nextVert = 1 + nextVert;
        vertices[0 + nextVert] = 0.5f * (vertices[0] + vertices[1]) + new Vector3(0.75f,0f,0f);//Vert 3
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        nextVert = 1 + nextVert;
        vertices[0 + nextVert] = vertices[1] + new Vector3(0.75f, 0f, 0f);//Vert 4
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        nextVert = 1 + nextVert;
        vertices[0 + nextVert] = 0.6f * vertices[0] + 0.4f * vertices[2];//Vert 5
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        nextVert = 1 + nextVert;
        Vector3 vert3Temp = vertices[3];
        vertices[0 + nextVert] = vertices[0] + new Vector3(-0.0625f + vert3Temp[0]-temp3[0],0f,0f);//Vert 6
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        nextVert = 1 + nextVert;
        vertices[0 + nextVert] = 0.6f * vertices[6] + 0.4f * vertices[3];//Vert 7
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);


        Vector3 aTemp1 = vertices[0] - vertices[5];
        Vector3 aTemp2 = vertices[5];


        float radius = Mathf.Abs(aTemp1[1]);


        nextVert = 1 + nextVert;
        for (int ii = 0; ii < Nrot; ii++)
        {
            float time = PI / 2f * ii / (Nrot - 1f);
            x = radius * Mathf.Cos(time + 0 * PI / 2f);
            y = radius * Mathf.Sin(time + 0 * PI / 2f);
            vertices[ii + nextVert] = new Vector3(-x+radius, y, 0f) + new Vector3(aTemp2[0], aTemp2[1], aTemp2[2]) + POS;// Right Half of right circle.
            uvs[ii + nextVert] = new Vector2(vertices[ii + nextVert].x, vertices[ii + nextVert].y);
        }

        nextVert = Nrot + nextVert;
        for (int ii = 0; ii < Nrot; ii++)
        {
            float time = PI / 2f * ii / (Nrot - 1f);
            x = radius * Mathf.Cos(time + PI / 2f);
            y = radius * Mathf.Sin(time + PI / 2f);
            vertices[ii + nextVert] = new Vector3(-x + radius, y, 0f) + new Vector3(aTemp2[0], aTemp2[1], aTemp2[2]) + POS;// Left Half of right circle
            uvs[ii + nextVert] = new Vector2(vertices[ii + nextVert].x, vertices[ii + nextVert].y);
        }

        nextVert = Nrot + nextVert;
        vertices[nextVert] = vertices[0] + new Vector3( 2f * radius , 0f , 0f );
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        nextVert = 1 + nextVert;
        vertices[nextVert] = vertices[6] + new Vector3(-1f * 0.0625f, 0f, 0f);
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        nextVert = 1 + nextVert;
        vertices[nextVert] = vertices[3] + new Vector3(-1f * 0.0625f, 0f, 0f);
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        Vector3 aTemp3 = 0.6f * vertices[2 * Nrot + 9] + 0.4f * vertices[2 * Nrot + 10];




        nextVert = 1 + nextVert;
        for (int ii = 0; ii < Nrot; ii++)
        {
            float time = PI / 2f * ii / (Nrot - 1f);
            x = radius * Mathf.Cos(time + 0f * PI / 2f);
            y = radius * Mathf.Sin(time + 0f * PI / 2f);
            vertices[ii + nextVert] = new Vector3(x - radius, y, 0f) + new Vector3(aTemp3[0], aTemp3[1], aTemp3[2]) + POS;// Left Half of right circle.
            uvs[ii + nextVert] = new Vector2(vertices[ii + nextVert].x, vertices[ii + nextVert].y);
        }


        nextVert = Nrot + nextVert;
        for (int ii = 0; ii < Nrot; ii++)
        {
            float time = PI / 2f * ii / (Nrot - 1f);
            x = radius * Mathf.Cos(time + 1f * PI / 2f);
            y = radius * Mathf.Sin(time + 1f * PI / 2f);
            vertices[ii + nextVert] = new Vector3(x - radius, y, 0f) + new Vector3(aTemp3[0], aTemp3[1], aTemp3[2]) + POS;// Right Half of left circle.
            uvs[ii + nextVert] = new Vector2(vertices[ii + nextVert].x, vertices[ii + nextVert].y);
        }


        nextVert = Nrot + nextVert;
        vertices[nextVert] = vertices[2 * Nrot + 9] + new Vector3(-2 * radius, 0f, 0f);
        uvs[nextVert] = new Vector2(vertices[nextVert].x, vertices[nextVert].y);

        int i3 = 0;
        triangles[i3] = 2;
        triangles[i3 + 1] = 1;
        triangles[i3 + 2] = 3;

        int nextTri = 3;
        triangles[nextTri] = 1;
        triangles[nextTri + 1] = 4;
        triangles[nextTri + 2] = 3;

        nextTri = nextTri + 3;
        for (int ii = 0; ii < Nrot - 1; ii++)
        {
            int ithree = ii * 3;
            triangles[ithree + nextTri] = 0;
            triangles[ithree + nextTri + 1] = ii + 8;
            triangles[ithree + nextTri + 2] = ii + 9;
        }

        nextTri = nextTri + 3 * Nrot;
        for (int ii = 0; ii < Nrot - 1; ii++)
        {
            int ithree = ii * 3;
            triangles[ithree + nextTri] = 8 + 2 * Nrot;
            triangles[ithree + nextTri + 1] = ii + 8 + Nrot;
            triangles[ithree + nextTri + 2] = ii + 9 + Nrot;
        }

        nextTri = nextTri + 3 * Nrot;
        for (int ii = 0; ii < Nrot - 1; ii++)
        {
            int ithree = ii * 3;
            triangles[ithree + nextTri] = 8 + 2 * Nrot;
            triangles[ithree + nextTri + 1] = ii + 8 + Nrot;
            triangles[ithree + nextTri + 2] = ii + 9 + Nrot;
        }


        nextTri = nextTri + 3 * Nrot;
        triangles[nextTri] = 9 + 2 * Nrot;
        triangles[nextTri + 1] = 3;
        triangles[nextTri + 2] = 6;


        nextTri = nextTri + 3;
        triangles[nextTri] = 10 + 2 * Nrot;
        triangles[nextTri + 1] = 3;
        triangles[nextTri + 2] = 9 + 2 * Nrot;

        nextTri = nextTri + 3;
        for (int ii = 0; ii < Nrot - 1; ii++)
        {
            int ithree = ii * 3;
            triangles[ithree + nextTri] = 2 * Nrot + 9;
            triangles[ithree + nextTri + 1] = ii + 12 + 2 * Nrot;
            triangles[ithree + nextTri + 2] = ii + 11 + 2 * Nrot;
        }

        nextTri = nextTri + 3 * Nrot;
        for (int ii = 0; ii < Nrot - 1; ii++)
        {
            int ithree = ii * 3;
            triangles[ithree + nextTri] = 3 * Nrot + 16;
            triangles[ithree + nextTri + 1] = ii + 12 + 3 * Nrot;
            triangles[ithree + nextTri + 2] = ii + 11 + 3 * Nrot;
        }
        
        nextTri = nextTri + 3 * Nrot;
        triangles[nextTri] = 16 + 3 * Nrot;
        triangles[nextTri + 1] = 8 + 2 * Nrot;
        triangles[nextTri + 2] = 2 * Nrot + 7;

        nextTri = nextTri + 3;
        triangles[nextTri] = 15 + 3 * Nrot;
        triangles[nextTri + 1] = 16 + 3 * Nrot;
        triangles[nextTri + 2] = 2 * Nrot + 7;




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


