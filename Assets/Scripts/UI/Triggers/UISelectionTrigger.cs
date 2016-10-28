using UnityEngine;

namespace UI
{
	public abstract class UISelectionTrigger : UITrigger
	{
		[SerializeField]
		protected GameObject selectionObject;

		[SerializeField]
		protected LeanTweenType selectTween;

		[SerializeField]
		protected LeanTweenType deSelectTween;

		[SerializeField]
		protected float selectTime;

		[SerializeField]
		protected float deSelectTime;
	}
}