using UnityEngine;
using Game.Activators;
using System;


namespace Utils
{
	public class ElementsPlatformPreferences : MonoBehaviour 
	{
		[Serializable]
		private class Preference
		{
			public RuntimePlatform platform;
			public float elementsCountFactor;
			public float frequencyFactor;
		}

		[SerializeField]
		private Preference[] preferences;


		private void Awake()
		{
			Preference pref = Array.FindLast<Preference> (preferences, p => p.platform == Application.platform);

			foreach (PoolItemSpawner spawner in FindObjectsOfType<PoolItemSpawner>())
			{
				spawner.SetElementsCountFactor (pref.elementsCountFactor);
				spawner.SetFrequencyFactor (pref.frequencyFactor);
			}
		}
	}
}
