Shader "Unlit/GradientShader"
{
	Properties
	{
		_OuterMultiplier ("Outer Multiplier", Range(0.0, 5.0)) = 1.0
		_Color ("Color", Color) = (1, 0, 0, 1)
	}
	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			float _OuterMultiplier;
			fixed4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = fixed4(_Color.rgb, 1 - ( (pow(2.0*((i.uv.x - 0.5)), 2.0) + _OuterMultiplier) * lerp(0.75, 1, 0.5*(_CosTime.w + 1))));
				return col;
			}
			ENDCG
		}
	}
}
