using UnityEngine;


namespace UI
{
	public class UISignalizeTrigger : UITrigger
	{
		[SerializeField]
		private GameObject signalizeObject;

		[SerializeField]
		private float duration;

		[SerializeField]
		private LeanTweenType tween;


		#region implemented abstract members of UITrigger

		public override void Init ()
		{
			
		}

		public override void DeInit ()
		{
			
		}

		public override void Activate ()
		{
			LeanTween.scale(signalizeObject, signalizeObject.transform.localScale, duration)
				.setEase (tween);
		}

		public override void Deactivate ()
		{
			
		}

		#endregion
		
	}
}

