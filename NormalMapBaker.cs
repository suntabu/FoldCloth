using System.IO;
using UnityEngine;

public class NormalMapBaker : MonoBehaviour
{
    public MeshFilter target;
    public int size;

    [ContextMenu("Create Normal")]
    void CreateNormalMap()
    {
        var mat = new Material(Shader.Find("Paint/BakeUVNormal"));
        var rt = RenderTexture.GetTemporary(size, size, 0);
        var old = RenderTexture.active;
        Graphics.SetRenderTarget(rt);
        mat.SetPass(0);
        Graphics.DrawMeshNow(target.mesh, Matrix4x4.identity, 0);

        var tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply();
        Graphics.SetRenderTarget(old);
        RenderTexture.ReleaseTemporary(rt);
        
        
        File.WriteAllBytes("Assets/my.png",tex.EncodeToPNG());
    }
}