using UnityEngine;


namespace UI
{
	public class UIScaleSelectionTrigger : UISelectionTrigger
	{
		[SerializeField]
		private float scaleFactor;

		private bool isBusy;

		#region implemented abstract members of UITrigger
		public override void Init ()
		{
			isBusy = false;
		}

		public override void DeInit ()
		{

		}
		#endregion

		#region implemented abstract members of UISelectionTrigger
		public override void Activate ()
		{
			if (isBusy)
				return;

			isBusy = true;

			LeanTween.scale (selectionObject, selectionObject.transform.localScale * scaleFactor, selectTime)
				.setEase (selectTween)
				.setOnComplete (() => {
					isBusy = false;
				});
		}

		public override void Deactivate ()
		{
			if (isBusy)
				return;

			isBusy = true;

			LeanTween.scale(selectionObject, selectionObject.transform.localScale / scaleFactor, deSelectTime)
				.setEase (deSelectTween)
				.setOnComplete (() => {
					isBusy = false;
				});
		}
		#endregion		
	}
}