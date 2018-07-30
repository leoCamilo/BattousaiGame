using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    public float power = 2;
    public float scale = 1;
    public float timeScale = 1;
    // public float size = 1;
    // public Vector2 gridSize = new Vector2(16, 16);

    private MeshFilter filter;
    private float xOffset;
    private float yOffset;

    void Start ()
    {
        filter = GetComponent<MeshFilter>();
        // filter.mesh = GetGeneratedMesh();
	}

    private void Update()
    {
        // filter.mesh = GetGeneratedMesh();   // for test
        
        MakeWaves();
        xOffset += Time.deltaTime * timeScale;
        yOffset += Time.deltaTime * timeScale;
    }

    //private Mesh GetGeneratedMesh()
    //{
    //    var mesh = new Mesh();
    //    var triangles = new List<int>();
    //    var verticles = new List<Vector3>();
    //    var normals = new List<Vector3>();
    //    var uvs = new List<Vector2>();

    //    for (int i = 0; i <= gridSize.x; i++)
    //        for (int j = 0; j <= gridSize.y; j++)
    //        {
    //            verticles.Add(new Vector3(-0.5f + i / gridSize.x, 0, -0.5f + j / gridSize.y) * size);
    //            normals.Add(Vector3.up);
    //            uvs.Add(new Vector2(i / gridSize.x, gridSize.y));
    //        }


    //    var verCountX = (int)gridSize.x + 1;
    //    var verCountY = (int)gridSize.x + 1;

    //    for (int v = 0; v < verCountX * verCountY - verCountX; v++)
    //    {
    //        if ((v + 1) % verCountX == 0)
    //        {
    //            continue;
    //        }

    //        triangles.AddRange(new List<int>()
    //        {
    //            v + 1 + verCountX,
    //            v + verCountX,
    //            v,
    //            v,
    //            v + 1,
    //            v + 1 + verCountX
    //        });
    //    }

    //    mesh.SetVertices(verticles);
    //    mesh.SetNormals(normals);
    //    mesh.SetUVs(0, uvs);
    //    mesh.SetTriangles(triangles, 0);

    //    return mesh;
    //}

    private void MakeWaves()
    {
        var vertices = filter.mesh.vertices;

        if (vertices.Length != 0)
        {
            for (int i = vertices.Length - 1; i >= 0; i--)
                // vertices[i].z = CalcHeight(vertices[i].x, vertices[i].z) * power;
                vertices[i].z = CalcHeight(vertices[i].x, vertices[i].y) * power;

            filter.mesh.vertices = vertices;
        }
    }

    private float CalcHeight(float x, float y)
    {
        var xCoord = x * scale + xOffset;
        var zCoord = y * scale + yOffset;

        return Mathf.PerlinNoise(xCoord, zCoord);
    }
}