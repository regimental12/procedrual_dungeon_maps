using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class TileMap : MonoBehaviour 
{
    public int size_x = 100;
    public int size_z = 50;
    public float tileSize = 1.0f;
    

	void Start () 
    {
        buildMesh();
	}

    public void buildMesh()
    {
        int numOfTiles = size_x * size_z;
        int numTriangles = numOfTiles * 2;

        int vsize_x = size_x + 1;
        int vsize_z = size_z + 1;
        int numVerts = vsize_x * vsize_z;


        //Generate mesh data
        Vector3[] vertices = new Vector3[numVerts];
        Vector3[] normals = new Vector3[numVerts];
        Vector2[] uv = new Vector2[numVerts];

        int[] triangles = new int[numTriangles * 3];

        int x, z;
        for ( z = 0 ; z < vsize_z ; z++)
        {
             for( x = 0 ; x < vsize_x ; x++)
            {
                 vertices[z * vsize_x + x] = new Vector3(x * tileSize, 0, z * tileSize);
                 normals[z * vsize_x + x] = Vector3.up;
                 uv[z * vsize_x + x] = new Vector2((float)x / vsize_x, (float)z / vsize_z);
            }
        }
        Debug.Log("Done Verts!");

        for (z = 0; z < size_z; z++)
        {
            for (x = 0; x < size_x; x++)
            {
                int squareIndex = z * size_x + x;
                int triIndex = squareIndex * 6;
                triangles[triIndex + 0] = z * vsize_x + x +           0;
                triangles[triIndex + 1] = z * vsize_x + x + vsize_x + 0;
                triangles[triIndex + 2] = z * vsize_x + x + vsize_x + 1;

                triangles[triIndex + 3] = z * vsize_x + x +           0;
                triangles[triIndex + 4] = z * vsize_x + x + vsize_x + 1;
                triangles[triIndex + 5] = z * vsize_x + x +           1;
            }
        }

        Debug.Log("Done Triangles!");

        //Create a new mesh and populate with data
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        //Assign mesh to the filter/collider
        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
        MeshCollider mesh_collider = GetComponent<MeshCollider>();

        mesh_filter.mesh = mesh;
        Debug.Log("Done Mesh!");
    }
	
	
}
