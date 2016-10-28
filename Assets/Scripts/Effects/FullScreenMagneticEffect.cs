using UnityEngine;


namespace Effects
{
	[ExecuteInEditMode]
	public class FullScreenMagneticEffect : MonoBehaviour 
	{
		[SerializeField]
		private Shader shader;

		[SerializeField]
		private Texture magneticNormalMap;

		[SerializeField]
		private Vector2 effectSize;

		private Material material;


		private void OnEnable()
		{
			material = new Material(shader);
			material.SetTexture ("_MagneticNormalMap", magneticNormalMap);
			material.SetFloat ("effectSizeX", effectSize.x);
			material.SetFloat ("effectSizeY", effectSize.y);
		}

		private void OnDisable()
		{
			material = null;
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			Graphics.Blit(src, dest, material);
		}
	}
}

