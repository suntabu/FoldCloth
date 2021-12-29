Shader "Paint/BakeUVVertext"
{
  	Properties
	{
	}
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
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 localPos : TEXCOORD0;
			};
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex =ConvertUV2Vertext(v.uv);
				o.localPos = v.vertex;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return fixed4(EncodeVertex(i.localPos), 1.0);
			}

			ENDCG
		}
	}
}
