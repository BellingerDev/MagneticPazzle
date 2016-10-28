using UnityEngine;
using Utils;
using Player;
using System.Collections.Generic;


public class MinimizeController : MonoBehaviour 
{
    /*
	private enum Type
	{
		Minimize, Maximize
	}

	[SerializeField]
	private Type type;
    
	private LineRenderer lines;
	private List<Collider> accumulatedColliders;


	private void OnEnable()
	{
		lines = GetComponentInChildren <LineRenderer>();
		lines.SetVertexCount (2);
		lines.SetPosition (0, lines.transform.position);

		accumulatedColliders = new List<Collider>();
		ColliderTrigger = GetComponentInChildren <ColliderTriggerController> ();
		ColliderTrigger.OnTriggerEnterCallback += OnEnter;
		ColliderTrigger.OnTriggerExitCallback += OnExit;
	}

	private void OnDisable()
	{
		lines = null;
		ColliderTrigger.OnTriggerEnterCallback -= OnEnter;
		ColliderTrigger.OnTriggerExitCallback -= OnExit;
		ColliderTrigger = null;
	}

	private void OnEnter(Collider col)
	{
		if (col.tag == ElementController.ElementTag || col.tag == PlayerController.PlayerTag)
		{
			GameObjectTweenAnimator animator = col.GetComponent <GameObjectTweenAnimator> ();
			if (animator != null)
				animator.Animate (type == Type.Minimize ? GameObjectTweenAnimator.AnimateType.Hide : GameObjectTweenAnimator.AnimateType.Show);

			accumulatedColliders.Add (col);
		}
	}

	private void OnExit(Collider col)
	{
		if (col.tag == ElementController.ElementTag || col.tag == PlayerController.PlayerTag)
			accumulatedColliders.Remove (col);
	}

	private void Update()
	{
		lines.SetVertexCount (accumulatedColliders.Count*2);

		for (int i = 0; i < accumulatedColliders.Count * 2; i++)
		{
			if (i % 2 == 0)
				lines.SetPosition (i, lines.transform.position);
			else
				lines.SetPosition (i, accumulatedColliders [i / 2].transform.position);
		}
	}*/
}
