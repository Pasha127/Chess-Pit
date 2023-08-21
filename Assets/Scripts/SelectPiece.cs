using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectPiece : MonoBehaviour
{
    GameManager gameManager;
    public Material selectEffectMaterial;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void selectEffect()
    {
        if (this.gameObject != null && selectEffectMaterial != null)
        {
            MeshFilter originalMeshFilter = this.gameObject.GetComponent<MeshFilter>();
            Debug.Log("OGMESHFILTER", originalMeshFilter);
            if (originalMeshFilter != null)
            {
                Mesh originalMesh = originalMeshFilter.mesh;

                // Create a new mesh to hold the flipped normals
                Mesh flippedMesh = new Mesh();
                Debug.Log(flippedMesh);
                flippedMesh.vertices = originalMesh.vertices;
                flippedMesh.triangles = originalMesh.triangles;
                flippedMesh.uv = originalMesh.uv;

                // Flip the normals by inverting them
                Vector3[] flippedNormals = new Vector3[originalMesh.normals.Length];
                for (int i = 0; i < flippedNormals.Length; i++)
                {
                    flippedNormals[i] = -originalMesh.normals[i];
                }
                flippedMesh.normals = flippedNormals;

                // Attach the flipped mesh to the original GameObject
                MeshFilter flippedMeshFilter = this.gameObject.AddComponent<MeshFilter>();
                flippedMeshFilter.mesh = flippedMesh;
                // Set the new material
                MeshRenderer duplicatedRenderer = this.gameObject.AddComponent<MeshRenderer>();
                duplicatedRenderer.material = selectEffectMaterial;

            }
        }
    }
}
