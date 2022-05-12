void uvFilteralpha0_float(in float2 uv,in float4 inCol,out float4 color)
{
    color=inCol;
    if(uv.x<0||uv.x>1||uv.y<0||uv.y>1)
    {
        color=float4(0,0,0,0);
    }
    
    
}
void uvFilteralpha1_float(in float2 uv,in float4 inCol,out float4 color)
{
    color=inCol;
    if(uv.x<0||uv.x>1||uv.y<0||uv.y>1)
    {
        color=float4(0,0,0,1);
    }
    
    
}
void noise_float(in float2 uv,in float size,out float color)
{
   color=frac(sin(dot(uv*size, float2(12.9898,78.233))) * 43758.5453);;
    
    
}