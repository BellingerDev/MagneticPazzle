using UnityEngine;
using System;


namespace UI
{
	public class UIRotateSelectionTrigger : UISelectionTrigger
	{
		[Serializable]
		private struct Axis
		{
			public bool x;
			public bool y;
			public bool z;

			public Vector3 GetRotationByAxis(float rotationValue)
			{
				return new Vector3(x ? rotationValue : 0, y ? rotationValue : 0, z ? rotationValue : 0);
			}
		}

		[SerializeField]
		private bool isLoop;

		[SerializeField]
		private bool isStopOnDeactivate;

		[SerializeField]
		private Axis axis;

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

			LeanTween.rotateLocal (selectionObject, selectionObject.transform.localEulerAngles + axis.GetRotationByAxis (90), selectTime)
				.setEase (selectTween)
				.setOnComplete (() => {
					isBusy = false;
					if (isLoop)
						Activate();
				});
		}

		public override void Deactivate ()
		{
			if (isStopOnDeactivate)
			{
				LeanTween.rotateLocal (selectionObject, selectionObject.transform.localEulerAngles, 0);
				return;
			}
			
			if (isBusy)
				return;

			isBusy = true;


			LeanTween.rotateLocal (selectionObject, selectionObject.transform.localEulerAngles - axis.GetRotationByAxis (90), deSelectTime)
				.setEase (deSelectTween)
				.setLoopClamp()
				.setOnComplete (() => {
					isBusy = false;

					if (isLoop)
						Deactivate();
				});
		}
		#endregion		
	}
}