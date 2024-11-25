Shader "CustomRenderTexture/shader"
{
    Properties
    { 
        _MainTex("InputTex", 2D) = "white" {}
    }

    SubShader {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Pass {
            Blend SrcAlpha OneMinusSrcAlpha
            SetTexture [_MainTex] {
                Combine texture * primary
                Matrix [_Matrix]
            }
        }

        Pass {
			SetTexture [_MainTex] {
				Matrix [_Matrix]
			}
		}

        
    }
}
