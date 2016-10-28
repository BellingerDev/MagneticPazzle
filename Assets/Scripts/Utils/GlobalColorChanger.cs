using UnityEngine;


namespace Utils
{
	public class GlobalColorChanger : MonoBehaviour
	{
		[SerializeField]
		private int propertyIndex;

		private int currentIndex;

		private RealtimeGIPreferenceChanger realtimeGIChanger;
		private FogColorChanger fogChanger;


		private void OnEnable()
		{
			realtimeGIChanger = GetComponent<RealtimeGIPreferenceChanger>();
			fogChanger = GetComponent<FogColorChanger> ();
		}

		private void OnDisable()
		{
			realtimeGIChanger = null;
			fogChanger = null;
		}

		private void Update()
		{
			if (propertyIndex != currentIndex)
			{
				realtimeGIChanger.SetPropertyIndex (propertyIndex);
				fogChanger.SetPropertyIndex (propertyIndex);

				currentIndex = propertyIndex;
			}
		}
	}
}

