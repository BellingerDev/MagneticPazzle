using System;
using UnityEngine;


namespace Player.Properties
{
    public class MovePlayerProperties : PlayerPropertiesBase
    {
        [Serializable]
		public class MoveProperties : PropertiesBase
        {
            public float linearVelocity;
            public float angularVelocity;

            public float linearVelocityLimit;
            public float angularVelocityLimit;
        }

        [SerializeField]
        private MoveProperties[] properties;

        public MoveProperties Properties
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
            CurrentLevel = PreferencesManager.GetProfile<MovePropertiesProfile>().Load<int>("CurrentLevel");
        }
    }
}