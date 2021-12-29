#include "UnityCG.cginc"

fixed SolidColor(fixed2 pos,fixed2 center,fixed radians,fixed solid)
{
	fixed dist = length(pos -center);
	return max((dist - radians) / (solid - radians), 0 )  ;
}
		
//(0,1)的UV值转换为(-1,1)的齐次剪裁空间作为顶点
float4 ConvertUV2Vertext(float2 pointValue)
{
#if UNITY_UV_STARTS_AT_TOP
	return float4(pointValue.x * 2.0 - 1.0, 1.0 - pointValue.y * 2.0, 0.0, 1.0);
#else
	return float4(pointValue.x * 2.0 - 1.0, pointValue.y * 2.0 - 1, 0.0, 1.0);
#endif
}

//法线x/y/z范围在(-1,1)，颜色值只能存储(0,1)。需要转换
float3 EncodeNormal(float3 value)
{
	float3 encoded;
	encoded.xyz = value.xyz*0.5 + 0.5;
	return encoded;
}

//还原法线
float3 DecodeNormal(float3 value)
{
	float3 decode;
	decode.xyz = (value.xyz - 0.5) * 2;
	return decode;
}

//与法线一样，需要将坐标值转换到(0,1)存储
//但是顶点坐标值范围不确定，需要根据项目模型实际顶点范围情况做转换
//这里以顶点范围x(-0.5,0.5),y(0,2),z(-0.5,0.5)做转换
float3 EncodeVertex(float3 value)
{
	float3 encoded;
	encoded.xz = value.xz + 0.5;
	encoded.y = value.y * 0.5;
	return encoded;
}

//还原顶点
float3 DecodeVertex(float3 value)
{
	float3 decode;
	decode.xz = value.xz - 0.5;
	decode.y = value.y * 2;
	return decode;
}
