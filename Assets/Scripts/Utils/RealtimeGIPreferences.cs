using UnityEngine;


namespace Utils
{
    public class RealtimeGIPreferences : MonoBehaviour
    {
        public static RealtimeGIPreferences Instance { get; private set; }

		public Color CurrentGroundColor { get; private set; }

        [System.Serializable]
        private struct Preference
        {
			public UnityEngine.Rendering.AmbientMode mode;

			public float intensity;

			// for color mode
			public Color ambientColor;

			// for gradient mode
			public Color skyColor;
			public Color equatorColor;
			public Color groundColor;

			// for skybox mode
			public Material skyboxMaterial;
        }

        [SerializeField]
        private Preference[] preference;

        [SerializeField]
        private int startId;


        private void Awake()
        {
            Instance = this;

            Apply(startId);
        }

        public void Apply(int index)
		{
            Preference p = preference[index];

			RenderSettings.ambientLight = p.ambientColor;

			RenderSettings.ambientSkyColor = p.skyColor;
			RenderSettings.ambientEquatorColor = p.equatorColor;
			RenderSettings.ambientGroundColor = p.groundColor;

			RenderSettings.ambientIntensity = p.intensity;
			RenderSettings.skybox = p.skyboxMaterial;

			RenderSettings.ambientMode = p.mode;

			CurrentGroundColor = p.groundColor;
        }
    }
}
