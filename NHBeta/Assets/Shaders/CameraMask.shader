Shader "Masked/Mask" {
 
	SubShader {
		// Render the mask gefore regular geometry
		Tags {"Queue" = "Geometry-10" }
 
		// Don't draw in the RGBA channels; just the depth buffer
 
		ColorMask 0
		ZWrite On
 
		// Do nothing specific in the pass:
 
		Pass {}
	}
}