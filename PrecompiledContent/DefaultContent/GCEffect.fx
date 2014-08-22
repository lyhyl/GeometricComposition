//0
float4x4 World;
float4x4 View;
float4x4 Projection;

//3
float3 CameraPos;

//material
//4
float3 DiffuseColor={.5,.5,.5};
float3 EmissiveColor={.5,.5,.5};
float3 SpecularColor={.5,.5,.5};
float SpecularPower=16;
float Alpha=0.25;

//light
//9
float3 AmbientColor={.5,.5,.5};
//t0 direction
//t1 spot
//t2
int LightType=0;
float3 LightPosition={100,100,100};
float3 LightDiffuseColor={1,1,1};
float3 LightSpecularColor={1,1,1};
float LightDistanceSquared=10000;

struct VertexShaderInput
{
	float4 Position : POSITION0;
	float3 Normal : NORMAL0;
	float3 Color : COLOR0;
};

struct VertexShaderOutput
{
	float4 Position : POSITION0;
	float3 Normal : TEXCOORD0;
	float3 Color : COLOR0;
	float3 WorldPos : TEXCOORD1;
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
	VertexShaderOutput output;

	// Multiplication will be done in the pre-shader - so no cost per vertex
	float4 worldPos = mul(input.Position, World);
	output.Position = mul(mul(worldPos, View), Projection);
	// Passing information on to do both specular AND diffuse calculation in pixel shader
	output.Color = input.Color;
	output.Normal = mul(input.Normal, (float3x3)World);
	output.WorldPos = worldPos;

	return output;
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	// Phong relfection is ambient + light-diffuse + spec highlights.
	// I = Ia*ka*Oda + fatt*Ip[kd*Od(N.L) + ks(R.V)^n]
	// Ref: http://www.whisqu.se/per/docs/graphics8.htm
	// and http://en.wikipedia.org/wiki/Phong_shading
	// Get light direction for this fragment
	float3 lightDir = normalize(input.WorldPos - LightPosition);

	// Note: Non-uniform scaling not supported
	// LYH: I give it abs(dot...)
	float diffuseLighting = saturate(abs(dot(input.Normal, -lightDir))); // per pixel diffuse lighting

	// Introduce fall-off of light intensity
	diffuseLighting *= (LightDistanceSquared / dot(LightPosition - input.WorldPos, LightPosition - input.WorldPos));

	// Using Blinn half angle modification for perofrmance over correctness
	float3 h = normalize(normalize(CameraPos - input.WorldPos) - lightDir);

	float specLighting = pow(saturate(dot(h, input.Normal)), SpecularPower);

	return float4(saturate(
		Alpha * AmbientColor +
		(Alpha * DiffuseColor * LightDiffuseColor * diffuseLighting) + // Use light diffuse vector as intensity multiplier
		(Alpha * SpecularColor * LightSpecularColor * specLighting) // Use light specular vector as intensity multiplier
		), Alpha);
}

technique PerPixelLighing
{
	pass
	{
		VertexShader = compile vs_2_0 VertexShaderFunction();
		PixelShader = compile ps_2_0 PixelShaderFunction();
	}
}