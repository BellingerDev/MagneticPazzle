using UnityEngine;


namespace Utils
{
    public class FogPreferences : MonoBehaviour
    {
        public enum State
        {
            InGame = 0,
            LevelChoose,
			Upgrade
        }

        [System.Serializable]
        private struct Preference
        {
			public bool isManagedByRealtimeGI;
            public bool enabled;
            public float startDistance;
            public float endDistance;
            public Color color;


			public void Apply()
            {
                RenderSettings.fogStartDistance = startDistance;
                RenderSettings.fogEndDistance = endDistance;
                RenderSettings.fog = enabled;

				if (!isManagedByRealtimeGI)
				{
					RenderSettings.fogColor = color;
					CameraController.Instance.GetComponent<Camera>().backgroundColor = color;
				}
				else
				{
					RenderSettings.fogColor = RealtimeGIPreferences.Instance.CurrentGroundColor;
					CameraController.Instance.GetComponent<Camera>().backgroundColor = RealtimeGIPreferences.Instance.CurrentGroundColor;	
				}
            }
        }

        public static FogPreferences Instance { get; private set; }

        [SerializeField]
        private Preference[] preferences;


        private void OnEnable()
        {
            Instance = this;
        }

		private void OnDisable()
		{
			Instance = null;
		}

        public void Switch(State state)
        {
			preferences[(int)state].Apply();
        }
    }
}
