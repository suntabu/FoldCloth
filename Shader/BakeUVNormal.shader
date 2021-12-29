Shader "Paint/BakeUVNormal"
{
    Properties {}
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "CommonUtils.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;

                float4 positionWS:TEXCOORD1;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = ConvertUV2Vertext(v.uv);
                o.normal = v.normal;
                o.positionWS = v.vertex;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 dpdx = ddx(i.positionWS.xyz);
                float3 dpdy = ddy(i.positionWS.xyz);
                float3 n = normalize(cross(dpdy, dpdx));
                return fixed4(EncodeNormal(n), 1.0);
            }
            ENDCG
        }
    }
}