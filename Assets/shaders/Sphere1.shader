Shader "Custom/Sphere1"
{
    Properties
    {
        _P1Col1 ("P1Col1", Color) = (1,0,1,1)
		_P1Col2("P1Col2", Color) = (1,1,0,1)
		_P2Col1("P2Col1", Color) = (1,1,0,1)
		_P2Col2("P2Col2", Color) = (1, 1, 0, 1)
        _MainTex ("MainTex", 2D) = "white" {}
		_SecondTex ("SecondTex", 2D) = "white" {}
		_BlendTex ("BlendTex", 2D) = "white" {}
		_cutoff ("Cutoff", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex,_SecondTex,_BlendTex;

        struct Input
        {
            float2 uv_MainTex, uv_SecondTex, uv_BlendTex;
        };
        fixed4 _P1Col2;
		fixed4 _P1Col1;
		fixed4 _P2Col1;
		fixed4 _P2Col2;
		float _cutoff;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c1 = tex2D (_MainTex, IN.uv_MainTex);
			fixed4 c2 = tex2D(_SecondTex, IN.uv_SecondTex);
			fixed4 c3 = tex2D(_BlendTex, IN.uv_BlendTex);
			if (c3.r > _cutoff+0.01) {
				o.Albedo = lerp(_P1Col2, _P1Col1, c1.r);
				o.Emission = lerp(_P1Col2, _P1Col1, c1.r);
			}
			else if (c3.r < _cutoff-0.01) {
				o.Albedo = lerp(_P2Col2, _P2Col1, c2.r);
				o.Emission = lerp(_P2Col2, _P2Col1, c2.r);
			}else {
				o.Albedo = fixed4(1, 1, 1, 1);
				o.Emission = fixed4(1, 1, 1, 1);
			}
        }
        ENDCG
    }
    FallBack "Diffuse"
}
