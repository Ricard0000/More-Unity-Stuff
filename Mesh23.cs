using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Mesh23 : MonoBehaviour
{

    // Center Rail
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
    const int N = 14;
    const int NN = 6;
    float delta_theta = (PI / 2) / N;
    public int rot = 0;

    public Material mat;

    GameObject gog;// = new GameObject("Plane");
    void Awake()
    {
        gog = MakeDiscreteProceduralGrid(Pos1, Pos2, Pos3, c1, c2, c3, c4, s, t, delta_theta, N, NN, true, mat, rot);
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

        vertices = new Vector3[172];
        triangles = new int[330];
        uvs = new Vector2[172];
        float meshScale = 4f;

        

        // 0 - 15 post1, 16 - 31: post 2, 32-47: Post3, 48-63: post 4.
        vertices[0] = new Vector3(0f, -0.29f, -0.20325f);
        uvs[0] = new Vector2(vertices[0].y, vertices[0].z);
        vertices[1] = new Vector3(0f, -0.29f, -0.2125f);
        uvs[1] = new Vector2(vertices[1].y, vertices[1].z);
        vertices[2] = new Vector3(0f, -0.07219998f, -0.20325f);
        uvs[2] = new Vector2(vertices[2].y, vertices[2].z);
        vertices[3] = new Vector3(0f, -0.07039998f, -0.2125f);
        uvs[3] = new Vector2(vertices[3].y, vertices[3].z);
        
        vertices[4] = new Vector3(0.00925f, -0.29f, -0.20325f);
        uvs[4] = new Vector2(vertices[4].y, vertices[4].z);
        vertices[5] = new Vector3(0.00925f, -0.29f, -0.2125f);
        uvs[5] = new Vector2(vertices[5].y, vertices[5].z);
        vertices[6] = new Vector3(0.00925f, -0.07219998f, -0.20325f);
        uvs[6] = new Vector2(vertices[6].y, vertices[6].z);
        vertices[7] = new Vector3(0.00925f, -0.07039998f, -0.2125f);
        uvs[7] = new Vector2(vertices[7].y, vertices[7].z);


        vertices[8] = new Vector3(0f, -0.29f, -0.20325f);
        uvs[8] = new Vector2(vertices[8].x, vertices[8].y);
        vertices[9] = new Vector3(0.00925f, -0.29f, -0.20325f);
        uvs[9] = new Vector2(vertices[9].x, vertices[9].y);
        vertices[10] = new Vector3(0f, -0.07219998f, -0.20325f);
        uvs[10] = new Vector2(vertices[10].x, vertices[10].y);
        vertices[11] = new Vector3(0.00925f, -0.07219998f, -0.20325f);
        uvs[11] = new Vector2(vertices[11].x, vertices[11].y);

        vertices[12] = new Vector3(0f, -0.29f, -0.2125f);
        uvs[12] = new Vector2(vertices[12].x, vertices[12].y);
        vertices[13] = new Vector3(0.00925f, -0.29f, -0.2125f);
        uvs[13] = new Vector2(vertices[13].x, vertices[13].y);
        vertices[14] = new Vector3(0f, -0.07039998f, -0.2125f);
        uvs[14] = new Vector2(vertices[14].x, vertices[14].y);
        vertices[15] = new Vector3(0.00925f, -0.07039998f, -0.2125f);
        uvs[15] = new Vector2(vertices[15].x, vertices[15].y);


        vertices[16] = new Vector3(0f, -0.4f, 0.12425f);
        uvs[16] = new Vector2(vertices[16].y, vertices[16].z);
        vertices[17] = new Vector3(0f, -0.4f, 0.115f);
        uvs[17] = new Vector2(vertices[17].y, vertices[17].z);
        vertices[18] = new Vector3(0f, -0.1462f, 0.12425f);
        uvs[18] = new Vector2(vertices[18].y, vertices[18].z);
        vertices[19] = new Vector3(0f, -0.1444f, 0.115f);
        uvs[19] = new Vector2(vertices[19].y, vertices[19].z);


        vertices[20] = new Vector3(0.00925f, -0.4f, 0.12425f);
        uvs[20] = new Vector2(vertices[20].y, vertices[20].z);
        vertices[21] = new Vector3(0.00925f, -0.4f, 0.115f);
        uvs[21] = new Vector2(vertices[21].y, vertices[21].z);
        vertices[22] = new Vector3(0.00925f, -0.1462f, 0.12425f);
        uvs[22] = new Vector2(vertices[22].y, vertices[22].z);
        vertices[23] = new Vector3(0.00925f, -0.1444f, 0.115f);
        uvs[23] = new Vector2(vertices[23].y, vertices[23].z);


        vertices[24] = new Vector3(0f, -0.4f, 0.12425f);
        uvs[24] = new Vector2(vertices[24].x, vertices[24].y);
        vertices[25] = new Vector3(0.00925f, -0.4f, 0.12425f);
        uvs[25] = new Vector2(vertices[25].x, vertices[25].y);
        vertices[26] = new Vector3(0f, -0.1462f, 0.12425f);
        uvs[26] = new Vector2(vertices[26].x, vertices[26].y);
        vertices[27] = new Vector3(0.00925f, -0.1462f, 0.12425f);
        uvs[27] = new Vector2(vertices[27].x, vertices[27].y);


        vertices[28] = new Vector3(0f, -0.4f, 0.115f);
        uvs[28] = new Vector2(vertices[28].x, vertices[28].y);
        vertices[29] = new Vector3(0.00925f, -0.4f, 0.115f);
        uvs[29] = new Vector2(vertices[29].x, vertices[29].y);
        vertices[30] = new Vector3(0f, -0.1444f, 0.115f);
        uvs[30] = new Vector2(vertices[30].x, vertices[30].y);
        vertices[31] = new Vector3(0.00925f, -0.1444f, 0.115f);
        uvs[31] = new Vector2(vertices[31].x, vertices[31].y);


        vertices[32] = new Vector3(0f, -0.47125f, 0.52425f);
        uvs[32] = new Vector2(vertices[32].y, vertices[32].z);
        vertices[33] = new Vector3(0f, -0.47125f, 0.515f);
        uvs[33] = new Vector2(vertices[33].y, vertices[33].z);
        vertices[34] = new Vector3(0f, -0.23725f, 0.52425f);
        uvs[34] = new Vector2(vertices[34].y, vertices[34].z);
        vertices[35] = new Vector3(0f, -0.23545f, 0.515f);
        uvs[35] = new Vector2(vertices[35].y, vertices[35].z);


        vertices[36] = new Vector3(0.00925f, -0.47125f, 0.52425f);
        uvs[36] = new Vector2(vertices[36].y, vertices[36].z);
        vertices[37] = new Vector3(0.00925f, -0.47125f, 0.515f);
        uvs[37] = new Vector2(vertices[37].y, vertices[37].z);
        vertices[38] = new Vector3(0.00925f, -0.23725f, 0.52425f);
        uvs[38] = new Vector2(vertices[38].y, vertices[38].z);
        vertices[39] = new Vector3(0.00925f, -0.23545f, 0.515f);
        uvs[39] = new Vector2(vertices[39].y, vertices[39].z);


        vertices[40] = new Vector3(0f, -0.47125f, 0.52425f);
        uvs[40] = new Vector2(vertices[40].x, vertices[40].y);
        vertices[41] = new Vector3(0.00925f, -0.47125f, 0.52425f);
        uvs[41] = new Vector2(vertices[41].x, vertices[41].y);
        vertices[42] = new Vector3(0f, -0.23725f, 0.52425f);
        uvs[42] = new Vector2(vertices[42].x, vertices[42].y);
        vertices[43] = new Vector3(0.00925f, -0.23725f, 0.52425f);
        uvs[43] = new Vector2(vertices[43].x, vertices[43].y);


        vertices[44] = new Vector3(0f, -0.47125f, 0.515f);
        uvs[44] = new Vector2(vertices[44].x, vertices[44].y);
        vertices[45] = new Vector3(0.00925f, -0.47125f, 0.515f);
        uvs[45] = new Vector2(vertices[45].x, vertices[45].y);
        vertices[46] = new Vector3(0f, -0.23545f, 0.515f);
        uvs[46] = new Vector2(vertices[46].x, vertices[46].y);
        vertices[47] = new Vector3(0.00925f, -0.23545f, 0.515f);
        uvs[47] = new Vector2(vertices[47].x, vertices[47].y);


        vertices[48] = new Vector3(0f, -0.52125f, 0.92425f);
        uvs[48] = new Vector2(vertices[48].y, vertices[48].z);
        vertices[49] = new Vector3(0f, -0.52125f, 0.915f);
        uvs[49] = new Vector2(vertices[49].y, vertices[49].z);
        vertices[50] = new Vector3(0f, -0.33045f, 0.92425f);
        uvs[50] = new Vector2(vertices[50].y, vertices[50].z);
        vertices[51] = new Vector3(0f, -0.32865f, 0.915f);
        uvs[51] = new Vector2(vertices[51].y, vertices[51].z);


        vertices[52] = new Vector3(0.00925f, -0.52125f, 0.92425f);
        uvs[52] = new Vector2(vertices[52].y, vertices[52].z);
        vertices[53] = new Vector3(0.00925f, -0.52125f, 0.915f);
        uvs[53] = new Vector2(vertices[53].y, vertices[53].z);
        vertices[54] = new Vector3(0.00925f, -0.33045f, 0.92425f);
        uvs[54] = new Vector2(vertices[54].y, vertices[54].z);
        vertices[55] = new Vector3(0.00925f, -0.32865f, 0.915f);
        uvs[55] = new Vector2(vertices[55].y, vertices[55].z);

        
        vertices[56] = new Vector3(0f, -0.52125f, 0.92425f);
        uvs[56] = new Vector2(vertices[56].x, vertices[56].y);
        vertices[57] = new Vector3(0.00925f, -0.52125f, 0.92425f);
        uvs[57] = new Vector2(vertices[57].x, vertices[57].y);
        vertices[58] = new Vector3(0f, -0.33045f, 0.92425f);
        uvs[58] = new Vector2(vertices[58].x, vertices[58].y);
        vertices[59] = new Vector3(0.00925f, -0.33045f, 0.92425f);
        uvs[59] = new Vector2(vertices[59].x, vertices[59].y);


        vertices[60] = new Vector3(0f, -0.52125f, 0.915f);
        uvs[60] = new Vector2(vertices[60].x, vertices[60].y);
        vertices[61] = new Vector3(0.00925f, -0.52125f, 0.915f);
        uvs[61] = new Vector2(vertices[61].x, vertices[61].y);
        vertices[62] = new Vector3(0f, -0.32865f, 0.915f);
        uvs[62] = new Vector2(vertices[62].x, vertices[62].y);
        vertices[63] = new Vector3(0.00925f, -0.32865f, 0.915f);
        uvs[63] = new Vector2(vertices[63].x, vertices[63].y);

        // Top of Rail: Right side: towards negative x.
        vertices[64] = new Vector3(0f, -0.06749998f, -0.225f); // save
        uvs[64] = new Vector2(vertices[64].y, vertices[64].z);
        vertices[65] = new Vector3(0f, -0.34425f, 0.9555f);
        uvs[65] = new Vector2(vertices[65].y, vertices[65].z); 
        vertices[66] = new Vector3(0f, -0.05968748f, -0.225f); // save
        uvs[66] = new Vector2(vertices[66].y, vertices[66].z);
        vertices[67] = new Vector3(0f, -0.3364375f, 0.9555f);
        uvs[67] = new Vector2(vertices[67].y, vertices[67].z);


        // Top of Rail: Left side: towards positive x.
        vertices[68] = new Vector3(0.00925f, -0.06749998f, -0.225f); // save
        uvs[68] = new Vector2(vertices[68].y, vertices[68].z);
        vertices[69] = new Vector3(0.00925f, -0.34425f, 0.9555f);
        uvs[69] = new Vector2(vertices[69].y, vertices[69].z);
        vertices[70] = new Vector3(0.00925f, -0.05968748f, -0.225f); // save
        uvs[70] = new Vector2(vertices[70].y, vertices[70].z);
        vertices[71] = new Vector3(0.00925f, -0.3364375f, 0.9555f);
        uvs[71] = new Vector2(vertices[71].y, vertices[71].z);

        // Top of Rail: Left side: towards negative y.
        vertices[72] = new Vector3(0f, -0.06749998f, -0.225f);
        uvs[72] = new Vector2(vertices[72].x, vertices[72].z);
        vertices[73] = new Vector3(0f, -0.34425f, 0.9555f);
        uvs[73] = new Vector2(vertices[73].x, vertices[73].z);
        vertices[74] = new Vector3(0.00925f, -0.06749998f, -0.225f);
        uvs[74] = new Vector2(vertices[74].x, vertices[74].z);
        vertices[75] = new Vector3(0.00925f, -0.34425f, 0.9555f);
        uvs[75] = new Vector2(vertices[75].x, vertices[75].z);

        // Top of Rail: Left side: towards positive y.
        vertices[76] = new Vector3(0f, -0.05968748f, -0.225f);
        uvs[76] = new Vector2(vertices[76].x, vertices[76].z);
        vertices[77] = new Vector3(0f, -0.3364375f, 0.9555f);
        uvs[77] = new Vector2(vertices[77].x, vertices[77].z);
        vertices[78] = new Vector3(0.00925f, -0.05968748f, -0.225f);
        uvs[78] = new Vector2(vertices[78].x, vertices[78].z);
        vertices[79] = new Vector3(0.00925f, -0.3364375f, 0.9555f);
        uvs[79] = new Vector2(vertices[79].x, vertices[79].z);

// Start of curved part : negative x side:
        vertices[80] = new Vector3(0f, -0.34425f, 0.9555f);
        uvs[80] = new Vector2(vertices[80].y, vertices[80].z);
        vertices[81] = new Vector3(0f, -0.3364375f, 0.9555f);
        uvs[81] = new Vector2(vertices[81].y, vertices[81].z);
        vertices[82] = new Vector3(0f, -0.35175f, 0.9705f);
        uvs[82] = new Vector2(vertices[82].y, vertices[82].z);
        vertices[83] = new Vector3(0f, -0.3464375f, 0.9755f);
        uvs[83] = new Vector2(vertices[83].y, vertices[83].z);



        vertices[84] = new Vector3(0f, -0.36075f, 0.9805f);
        uvs[84] = new Vector2(vertices[84].y, vertices[84].z);
        vertices[85] = new Vector3(0f, -0.3559375f, 0.9855f);
        uvs[85] = new Vector2(vertices[85].y, vertices[85].z);
        vertices[86] = new Vector3(0f, -0.36875f, 0.9835f);
        uvs[86] = new Vector2(vertices[86].y, vertices[86].z);
        vertices[87] = new Vector3(0f, -0.3684375f, 0.9905f);
        uvs[87] = new Vector2(vertices[87].y, vertices[87].z);



        vertices[88] = new Vector3(0f, -0.37575f, 0.9817f);
        uvs[88] = new Vector2(vertices[88].y, vertices[88].z);
        vertices[89] = new Vector3(0f, -0.3774375f, 0.9885f);
        uvs[89] = new Vector2(vertices[89].y, vertices[89].z);
        vertices[90] = new Vector3(0f, -0.37675f, 0.9797f);
        uvs[90] = new Vector2(vertices[90].y, vertices[90].z);
        vertices[91] = new Vector3(0f, -0.3844375f, 0.9815f);
        uvs[91] = new Vector2(vertices[91].y, vertices[91].z);



        vertices[92] = new Vector3(0f, -0.37775f, 0.9747f);
        uvs[92] = new Vector2(vertices[92].y, vertices[92].z);
        vertices[93] = new Vector3(0f, -0.3854375f, 0.9715f);
        uvs[93] = new Vector2(vertices[93].y, vertices[93].z);
        vertices[94] = new Vector3(0f, -0.37575f, 0.9647f);
        uvs[94] = new Vector2(vertices[94].y, vertices[94].z);
        vertices[95] = new Vector3(0f, -0.3834375f, 0.9615f);
        uvs[95] = new Vector2(vertices[95].y, vertices[95].z);

        // Start of positive x-side of curved part.
        vertices[96] = new Vector3(0.00925f, -0.34425f, 0.9555f);
        uvs[96] = new Vector2(vertices[96].y, vertices[96].z);
        vertices[97] = new Vector3(0.00925f, -0.3364375f, 0.9555f);
        uvs[97] = new Vector2(vertices[97].y, vertices[97].z);
        vertices[98] = new Vector3(0.00925f, -0.35175f, 0.9705f);
        uvs[98] = new Vector2(vertices[98].y, vertices[98].z);
        vertices[99] = new Vector3(0.00925f, -0.3464375f, 0.9755f);
        uvs[99] = new Vector2(vertices[99].y, vertices[99].z);


        
        vertices[100] = new Vector3(0.00925f, -0.36075f, 0.9805f);
        uvs[100] = new Vector2(vertices[100].y, vertices[100].z);
        vertices[101] = new Vector3(0.00925f, -0.3559375f, 0.9855f);
        uvs[101] = new Vector2(vertices[101].y, vertices[101].z);
        vertices[102] = new Vector3(0.00925f, -0.36875f, 0.9835f);
        uvs[102] = new Vector2(vertices[102].y, vertices[102].z);
        vertices[103] = new Vector3(0.00925f, -0.3684375f, 0.9905f);
        uvs[103] = new Vector2(vertices[103].y, vertices[103].z);



        vertices[104] = new Vector3(0.00925f, -0.37575f, 0.9817f);
        uvs[104] = new Vector2(vertices[104].y, vertices[104].z);
        vertices[105] = new Vector3(0.00925f, -0.3774375f, 0.9885f);
        uvs[105] = new Vector2(vertices[105].y, vertices[105].z);
        vertices[106] = new Vector3(0.00925f, -0.37675f, 0.9797f);
        uvs[106] = new Vector2(vertices[106].y, vertices[106].z);
        vertices[107] = new Vector3(0.00925f, -0.3844375f, 0.9815f);
        uvs[107] = new Vector2(vertices[107].y, vertices[107].z);



        vertices[108] = new Vector3(0.00925f, -0.37775f, 0.9747f);
        uvs[108] = new Vector2(vertices[108].y, vertices[108].z);
        vertices[109] = new Vector3(0.00925f, -0.3854375f, 0.9715f);
        uvs[109] = new Vector2(vertices[109].y, vertices[109].z);
        vertices[110] = new Vector3(0.00925f, -0.37575f, 0.9647f);
        uvs[110] = new Vector2(vertices[110].y, vertices[110].z);
        vertices[111] = new Vector3(0.00925f, -0.3834375f, 0.9615f);
        uvs[111] = new Vector2(vertices[111].y, vertices[111].z);

        // Start of the innner curved part
        vertices[112] = new Vector3(0f, -0.34425f, 0.9555f);
        uvs[112] = new Vector2(vertices[112].x, vertices[112].z);
        vertices[113] = new Vector3(0.00925f, -0.34425f, 0.9555f);
        uvs[113] = new Vector2(vertices[113].x, vertices[113].z);
        vertices[114] = new Vector3(0f, -0.35175f, 0.9705f);
        uvs[114] = new Vector2(vertices[114].x, vertices[114].z);
        vertices[115] = new Vector3(0.00925f, -0.35175f, 0.9705f);
        uvs[115] = new Vector2(vertices[115].x, vertices[115].z);

        // Could be x,y
        vertices[116] = new Vector3(0f, -0.36075f, 0.9805f);
        uvs[116] = new Vector2(vertices[116].x, vertices[116].y);
        vertices[117] = new Vector3(0.00925f, -0.36075f, 0.9805f);
        uvs[117] = new Vector2(vertices[117].x, vertices[117].y);
        vertices[118] = new Vector3(0f, -0.36875f, 0.9835f);
        uvs[118] = new Vector2(vertices[118].x, vertices[118].y);
        vertices[119] = new Vector3(0.00925f, -0.36875f, 0.9835f);
        uvs[119] = new Vector2(vertices[119].x, vertices[119].y);

        //could be x,y
        vertices[120] = new Vector3(0f, -0.37575f, 0.9817f);
        uvs[120] = new Vector2(vertices[120].x, vertices[120].y);
        vertices[121] = new Vector3(0.00925f, -0.37575f, 0.9817f);
        uvs[121] = new Vector2(vertices[121].x, vertices[121].y);
        vertices[122] = new Vector3(0f, -0.37675f, 0.9797f);
        uvs[122] = new Vector2(vertices[122].x, vertices[122].y);
        vertices[123] = new Vector3(0.00925f, -0.37675f, 0.9797f);
        uvs[123] = new Vector2(vertices[123].x, vertices[123].y);



        vertices[124] = new Vector3(0f, -0.37775f, 0.9747f);
        uvs[124] = new Vector2(vertices[124].x, vertices[124].z);
        vertices[125] = new Vector3(0.00925f, -0.37775f, 0.9747f);
        uvs[125] = new Vector2(vertices[125].x, vertices[125].z);
        vertices[126] = new Vector3(0f, -0.37575f, 0.9647f); // save this vert
        uvs[126] = new Vector2(vertices[126].x, vertices[126].z);
        vertices[127] = new Vector3(0.00925f, -0.37575f, 0.9647f); // Save this vert
        uvs[127] = new Vector2(vertices[127].x, vertices[127].z);

        // Start of the outter Curved part        
        vertices[128] = new Vector3(0f, -0.3364375f, 0.9555f);
        uvs[128] = new Vector2(vertices[128].x, vertices[128].z);
        vertices[129] = new Vector3(0.00925f, -0.3364375f, 0.9555f);
        uvs[129] = new Vector2(vertices[129].x, vertices[129].z);
        vertices[130] = new Vector3(0f, -0.3464375f, 0.9755f);
        uvs[130] = new Vector2(vertices[130].x, vertices[130].z);
        vertices[131] = new Vector3(0.00925f, -0.3464375f, 0.9755f);
        uvs[131] = new Vector2(vertices[131].x, vertices[131].z);

        
        vertices[132] = new Vector3(0f, -0.3559375f, 0.9855f);
        uvs[132] = new Vector2(vertices[132].x, vertices[132].y);
        vertices[133] = new Vector3(0.00925f, -0.3559375f, 0.9855f);
        uvs[133] = new Vector2(vertices[133].x, vertices[133].y);
        vertices[134] = new Vector3(0f, -0.3684375f, 0.9905f);
        uvs[134] = new Vector2(vertices[134].x, vertices[134].y);
        vertices[135] = new Vector3(0.00925f, -0.3684375f, 0.9905f);
        uvs[135] = new Vector2(vertices[135].x, vertices[135].y);


        vertices[136] = new Vector3(0f, -0.3774375f, 0.9885f);
        uvs[136] = new Vector2(vertices[136].x, vertices[136].y);
        vertices[137] = new Vector3(0.00925f, -0.3774375f, 0.9885f);
        uvs[137] = new Vector2(vertices[137].x, vertices[137].y);
        vertices[138] = new Vector3(0f, -0.3844375f, 0.9815f);
        uvs[138] = new Vector2(vertices[138].x, vertices[138].y);
        vertices[139] = new Vector3(0.00925f, -0.3844375f, 0.9815f);
        uvs[139] = new Vector2(vertices[139].x, vertices[139].y);


        vertices[140] = new Vector3(0f, -0.3854375f, 0.9715f);
        uvs[140] = new Vector2(vertices[140].x, vertices[140].z);
        vertices[141] = new Vector3(0.00925f, -0.3854375f, 0.9715f);
        uvs[141] = new Vector2(vertices[141].x, vertices[141].z);
        vertices[142] = new Vector3(0f, -0.3834375f, 0.9615f); // Save This Vert
        uvs[142] = new Vector2(vertices[142].x, vertices[142].z);
        vertices[143] = new Vector3(0.00925f, -0.3834375f, 0.9615f); // Save This Vert
        uvs[143] = new Vector2(vertices[143].x, vertices[143].z);



        vertices[144] = new Vector3(0f, -0.37575f, 0.9647f); // save this vert
        uvs[144] = new Vector2(vertices[144].x, vertices[144].y);
        vertices[145] = new Vector3(0.00925f, -0.37575f, 0.9647f); // Save this vert
        uvs[145] = new Vector2(vertices[145].x, vertices[145].y);
        vertices[146] = new Vector3(0f, -0.3834375f, 0.9615f); // Save This Vert
        uvs[146] = new Vector2(vertices[146].x, vertices[146].y);
        vertices[147] = new Vector3(0.00925f, -0.3834375f, 0.9615f); // Save This Vert
        uvs[147] = new Vector2(vertices[147].x, vertices[147].y);





        // Front Curvy part :
        vertices[148] = new Vector3(0f, -0.06749998f, -0.225f);
        vertices[149] = new Vector3(0f, -0.05968748f, -0.225f);
        vertices[150] = new Vector3(0f, -0.06749998f, -0.225f-0.03f);
        vertices[151] = new Vector3(0f, -0.05968748f, -0.225f - 0.03f);


        vertices[152] = new Vector3(0f, -0.06749998f, -0.225f - 0.03f);
        vertices[153] = new Vector3(0f, -0.05968748f, -0.225f - 0.03f);
        vertices[154] = new Vector3(0f, -0.06749998f - 0.008f , -0.225f - 0.045f);
        vertices[155] = new Vector3(0f, -0.05968748f - 0.01f, -0.225f - 0.05f);


        vertices[156] = new Vector3(0f, -0.07549998f, -0.27f);
        vertices[157] = new Vector3(0f, -0.06968748f, -0.275f);
        vertices[158] = new Vector3(0f, -0.08449998f + 0.003f, -0.274f);
        vertices[159] = new Vector3(0f, -0.08218748f, -0.282f);

        vertices[160] = new Vector3(0f, -0.08449998f + 0.003f, -0.274f);
        vertices[161] = new Vector3(0f, -0.08218748f, -0.282f);
        vertices[162] = new Vector3(0f, -0.09349998f, -0.271f);
        vertices[163] = new Vector3(0f, -0.09518748f - 0.002f, -0.278f + 0.001f);

        vertices[164] = new Vector3(0f, -0.09349998f, -0.271f);
        vertices[165] = new Vector3(0f, -0.09518748f - 0.002f, -0.278f + 0.001f);
        vertices[166] = new Vector3(0f, -0.09549998f, -0.263f);
        vertices[167] = new Vector3(0f, -0.10218748f, -0.263f);

        vertices[168] = new Vector3(0f, -0.09549998f, -0.263f);
        vertices[169] = new Vector3(0f, -0.10218748f, -0.263f);
        vertices[170] = new Vector3(0f, -0.09549998f + 0.005f, -0.263f + 0.01f);
        vertices[171] = new Vector3(0f, -0.10218748f + 0.005f, -0.263f + 0.013f);



        /*
                vertices[152] = new Vector3(0.00925f, -0.06749998f, -0.225f);
                vertices[153] = new Vector3(0.00925f, -0.05968748f, -0.225f);
                vertices[154] = new Vector3(0.00925f, -0.06749998f, -0.225f - 0.03f);
                vertices[155] = new Vector3(0.00925f, -0.05968748f, -0.225f - 0.03f);
        */





        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;
        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;
        triangles[6] = 4;
        triangles[7] = 5;
        triangles[8] = 6;
        triangles[9] = 5;
        triangles[10] = 7;
        triangles[11] = 6;
        triangles[12] = 8;
        triangles[13] = 9;
        triangles[14] = 10;
        triangles[15] = 9;
        triangles[16] = 11;
        triangles[17] = 10;
        triangles[18] = 12;
        triangles[19] = 14;
        triangles[20] = 13;
        triangles[21] = 13;
        triangles[22] = 14;
        triangles[23] = 15;
        triangles[24] = 16;
        triangles[25] = 18;
        triangles[26] = 17;
        triangles[27] = 17;
        triangles[28] = 18;
        triangles[29] = 19;
        triangles[30] = 20;
        triangles[31] = 21;
        triangles[32] = 22;
        triangles[33] = 21;
        triangles[34] = 23;
        triangles[35] = 22;
        triangles[36] = 24;
        triangles[37] = 25;
        triangles[38] = 26;
        triangles[39] = 25;
        triangles[40] = 27;
        triangles[41] = 26;
        triangles[42] = 28;
        triangles[43] = 30;
        triangles[44] = 29;
        triangles[45] = 29;
        triangles[46] = 30;
        triangles[47] = 31;
        triangles[48] = 32;
        triangles[49] = 34;
        triangles[50] = 33;
        triangles[51] = 33;
        triangles[52] = 34;
        triangles[53] = 35;
        triangles[54] = 36;
        triangles[55] = 37;
        triangles[56] = 38;
        triangles[57] = 37;
        triangles[58] = 39;
        triangles[59] = 38;
        triangles[60] = 40;
        triangles[61] = 41;
        triangles[62] = 42;
        triangles[63] = 41;
        triangles[64] = 43;
        triangles[65] = 42;
        triangles[66] = 44;
        triangles[67] = 46;
        triangles[68] = 45;
        triangles[69] = 45;
        triangles[70] = 46;
        triangles[71] = 47;
        triangles[72] = 48;
        triangles[73] = 50;
        triangles[74] = 49;
        triangles[75] = 49;
        triangles[76] = 50;
        triangles[77] = 51;
        triangles[78] = 52;
        triangles[79] = 53;
        triangles[80] = 54;
        triangles[81] = 53;
        triangles[82] = 55;
        triangles[83] = 54;
        triangles[84] = 56;
        triangles[85] = 57;
        triangles[86] = 58;
        triangles[87] = 57;
        triangles[88] = 59;
        triangles[89] = 58;
        triangles[90] = 60;
        triangles[91] = 62;
        triangles[92] = 61;
        triangles[93] = 61;
        triangles[94] = 62;
        triangles[95] = 63;
        triangles[96] = 64;
        triangles[97] = 65;
        triangles[98] = 67;
        triangles[99] = 64;
        triangles[100] = 67;
        triangles[101] = 66;
        triangles[102] = 69;
        triangles[103] = 68;
        triangles[104] = 71;
        triangles[105] = 68;
        triangles[106] = 70;
        triangles[107] = 71;
        triangles[108] = 73;
        triangles[109] = 72;
        triangles[110] = 75;
        triangles[111] = 72;
        triangles[112] = 74;
        triangles[113] = 75;
        triangles[114] = 76;
        triangles[115] = 77;
        triangles[116] = 79;
        triangles[117] = 76;
        triangles[118] = 79;
        triangles[119] = 78;
        triangles[120] = 80;
        triangles[121] = 82;
        triangles[122] = 81;
        triangles[123] = 81;
        triangles[124] = 82;
        triangles[125] = 83;
        triangles[126] = 82;
        triangles[127] = 84;
        triangles[128] = 83;
        triangles[129] = 83;
        triangles[130] = 84;
        triangles[131] = 85;
        triangles[132] = 84;
        triangles[133] = 86;
        triangles[134] = 85;
        triangles[135] = 85;
        triangles[136] = 86;
        triangles[137] = 87;
        triangles[138] = 86;
        triangles[139] = 88;
        triangles[140] = 87;
        triangles[141] = 87;
        triangles[142] = 88;
        triangles[143] = 89;
        triangles[144] = 88;
        triangles[145] = 90;
        triangles[146] = 89;
        triangles[147] = 89;
        triangles[148] = 90;
        triangles[149] = 91;
        triangles[150] = 90;
        triangles[151] = 92;
        triangles[152] = 91;
        triangles[153] = 91;
        triangles[154] = 92;
        triangles[155] = 93;
        triangles[156] = 92;
        triangles[157] = 94;
        triangles[158] = 93;
        triangles[159] = 93;
        triangles[160] = 94;
        triangles[161] = 95;
        triangles[162] = 96;
        triangles[163] = 97;
        triangles[164] = 98;
        triangles[165] = 97;
        triangles[166] = 99;
        triangles[167] = 98;
        triangles[168] = 98;
        triangles[169] = 99;
        triangles[170] = 100;
        triangles[171] = 99;
        triangles[172] = 101;
        triangles[173] = 100;
        triangles[174] = 100;
        triangles[175] = 101;
        triangles[176] = 102;
        triangles[177] = 101;
        triangles[178] = 103;
        triangles[179] = 102;
        triangles[180] = 102;
        triangles[181] = 103;
        triangles[182] = 104;
        triangles[183] = 104;
        triangles[184] = 103;
        triangles[185] = 105;
        triangles[186] = 105;
        triangles[187] = 106;
        triangles[188] = 104;
        triangles[189] = 105;
        triangles[190] = 107;
        triangles[191] = 106;
        triangles[192] = 106;
        triangles[193] = 107;
        triangles[194] = 108;
        triangles[195] = 107;
        triangles[196] = 109;
        triangles[197] = 108;
        triangles[198] = 108;
        triangles[199] = 109;
        triangles[200] = 110;
        triangles[201] = 109;
        triangles[202] = 111;
        triangles[203] = 110;
        triangles[204] = 112;
        triangles[205] = 113;
        triangles[206] = 114;
        triangles[207] = 113;
        triangles[208] = 115;
        triangles[209] = 114;
        triangles[210] = 114;
        triangles[211] = 115;
        triangles[212] = 116;
        triangles[213] = 115;
        triangles[214] = 117;
        triangles[215] = 116;
        triangles[216] = 116;
        triangles[217] = 117;
        triangles[218] = 118;
        triangles[219] = 117;
        triangles[220] = 119;
        triangles[221] = 118;
        triangles[222] = 118;
        triangles[223] = 119;
        triangles[224] = 120;
        triangles[225] = 119;
        triangles[226] = 121;
        triangles[227] = 120;
        triangles[228] = 120;
        triangles[229] = 121;
        triangles[230] = 122;
        triangles[231] = 121;
        triangles[232] = 123;
        triangles[233] = 122;
        triangles[234] = 122;
        triangles[235] = 123;
        triangles[236] = 124;
        triangles[237] = 123;
        triangles[238] = 125;
        triangles[239] = 124;
        triangles[240] = 124;
        triangles[241] = 125;
        triangles[242] = 126;
        triangles[243] = 125;
        triangles[244] = 127;
        triangles[245] = 126;
        triangles[246] = 129;
        triangles[247] = 128;
        triangles[248] = 130;
        triangles[249] = 129;
        triangles[250] = 130;
        triangles[251] = 131;
        triangles[252] = 130;
        triangles[253] = 132;
        triangles[254] = 131;
        triangles[255] = 131;
        triangles[256] = 132;
        triangles[257] = 133;
        triangles[258] = 132;
        triangles[259] = 134;
        triangles[260] = 133;
        triangles[261] = 133;
        triangles[262] = 134;
        triangles[263] = 135;
        triangles[264] = 135;
        triangles[265] = 134;
        triangles[266] = 136;
        triangles[267] = 135;
        triangles[268] = 136;
        triangles[269] = 137;
        triangles[270] = 136;
        triangles[271] = 138;
        triangles[272] = 137;
        triangles[273] = 137;
        triangles[274] = 138;
        triangles[275] = 139;
        triangles[276] = 138;
        triangles[277] = 140;
        triangles[278] = 139;
        triangles[279] = 139;
        triangles[280] = 140;
        triangles[281] = 141;
        triangles[282] = 140;
        triangles[283] = 142;
        triangles[284] = 141;
        triangles[285] = 142;
        triangles[286] = 143;
        triangles[287] = 141;

        triangles[288] = 144;
        triangles[289] = 145;
        triangles[290] = 146;
        triangles[291] = 146;
        triangles[292] = 145;
        triangles[293] = 147;


        triangles[294] = 148;
        triangles[295] = 149;
        triangles[296] = 150;
        triangles[297] = 150;
        triangles[298] = 149;
        triangles[299] = 151;

        triangles[300] = 152;
        triangles[301] = 153;
        triangles[302] = 154;
        triangles[303] = 154;
        triangles[304] = 153;
        triangles[305] = 155;

        triangles[306] = 156;
        triangles[307] = 157;
        triangles[308] = 158;
        triangles[309] = 158;
        triangles[310] = 157;
        triangles[311] = 159;

        triangles[312] = 160;
        triangles[313] = 161;
        triangles[314] = 162;
        triangles[315] = 162;
        triangles[316] = 161;
        triangles[317] = 163;

        triangles[318] = 164;
        triangles[319] = 165;
        triangles[320] = 166;
        triangles[321] = 166;
        triangles[322] = 165;
        triangles[323] = 167;

        triangles[324] = 168;
        triangles[325] = 169;
        triangles[326] = 170;
        triangles[327] = 170;
        triangles[328] = 169;
        triangles[329] = 171;


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



/*
Length
Out[8]: 0.8361311504699118

dz
Out[9]: 0.0625

c1
Out[10]: 1.25

*/