using UnityEngine;


namespace Environment
{
	public class ActivatableParticleSystemChanger : MonoBehaviour, IActivatable
	{
		[SerializeField]
		private bool isChangeVisibility;

		[SerializeField]
		private bool visibilityOnActivate;

		[SerializeField]
		private bool visibilityOnDeactivate;

		[SerializeField]
		private bool isChangeColor;

		[SerializeField]
		private Material material;

		[SerializeField]
		private Color activatedColor;

		[SerializeField]
		private Color deactivatedColor;

		[SerializeField]
		private bool isChangeSize;

		[SerializeField]
		private float activatedSize;

		[SerializeField]
		private float deactivatedSize;

		private ParticleSystem system;


		private void OnEnable()
		{
			system = GetComponent<ParticleSystem>();
		}

		private void OnDisable()
		{
			system = null;
		}

		#region IActivatable implementation

		public void Activate ()
		{
			if (isChangeVisibility)
			{
				this.gameObject.SetActive(visibilityOnActivate);
			}

			if (isChangeColor)
			{
				if (material != null)
				{
					material.color = activatedColor;
				}
				else
				{
					system.startColor = activatedColor;
				}
			}

			if (isChangeSize)
			{
				system.startSize = activatedSize;
			}
			else
			{
				system.startSize = deactivatedSize;
			}
		}

		public void Deactivate ()
		{
			if (isChangeVisibility) 
			{
				this.gameObject.SetActive (visibilityOnDeactivate);
			}

			if (isChangeColor)
			{
				if (material != null)
				{
					material.color = deactivatedColor;
				}
				else
				{
					system.startColor = deactivatedColor;
				}
			}
		}

		#endregion
		
	}
}

