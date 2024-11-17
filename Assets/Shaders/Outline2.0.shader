Shader "Custom/SimplifiedOutlineShader"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineSize ("Outline Size", Float) = 1.0
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        Lighting Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float4 _OutlineColor;
            float _OutlineSize;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.uv);

                // Se o pixel for transparente, verificar os vizinhos para criar o contorno
                if (color.a <= 0.0)
                {
                    float outline = 0.0;

                    // Ajuste de deslocamento para melhorar o alinhamento do contorno
                    float outlineSizeX = _OutlineSize * _MainTex_TexelSize.x;
                    float outlineSizeY = _OutlineSize * _MainTex_TexelSize.y;

                    // Cálculo dos vizinhos para detectar bordas
                    outline += tex2D(_MainTex, i.uv + float2(-outlineSizeX, 0)).a;
                    outline += tex2D(_MainTex, i.uv + float2(outlineSizeX, 0)).a;
                    outline += tex2D(_MainTex, i.uv + float2(0, -outlineSizeY)).a;
                    outline += tex2D(_MainTex, i.uv + float2(0, outlineSizeY)).a;

                    // Se a borda for detectada, retorna a cor de contorno
                    if (outline > 0.0)
                        return _OutlineColor;
                }

                // Retorna a cor original para pixels não transparentes
                return color;
            }

            ENDCG
        }
    }
}