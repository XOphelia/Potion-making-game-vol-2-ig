Shader "PotionMaker/UILiquidWave"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _WaveSpeed ("Wave Speed", Float) = 2
        _WaveFrequency ("Wave Frequency", Float) = 12
        _WaveAmplitude ("Wave Amplitude", Float) = 0.02
        _ShimmerStrength ("Shimmer Strength", Range(0, 1)) = 0.25
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
        ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            fixed4 _Color;
            float _WaveSpeed;
            float _WaveFrequency;
            float _WaveAmplitude;
            float _ShimmerStrength;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color * _Color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float t = _Time.y * _WaveSpeed;

                // 1. On décale les coordonnées de la texture avec des vagues
                float2 uv = i.uv;
                uv.x += sin(uv.y * _WaveFrequency + t) * _WaveAmplitude;
                uv.y += cos(uv.x * _WaveFrequency + t) * _WaveAmplitude;

                fixed4 c = tex2D(_MainTex, uv) * i.color;

                // 2. Un reflet qui glisse de bas en haut
                float shimmer = sin(i.uv.y * 20.0 - t * 1.5) * 0.5 + 0.5;
                c.rgb += shimmer * _ShimmerStrength * c.a;

                return c;
            }
            ENDCG
        }
    }
}