using UnityEngine;


public class Spawnable : Affectable
{
	[SerializeField]
	private GameObject prefab;

	[SerializeField]
	private bool isPoolable;

	[SerializeField]
	private float duration;

	[SerializeField]
	private LeanTweenType tween;


	public override void Activate ()
	{
		base.Activate ();

		GameObject instance = null;

		if (isPoolable)
			instance = PoolController.Instance.Get (prefab);
		else
			instance = Instantiate<GameObject> (prefab);

		Vector3 originScale = instance.transform.localScale;

		instance.transform.SetParent (this.transform);

		instance.transform.localPosition = Vector3.zero;
		instance.transform.localScale = originScale * 0.2f;

		instance.SetActive (true);

		LeanTween.scale (instance, originScale, duration)
			.setEase (tween);
	}
}
