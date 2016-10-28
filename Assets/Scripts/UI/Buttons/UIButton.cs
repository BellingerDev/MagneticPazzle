using UnityEngine;
using System;


namespace UI
{
	public class UIButton : MonoBehaviour
	{
		private UITrigger[] triggers;

		public virtual void Init()
		{
			triggers = GetComponents<UITrigger> ();

			foreach (var trigger in triggers)
				trigger.Init ();
		}

		public virtual void DeInit()
		{
			foreach (var trigger in triggers)
				trigger.DeInit ();

			triggers = null;
		}

		protected UITrigger GetTrigger<TriggerType>() where TriggerType : UITrigger
		{
			UITrigger trigger = Array.FindLast<UITrigger> (triggers, t => t is TriggerType);

			return trigger;
		}

		protected UITrigger[] GetTriggers<TriggerType>() where TriggerType : UITrigger
		{
			UITrigger[] sortedTriggers = Array.FindAll<UITrigger> (triggers, t => t is TriggerType);

			return sortedTriggers;
		}
	}
}