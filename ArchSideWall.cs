using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchSideWall : MonoBehaviour
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

        vertices = new Vector3[24];
        triangles = new int[60];
        uvs = new Vector2[24];


        float angle1 = -45f / 180f * PI;


        float angle = rot * angle1;
        float x;
        float z;
        float dz = 0.0625f;

        x = c1 * (-1f);
        z = 0.0f - 0.5f * dz;
        vertices[0] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0.5f, 0, -dz * 0.5f);

        x = c1 * (-1f);
        z = 0.0f;
        vertices[1] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0.5f, 0, dz * 0.5f);

        x = c1 * (-1f);
        z = 0.0f;
        vertices[2] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(2f * dz, 0, dz * 0.5f);

        x = 0.6625f * c1 * (-1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f;
        vertices[3] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS + new Vector3(dz * 0.5f, 0, dz * 0.5f);

        x = 0.6625f * c1 * (-1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - 2f * dz;
        vertices[4] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS + new Vector3(dz * 0.5f, 0, -dz * 0.5f);

        x = 0.725f * c1 * (-1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - 2f * dz;
        vertices[5] = Arch_eq_6_A(x, z, 0.725f * c1, 0.725f * c2, angle) + POS + new Vector3(0, 0, -dz * 0.5f);



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








        x = c1 * (-1f);
        z = 0.0f - 0.5f * dz;
        vertices[12] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0.5f, -10f*dz, -dz * 0.5f);

        x = c1 * (-1f);
        z = 0.0f;
        vertices[13] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0.5f, -10f * dz, dz * 0.5f);

        x = c1 * (-1f);
        z = 0.0f;
        vertices[14] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(2f * dz, -10f * dz, dz * 0.5f);

        x = 0.6625f * c1 * (-1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f;
        vertices[15] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS + new Vector3(dz * 0.5f, -10f * dz, dz * 0.5f); ;

        x = 0.6625f * c1 * (-1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - 2f * dz;
        vertices[16] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS + new Vector3(dz * 0.5f, -10f * dz, -dz * 0.5f);

        x = 0.725f * c1 * (-1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - 2f * dz;
        vertices[17] = Arch_eq_6_A(x, z, 0.725f * c1, 0.725f * c2, angle) + POS + new Vector3(0, -10f * dz, -dz * 0.5f);








        x = c1 * (1f);
        z = 0.0f - 0.5f * dz;
        vertices[18] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(dz * 0.5f, -10f * dz, -dz * 0.5f);

        x = c1 * (1f);
        z = 0.0f;
        vertices[19] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(dz * 0.5f, -10f * dz, dz * 0.5f);

        x = c1 * (1f);
        z = 0.0f;
        vertices[20] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-2f * dz, -10f * dz, dz * 0.5f);

        x = 0.6625f * c1 * (1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f;
        vertices[21] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS + new Vector3(-dz * 0.5f, -10f * dz, dz * 0.5f);

        x = 0.6625f * c1 * (1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - 2f * dz;
        vertices[22] = Arch_eq_6_A(x, z, 0.6625f * c1, 0.6625f * c2, angle) + POS + new Vector3(-dz * 0.5f, -10f * dz, -dz * 0.5f);

        x = 0.725f * c1 * (1f);
        z = 0.0f - dz - dz - dz - dz - dz * 0.3333333f - 2f * dz;
        vertices[23] = Arch_eq_6_A(x, z, 0.725f * c1, 0.725f * c2, angle) + POS + new Vector3(0, -10f * dz, -dz * 0.5f);



        triangles[0] = 0;
        triangles[1] = 12;
        triangles[2] = 13;

        triangles[3] = 1;
        triangles[4] = 0;
        triangles[5] = 13;

        triangles[6] = 1;
        triangles[7] = 13;
        triangles[8] = 14;

        triangles[9] = 2;
        triangles[10] = 1;
        triangles[11] = 14;

        triangles[12] = 2;
        triangles[13] = 14;
        triangles[14] = 15;

        triangles[15] = 3;
        triangles[16] = 2;
        triangles[17] = 15;

        triangles[18] = 3;
        triangles[19] = 15;
        triangles[20] = 16;

        triangles[21] = 4;
        triangles[22] = 3;
        triangles[23] = 16;

        triangles[24] = 4;
        triangles[25] = 16;
        triangles[26] = 17;

        triangles[27] = 5;
        triangles[28] = 4;
        triangles[29] = 17;






     
        triangles[30] = 0+6;
        triangles[31] = 13 + 6;
        triangles[32] = 12 + 6;

        triangles[33] = 0 + 6;
        triangles[34] = 1 + 6;
        triangles[35] = 13 + 6;

        triangles[36] = 1 + 6;
        triangles[37] = 14 + 6;
        triangles[38] = 13 + 6;

        triangles[39] = 1 + 6;
        triangles[40] = 2 + 6;
        triangles[41] = 14 + 6;

        triangles[42] = 2 + 6;
        triangles[43] = 15 + 6;
        triangles[44] = 14 + 6;

        triangles[45] = 2 + 6;
        triangles[46] = 3 + 6;
        triangles[47] = 15 + 6;

        triangles[48] = 3 + 6;
        triangles[49] = 16 + 6;
        triangles[50] = 15 + 6;

        triangles[51] = 3 + 6;
        triangles[52] = 4 + 6;
        triangles[53] = 16 + 6;

        triangles[54] = 4 + 6;
        triangles[55] = 17 + 6;
        triangles[56] = 16 + 6;

        triangles[57] = 4 + 6;
        triangles[58] = 5 + 6;
        triangles[59] = 17 + 6;



        uvs[0] = new Vector2(0f, 0.0f);
        uvs[1] = new Vector2(0.05f, 0.0f);
        uvs[2] = new Vector2(0.15f, 0.0f);
        uvs[3] = new Vector2(0.75f, 0.0f);
        uvs[4] = new Vector2(0.90f, 0.0f);
        uvs[5] = new Vector2(1f, 0.0f);

        uvs[6] = new Vector2(0f, 0.0f);
        uvs[7] = new Vector2(0.05f, 0.0f);
        uvs[8] = new Vector2(0.15f, 0.0f);
        uvs[9] = new Vector2(0.75f, 0.0f);
        uvs[10] = new Vector2(0.90f, 0.0f);
        uvs[11] = new Vector2(1f, 0.0f);

        uvs[12] = new Vector2(0f, .999999f);
        uvs[13] = new Vector2(0.05f, .999999f);
        uvs[14] = new Vector2(0.15f, .999999f);
        uvs[15] = new Vector2(0.75f, .999999f);
        uvs[16] = new Vector2(0.90f, .999999f);
        uvs[17] = new Vector2(1f, .999999f);

        uvs[18] = new Vector2(0f, .999999f);
        uvs[19] = new Vector2(0.05f, .999999f);
        uvs[20] = new Vector2(0.15f, .999999f);
        uvs[21] = new Vector2(0.75f, .999999f);
        uvs[22] = new Vector2(0.90f, .999999f);
        uvs[23] = new Vector2(1f, .999999f);


        //        float LengthX = 2f * c1 * (1f) + dz;
        //        float LengthZ = 2f * (dz + dz + dz + dz + dz * 0.3333333f + 2f * dz) + 2f * dz;



        /*

        float Length = 2f * (dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f*dz)* (4.3333333f * dz))
            + 3f * dz + 0.5f * dz);


        uvs[0] = new Vector2(0f, 0.0f);
        uvs[1] = new Vector2(dz / Length * 0.5f, 0.0f);
        uvs[2] = new Vector2((dz + 3f * dz) / Length * 0.5f, 0.0f);
        uvs[3] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz))) / Length * 0.5f, 0.0f);
        uvs[4] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz)) + 3f * dz) / Length * 0.5f, 0.0f);
        uvs[5] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz)) + 3f * dz + 0.5f * dz) / Length * 0.5f, 0.0f);


        uvs[6] = new Vector2(0f + 0.5f, 0.0f);
        uvs[7] = new Vector2(dz / Length * 0.5f + 0.5f, 0.0f);
        uvs[8] = new Vector2((dz + 3f * dz) / Length * 0.5f + 0.5f, 0.0f);
        uvs[9] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            + ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz))) / Length * 0.5f + 0.5f, 0.0f);
        uvs[10] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz)) + 3f * dz) / Length * 0.5f + 0.5f, 0.0f);
        uvs[11] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz)) + 3f * dz + 0.5f * dz) / Length * 0.5f + 0.5f, 0.0f);


        uvs[12] = new Vector2(0f, 1.0f);
        uvs[13] = new Vector2(dz / Length * 0.5f, 1.0f);
        uvs[14] = new Vector2((dz + 3f * dz) / Length * 0.5f, 1.0f);
        uvs[15] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz))) / Length * 0.5f, 1.0f);
        uvs[16] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz)) + 3f * dz) / Length * 0.5f, 1.0f);
        uvs[17] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz)) + 3f * dz + 0.5f * dz) / Length * 0.5f, 1.0f);

        uvs[18] = new Vector2(0f + 0.5f, 1.0f);
        uvs[19] = new Vector2(dz / Length * 0.5f + 0.5f, 1.0f);
        uvs[20] = new Vector2((dz + 3f * dz) / Length * 0.5f + 0.5f, 1.0f);
        uvs[21] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz))) / Length * 0.5f + 0.5f, 1.0f);
        uvs[22] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz)) + 3f * dz) / Length * 0.5f + 0.5f, 1.0f);
        uvs[23] = new Vector2((dz + 3f * dz + Mathf.Sqrt(((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz))
            * ((c1 - 2.5f * dz) - (.06625f * c1 - 0.5f * dz)) + (4.3333333f * dz) * (4.3333333f * dz)) + 3f * dz + 0.5f * dz) / Length * 0.5f + 0.5f, 1.0f);
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


