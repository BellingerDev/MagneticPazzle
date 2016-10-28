using System;
using UnityEngine;


namespace Player.Properties
{
    public class MagneticPlayerProperties : PlayerPropertiesBase
    {
        [Serializable]
		public class MagneticProperties : PropertiesBase
        {
            public float force;
            public float radius;
        }

        [SerializeField]
        private MagneticProperties[] properties;
    
        public MagneticProperties Properties
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
            CurrentLevel = PreferencesManager.GetProfile<MagneticPropertiesProfile>().Load<int>("CurrentLevel");
        }
    }
}