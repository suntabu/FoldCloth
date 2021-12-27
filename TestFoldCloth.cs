using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TestFoldCloth : MonoBehaviour
{
    public Mesh[] meshes;
    public float speed;

    private Vector3 initialLocalPosition;

    void Start()
    {
        fc = GetComponent<FoldCloth>();
        ResetMeshes(fc);

        vertices = new Vector3[meshes[0].vertexCount];
        initialLocalPosition = transform.localPosition;
    }

    private void ResetMeshes(FoldCloth fc)
    {
        meshes = new[]
        {
            fc.CreatePhase1(),
            fc.CreatePhase2(),
            fc.CreatePhase3()
        };
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
    public Vector3 targetJump;
    public float jumpPower;
    private FoldCloth fc;


    IEnumerator DoAnimation()
    {
        t = 0;
        transform.localPosition = initialLocalPosition;
        bool isFolding = true;
        while (isFolding)
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

            if (t > 1)
            {
                isFolding = false;
            }

            mesh.vertices = vertices;
            meshFilter.mesh = mesh;
            yield return null;
        }

        yield return transform.DOLocalJump(targetJump, jumpPower, 1, .25f, true).WaitForCompletion();
        yield return new WaitForSeconds(1);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 100), "fold"))
        {
            StartCoroutine(DoAnimation());
        }
        
        if (GUI.Button(new Rect(10, 120, 100, 100), "reset"))
        {
           ResetMeshes(fc);
        }
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