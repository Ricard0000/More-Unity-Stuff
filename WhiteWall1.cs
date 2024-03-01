using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class WhiteWall1 : MonoBehaviour
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
    const int NN = 6;
    float delta_theta = (PI / 2) / N;
    public int rot = 0;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, NN, true, mat, rot);
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

    public static GameObject MakeDiscreteProceduralGrid(float Pos1, float Pos2, float Pos3, float c1, float c2, float c3, float c4, float s, float t, float delta_theta, int N, int NN, bool collider, Material mat, int rot)
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
        vertices = new Vector3[2 * (2 * N + 1) + 4 * ( N / 2 + 1) + 2 * (NN + 1)];
        triangles = new int[3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * (2 * N + 1) + 3 * NN + 3 * NN];
        uvs = new Vector2[2 * (2 * N + 1) + 4 * (N / 2 + 1) + 2 * (NN + 1)];


        float angle1 = -45f / 180f * PI;


        float angle = rot * angle1;
        float x;
        float z;
        float dz = 0.0625f;

        int itsize1 = 0;

        // Main Arch
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f;
            vertices[i] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS;
        }


        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f - 8*dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS;
        }


        // 4 N + 2

        itsize1 = 2 * N + 1 + itsize1;
        for (int i = 0; i < N / 2 - 0; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f - 2f * dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS;
        }
        Vector3 vertL = vertices[N / 2 - 1 + itsize1];// 4 N +2 +N/2 - 1

        itsize1 = N / 2 + 0 + itsize1 - 0; // 4 N + 2 + N / 2
        for (int i = 0; i < N / 2 - 0; i++)
        {
            x = 0.7f * c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f - 6f * dz;
            vertices[i + itsize1] = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS;
        }
        Vector3 vertR = vertices[N / 2 - 1 + itsize1]; // 4 N + 2 + N / 2 + N / 2 - 1 = 5 N + 1.

        //        float zCen = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f - 4f * dz;
        x = 0.7f * c1 * Mathf.Cos(PI - (N / 2 + 2) * delta_theta);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f - 4f * dz;
        Vector3 Cen = Arch_eq_6_A(x, z, 0.7f * c1, 0.7f * c2, angle) + POS;
        float rad = 2 * dz;

        itsize1 = N / 2 + 0 + itsize1;


        int CircIndexL = itsize1;
        float y;
        float x1;
        float x2;
        Vector3 temp;

        // For Left Circle.
        for (int i = 0; i < NN - 0; i++)
        {
            x1 = 0.7f * c1 * Mathf.Cos(PI - (N / 2 - 2) * delta_theta);
            x2 = 0.7f * c1 * Mathf.Cos(PI - (N / 2 - 1) * delta_theta);

            z = (2 * dz) * Mathf.Cos(0.5f * PI / (NN - 1) * i) + 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f - 4f * dz;

            temp = Arch_eq_6_A(x1, -4f * dz - dz * 0.3333333f - dz * 2.5f - 4f * dz, 0.7f * c1, 0.7f * c2, angle);

            y = (0.002f + 2f * dz) * Mathf.Sin(0.5f * PI / (float)(NN - 1) * i) + temp[1];

            float factor = Mathf.Sin(0.5f * PI / (float)(NN - 1) * i);

            x = x1 * (1f - factor) + x2 * (factor);

            vertices[i + itsize1] = new Vector3(x, y, z) + POS;
        }


        itsize1 = NN + itsize1;
        int Lindex = itsize1;
        vertices[0 + itsize1] = vertL;


        itsize1 = itsize1 + 1;

        int CircIndexR = itsize1;
        // For Right Circle.
        for (int i = 0; i < NN - 0; i++)
        {
            x1 = 0.7f * c1 * Mathf.Cos(PI - (N / 2 - 2) * delta_theta);
            x2 = 0.7f * c1 * Mathf.Cos(PI - (N / 2 - 1) * delta_theta);

            z = (2 * dz) * Mathf.Cos(PI - 0.5f * PI / (NN - 1) * i) + 0.0f - dz - dz - dz - dz - dz * 0.3333333f - dz * 2.5f - 4f * dz;

            temp = Arch_eq_6_A(x1, -4f * dz - dz * 0.3333333f - dz * 2.5f - 4f * dz, 0.7f * c1, 0.7f * c2, angle);

            y = (0.002f + 2f * dz) * Mathf.Sin(0.5f * PI / (float)(NN - 1) * i) + temp[1];

            float factor = Mathf.Sin(0.5f * PI / (float)(NN - 1) * i);

            x = x1 * (1f - factor) + x2 * (factor);

            vertices[i + itsize1] = new Vector3(x, y, z) + POS;
        }

        itsize1 = NN + itsize1;
        int Rindex = itsize1;
        vertices[0 + itsize1] = vertR; // Correct this to -1


        //        vertices[itsize1] = vertices[itsize1] + probe;

