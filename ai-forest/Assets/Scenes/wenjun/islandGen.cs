using UnityEngine;

public class FloatingIslandGenerator : MonoBehaviour
{
    public float islandRadius = 50f; // The radius of the island
    public int resolution = 256; // How many vertices for the circle
    public float islandHeight = 5f; // The height of the island from top to bottom
    public float noiseScale = 0.3f; // The scale factor for the noise

    void Start()
    {
        Mesh islandMesh = CreateIslandMesh(islandRadius, resolution, islandHeight);
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            meshFilter = gameObject.AddComponent<MeshFilter>();
        }

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
            Material islandMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            meshRenderer.sharedMaterial = islandMaterial;
        }
        meshFilter.mesh = islandMesh;

        // Set the position of the GameObject to (0,0,0)
        transform.position = Vector3.zero;
    }

    Mesh CreateIslandMesh(float radius, int resolution, float height)
    {
        Mesh mesh = new Mesh();

        // Vertices
        Vector3[] vertices = new Vector3[(resolution + 1) * 2 + 2]; // +2 for the center vertices
        int[] triangles = new int[resolution * 12]; // 6 vertices per quad, 2 quads per sector

        // Create top circle vertices with noise
        float angleStep = 360.0f / resolution;
        for (int i = 0; i < resolution; i++)
        {
            float angleInRad = Mathf.Deg2Rad * angleStep * i;
            float x = radius * Mathf.Cos(angleInRad);
            float z = radius * Mathf.Sin(angleInRad);

            // Apply noise to y coordinate to simulate terrain
            float y = Mathf.PerlinNoise(x * noiseScale, z * noiseScale) * height;
            vertices[i] = new Vector3(x, y, z);
        }
        vertices[resolution] = Vector3.zero; // Center vertex for top

        // Create bottom circle vertices
        for (int i = 0; i < resolution; i++)
        {
            vertices[i + resolution + 1] = vertices[i] - Vector3.up * height;
        }
        vertices[vertices.Length - 2] = Vector3.down * height; // Center vertex for bottom

        // Triangles for the top circle
        for (int i = 0; i < resolution; i++)
        {
            int nextIndex = (i + 1) % resolution;
            int currentTriangleIndex = i * 3;
            triangles[currentTriangleIndex] = i;
            triangles[currentTriangleIndex + 1] = resolution;
            triangles[currentTriangleIndex + 2] = nextIndex;
        }

        // Triangles for the bottom circle
        for (int i = 0; i < resolution; i++)
        {
            int nextIndex = (i + 1) % resolution;
            int currentTriangleIndex = (resolution + i) * 3;
            triangles[currentTriangleIndex] = i + resolution + 1;
            triangles[currentTriangleIndex + 1] = vertices.Length - 2;
            triangles[currentTriangleIndex + 2] = nextIndex + resolution + 1;
        }

        // Side triangles
        for (int i = 0; i < resolution; i++)
        {
            int nextIndex = (i + 1) % resolution;
            int currentTriangleIndex = (resolution * 2 + i) * 6;

            triangles[currentTriangleIndex] = i;
            triangles[currentTriangleIndex + 1] = nextIndex;
            triangles[currentTriangleIndex + 2] = i + resolution + 1;

            triangles[currentTriangleIndex + 3] = nextIndex;
            triangles[currentTriangleIndex + 4] = nextIndex + resolution + 1;
            triangles[currentTriangleIndex + 5] = i + resolution + 1;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals(); // To make sure the lighting gets updated

        return mesh;
    }
}
