using UnityEngine;
using Utils.Events;
using System;


namespace Player
{
	[RequireComponent (typeof(Animator))]
	public class PlayerEventAnimationActivator : MonoBehaviour
	{
		[Serializable]
		private struct AnimationToggle
		{
			public string name;
			public bool state;
		}

		[SerializeField]
		private PlayerEvents eventName;

		[SerializeField]
		private string triggerName;

		[SerializeField]
		private AnimationToggle toggle;

		private Animator target;

		private void Awake()
		{
			target = GetComponent<Animator> ();
		}

		private void OnDestroy()
		{
		}

		private void OnEvent(object value)
		{
			if (!string.IsNullOrEmpty(triggerName))
			{
				target.SetTrigger(triggerName);
				return;
			}
			else
				target.SetBool(toggle.name, toggle.state);
		}
	}
}