//        Vector3 probe = new Vector3(0f, 0f, -0.0625f);
//        Vector3 probe = new Vector3(0f, -0.0625f, 0f);
//        vertices[47] = vertices[47] + probe;


/*
        string fileName = "VertRecords3.txt";

        var sr = File.CreateText(fileName);

        Vector3 pos1;

        float xx;
        float yy;
        float zz;
        for (int L = 42; L < 45; L++)
        {
            pos1 = vertices[L];
            xx = pos1[0];
            yy = pos1[1];
            zz = pos1[2];
            sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
        }
        for (int L = 53; L < 58; L++)
        {
            pos1 = vertices[L];
            xx = pos1[0];
            yy = pos1[1];
            zz = pos1[2];
            sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
        }
        // 64 to 60
        for (int L = 0; L < 5; L++)
        {
            pos1 = vertices[64 - L];
            xx = pos1[0];
            yy = pos1[1];
            zz = pos1[2];
            sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
        }
        //50 to 47
        for (int L = 0; L < 4; L++)
        {
            pos1 = vertices[50 - L];
            xx = pos1[0];
            yy = pos1[1];
            zz = pos1[2];
            sr.WriteLine("{0}, {1}, {2}", xx, yy, zz);
        }
        sr.Close();
*/


        // First Top arch part (Right Side)
        for (int i = N / 2 - 1; i < 2 * N + 0; i++)
        {
            int i3 = 3 * (i - (N / 2 - 1));
            triangles[i3 ] = i + 0;
            triangles[i3 + 1] = 2 * N + 0 + i + 1;
            triangles[i3 + 2] = i + 1;
        }

        int skip = 3 * (2 * N - N / 2 + 1 + 0);//+1?
        for (int i = N / 2 - 1; i < 2 * N + 0; i++)
        {
            int i3 = 3 * (i - (N / 2 - 1));
            triangles[i3 + skip] = i + 1;
            triangles[i3 + 1 + skip] = 2 * N + i + 1;
            triangles[i3 + 2 + skip] = 2 * N + i + 2;
        }

        //
        skip = 3 * (2 * N - N / 2 + 1) + skip;
        for (int i = 0; i < N / 2 - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = i + 0;
            triangles[i3 + 1 + skip] = 4 * N + i + 2;
            triangles[i3 + 2 + skip] = 4 * N + i + 3;
        }

        skip = 3 * ( N / 2 - 1) + skip;
        for (int i = 0; i < N / 2 - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = i + 1;
            triangles[i3 + 1 + skip] = i + 0;
            triangles[i3 + 2 + skip] = 4 * N + i + 3;
        }
        //
        
        skip = 3 * ( N / 2 - 1) + skip;
        for (int i = 0; i < N / 2 - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = 5 * N - 2 + i - 1;
            triangles[i3 + 1 + skip] = 2 * N + i + 1;
            triangles[i3 + 2 + skip] = 2 * N + i + 2;
        }

        skip = 3 * (N / 2 - 1) + skip;
        for (int i = 0; i < N / 2 - 1; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip]     = 5 * N - 2 + i + 0;
            triangles[i3 + 1 + skip] = 5 * N - 2 + i - 1;
            triangles[i3 + 2 + skip] = 2 * N + i + 2;
        }
        
        //
        skip = 3 * (N / 2 - 1) + skip;
        for (int i = 0; i < NN; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = CircIndexL + i + 1;
            triangles[i3 + 1 + skip] = Lindex;
            triangles[i3 + 2 + skip] = CircIndexL + i + 0;
        }
        
        skip = 3 * NN + skip;
        for (int i = 0; i < NN; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + skip] = CircIndexR + i + 0;
            triangles[i3 + 1 + skip] = Rindex;
            triangles[i3 + 2 + skip] = CircIndexR + i + 1;
        }



        float Length = dz + .1f * c1 + dz + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
            + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
            + 0.5f * dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.583333f, 2) + Mathf.Pow(0.025f * c1, 2))
            + 0.05f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2))
            + 0.025f * c1 + 2f * dz;

        for (int i = 0; i < 2 * N + 1; i++)
        {
//            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1.000005f) * 0.49995f;
            x = (float)i / (float)(2.00001f * N);
            uvs[i] = new Vector2(x, 0f);
//            uvs[i] = new Vector2(0f, x);
        }
        int uvIndex = 2 * N + 1;
        for (int i = 0; i < 2 * N + 1; i++)
        {
//            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1.000005f) * 0.49995f;
            x = (float)i / (float)(2.00001f * N);
            uvs[i + uvIndex] = new Vector2(x, 0.25f);
        }
        uvIndex = 2 * N + 1 + uvIndex;

        float saveUV = ((float) N / 2f)/ ((float)N * 2f);

        
        for (int i = 0; i < N / 2; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1.000005f) * 0.49995f;
            //x = (float)(i + 1f + 1.5f * N) / (float)(2.00001f * N);
            x = (float)(i) / (float)(2.00001f * N);
            //            uvs[i + uvIndex] = new Vector2(x, 0.1875f);
            uvs[i + uvIndex] = new Vector2(x, 0.0625f);
        }




        uvIndex = N / 2 + uvIndex + 0;

        float interpx2 = (4f) / (2.00001f * (float)N);
        float interpx1 = (3f) / (2.00001f * (float)N);


        for (int i = 0; i < N / 2; i++)
        {
            //            x = (Mathf.Cos(PI - (float)i * delta_theta) + 1.000005f) * 0.49995f;
            //x = (float)(i + 1f + 1.5f * N) / (float)(2.00001f * N);
            x = (float)(i) / (float)(2.00001f * N);
            //            uvs[i + uvIndex] = new Vector2(x, 0.0625f);
            uvs[i + uvIndex] = new Vector2(x, 0.1875f);
        }
        uvIndex = N / 2 + uvIndex + 0;

        uvs[0 + uvIndex] = new Vector2(interpx1 * 1.0f + interpx2 * 0.0f , 0.0625f);
        uvs[1 + uvIndex] = new Vector2(interpx1 * 0.67f + interpx2 * 0.33f  , 0.125f * 0.1f + 0.0625f * 0.9f);
        uvs[2 + uvIndex] = new Vector2(interpx1 * 0.45f + interpx2 * 0.55f  , 0.125f * 0.25f + 0.0625f * 0.75f);
        uvs[3 + uvIndex] = new Vector2(interpx1 * 0.25f + interpx2 * 0.75f  , 0.125f * 0.5f + 0.0625f * 0.5f);
        uvs[4 + uvIndex] = new Vector2(interpx1 * 0.1f + interpx2 * 0.9f    , 0.125f * 0.77f + 0.0625f * 0.23f);
        uvs[5 + uvIndex] = new Vector2(interpx1 * (0.0f) + interpx2 * 1.0f , 0.125f * 1f + 0.0625f * 0f);

        uvs[6 + uvIndex] = new Vector2(interpx1 * (0.0f) + interpx2 * 1.0f, 0.0625f);


        uvs[7 + uvIndex] = new Vector2(interpx1 * 1.0f + interpx2 * 0.0f, 0.1875f);
        uvs[8 + uvIndex] = new Vector2(interpx1 * 0.67f + interpx2 * 0.33f, 0.125f * 0.1f + 0.1875f * 0.9f);
        uvs[9 + uvIndex] = new Vector2(interpx1 * 0.45f + interpx2 * 0.55f, 0.125f * 0.25f + 0.1875f * 0.75f);
        uvs[10 + uvIndex] = new Vector2(interpx1 * 0.25f + interpx2 * 0.75f, 0.125f * 0.5f + 0.1875f * 0.5f);
        uvs[11 + uvIndex] = new Vector2(interpx1 * 0.1f + interpx2 * 0.9f, 0.125f * 0.77f + 0.1875f * 0.23f);
        uvs[12 + uvIndex] = new Vector2(interpx1 * 0.0f + interpx2 * 1.0f, 0.125f * 1f + 0.1875f * 0f);

        uvs[13 + uvIndex] = new Vector2(interpx1 * (0.0f) + interpx2 * 1.0f, 0.1875f);

        /*
        uvs[6 + uvIndex] = new Vector2(interpx1 * 1f + interpx2 * 0f       , 0.1875f);
        uvs[7 + uvIndex] = new Vector2(interpx1 * 0.8f + interpx2 * 0.2f   , 0.125f * 0.2f + 0.1875f * 0.8f);
        uvs[8 + uvIndex] = new Vector2(interpx1 * 0.65f + interpx2 * 0.35f , 0.125f * 0.35f + 0.1875f * 0.65f);
        uvs[9 + uvIndex] = new Vector2(interpx1 * 0.35f + interpx2 * 0.65f , 0.125f * 0.65f + 0.1875f * 0.35f);
        uvs[10 + uvIndex] = new Vector2(interpx1 * 0.2f + interpx2 * 0.8f  , 0.125f * 0.8f + 0.1875f * 0.2f);
        uvs[11 + uvIndex] = new Vector2(interpx1 * 0f + interpx2 * 1f      , 0.125f * 1f + 0.1875f * 0f);

        uvs[0 + uvIndex] = new Vector2(interpx1 * (0.0f) + interpx2 * 1.0f, 0.0625f);

        uvIndex = uvIndex + 1;
         
         
         */
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



/*
Length
Out[8]: 0.8361311504699118

dz
Out[9]: 0.0625

c1
Out[10]: 1.25

*/