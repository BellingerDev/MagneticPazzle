using UnityEngine;


namespace Utils
{
	public class MaterialDSPItem : MonoBehaviour
	{
		[SerializeField]
		private Material material;

		[SerializeField]
		private float animationDuration;

		[SerializeField]
		private float amplitudeMin;

		[SerializeField]
		private float amplitudeMax;

		private Color baseColor;
		private bool alreadyAnimated = false;


		private void Awake()
		{
			baseColor = material.color;
		}

		private void OnDestroy()
		{
			material.color = baseColor;
		}

		public void OnUpdate(float amplitude)
		{
			if (amplitude > amplitudeMin && amplitude < amplitudeMax)
			{
				if (!alreadyAnimated)
					AnimateColor(new Color(baseColor.r * amplitude, baseColor.g * amplitude, baseColor.b * amplitude));
			}
			else
				RestoreColor();
		}

		private void AnimateColor(Color finalColor)
		{
			LeanTween.value(this.gameObject, 
			                (Color c) => { material.color = c; alreadyAnimated = true; },
			material.color, finalColor, 
			animationDuration).setOnComplete(() => { alreadyAnimated = false; });
		}

		public void RestoreColor()
		{
			AnimateColor (baseColor);
		}
	}
}