using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoldCloth : MonoBehaviour
{
    public float width = 100;
    public float height = 100;

    public float thick = 3;

    public float hw
    {
        get { return width * 0.5f; }
    }

    public float qw
    {
        get { return width * 0.25f; }
    }

    public float hh
    {
        get { return height * 0.5f; }
    }

    public float h_3_1
    {
        get { return height * 0.3333f; }
    }

    public float h_3_2
    {
        get { return height * 0.66666f; }
    }


    public float ax;
    public float bx;
    public float cx;
    public float dx;
    public float ex;
    public float fx;
    public float gx;
    public float hx;


    private float a0, a1, a2, a3, a4, a5, a6, a7;
    private float b0, b1, b2, b3, b4, b5, b6, b7;
    private float c0, c1, c2, c3, c4, c5, c6, c7;
    private float d0, d1, d2, d3, d4, d5, d6, d7;
    private float e0, e1, e2, e3, e4, e5, e6, e7;
    private float f0, f1, f2, f3, f4, f5, f6, f7;
    private float g0, g1, g2, g3, g4, g5, g6, g7;
    private float h0, h1, h2, h3, h4, h5, h6, h7;

    private float az0, az1, az2, az3, az4, az5, az6, az7;
    private float bz0, bz1, bz2, bz3, bz4, bz5, bz6, bz7;
    private float cz0, cz1, cz2, cz3, cz4, cz5, cz6, cz7;
    private float dz0, dz1, dz2, dz3, dz4, dz5, dz6, dz7;
    private float ez0, ez1, ez2, ez3, ez4, ez5, ez6, ez7;
    private float fz0, fz1, fz2, fz3, fz4, fz5, fz6, fz7;
    private float gz0, gz1, gz2, gz3, gz4, gz5, gz6, gz7;
    private float hz0, hz1, hz2, hz3, hz4, hz5, hz6, hz7;

    private Vector2[] uv;

    public Mesh CreatePhase1()
    {
        var mesh = new Mesh() {name = "cloth phase 1"};
        var t1 = qw + thick;
        var t2 = qw - thick;
        ax = -hw;
        bx = -t1;
        gx = t1;
        cx = -qw;
        fx = qw;
        dx = -t2;
        ex = t2;
        hx = hw;

        a0 = b0 = c0 = d0 = e0 = f0 = g0 = h0 = 0;
        a1 = b1 = c1 = d1 = e1 = f1 = g1 = h1 = h_3_1;
        a2 = b2 = c2 = d2 = e2 = f2 = g2 = h2 = h_3_1 - thick;
        a3 = b3 = c3 = d3 = e3 = f3 = g3 = h3 = h_3_1;
        a4 = b4 = c4 = d4 = e4 = f4 = g4 = h4 = h_3_2;
        a5 = b5 = c5 = d5 = e5 = f5 = g5 = h5 = h_3_2 + thick * 0.707f;
        a6 = b6 = c6 = d6 = e6 = f6 = g6 = h6 = h_3_2;
        a7 = b7 = c7 = d7 = e7 = f7 = g7 = h7 = height;

        az0 = bz0 = cz0 = dz0 = ez0 = fz0 = gz0 = hz0 = 0;
        az1 = bz1 = cz1 = dz1 = ez1 = fz1 = gz1 = hz1 = 0;
        az2 = bz2 = cz2 = dz2 = ez2 = fz2 = gz2 = hz2 = 0;
        az3 = bz3 = cz3 = dz3 = ez3 = fz3 = gz3 = hz3 = 0;
        az4 = bz4 = cz4 = dz4 = ez4 = fz4 = gz4 = hz4 = 0;
        az5 = bz5 = cz5 = dz5 = ez5 = fz5 = gz5 = hz5 = 0;
        az6 = bz6 = cz6 = dz6 = ez6 = fz6 = gz6 = hz6 = 0;
        az7 = bz7 = cz7 = dz7 = ez7 = fz7 = gz7 = hz7 = 0;


        var vertices = CreateVertices();

        var triangles = CreateTriangles();
        uv = CreateUVs().ToArray();
        mesh.vertices = vertices.ToArray();
        mesh.uv = uv;
        mesh.triangles = triangles.ToArray();

        return mesh;
    }

    public Mesh CreatePhase2()
    {
        var mesh = new Mesh() {name = "cloth phase 2"};
        var t1 = qw + thick;
        var t2 = qw - thick;
        ax = hx = 0;
        bx = -qw;
        gx = qw;
        cx = -qw - thick * 0.707f;
        fx = qw + thick * 0.707f;
        dx = -qw;
        ex = qw;

        a0 = b0 = c0 = d0 = e0 = f0 = g0 = h0 = 0;                          
        a1 = b1 = c1 = d1 = e1 = f1 = g1 = h1 = h_3_1;                      
        a2 = b2 = c2 = d2 = e2 = f2 = g2 = h2 = h_3_1 - thick;              
        a3 = b3 = c3 = d3 = e3 = f3 = g3 = h3 = h_3_1;                      
        a4 = b4 = c4 = d4 = e4 = f4 = g4 = h4 = h_3_2;                      
        a5 = b5 = c5 = d5 = e5 = f5 = g5 = h5 = h_3_2 + thick * 0.707f;     
        a6 = b6 = c6 = d6 = e6 = f6 = g6 = h6 = h_3_2;                      
        a7 = b7 = c7 = d7 = e7 = f7 = g7 = h7 = height;                     
        
        
        
        
        
        
        

        gz0 = gz1 = gz3 = gz4 = gz5 = gz6 = gz7 = bz0 = bz1 = bz3 = bz4 = bz5 = bz6 = bz7 =
            hz0 = hz1 = hz3 = hz4 = hz5 = hz6 = hz7 = az0 = az1 = az3 = az4 = az5 = az6 = az7 = 1.414f * thick;
        fz0 = fz1 = fz3 = fz4 = fz5 = fz6 = fz7 = cz0 = cz1 = cz3 = cz4 = cz5 = cz6 = cz7 = 0.707f * thick;
        var vertices = CreateVertices();

        var triangles = CreateTriangles();

        mesh.vertices = vertices.ToArray();
        mesh.uv = uv;
        mesh.triangles = triangles.ToArray();

        return mesh;
    }

    public Mesh CreatePhase3()
    {
        var mesh = new Mesh() {name = "cloth phase 3"};
        var t1 = qw + thick;
        var t2 = qw - thick;
        ax = hx = 0;
        bx = -qw;
        gx = qw;
        cx = -qw - thick * 0.707f;
        fx = qw + thick * 0.707f;
        dx = -qw;
        ex = qw;

        a0 = b0 = c0 = d0 = e0 = f0 = g0 = h0 = h_3_2;
        a1 = b1 = c1 = d1 = e1 = f1 = g1 = h1 = h_3_1;
        a2 = b2 = c2 = d2 = e2 = f2 = g2 = h2 = h_3_1 - thick;
        a3 = b3 = c3 = d3 = e3 = f3 = g3 = h3 = h_3_1;
        a4 = b4 = c4 = d4 = e4 = f4 = g4 = h4 = h_3_2;
        a5 = b5 = c5 = d5 = e5 = f5 = g5 = h5 = h_3_2 + thick * 0.707f;
        a6 = b6 = c6 = d6 = e6 = f6 = g6 = h6 = h_3_2;
        a7 = b7 = c7 = d7 = e7 = f7 = g7 = h7 = h_3_1;

        az0 = bz0 = gz0 = hz0 =1.8f * thick;
        az1 = bz1 = gz1 = hz1 =1.8f * thick;
        az2 = bz2 = gz2 = hz2 =1 * thick;
        az3 = bz3 = gz3 = hz3 =0.5f * thick;
        az4 = bz4 = gz4 = hz4 =0.5f * thick;
        az5 = bz5 = gz5 = hz5 =0.6f * thick;
        az6 = bz6 = gz6 = hz6 =0.8f * thick;
        az7 = bz7 = gz7 = hz7 =0.8f * thick;
        cz0 = dz0 = ez0 = fz0 =  2 * thick;
        cz1 = dz1 = ez1 = fz1 =  2 * thick;
        cz2 = dz2 = ez2 = fz2 =  1 * thick;
        cz3 = dz3 = ez3 = fz3 =  0 * thick;
        cz4 = dz4 = ez4 = fz4 =  0 * thick;
        cz5 = dz5 = ez5 = fz5 =  0.5f * thick;
        cz6 = dz6 = ez6 = fz6 =  1 * thick;
        cz7 = dz7 = ez7 = fz7 =  1 * thick;


        var vertices = CreateVertices();

        var triangles = CreateTriangles();

        mesh.vertices = vertices.ToArray();
        mesh.uv = uv;
        mesh.triangles = triangles.ToArray();

        return mesh;
    }

    private List<int> CreateTriangles()
    {
        var triangles = new List<int>();

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                var o = i * 8 + j;
                var p = i * 8 + j + 1;
                var q = (i + 1) * 8 + j + 1;
                var r = (i + 1) * 8 + j;
                Add(triangles, o, p, q);
                Add(triangles, o, q, r);
            }
        }

        return triangles;
    }

    private List<Vector3> CreateVertices()
    {
        var vertices = new List<Vector3>()
        {
            V(ax, a0, az0), V(ax, a1, az1), V(ax, a2, az2), V(ax, a3, az3), V(ax, a4, az4), V(ax, a5, az5),
            V(ax, a6, az6), V(ax, a7, az7),

            V(bx, b0, bz0), V(bx, b1, bz1), V(bx, b2, bz2), V(bx, b3, bz3), V(bx, b4, bz4), V(bx, b5, bz5),
            V(bx, b6, bz6), V(bx, b7, bz7),

            V(cx, c0, cz0), V(cx, c1, cz1), V(cx, c2, cz2), V(cx, c3, cz3), V(cx, c4, cz4), V(cx, c5, cz5),
            V(cx, c6, cz6), V(cx, c7, cz7),


            V(dx, d0, dz0), V(dx, d1, dz1), V(dx, d2, dz2), V(dx, d3, dz3), V(dx, d4, dz4), V(dx, d5, dz5),
            V(dx, d6, dz6), V(dx, d7, dz7),


            V(ex, e0, ez0), V(ex, e1, ez1), V(ex, e2, ez2), V(ex, e3, ez3), V(ex, e4, ez4), V(ex, e5, ez5),
            V(ex, e6, ez6), V(ex, e7, ez7),


            V(fx, f0, fz0), V(fx, f1, fz1), V(fx, f2, fz2), V(fx, f3, fz3), V(fx, f4, fz4), V(fx, f5, fz5),
            V(fx, f6, fz6), V(fx, f7, fz7),


            V(gx, g0, gz0), V(gx, g1, gz1), V(gx, g2, gz2), V(gx, g3, gz3), V(gx, g4, gz4), V(gx, g5, gz5),
            V(gx, g6, gz6), V(gx, g7, gz7),


            V(hx, h0, hz0), V(hx, h1, hz1), V(hx, h2, hz2), V(hx, h3, hz3), V(hx, h4, hz4), V(hx, h5, hz5),
            V(hx, h6, hz6), V(hx, h7, hz7),
        };
        return vertices;
    }

    private List<Vector2> CreateUVs()
    {
        var uvs = new List<Vector2>()
        {
            V(ax, 0, az0), V(ax, a1, az1), V(ax, a2, az2), V(ax, a3, az3), V(ax, a4, az4), V(ax, a5, az5),
            V(ax, a6, az6), V(ax, height, az7),

            V(bx, 0, bz0), V(bx, b1, bz1), V(bx, b2, bz2), V(bx, b3, bz3), V(bx, b4, bz4), V(bx, b5, bz5),
            V(bx, b6, bz6), V(bx, height, bz7),

            V(cx, 0, cz0), V(cx, c1, cz1), V(cx, c2, cz2), V(cx, c3, cz3), V(cx, c4, cz4), V(cx, c5, cz5),
            V(cx, c6, cz6), V(cx, height, cz7),


            V(dx, 0, dz0), V(dx, d1, dz1), V(dx, d2, dz2), V(dx, d3, dz3), V(dx, d4, dz4), V(dx, d5, dz5),
            V(dx, d6, dz6), V(dx, height, dz7),


            V(ex, 0, ez0), V(ex, e1, ez1), V(ex, e2, ez2), V(ex, e3, ez3), V(ex, e4, ez4), V(ex, e5, ez5),
            V(ex, e6, ez6), V(ex, height, ez7),


            V(fx, 0, fz0), V(fx, f1, fz1), V(fx, f2, fz2), V(fx, f3, fz3), V(fx, f4, fz4), V(fx, f5, fz5),
            V(fx, f6, fz6), V(fx, height, fz7),


            V(gx, 0, gz0), V(gx, g1, gz1), V(gx, g2, gz2), V(gx, g3, gz3), V(gx, g4, gz4), V(gx, g5, gz5),
            V(gx, g6, gz6), V(gx, height, gz7),


            V(hx, 0, hz0), V(hx, h1, hz1), V(hx, h2, hz2), V(hx, h3, hz3), V(hx, h4, hz4), V(hx, h5, hz5),
            V(hx, h6, hz6), V(hx, height, hz7),
        };

        for (int i = 0; i < uvs.Count; i++)
        {
            uvs[i] = Vector2.Scale(uvs[i], new Vector2(1f / width, 1f / height));
            uvs[i] += new Vector2(.5f, 0);
        }


        return uvs;
    }

    Vector3 V(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }


    void Add(List<int> triangles, int a, int b, int c)
    {
        triangles.Add(a);
        triangles.Add(b);
        triangles.Add(c);
    }
}