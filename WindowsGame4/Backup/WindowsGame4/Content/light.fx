



sampler colormap;
sampler heightmap;

 static const int      MAXLIGHTS       = 70;
  shared float2 LightPositions[MAXLIGHTS];
  shared float4 LightColors[MAXLIGHTS];
  shared float LightIntense[MAXLIGHTS];
  

float screenwidth = 800;
float screenheight = 600;

struct PS_INPUT
{
    float2 TexCoord : TEXCOORD0;
};

struct LIGHT
{
	float2 lightpos : TEXCOORD0;
	float4 lightcolor : COLOR0;
};


float4 PixelShaderFunction(PS_INPUT tex) : COLOR0
{
	float PI = 3.14159265f;


	    float2 coord = tex.TexCoord;
	    //Color map color
    float4 color = tex2D(colormap,coord);
   
	
		//light information
		
	for(int j = 0; j < MAXLIGHTS; j++)
	{	
		
	LIGHT light = (LIGHT)0;
	
	light.lightpos = float2(LightPositions[j].x/screenwidth, LightPositions[j].y/screenheight);
	float lightintensity = LightIntense[j];
	light.lightcolor = LightColors[j];//float4(0.7f,0.8f,1,0.5f);
	

	

    
    //Height map info
    float heightmapcol = tex2D(heightmap,coord).r;
    float heightmapalpha = tex2D(heightmap,coord).a;
    

    
    //Calculate distance from light source to coord
    float dist = distance(float2(coord.x * screenwidth,coord.y * screenheight),float2(light.lightpos.x*screenwidth,light.lightpos.y*screenheight));
    
    
    //calculate intensity at point
    float i = lightintensity / (4 * PI * pow(dist,1.5f));
    
    //caculate color to multiply by
    float col = i * heightmapcol * heightmapalpha;
    float4 multi = (col,col,col,1); 

	//Multipy blending
	
	float4 lightmask = float4(light.lightcolor.r * i * heightmapcol,light.lightcolor.g *i *heightmapcol,light.lightcolor.b * i * heightmapcol,light.lightcolor.a);
	color = float4(color[0] + lightmask[0],color[1] + lightmask[1],color[2] + lightmask[2],color[3]);
    
    }
    return color;
    
}

technique Lighting
{
    pass P0
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}
