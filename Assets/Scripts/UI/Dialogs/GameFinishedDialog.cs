using UnityEngine;
using UnityEngine.UI;


public class GameFinishedDialog : UIDialogBase
{
	[SerializeField]
	private Text countText;

	[SerializeField]
	private GameObject winHead;

	[SerializeField]
	private GameObject loseHead;


	protected override void OnEnable ()
	{
		base.OnEnable ();

	}

	protected override void OnDisable ()
	{
		base.OnDisable ();
	}

	private void OnGameWin()
	{
		winHead.SetActive (true);
		loseHead.SetActive (false);
	}

	private void OnGameLose()
	{
		winHead.SetActive (false);
		loseHead.SetActive (true);
	}

	private void OnGameFinished(int count)
	{
		Show ();
		countText.text = count.ToString ();
	}
}

