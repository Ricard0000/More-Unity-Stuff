using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;


public class OutterWall : MonoBehaviour
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
    string fileName = "MyFile.txt";

    /*
    [SerializeField] private TMP_InputField txtInput;
    private string appendFile;
    private string overwriteFile;
    */

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, true, mat, rot);
    }



    public void Start()
    {
        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " already exists.");
            return;
        }
        var sr = File.CreateText(fileName);
        sr.WriteLine("This is my file.");
        sr.WriteLine("I can write ints {0} or floats {1}, and so on.",
            1, 4.2);
        sr.Close();

    }
/*
    void Start()
    {
        WriteToFile();
    }
*/
    public static void WriteToFile()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "table.txt");
        sw.WriteLine("Generated table of 1 to 10");
        sw.WriteLine("");

        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                sw.WriteLine("{0}x{1}= {2}", i, j, (i * j));
            }

            sw.WriteLine("====================================");
        }
        sw.WriteLine("Table successfully written to file!");
        sw.Close();
    }


    public static Vector3 Arch_eq_6(float x, float z, float c1, float c2)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f - 0.00001f;
        return new Vector3(x, y, z);
    }

    public static Vector3 Arch_eq_6_uv(float x, float c1, float c2, float up)
    {
        float y;
        y = c2 * Mathf.Sqrt(1 - Mathf.Abs(x) / (c1 + 0.00001f));
        y = y + c2 * Mathf.Sqrt(1 - Mathf.Abs(x * x) / (c1 * c1 + 0.00001f));
        y = y / 2.0f + up;

        return new Vector2(x, y);
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


    public static float Vert_Rot_x(float x, float z, float angle)
    {
        return x * Mathf.Cos(angle) - z * Mathf.Sin(angle);
    }

    public static float Vert_Rot_z(float x, float z, float angle)
    {
        return x * Mathf.Sin(angle) + z * Mathf.Cos(angle);
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

        vertices = new Vector3[4 + 2 * N + 2 + 1 + 1 + 1 + 1];
        triangles = new int[6 * N + 3 + 6 + 6];
        uvs = new Vector2[4 + 2 * N + 2 + 1 + 1 + 1 + 1];


        float angle1 = -45f / 180f * PI;


        float angle = rot * angle1;
        float x;
        float z;
        float dz = 0.0625f;
        float sideLengthFromBottom = 1f;

        x = c1 * (-1f);
        z = 0.0f - 0.5f * dz;
        vertices[0] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0f, c2, -dz * 0.5f);

        x = c1 * (-1f);
        z = 0.0f - 0.5f * dz;
        vertices[1] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0f, - 10f * dz, -dz * 0.5f);


        x = c1 * (-1f);
        z = 0.0f - 0.5f * dz;
        vertices[2] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0f - sideLengthFromBottom, c2, -dz * 0.5f);

        x = c1 * (-1f);
        z = 0.0f - 0.5f * dz;
        vertices[3] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0f - sideLengthFromBottom, - 10f * dz, -dz * 0.5f);



        int skip = 4;
        for (int i = 0; i < N + 1; i++)
        {
            x = c1 * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f - dz;
            vertices[i + skip] = Arch_eq_6_A(x, z, c1, c2, angle) + POS;
        }

        skip = skip + N + 1;
        for (int i = 0; i < N + 1; i++)
        {
            x = c1 * Mathf.Cos(PI * 0.5f - (i) * delta_theta);
            z = 0.0f - dz;
            vertices[i + skip] = Arch_eq_6_A(x, z, c1, c2, angle) + POS;
        }


        skip = skip + N + 1;

        x = c1 * (1f);
        z = 0.0f - 0.5f * dz;
        vertices[0 + skip] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0f, c2, -dz * 0.5f);

        x = c1 * (1f);
        z = 0.0f - 0.5f * dz;
        vertices[1 + skip] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(-dz * 0f, -10f * dz, -dz * 0.5f);

        x = c1 * (1f);
        z = 0.0f - 0.5f * dz;
        vertices[2 + skip] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(0f + sideLengthFromBottom, c2, -dz * 0.5f);

        x = c1 * (1f);
        z = 0.0f - 0.5f * dz;
        vertices[3 + skip] = Arch_eq_6_A(x, z, c1, c2, angle) + POS + new Vector3(0f + sideLengthFromBottom, -10f * dz, -dz * 0.5f);



        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;

        int triSkip = 6;
        for(int i = 0; i < N; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = i + 4;
            triangles[i3 + triSkip + 1] = i + 5;
            triangles[i3 + triSkip + 2] = 0;
        }

        triSkip = triSkip + 3 * N;
        for (int i = 0; i < N; i++)
        {
            int i3 = 3 * i;
            triangles[i3 + triSkip] = i + 5 + N;
            triangles[i3 + triSkip + 1] = i + 6 + N;
            triangles[i3 + triSkip + 2] = skip;
        }
        triSkip = triSkip + 3 * N;
        triangles[0 + triSkip] = 0 + 6 + 2 * N;
        triangles[1 + triSkip] = 1 + 6 + 2 * N;
        triangles[2 + triSkip] = 2 + 6 + 2 * N;

        triangles[3 + triSkip] = 2 + 6 + 2 * N;
        triangles[4 + triSkip] = 1 + 6 + 2 * N;
        triangles[5 + triSkip] = 3 + 6 + 2 * N;



        float L = sideLengthFromBottom * 2f + 2f * c1;
        float LVert = 10f * dz + c2;

        uvs[0] = new Vector2(sideLengthFromBottom / L, 1f);
        uvs[1] = new Vector2(sideLengthFromBottom / L, 0f);
        uvs[2] = new Vector2(0f, 1f);
        uvs[3] = new Vector2(0f, 0f);

        int uvSkip = 4;
        for(int i = 0; i < N + 1; i++)
        {
            x = Mathf.Cos(PI - i * delta_theta);
            Vector2 Temp;
            Temp = Arch_eq_6_uv(x, 1f, c2, 0f);
            uvs[i + uvSkip] = new Vector2(1.25f*Temp[0] / L + 0.5f, (Temp[1] + 10f * dz) / LVert);
        }
        uvSkip = uvSkip + N + 1;
        for (int i = 0; i < N; i++)
        {
            x = Mathf.Cos(PI * 0.5f - i * delta_theta);
            Vector2 Temp;
            Temp = Arch_eq_6_uv(x, 1f, c2, 0f);
            uvs[i + uvSkip] = new Vector2(1.25f * Temp[0] / L + 0.5f, (Temp[1] + 10f * dz) / LVert);
        }

        uvSkip = uvSkip + N + 1;
        uvs[0 + uvSkip] = new Vector2((L-sideLengthFromBottom) / L, 1f);
        uvs[1 + uvSkip] = new Vector2((L - sideLengthFromBottom) / L, 0f);
        uvs[2 + uvSkip] = new Vector2(1f, 1f);
        uvs[3 + uvSkip] = new Vector2(1f, 0f);

        /*
        skip = skip + 4;
        for (int i = 0; i < N + 1; i++)
        {
            x = (2 * c1) / L * Mathf.Cos(PI - i * delta_theta);
            z = 0.0f;

            uvs[i + skip] = Arch_eq_6_uv(x, (2 * c1) / L, c2, up);
        }
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


