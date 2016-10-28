using UnityEngine;


public class GameObjectTweenAnimator : MonoBehaviour 
{
	public enum AnimateType
	{
		Hide, Show
	}

	[SerializeField]
	private bool animateOnEnable;

	[SerializeField]
	private LeanTweenType tweenType;

	[SerializeField]
	private AnimateType animateType;

	[SerializeField]
	private float animateTime;

	private Vector3 originScale;


	private void OnEnable()
	{
		originScale = transform.localScale;
		
		if (animateOnEnable)
			Animate ();
	}

	private void OnDisable()
	{
		
	}

	public void Animate()
	{
		switch (animateType)
		{
			case AnimateType.Show:
				AnimateShow ();
				break;

			case AnimateType.Hide:
				AnimateHide ();
				break;
		}
	}

	public void Animate(AnimateType type)
	{
		switch (type)
		{
		case AnimateType.Show:
			AnimateShow ();
			break;

		case AnimateType.Hide:
			AnimateHide ();
			break;
		}
	}

	private void AnimateHide()
	{
		LeanTween.scale (this.gameObject, new Vector3 (0.1f, 0.1f, 0.1f), animateTime)
			.setEase (tweenType);
	}

	private void AnimateShow()
	{
		transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);

		LeanTween.scale (this.gameObject, originScale, animateTime)
			.setEase (tweenType);
	}
}
