using UnityEngine;


namespace UI
{
	public class UISwitchStateTrigger : UITrigger
	{
		[SerializeField]
		private GameObject[] states;

		[SerializeField]
		private float downscaleFactor;

		[SerializeField]
		private float scaleDuration;

		[SerializeField]
		private LeanTweenType scaleTween;

		private int currentState;


		public override void Init ()
		{
			foreach (var state in states)
				state.SetActive (false);
		}

		public override void DeInit ()
		{
			foreach (var state in states)
				state.SetActive (false);
		}

		public override void Activate ()
		{
			LeanTween.scale (states [currentState], states [currentState].transform.localScale * downscaleFactor, scaleDuration)
				.setEase (scaleTween)
				.setOnComplete (() => {
					if (++currentState > states.Length - 1)
						currentState = 0;

					LeanTween.scale (states [currentState], states [currentState].transform.localScale / downscaleFactor, scaleDuration)
						.setEase (scaleTween);
			});
		}

		public void SetState(int state)
		{
			GameObject stateGO = states [currentState];
			LeanTween.scale (stateGO, stateGO.transform.localScale * downscaleFactor, scaleDuration)
				.setEase (scaleTween)
				.setOnComplete (() => {
					stateGO.SetActive(false);

					currentState = state;

					stateGO = states [currentState];
					stateGO.SetActive (true);
					stateGO.transform.localScale *= downscaleFactor;

					LeanTween.scale (stateGO, stateGO.transform.localScale / downscaleFactor, scaleDuration)
						.setEase (scaleTween);
			});

		}

		public override void Deactivate ()
		{
			LeanTween.scale (states [currentState], states [currentState].transform.localScale * downscaleFactor, scaleDuration)
				.setEase (scaleTween)
				.setOnComplete (() => {
					if (--currentState < 0)
						currentState = states.Length - 1;

					LeanTween.scale (states [currentState], states [currentState].transform.localScale / downscaleFactor, scaleDuration)
						.setEase (scaleTween);
				});
		}
	}
}

