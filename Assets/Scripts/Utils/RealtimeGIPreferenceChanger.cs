using UnityEngine;


namespace Utils
{
    public class RealtimeGIPreferenceChanger : MonoBehaviour
    {
        [SerializeField]
        private int propertyIndex;

        private int currentIndex;


        private void Update()
        {
            if (propertyIndex != currentIndex)
            {
				RealtimeGIPreferences.Instance.Apply(propertyIndex);
                currentIndex = propertyIndex;
            }
        }

		public void SetPropertyIndex(int index)
		{
			this.propertyIndex = index;
		}
    }
}
