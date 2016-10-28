using System;
using UnityEngine;


namespace Player.Properties
{
    public class EnergyPlayerProperties : PlayerPropertiesBase
    {
        [Serializable]
		public class EnergyProperties : PropertiesBase
        {
            [HideInInspector]
            public int currentValue;

            public int maxValue;
            public float restoreSpeed;
            public int restoreValue;

            [HideInInspector]
            public float nextRestoreTime;
        }

        [SerializeField]
        private EnergyProperties[] properties;

        public EnergyProperties Properties
        {
            get { return properties[CurrentLevel]; }
        }

		public override int GetMaxLevel ()
		{
			return properties.Length;
		}

		public override int GetUpgradeCost ()
		{
			if (properties.Length < CurrentLevel)
				return properties [CurrentLevel + 1].upgradeCost;

			return -1;
		}

        protected override void Load()
        {
            CurrentLevel = PreferencesManager.GetProfile<EnergyPropertiesProfile>().Load<int>("CurrentLevel");
        }
    }
}
