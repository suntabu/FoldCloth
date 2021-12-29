Shader "Paint/ProjectPaint_WithExpand"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
		Cull Off ZWrite Off ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha, One One

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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;

			//相对于Model的绘制方向
			float3 _PaintDir;
			//模型顶点左边转到相对于Paint点本地坐标的矩阵
			float4x4 _PaintMatrix;
			//颜色
			float4 _DrawColor;
			//.xy存放绘制uv位置，.z存放绘制范围半径，.w存放绘制衰减范围半径
			float4 _PaintInfo;

			//扩展后的顶点和法线UV映射图
            sampler2D _VertextTex;
            sampler2D _NormalTex;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
			
			//半径为radius，边缘solid处开始衰减的圆形范围
			fixed PaintAlpha(float3 paint, float radius, float solid)
			{
				paint.z = 0;
				float dist = length(paint);
				fixed divisor = solid - radius;
				fixed uncamp = (dist - radius) / divisor;
				if (uncamp > 0)
				{
					uncamp = pow(uncamp, 3);
				}
				return clamp(uncamp, 0, 1);
			}
			
            fixed4 frag (v2f i) : SV_Target
            {
				//获取该像素点法线
				float3 normal= DecodeNormal(tex2D(_NormalTex,i.uv));

				fixed blend=0;
				if (dot(normal, _PaintDir) < 0)
				{
					//获取该像素点网格坐标
					float3 localPos = DecodeVertex(tex2D(_VertextTex,i.uv));

					float3 vertex = mul(_PaintMatrix, float4(localPos, 1.0)).xyz;
					blend = PaintAlpha(vertex, _PaintInfo.z, _PaintInfo.w);
				}

                return fixed4(_DrawColor.xyz,blend);
            }
            ENDCG
        }
    }
}
