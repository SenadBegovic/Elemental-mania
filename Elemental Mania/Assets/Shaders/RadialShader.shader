Shader "Unlit/RadialShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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

            static const float PI = 3.1415;
            static const float PI_2 = 2.0*3.1415;
            static const float fill = 0.75;
            static const float radius = 0.5;

            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col;
                float2 offset = float2(0.5, 0.5);
    
                float2 origo = i.uv - offset;
                
                float angle = atan2(origo.y , origo.x) + PI;
                
                //fragColor = vec4(0, origo.y, origo.x, 1.0);
                // Output to screen
                
                float distance = length(origo);
                const float angleEnd = PI_2 * fill;

                if(angle < angleEnd && distance < radius)
                {
                    col = float4(float3(0, 1, 0) , 1.0);
                }
                else
                {
                    col = float4(0, 0, 0, 0);
                }
                return col;
            }
            ENDCG
        }
    }
}