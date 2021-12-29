Shader "Paint/BakePixelExpand"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float4 _MainTex_TexelSize;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				if (col.a == 0.0)
				{
					float2 dy = float2(0, _MainTex_TexelSize.y * 2);
					float2 dx = float2(_MainTex_TexelSize.x * 2, 0);
					fixed4 col1 = tex2D(_MainTex, i.uv + dx);
					fixed4 col2 = tex2D(_MainTex, i.uv - dx);
					fixed4 col3 = tex2D(_MainTex, i.uv + dy);
					fixed4 col4 = tex2D(_MainTex, i.uv - dy);
					col = max(col, max(col1, max(col2, max(col3, col4))));
				}
				return col;
			}
			ENDCG
		}
	}
}
