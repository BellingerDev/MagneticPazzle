using System;
using System.Linq;
using UnityEngine;


namespace Player.Properties
{
    public abstract class PlayerPropertiesBase : MonoBehaviour
    {
		[Serializable]
		public class PropertiesBase
		{
			public int energyCost;
			public int upgradeCost;
		}

        public int CurrentLevel { get; set; }
        public bool IsActive { get; set; }

        protected virtual void Awake()
        {
            Load();
        }

        public virtual void Refresh()
        {
            Load();
        }

		public abstract int GetMaxLevel();
		public abstract int GetUpgradeCost ();

        protected abstract void Load();

        public static T GetByType<T>(PlayerPropertiesBase[] array)
        {
            return (T)Convert.ChangeType(array.Single(p => p.GetType() == typeof(T)), typeof(T));
        }
    }
}