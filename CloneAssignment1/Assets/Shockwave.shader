Shader "Custom/Shockwave"
{
    Properties
    {
        _MainTex("Sprite Texture", 2D) = "white" {}
        _waveDistanceFromCenter("Wave Distance", Float) = 0
        _waveWidth("Wave Width", Float) = 0.05
        _waveStrength("Distortion Strength", Float) = 0.03
        _Color("Tint", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _waveDistanceFromCenter;
            float _waveWidth;
            float _waveStrength;

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

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 center = float2(0.5, 0.5);
                float2 dir = i.uv - center;
                float dist = length(dir);

                // Ripple ring intensity
                float ring = smoothstep(_waveDistanceFromCenter - _waveWidth, _waveDistanceFromCenter, dist)
                           - smoothstep(_waveDistanceFromCenter, _waveDistanceFromCenter + _waveWidth, dist);

                // UV distortion outward
                float2 distortedUV = i.uv + normalize(dir) * ring * _waveStrength;

                fixed4 col = tex2D(_MainTex, distortedUV) * _Color;

                // Add a subtle glow ring
                col.rgb += ring * 0.5;

                // Optional fadeout as wave grows
                float fade = saturate(1.0 - _waveDistanceFromCenter);
                col *= fade;

                return col;
            }
            ENDCG
        }
    }
}
