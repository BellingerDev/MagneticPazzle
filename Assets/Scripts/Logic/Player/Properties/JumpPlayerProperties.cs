using System;
using UnityEngine;


namespace Player.Properties
{
    public class JumpPlayerProperties : PlayerPropertiesBase
    {
        [Serializable]
		public class JumpProperties : PropertiesBase
        {
            public float force;
        }

        [SerializeField]
        private JumpProperties[] properties;

        public JumpProperties Properties
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
            CurrentLevel = PreferencesManager.GetProfile<JumpPropertiesProfile>().Load<int>("CurrentLevel");
        }
    }
}