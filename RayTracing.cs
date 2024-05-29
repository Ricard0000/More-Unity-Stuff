using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RayTracing : MonoBehaviour
{
    public GameObject cam;
    Vector3 rayOrigin;
    Vector3 triangles;
    Vector3 rays = new Vector3(0f,1f,0f);
    public Material mat;
    GameObject gObj;
    public const float epsilon = 0.00001f;
    public int dimension;
    public float FOV;

    int triangleLength = 0;
    Vector3 point;
    Vector3[] p1;
    Vector3[] p2;
    Vector3[] p3;

    Vector3[] directions;
    Vector3[] points;

    private LayerMask layerMask = ~(1 << 8 | 1 << 9 | 1 << 10);

    // Start is called before the first frame update
    public void Awake()
    {
        // Load Mesh Data 2
        string fileName = "RTMesh2.txt";
        StreamReader inpStrm = new StreamReader(fileName);
        string str = inpStrm.ReadLine();
        int mesh2Length = System.Int32.Parse(str);

        // Load Vert Data 2
        Vector3[] mesh2;
        mesh2 = new Vector3[mesh2Length];
        for (int L = 0; L < mesh2Length; L++)
        {
            string strX = inpStrm.ReadLine();
            float x = float.Parse(strX);
            string strY = inpStrm.ReadLine();
            float y = float.Parse(strY);
            string strZ = inpStrm.ReadLine();
            float z = float.Parse(strZ);
            mesh2[L] = new Vector3(x, y, z);
        }
        str = inpStrm.ReadLine();
        int tri2Length = System.Int32.Parse(str);
        // Load Triangle Data 2
        int[] tri2;
        tri2 = new int[tri2Length];
        for (int L = 0; L < tri2Length; L++)
        {
            string strIndx = inpStrm.ReadLine();
            int triIndx = System.Int32.Parse(strIndx);
            tri2[L] = triIndx;
        }
        inpStrm.Close();


        // Load Mesh Data 3
        fileName = "RTMesh3.txt";
        inpStrm = new StreamReader(fileName);
        str = inpStrm.ReadLine();
        int meshLength3 = System.Int32.Parse(str);

        // Load Vert Data 3
        Vector3[] mesh3;
        mesh3 = new Vector3[meshLength3];
        for (int L = 0; L < meshLength3; L++)
        {
            string strX = inpStrm.ReadLine();
            float x = float.Parse(strX);
            string strY = inpStrm.ReadLine();
            float y = float.Parse(strY);
            string strZ = inpStrm.ReadLine();
            float z = float.Parse(strZ);
            mesh3[L] = new Vector3(x, y, z);
        }
        str = inpStrm.ReadLine();
        int triLength3 = System.Int32.Parse(str);
        // Load Triangle Data 3
        int[] tri3;
        tri3 = new int[triLength3];
        for (int L = 0; L < triLength3; L++)
        {
            string strIndx = inpStrm.ReadLine();
            int triIndx = System.Int32.Parse(strIndx);
            tri3[L] = triIndx;
        }
        inpStrm.Close();

        // Convert Mesh and Triangles into P1, P2, P3 format.

        p1 = new Vector3[mesh2Length + meshLength3];
        p2 = new Vector3[mesh2Length + meshLength3];
        p3 = new Vector3[mesh2Length + meshLength3];


        for (int L = 0; L < (int)(tri2Length/3); L++)
        {
            p1[L] = mesh2[tri2[3 * L]];
            p2[L] = mesh2[tri2[3 * L + 1]];
            p3[L] = mesh2[tri2[3 * L + 2]];
        }
        for (int L = (tri2Length / 3); L < (tri2Length / 3) + (int)(triLength3 / 3); L++)
        {
            p1[L] = mesh2[tri3[3 * (L- (tri2Length / 3))]];
            p2[L] = mesh2[tri3[3 * (L - (tri2Length / 3)) + 1]];
            p3[L] = mesh2[tri3[3 * (L - (tri2Length / 3)) + 2]];
        }



        // Transform rays to proper coordintate system.
        rays = Camera.main.transform.forward;
        rays.Normalize();
        rays[2] = -rays[2];
        rayOrigin = cam.transform.position;
        rayOrigin[1] = 3 + rayOrigin[1];
        rayOrigin[2] = -rayOrigin[2];


        triangleLength = (int)(tri2Length / 3) + (int)(triLength3 / 3);
        point = RayTriangleIntersection(p1, p2, p3, rayOrigin, rays, epsilon, triangleLength);
        gObj = DrawPoint(point, false, mat, rayOrigin);

//

    }

    IEnumerator RayTracerUpdate()
    {
        RaycastHit hit;

        // Position
        Vector3 v1 = cam.transform.position;
        
        // direction
        Vector3 v2 = Camera.main.transform.forward;


        directions = new Vector3[dimension * dimension];
        points = new Vector3[dimension * dimension];
        Vector3 direc = new Vector3(0f, 0f, 0f);
        float theta = (FOV * 3.14159265f / 180) / dimension;

        float x;
        float y;
        float z;

        float xx;
        float yy;
        float zz;
        float c;
        float s;

        Vector3 dirZ = new Vector3(0f,1f,0f);
        Vector3 rotAxis = new Vector3(0f, 0f, 0f);
        rotAxis = CrossProduct(dirZ, v2);
        rotAxis.Normalize();

        float q0;
        float q1;
        float q2;
        float q3;
        float angle;

        int L = 0;
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {

                c = Mathf.Cos(-theta * 0.5f * dimension + theta * (i + 0.5f));
                s = Mathf.Sin(-theta * 0.5f * dimension + theta * (i + 0.5f));
                x = c * v2[0] +  s * v2[2];
                y = v2[1];
                z = -s * v2[0] + c * v2[2];


                angle = -theta * 0.5f * dimension + theta * (j + 0.5f);
                s = Mathf.Sin(angle * 0.5f);
                q0 = Mathf.Cos(angle * 0.5f);
                q1 = rotAxis[0] * s;
                q2 = rotAxis[1] * s;
                q3 = rotAxis[2] * s;

                xx = (1f - 2f * q2 * q2 - 2f * q3 * q3) * x + (2f * q1 * q2 - 2f * q0 * q3) * y + (2f * q1 * q3 + 2f * q0 * q2) * z;
                yy = (2f * q1 * q2 + 2f * q0 * q3) * x + (1f - 2f * q1 * q1 - 2f * q3 * q3) * y + (2f * q2 * q3 - 2f * q0 * q1) * z;
                zz = (2f * q1 * q3 - 2f * q0 * q2) * x + (2f * q2 * q3 + 2f * q0 * q1) * y + (1f - 2f * q1 * q1 - 2f * q2 * q2) * z;

                directions[L] = new Vector3(xx, yy, zz);

                if (Physics.Raycast(v1, directions[L], out hit, Mathf.Infinity, layerMask))
//                if (Physics.Linecast(v1, directions[L], out hit, layerMask))
                {
                    //                    points[L] = hit.point;// - directions[L] * 0.01f;
                    Vector3 tempVect = directions[L];
                    tempVect.Normalize();
                    // Distance dependent range noise.
                    float noise = RandomGaussian(0.0f, 0.5f);
                    float d = hit.distance + noise;
                    points[L] = new Vector3(d * tempVect[0], d * tempVect[1], d * tempVect[2]) + v1;

                }
                else 
                {
                    points[L] = new Vector3(0f, 0f, 0f);
                }
                L++;
            }
        }
        Destroy(gObj);
        gObj = DrawPoints(points, false, mat, dimension);
        yield return new WaitForSeconds(0.25f);
    }

    public static float RandomGaussian(float minValue = 0.0f, float maxValue = 1.0f)
    {
        float u, v, S;
        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            //           v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u;
        }
        while (S >= 1.0f);
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);

    }


    public void Update()
    {
        if (true)
        {
            StartCoroutine(RayTracerUpdate());
        }
    }


    public static Vector3 RayTriangleIntersection(Vector3[] p1, Vector3[] p2, Vector3[] p3, Vector3 rayOrigin,Vector3 rays, float epsilon, int triNum)
    {

        Vector3[] e1;
        e1 = new Vector3[triNum];
        Vector3[] e2;
        e2 = new Vector3[triNum];

        for(int i = 0; i< triNum; i++)
        {
            e1[i] = p2[i] - p1[i];
            e2[i] = p3[i] - p1[i];
        }
        Vector3[] rayCrosse2;
        rayCrosse2 = new Vector3[triNum];
        for (int i = 0; i < triNum; i++)
        {
            rayCrosse2[i] = CrossProduct(rays, e2[i]);
        }


        for (int i = 0; i < triNum; i++)
        {
            float det;
            det = DotProduct(rayCrosse2[i], e1[i]);
            if (det > -epsilon && det < epsilon)
            {
                continue;
            }

            float invDet = 1.0f / det;

            Vector3 s = rayOrigin - p1[i];

            float u = invDet * DotProduct(s, rayCrosse2[i]);

            if (u < 0 || u > 1)
            {
                continue;
            }

            Vector3 sCrosse1;
            sCrosse1 = CrossProduct(s, e1[i]);

            float v = invDet * DotProduct(rays, sCrosse1);

            if (v < 0 || u + v > 1)
            {
                continue;
            }

            float t = invDet * DotProduct(e2[i], sCrosse1);

            if (t > epsilon)
            {
                return rays * (t + 0.00001f);
            }
            else
            {
                continue;
            }
        }
        return new Vector3(0f, 0f, 0f);
    }

    public static Vector3 CrossProduct(Vector3 a, Vector3 b)
    {
        Vector3 result;
        result = new Vector3(a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]);
        return result;
    }

    public static float DotProduct(Vector3 a, Vector3 b)
    {
        float result;
        result = a[0] * b[0] + a[1] * b[1] + a[2] * b[2];
        return result;
    }


    public static GameObject DrawPoint(Vector3 point, bool collider, Material mat, Vector3 cameraLocation)
    {
        if(point != Vector3.zero)
        {
            GameObject go = new GameObject("Plane");
            MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
            MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

            Mesh m = new Mesh();
            Vector3[] vertices;
            Vector2[] uvs;
            int[] triangles;

            float scale = 0.03125f;
            vertices = new Vector3[4];
            triangles = new int[6];
            uvs = new Vector2[4];

            // Construct Verts
            vertices[0] = point + new Vector3(-1f, -1f, 0f) * scale + cameraLocation;
            vertices[1] = point + new Vector3(-1f, 1f, 0f) * scale + cameraLocation;
            vertices[2] = point + new Vector3(1f, 1f, 0f) * scale + cameraLocation;
            vertices[3] = point + new Vector3(1f, -1f, 0f) * scale + cameraLocation;


            // Construct Tris
            triangles[0] = 0;
            triangles[1] = 2;
            triangles[2] = 1;
            triangles[3] = 0;
            triangles[4] = 3;
            triangles[5] = 2;

            // UV Mesh
            /*
            uvs[0] = new Vector2(vertices[0].x, vertices[0].y);
            uvs[1] = new Vector2(vertices[1].x, vertices[1].y);
            uvs[2] = new Vector2(vertices[2].x, vertices[2].y);
            uvs[3] = new Vector2(vertices[3].x, vertices[3].y);
            */
            uvs[0] = new Vector2(0f,0f);
            uvs[1] = new Vector2(0f,1f);
            uvs[2] = new Vector2(1f,1f);
            uvs[3] = new Vector2(1f,0f);



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
        else
        {
            return null;
        }
        
    }



    public static GameObject DrawPoints(Vector3[] points, bool collider, Material mat, int dimension)
    {
        GameObject go = new GameObject("Plane");
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Mesh m = new Mesh();
        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

        float scale = 0.03125f * 0.5f;
        vertices = new Vector3[4 * dimension * dimension];
        triangles = new int[6 * dimension * dimension * 2];
        uvs = new Vector2[4 * dimension * dimension];


        // If Camera.forward == 0,0,-1:



        // If Camera.forward == 0,0,+1:
        // Angle with respect to x - axis: theta.
        Vector3 minusZdir = new Vector3(0f,0f,-1f); 
        Vector3 lookDirection = Camera.main.transform.forward;

        Vector3 crossProduct = CrossProduct(minusZdir, lookDirection);

        Vector3 projectOntoXZ = new Vector3(lookDirection[0], 0f, lookDirection[2]);

        Vector3 projectOntoYZ = new Vector3(0f, lookDirection[1], lookDirection[2]);
        projectOntoYZ.Normalize();

        float theta = Mathf.Acos(DotProduct(projectOntoXZ, minusZdir)) * Mathf.Sign(crossProduct[1]);// * 180 / Mathf.PI
//        float phi = Mathf.Atan2(lookDirection[1], Mathf.Sqrt(lookDirection[0] * lookDirection[0] + lookDirection[2] * lookDirection[2]));// * 180 / Mathf.PI;

        Vector3 dir1 = new Vector3(-Mathf.Cos(-theta), -1f, -Mathf.Sin(-theta)) * scale;
        Vector3 dir2 = new Vector3(-Mathf.Cos(-theta),  1f, -Mathf.Sin(-theta)) * scale;
        Vector3 dir3 = new Vector3(-Mathf.Cos(-theta + Mathf.PI),  1f, -Mathf.Sin(-theta + Mathf.PI)) * scale;
        Vector3 dir4 = new Vector3(-Mathf.Cos(-theta + Mathf.PI), -1f, -Mathf.Sin(-theta + Mathf.PI)) * scale;


        // Construct Verts
        for (int i = 0; i < dimension * dimension; i++)
        {
            if (points[i] != Vector3.zero)
            {
                int i4 = 4 * i;
                vertices[i4] = points[i] + dir1;
                vertices[1 + i4] = points[i] + dir2;
                vertices[2 + i4] = points[i] + dir3;
                vertices[3 + i4] = points[i] + dir4;
            }
            else
            {
                vertices[0 + 4 * i] = new Vector3(0f, 0f, 0f);
                vertices[1 + 4 * i] = new Vector3(0f, 0f, 0f);
                vertices[2 + 4 * i] = new Vector3(0f, 0f, 0f);
                vertices[3 + 4 * i] = new Vector3(0f, 0f, 0f);
            }
        }
//        int flag = 1;
        // Construct Tris
        /*
        for (int i = 0; i < dimension * dimension; i++)
        {
            int i6 = 6 * i;
            int i4 = 4 * i;
            triangles[i6] = 0 + i4;
            triangles[1 + i6] = (2 + i4) * flag + (1 + i4) * (1 - flag);
            triangles[2 + i6] = (1 + i4) * flag + (2 + i4) * (1 - flag);
            triangles[3 + i6] = 0 + i4;
            triangles[4 + i6] = (3 + i4) * flag + (2 + i4) * (1 - flag);
            triangles[5 + i6] = (2 + i4) * flag + (3 + i4) * (1 - flag);
        }
        */
        
        for (int i = 0; i < dimension * dimension; i++)
        {
            int i6 = 6 * i;
            int i4 = 4 * i;
            triangles[i6] = 0 + i4;
            triangles[1 + i6] = 2 + i4;
            triangles[2 + i6] = 1 + i4;
            triangles[3 + i6] = 0 + i4;
            triangles[4 + i6] = 3 + i4;
            triangles[5 + i6] = 2 + i4;
        }
        

        for (int i = 0; i < dimension * dimension; i++)
        {
            int i4 = 4 * i;
            uvs[i4] = new Vector2(0f, 0f);
            uvs[1 + i4] = new Vector2(0f, 1f);
            uvs[2 + i4] = new Vector2(1f, 1f);
            uvs[3 + i4] = new Vector2(1f, 0f);
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


    public static float ModularArithmetic(float x, int N)
    {
        int n = (int)Mathf.Floor((x / (float)N));
        float y = x - N * n;
        return y;
    }

    public static Vector3 RotateY(Vector3 vect, float theta)
    {
        float c = Mathf.Cos(theta - 0f * Mathf.PI * 0.5f);
        float s = Mathf.Sin(theta - 0f * Mathf.PI * 0.5f);

//        float x = vect[0];
  //      float y = c * vect[1] - s * vect[2];
    //    float z = s * vect[1] + c * vect[2];




        float x = c * vect[0] + s * vect[2];
        float y = vect[1];
        float z = -s * vect[0] + c * vect[2];


        return new Vector3(x, y, z);
    }



}
//                Destroy(gObj);
//                gObj = DrawPoint(hit.point, false, mat, Vector3.zero);
//                yield return new WaitForSeconds(0.25f);


// Transform rays to proper coordintate system.

/*
        Vector3 rays = Camera.main.transform.forward;
        rays.Normalize();
        rays[2] = -rays[2];
        rayOrigin = cam.transform.position;
        rayOrigin[2] = -rayOrigin[2];
*/




//            Debug.Log(hit.point.x);
//           Debug.Log(hit.point.y);
//          Debug.Log(hit.point.z);
//            Debug.DrawRay(v1,hit.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

//        point = RayTriangleIntersection(p1, p2, p3, rayOrigin, rays, epsilon, triangleLength);

// To DO: Update points...

//        Debug.Log(point.x);
//      Debug.Log(point.y);
//     Debug.Log(point.z);

//        Destroy(gObj);
//        gObj = DrawPoint(point, false, mat, rayOrigin);