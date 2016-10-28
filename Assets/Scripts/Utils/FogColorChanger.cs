using UnityEngine;


namespace Utils
{
	public class FogColorChanger : MonoBehaviour
	{
		[SerializeField]
		private int propertyIndex;

		private int currentIndex;


		private void Update()
		{
			if (currentIndex != propertyIndex)
			{
				FogPreferences.Instance.Switch ((FogPreferences.State)propertyIndex);

				currentIndex = propertyIndex;
			}
		}

		public void SetPropertyIndex(int index)
		{
			this.propertyIndex = index;
		}
	}
}

