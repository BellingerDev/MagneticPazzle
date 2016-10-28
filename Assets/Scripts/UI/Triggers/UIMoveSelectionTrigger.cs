using UnityEngine;


namespace UI
{
	public class UIMoveSelectionTrigger : UISelectionTrigger
	{
		[SerializeField]
		private Vector3 popPosition;

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

			LeanTween.moveLocal (selectionObject, selectionObject.transform.localPosition + popPosition, selectTime)
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

			LeanTween.moveLocal(selectionObject, selectionObject.transform.localPosition - popPosition, deSelectTime)
				.setEase (deSelectTween)
				.setOnComplete (() => {
					isBusy = false;
				});
		}
		#endregion		
	}
}