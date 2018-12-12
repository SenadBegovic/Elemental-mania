Shader "Unlit/RadialTextureShader"
{
    Properties
    {
        _MyTexture("Gradient", 2D) = "white" {}
		_Gradient("Radial", Range(0.00, 1.0)) = 0.5
		_Color("Color", Color) = (1, 0, 0, 1)
    }
    SubShader
    {
        Tags
        { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
            "PreviewType"="Plane"
        }
        LOD 100
        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha
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

                #ifdef PIXELSNAP_ON
                o.vertex = UnityPixelSnap (o.vertex);
                #endif
                return o;
            }

            sampler2D _MyTexture;
            float _Gradient;
			fixed4 _Color;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col;
                half4 sample = tex2D(_MyTexture, i.uv);
                if(sample.a > 1 - _Gradient)
                {
                    col = float4(_Color.xyz, 1.0);
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