using UnityEngine;


public class GameStartedDialog : UIDialogBase
{
	protected override void OnEnable ()
	{
		base.OnEnable ();
	}

	protected override void OnDisable ()
	{
		base.OnDisable ();
	}

	private void OnGameStartedCallback()
	{
		Show ();
	}
}

