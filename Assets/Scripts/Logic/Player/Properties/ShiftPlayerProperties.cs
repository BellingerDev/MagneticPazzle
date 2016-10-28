using System;
using UnityEngine;


namespace Player.Properties
{
    public class ShiftPlayerProperties : PlayerPropertiesBase
    {
        [Serializable]
        public class ShiftProperties : PropertiesBase
        {
            public int shiftDistance;
        }

        [SerializeField]
        private ShiftProperties[] properties;


        public ShiftProperties Properties
        {
            get { return properties[CurrentLevel]; }
        }

        public override int GetMaxLevel()
        {
            return properties.Length;
        }

        public override int GetUpgradeCost()
        {
            if (properties.Length < CurrentLevel)
                return properties[CurrentLevel + 1].upgradeCost;

            return -1;
        }

        protected override void Load()
        {
            CurrentLevel = PreferencesManager.GetProfile<ShiftPropertiesProfile>().Load<int>("CurrentLevel");
        }
    }
}
