using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFoldCloth : MonoBehaviour
{
    public Mesh[] meshes;
    public float speed;

    void Start()
    {
        var fc = GetComponent<FoldCloth>();
        meshes = new[]
        {
            fc.CreatePhase1(),
            fc.CreatePhase2(),
            fc.CreatePhase3()
        };

        vertices = new Vector3[meshes[0].vertexCount];
    }

    public float t;

    private MeshFilter meshFilter
    {
        get
        {
            if (!_meshFilter)
                _meshFilter = GetComponent<MeshFilter>();

            return _meshFilter;
        }
    }

    private MeshFilter _meshFilter;
    private Mesh _mesh;

    Mesh mesh
    {
        get
        {
            if (_mesh == null)
                _mesh = new Mesh()
                {
                    name = this.name,
                    vertices = meshes[0].vertices,
                    uv = meshes[0].uv,
                    triangles = meshes[0].triangles
                };
            return _mesh;
        }
    }

    private Vector3[] vertices;

    void Update()
    {
        t += Time.deltaTime * speed;

        for (int i = 0; i < mesh.vertexCount; i++)
        {
            if (t > 0.5f)
            {
                vertices[i] = Vector3.Lerp(meshes[1].vertices[i], meshes[2].vertices[i], (t - 0.5f) * 2);
            }
            else
            {
                vertices[i] = Vector3.Lerp(meshes[0].vertices[i], meshes[1].vertices[i], t * 2);
            }
        }

        if (t >= 1)
        {
            t = 0;
        }

        mesh.vertices = vertices;
        meshFilter.mesh = mesh;
    }

    [ContextMenu("Set 1")]
    void ChangeSet1()
    {
        var fc = GetComponent<FoldCloth>();

        meshFilter.mesh = fc.CreatePhase1();
    }

    [ContextMenu("Set 2")]
    void ChangeSet2()
    {
        var fc = GetComponent<FoldCloth>();

        meshFilter.mesh = fc.CreatePhase2();
    }

    [ContextMenu("Set 3")]
    void ChangeSet3()
    {
        var fc = GetComponent<FoldCloth>();

        meshFilter.mesh = fc.CreatePhase3();
    }
}