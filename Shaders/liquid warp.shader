Shader "Custom/liquid warp" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
        _EmissionMap("Emission", 2D) = "white" {}
        _EmissionVal("Emission amount", float) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
        sampler2D _Emission;
        float _EmissionVal;

		struct Input {
			float2 uv_MainTex;
            float4 _Time;
		};

		fixed4 _Color;

        

        float warp( float a, float time )
        {
            float violence = 0.04;
            float levelOfExtreme = 6.0;
            float timeMod = time + a;
            return a + sin( timeMod * levelOfExtreme ) * violence;
            
            //return a + sin(time + a) * violence;
        }
        
		void surf (Input IN, inout SurfaceOutputStandard o) {
            float2 wuv = IN.uv_MainTex;
            
            wuv.x = warp(wuv.x, _Time.y) + (_Time.x * 4.0);
            wuv.y = warp(wuv.y, _Time.y) + (_Time.x * 3.2);
        
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, wuv);
			o.Albedo = c.rgb;
            o.Smoothness = 1.0;
            o.Emission = c.rgb * (tex2D(_Emission, wuv).rgb * _EmissionVal);
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
