using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoldCloth : MonoBehaviour
{
    public float width = 100;
    public float height = 100;

    public float thick = 3;
    public float upAreaHeight = 3;
    public float downAreaHeight = 3;

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


    public float ax0, ax1, ax2, ax3, ax4, ax5, ax6, ax7;
    public float bx0, bx1, bx2, bx3, bx4, bx5, bx6, bx7;
    public float cx0, cx1, cx2, cx3, cx4, cx5, cx6, cx7;
    public float dx0, dx1, dx2, dx3, dx4, dx5, dx6, dx7;
    public float ox0, ox1, ox2, ox3, ox4, ox5, ox6, ox7;
    public float ex0, ex1, ex2, ex3, ex4, ex5, ex6, ex7;
    public float fx0, fx1, fx2, fx3, fx4, fx5, fx6, fx7;
    public float gx0, gx1, gx2, gx3, gx4, gx5, gx6, gx7;
    public float hx0, hx1, hx2, hx3, hx4, hx5, hx6, hx7;


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
        ax0 = ax1 = ax2 = ax3 = ax4 = ax5 = ax6 = ax7 = -hw;
        bx0 = bx1 = bx2 = bx3 = bx4 = bx5 = bx6 = bx7 = -t1;
        cx0 = cx1 = cx2 = cx3 = cx4 = cx5 = cx6 = cx7 = -qw;
        dx0 = dx1 = dx2 = dx3 = dx4 = dx5 = dx6 = dx7 = -t2;
        ex0 = ex1 = ex2 = ex3 = ex4 = ex5 = ex6 = ex7 = t2;
        fx0 = fx1 = fx2 = fx3 = fx4 = fx5 = fx6 = fx7 = qw;
        gx0 = gx1 = gx2 = gx3 = gx4 = gx5 = gx6 = gx7 = t1;
        hx0 = hx1 = hx2 = hx3 = hx4 = hx5 = hx6 = hx7 = hw;

        a0 = b0 = c0 = d0 = e0 = f0 = g0 = h0 = -hh;
        a1 = b1 = c1 = d1 = e1 = f1 = g1 = h1 = -height / 6;
        a2 = b2 = c2 = d2 = e2 = f2 = g2 = h2 = -height / 6 - thick;
        a3 = b3 = c3 = d3 = e3 = f3 = g3 = h3 = -height / 6;
        a4 = b4 = c4 = d4 = e4 = f4 = g4 = h4 = height / 6;
        a5 = b5 = c5 = d5 = e5 = f5 = g5 = h5 = height / 6 + thick * 0.707f;
        a6 = b6 = c6 = d6 = e6 = f6 = g6 = h6 = height / 6;
        a7 = b7 = c7 = d7 = e7 = f7 = g7 = h7 = hh;

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
        ax0 = ax1 = ax2 = ax3 = ax4 = ax5 = ax6 = ax7 = 0;
        bx0 = bx1 = bx2 = bx3 = bx4 = bx5 = bx6 = bx7 = -qw;
        cx0 = cx1 = cx2 = cx3 = cx4 = cx5 = cx6 = cx7 = -qw - thick * 0.707f;
        dx0 = dx1 = dx2 = dx3 = dx4 = dx5 = dx6 = dx7 = -qw;
        ex0 = ex1 = ex2 = ex3 = ex4 = ex5 = ex6 = ex7 = qw;
        fx0 = fx1 = fx2 = fx3 = fx4 = fx5 = fx6 = fx7 = qw + thick * 0.707f;
        gx0 = gx1 = gx2 = gx3 = gx4 = gx5 = gx6 = gx7 = qw;
        hx0 = hx1 = hx2 = hx3 = hx4 = hx5 = hx6 = hx7 = 0;


        a0 = b0 = c0 = d0 = e0 = f0 = g0 = h0 = -hh;
        a1 = b1 = c1 = d1 = e1 = f1 = g1 = h1 = -height / 6;
        a2 = b2 = c2 = d2 = e2 = f2 = g2 = h2 = -height / 6 - thick;
        a3 = b3 = c3 = d3 = e3 = f3 = g3 = h3 = -height / 6;
        a4 = b4 = c4 = d4 = e4 = f4 = g4 = h4 = height / 6;
        a5 = b5 = c5 = d5 = e5 = f5 = g5 = h5 = height / 6 + thick * 0.707f;
        a6 = b6 = c6 = d6 = e6 = f6 = g6 = h6 = height / 6;
        a7 = b7 = c7 = d7 = e7 = f7 = g7 = h7 = hh;


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
        ax0 = ax1 = ax2 = ax3 = ax4 = ax5 = ax6 = ax7 = 0;
        bx0 = bx1 = bx2 = bx3 = bx4 = bx5 = bx6 = bx7 = -qw;
        cx0 = cx1 = cx2 = cx3 = cx4 = cx5 = cx6 = cx7 = -qw - thick * 0.707f;
        dx0 = dx1 = dx2 = dx3 = dx4 = dx5 = dx6 = dx7 = -qw;
        ex0 = ex1 = ex2 = ex3 = ex4 = ex5 = ex6 = ex7 = qw;
        fx0 = fx1 = fx2 = fx3 = fx4 = fx5 = fx6 = fx7 = qw + thick * 0.707f;
        gx0 = gx1 = gx2 = gx3 = gx4 = gx5 = gx6 = gx7 = qw;
        hx0 = hx1 = hx2 = hx3 = hx4 = hx5 = hx6 = hx7 = 0;

        bx0 *= r0;
        bx1 *= r1;
        bx2 *= r2;
        bx3 *= r3;
        bx4 *= r4;
        bx5 *= r5;
        bx6 *= r6;
        bx7 *= r7;

        cx0 *= r0;
        cx1 *= r1;
        cx2 *= r2;
        cx3 *= r3;
        cx4 *= r4;
        cx5 *= r5;
        cx6 *= r6;
        cx7 *= r7;

        dx0 *= r0;
        dx1 *= r1;
        dx2 *= r2;
        dx3 *= r3;
        dx4 *= r4;
        dx5 *= r5;
        dx6 *= r6;
        dx7 *= r7;

        ex0 *= r0;
        ex1 *= r1;
        ex2 *= r2;
        ex3 *= r3;
        ex4 *= r4;
        ex5 *= r5;
        ex6 *= r6;
        ex7 *= r7;

        fx0 *= r0;
        fx1 *= r1;
        fx2 *= r2;
        fx3 *= r3;
        fx4 *= r4;
        fx5 *= r5;
        fx6 *= r6;
        fx7 *= r7;

        gx0 *= r0;
        gx1 *= r1;
        gx2 *= r2;
        gx3 *= r3;
        gx4 *= r4;
        gx5 *= r5;
        gx6 *= r6;
        gx7 *= r7;


        a0 = b0 = c0 = d0 = e0 = f0 = g0 = h0 = height / 6;
        a1 = b1 = c1 = d1 = e1 = f1 = g1 = h1 = -height / 6;
        a2 = b2 = c2 = d2 = e2 = f2 = g2 = h2 = -height / 6 - downAreaHeight;
        a3 = b3 = c3 = d3 = e3 = f3 = g3 = h3 = -height / 6;
        a4 = b4 = c4 = d4 = e4 = f4 = g4 = h4 = height / 6;
        a5 = b5 = c5 = d5 = e5 = f5 = g5 = h5 = height / 6 + upAreaHeight * 0.707f;
        a6 = b6 = c6 = d6 = e6 = f6 = g6 = h6 = height / 6;
        a7 = b7 = c7 = d7 = e7 = f7 = g7 = h7 = -height / 6;

        az0 = bz0 = gz0 = hz0 = 1.8f * thick;
        az1 = bz1 = gz1 = hz1 = 1.8f * thick;
        az2 = bz2 = gz2 = hz2 = 1 * thick;
        az3 = bz3 = gz3 = hz3 = 0.5f * thick;
        az4 = bz4 = gz4 = hz4 = 0.5f * thick;
        az5 = bz5 = gz5 = hz5 = 0.6f * thick;
        az6 = bz6 = gz6 = hz6 = 0.8f * thick;
        az7 = bz7 = gz7 = hz7 = 0.8f * thick;
        cz0 = dz0 = ez0 = fz0 = 2 * thick;
        cz1 = dz1 = ez1 = fz1 = 2 * thick;
        cz2 = dz2 = ez2 = fz2 = 1 * thick;
        cz3 = dz3 = ez3 = fz3 = 0 * thick;
        cz4 = dz4 = ez4 = fz4 = 0 * thick;
        cz5 = dz5 = ez5 = fz5 = 0.5f * thick;
        cz6 = dz6 = ez6 = fz6 = 1 * thick;
        cz7 = dz7 = ez7 = fz7 = 1 * thick;


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

        for (int i = 0; i < 8; i++)
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

    public float r0, r1, r2, r3, r4, r5, r6, r7;

    private List<Vector3> CreateVertices()
    {
        var vertices = new List<Vector3>()
        {
            V(ax0, a0, az0), V(ax1, a1, az1), V(ax2, a2, az2), V(ax3, a3, az3), V(ax4, a4, az4),
            V(ax5, a5, az5),
            V(ax6, a6, az6), V(ax7, a7, az7),

            V(bx0, b0, bz0), V(bx1, b1, bz1), V(bx2, b2, bz2), V(bx3, b3, bz3), V(bx4, b4, bz4),
            V(bx5, b5, bz5),
            V(bx6, b6, bz6), V(bx7, b7, bz7),

            V(cx0, c0, cz0), V(cx1, c1, cz1), V(cx2, c2, cz2), V(cx3, c3, cz3), V(cx4, c4, cz4),
            V(cx5, c5, cz5),
            V(cx6, c6, cz6), V(cx7, c7, cz7),

            V(dx0, d0, dz0), V(dx1, d1, dz1), V(dx2, d2, dz2), V(dx3, d3, dz3), V(dx4, d4, dz4),
            V(dx5, d5, dz5),
            V(dx6, d6, dz6), V(dx7, d7, dz7),
            
            V(ox0, d0, dz0), V(ox1, d1, dz1), V(ox2, d2, dz2), V(ox3, d3, dz3), V(ox4, d4, dz4),
            V(ox5, d5, dz5),
            V(ox6, d6, dz6), V(ox7, d7, dz7),
            
            V(ex0, e0, ez0), V(ex1, e1, ez1), V(ex2, e2, ez2), V(ex3, e3, ez3), V(ex4, e4, ez4),
            V(ex5, e5, ez5),
            V(ex6, e6, ez6), V(ex7, e7, ez7),

            V(fx0, f0, fz0), V(fx1, f1, fz1), V(fx2, f2, fz2), V(fx3, f3, fz3), V(fx4, f4, fz4),
            V(fx5, f5, fz5),
            V(fx6, f6, fz6), V(fx7, f7, fz7),

            V(gx0, g0, gz0), V(gx1, g1, gz1), V(gx2, g2, gz2), V(gx3, g3, gz3), V(gx4, g4, gz4),
            V(gx5, g5, gz5),
            V(gx6, g6, gz6), V(gx7, g7, gz7),

            V(hx0, h0, hz0), V(hx1, h1, hz1), V(hx2, h2, hz2), V(hx3, h3, hz3), V(hx4, h4, hz4),
            V(hx5, h5, hz5),
            V(hx6, h6, hz6), V(hx7, h7, hz7),
        };
        return vertices;
    }

    private List<Vector2> CreateUVs()
    {
        var uvs = new List<Vector2>()
        {
            V(ax0, a0, az0), V(ax1, a1, az1), V(ax2, a2, az2), V(ax3, a3, az3), V(ax4, a4, az4),
            V(ax5, a5, az5),
            V(ax6, a6, az6), V(ax7, a7, az7),

            V(bx0, b0, bz0), V(bx1, b1, bz1), V(bx2, b2, bz2), V(bx3, b3, bz3), V(bx4, b4, bz4),
            V(bx5, b5, bz5),
            V(bx6, b6, bz6), V(bx7, b7, bz7),

            V(cx0, c0, cz0), V(cx1, c1, cz1), V(cx2, c2, cz2), V(cx3, c3, cz3), V(cx4, c4, cz4),
            V(cx5, c5, cz5),
            V(cx6, c6, cz6), V(cx7, c7, cz7),

            V(dx0, d0, dz0), V(dx1, d1, dz1), V(dx2, d2, dz2), V(dx3, d3, dz3), V(dx4, d4, dz4),
            V(dx5, d5, dz5),
            V(dx6, d6, dz6), V(dx7, d7, dz7),
            
        
            V(ox0, d0, dz0), V(ox1, d1, dz1), V(ox2, d2, dz2), V(ox3, d3, dz3), V(ox4, d4, dz4),
            V(ox5, d5, dz5),
            V(ox6, d6, dz6), V(ox7, d7, dz7),
            
            V(ex0, e0, ez0), V(ex1, e1, ez1), V(ex2, e2, ez2), V(ex3, e3, ez3), V(ex4, e4, ez4),
            V(ex5, e5, ez5),
            V(ex6, e6, ez6), V(ex7, e7, ez7),

            V(fx0, f0, fz0), V(fx1, f1, fz1), V(fx2, f2, fz2), V(fx3, f3, fz3), V(fx4, f4, fz4),
            V(fx5, f5, fz5),
            V(fx6, f6, fz6), V(fx7, f7, fz7),

            V(gx0, g0, gz0), V(gx1, g1, gz1), V(gx2, g2, gz2), V(gx3, g3, gz3), V(gx4, g4, gz4),
            V(gx5, g5, gz5),
            V(gx6, g6, gz6), V(gx7, g7, gz7),

            V(hx0, h0, hz0), V(hx1, h1, hz1), V(hx2, h2, hz2), V(hx3, h3, hz3), V(hx4, h4, hz4),
            V(hx5, h5, hz5),
            V(hx6, h6, hz6), V(hx7, h7, hz7),
        };

        for (int i = 0; i < uvs.Count; i++)
        {
            uvs[i] = Vector2.Scale(uvs[i], new Vector2(1f / width, 1f / height));
            uvs[i] += new Vector2(.5f, 0.5f);
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