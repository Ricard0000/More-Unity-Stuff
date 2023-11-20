using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMainArch : MonoBehaviour
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

        vertices = new Vector3[12];
        triangles = new int[24];
        uvs = new Vector2[12];


        float angle1 = -45f / 180f * PI;


        float angle = rot * angle1;
        float x;
        float z;
        float dz = 0.0625f;

        x = c1 * (-1f);
        z = 0.0f - 0.5f * dz;
        vertices[0] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz*0.5f,0,-dz * 0.5f);

        x = c1 * (-1f);
        z = 0.0f;
        vertices[1] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0.5f, 0, dz * 0.5f);

        x = c1 * (-1f);
        z = 0.0f;
        vertices[2] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(2f * dz, 0, dz * 0.5f);

        x = 0.6625f * c1 * (-1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f;
        vertices[3] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS + new Vector3(dz * 0.5f, 0, dz * 0.5f); ;

        x = 0.6625f * c1 * (-1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - 2f * dz;
        vertices[4] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS + new Vector3(dz*0.5f, 0, -dz * 0.5f);

        x = 0.725f * c1 * (-1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - 2f * dz;
        vertices[5] = Arch_eq_6_A(x, z, 0.725f * c1, 0.725f * c2, angle) + POS + new Vector3(0f, 0, -dz * 0.5f);








        x = c1 * (1f);
        z = 0.0f - 0.5f * dz;
        vertices[6] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(dz * 0.5f, 0, -dz * 0.5f);

        x = c1 * (1f);
        z = 0.0f;
        vertices[7] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(dz * 0.5f, 0, dz * 0.5f);

        x = c1 * (1f);
        z = 0.0f;
        vertices[8] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-2f * dz, 0, dz * 0.5f);

        x = 0.6625f * c1 * (1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f;
        vertices[9] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS + new Vector3(-dz * 0.5f, 0, dz * 0.5f);

        x = 0.6625f * c1 * (1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - 2f * dz;
        vertices[10] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS + new Vector3(-dz * 0.5f, 0, -dz * 0.5f);

        x = 0.725f * c1 * (1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - 2f * dz;
        vertices[11] = Arch_eq_6_A(x, z, 0.725f * c1, 0.725f * c2, angle) + POS + new Vector3(0, 0, -dz * 0.5f);


        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 5;


        triangles[6] = 5;
        triangles[7] = 2;
        triangles[8] = 3;

        triangles[9] = 5;
        triangles[10] = 3;
        triangles[11] = 4;




        triangles[12] = 7;
        triangles[13] = 6;
        triangles[14] = 8;

        triangles[15] = 8;
        triangles[16] = 6;
        triangles[17] = 11;

        triangles[18] = 11;
        triangles[19] = 9;
        triangles[20] = 8;

        triangles[21] = 10;
        triangles[22] = 9;
        triangles[23] = 11;


        /*
        float Length = dz + .1f * c1 + dz + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.03f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0075f * c1, 2))
            + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.66666f, 2) + Mathf.Pow(0.0325f * c1, 2))
            + 0.5f * dz + Mathf.Sqrt(Mathf.Pow(dz * 0.25f, 2) + Mathf.Pow(0.025f * c1, 2)) + Mathf.Sqrt(Mathf.Pow(dz * 0.583333f, 2) + Mathf.Pow(0.025f * c1, 2))
            + 0.05f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2)) + 0.0125f * c1 + Mathf.Sqrt(Mathf.Pow(dz * 0.33333f, 2) + Mathf.Pow(0.0125f * c1, 2))
            + 0.025f * c1 + 2f * dz;
        */


        float LengthX = 2f * c1 * (1f) + dz;
        float LengthZ = 2f * (dz + dz + dz + dz + dz * 0.3333333f + 2f * dz) + 2f * dz;

        /*
        float zuv = 2f * dz / LengthZ;
        uvs[0] = new Vector2(0f, zuv);

        x = 0;
        uvs[1] = new Vector2(0f, 0f);

        x = 0;
        uvs[2] = new Vector2(2.5f * dz, 0f);

        x = 0;
        uvs[3] = new Vector2(2.5f * dz, 0f);
        */
/*
        uvs[0] = new Vector2(0f, 0.1f);
        uvs[1] = new Vector2(0f, 0f);
        uvs[2] = new Vector2(0.1f, 0f);
        uvs[3] = new Vector2(0.5f, .4f);
        uvs[4] = new Vector2(0.5f, 5f);
        uvs[5] = new Vector2(0.4f, 5f);


        uvs[6] = new Vector2(1f, 0.1f);
        uvs[7] = new Vector2(1f, 0f);
        uvs[8] = new Vector2(0.9f, 0f);
        uvs[9] = new Vector2(0.5f, .4f);
        uvs[10] = new Vector2(0.5f, 5f);
        uvs[11] = new Vector2(0.6f, 5f);
*/
/*
        uvs[0] = new Vector2(0f, 0.02f);
        uvs[1] = new Vector2(0f, 0f);
        uvs[2] = new Vector2(0.05f, 0f);
        uvs[3] = new Vector2(0.15f, .2f);
        uvs[4] = new Vector2(0.15f, .22f);
        uvs[5] = new Vector2(0.1f, .22f);
*/


        uvs[0] = new Vector2(0f, 0.25f);
        uvs[1] = new Vector2(0f, 0f);
        uvs[2] = new Vector2(0.25f, 0f);
        uvs[3] = new Vector2(1f, .75f);
        uvs[4] = new Vector2(1f, 1f);
        uvs[5] = new Vector2(0.75f, 1f);


        uvs[6] = new Vector2(0f, 0.25f);
        uvs[7] = new Vector2(0f, 0f);
        uvs[8] = new Vector2(.25f, 0f);
        uvs[9] = new Vector2(1f, .75f);
        uvs[10] = new Vector2(1f, 1f);
        uvs[11] = new Vector2(0.75f, 1f);

/*
        uvs[6] = new Vector2(1f, 0.02f);
        uvs[7] = new Vector2(1f, 0f);
        uvs[8] = new Vector2(.95f, 0f);
        uvs[9] = new Vector2(.85f, .2f);
        uvs[10] = new Vector2(.85f, .22f);
        uvs[11] = new Vector2(0.9f, .22f);
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