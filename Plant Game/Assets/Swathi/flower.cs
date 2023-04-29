using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public int numPetals = 5;
    public float petalLength = 0.5f;
    public float petalWidth = 0.2f;
    public float petalCurve = 0.5f;
    public float flowerRadius = 1.0f;
    public float stemHeight = 2.0f;
    public float stemThickness = 0.1f;
    public float noiseFrequency = 0.5f;
    public float noiseAmplitude = 0.5f;

    void Start()
    {
        GenerateFlower();
    }

    void GenerateFlower()
    {
        // Generate stem
        GameObject stem = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        stem.transform.parent = transform;
        stem.transform.localPosition = Vector3.zero;
        stem.transform.localScale = new Vector3(stemThickness, stemHeight, stemThickness);

        // Generate petals
        for (int i = 0; i < numPetals; i++)
        {
            float angle = (360 / numPetals) * i;
            float petalNoise = Mathf.PerlinNoise(i * noiseFrequency, 0) * noiseAmplitude;

            GameObject petal = new GameObject("Petal");
            petal.transform.parent = transform;
            petal.transform.localRotation = Quaternion.Euler(0, angle, 0);
            petal.transform.localPosition = Vector3.zero;

            MeshFilter meshFilter = petal.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = petal.AddComponent<MeshRenderer>();
            Mesh mesh = new Mesh();

            Vector3[] vertices = new Vector3[4];
            Vector2[] uv = new Vector2[4];
            int[] triangles = new int[6];

            vertices[0] = new Vector3(0, 0, 0);
            vertices[1] = new Vector3(petalWidth * petalNoise, 0, petalLength);
            vertices[2] = new Vector3(0, petalCurve * petalLength * petalNoise, petalLength);
            vertices[3] = new Vector3(-petalWidth * petalNoise, 0, petalLength);

            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(1, 0);
            uv[2] = new Vector2(0, 1);
            uv[3] = new Vector2(-1, 0);

            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 2;
            triangles[3] = 0;
            triangles[4] = 2;
            triangles[5] = 3;

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;

            meshFilter.mesh = mesh;
            meshRenderer.material = new Material(Shader.Find("Standard"));
        }

    }
}
