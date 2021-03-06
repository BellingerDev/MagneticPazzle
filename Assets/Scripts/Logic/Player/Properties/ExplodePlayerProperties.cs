﻿using System;
using UnityEngine;


namespace Player.Properties
{
    public class ExplodePlayerProperties : PlayerPropertiesBase
    {
        [Serializable]
		public class ExplodeProperties : PropertiesBase
        {
            public float force;
            public float radius;
        }

        [SerializeField]
        private ExplodeProperties[] properties;

        public ExplodeProperties Properties
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
            CurrentLevel = PreferencesManager.GetProfile<ExplodePropertiesProfile>().Load<int>("CurrentLevel");
        }
    }
}